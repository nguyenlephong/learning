using QRCoder;
using System.Text;

public interface INapasQrService
{
    QRDataResponse GenerateNapassQr(QRDataRequest request);
}

public class NapasQrService : INapasQrService
{
    public QRDataResponse GenerateNapassQr(QRDataRequest req)
    {
        var raw = GenerateEmvcoNapassQrRaw(req);

        // Generate QR Image (base64)
        using var qrGenerator = new QRCodeGenerator();
        using var qrData = qrGenerator.CreateQrCode(raw, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrData);
        var qrBytes = qrCode.GetGraphic(10);
        string base64Qr = Convert.ToBase64String(qrBytes);

        return new QRDataResponse
        {
            RawData = raw,
            Base64QrImage = $"data:image/png;base64,{base64Qr}"
        };
    }

    private string GenerateEmvcoNapassQrRaw(QRDataRequest r)
    {
        // EMVCo QR Code format: ID(length) + Value
        // Example: "00" + "02" + "01" = "000201"
        var sb = new StringBuilder();

        void Add(string id, string val)
        {
            if (string.IsNullOrEmpty(val)) return;
            sb.Append(id);
            sb.Append(val.Length.ToString("D2"));
            sb.Append(val);
        }

        // Payload Format Indicator (Mandatory)
        Add("00", "02"); // EMV QR Code

        // Point of Initiation Method (Optional)
        Add("01", "12"); // 12: Static QR Code

        // Merchant Account Information (Mandatory for NAPAS)
        string merchantInfo = "";
        void AddSub(string id, string val)
        {
            if (string.IsNullOrEmpty(val)) return;
            merchantInfo += id + val.Length.ToString("D2") + val;
        }
        
        // NAPAS Bank Code (Required)
        AddSub("00", r.BankCode);
        
        // Account Number (Required)
        AddSub("01", r.AccountNumber);

        // Add Merchant Account Information
        Add("26", merchantInfo);

        // Merchant Category Code (Optional)
        Add("52", "0000"); // Default MCC for general purpose

        // Transaction Currency (Mandatory)
        Add("53", "704"); // VND currency code

        // Transaction Amount (Optional)
        if (r.Amount > 0)
        {
            Add("54", r.Amount.ToString("F2"));
        }

        // Country Code (Mandatory)
        Add("58", "VN");

        // Merchant Name (Optional)
        Add("59", r.AccountName ?? "");

        // Merchant City (Optional)
        Add("60", r.BankName ?? "");

        // Additional Data Field Template (Optional)
        if (!string.IsNullOrEmpty(r.Description))
        {
            string additionalData = "";
            void AddAdditional(string id, string val)
            {
                if (string.IsNullOrEmpty(val)) return;
                additionalData += id + val.Length.ToString("D2") + val;
            }
            
            AddAdditional("01", r.Description); // Purpose/Description
            
            Add("62", additionalData);
        }

        // CRC will be calculated after all fields
        var partial = sb.ToString() + "6304";
        var crc = CRC16_CCITT(partial).ToUpper();
        sb.Append("63");
        sb.Append("04");
        sb.Append(crc);

        return sb.ToString();
    }

    // CRC16-CCITT calculation (EMVCo standard)
    private string CRC16_CCITT(string input)
    {
        ushort crc = 0xFFFF;
        foreach (byte b in Encoding.ASCII.GetBytes(input))
        {
            crc ^= (ushort)(b << 8);
            for (int i = 0; i < 8; i++)
                crc = (crc & 0x8000) != 0 ? (ushort)((crc << 1) ^ 0x1021) : (ushort)(crc << 1);
        }
        return crc.ToString("X4");
    }
}