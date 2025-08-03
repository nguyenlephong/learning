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

        // Tạo QR Image (base64)
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
        // EMVCo format: ID(length) + Value
        // Ví dụ: "00" + "02" + "01" = "000201"
        var sb = new StringBuilder();

        void Add(string id, string val)
        {
            if (string.IsNullOrEmpty(val)) return;
            sb.Append(id);
            sb.Append(val.Length.ToString("D2"));
            sb.Append(val);
        }

        Add("00", "01"); // Payload Format Indicator
        Add("01", "12"); // Point of Initiation Method (12: static QR)
        Add("38", r.BankCode); // NAPAS bank code (required)

        // Merchant Account Information (for NAPAS QR)
        string merchantInfo = "";
        void AddSub(string id, string val)
        {
            if (string.IsNullOrEmpty(val)) return;
            merchantInfo += id + val.Length.ToString("D2") + val;
        }
        AddSub("00", r.BankCode); // Bank code
        AddSub("01", r.AccountNumber); // Account Number

        Add("38", merchantInfo);

        Add("54", r.Amount > 0 ? r.Amount.ToString("F2") : null); // Amount
        Add("59", r.AccountName); // Account Holder Name
        Add("60", r.BankName); // Bank Name

        // Optional: Purpose/Description
        Add("62", r.Description);

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