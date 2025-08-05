using System.Text;
using NapasPayment.Constants;

namespace NapasPayment.Services
{
    public interface INapasQrServiceV2
    {
        QRDataResponse GenerateNapasQr(QRDataRequest request);
    }

    public class NapasQrServiceV2 : INapasQrServiceV2
    {
        public QRDataResponse GenerateNapasQr(QRDataRequest req)
        {
            try
            {
                var raw = GenerateEmvcoNapassQrRaw(req);
                return new QRDataResponse
                {
                    RawData = raw,
                    IsValid = true
                };
            }
            catch (Exception ex)
            {
                return new QRDataResponse
                {
                    RawData = string.Empty,
                    IsValid = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        private string GenerateEmvcoNapassQrRaw(QRDataRequest r)
        {
            var sb = new StringBuilder();

            void Add(string id, string val)
            {
                if (string.IsNullOrEmpty(val)) return;
                sb.Append(id);
                sb.Append(val.Length.ToString("D2"));
                sb.Append(val);
            }

            // Payload Format Indicator (Mandatory)
            Add(NapasQrConstants.PAYLOAD_FORMAT_INDICATOR, r.PayloadFormatIndicator ?? NapasQrConstants.DEFAULT_PAYLOAD_FORMAT);

            // Point of Initiation Method (Optional)
            Add(NapasQrConstants.POINT_OF_INITIATION_METHOD, r.PointOfInitiationMethod ?? NapasQrConstants.DEFAULT_POINT_OF_INITIATION);

            // Merchant Account Information (Mandatory for NAPAS)
            string merchantInfo = "";
            void AddSub(string id, string val)
            {
                if (string.IsNullOrEmpty(val)) return;
                merchantInfo += id + val.Length.ToString("D2") + val;
            }
            
            // NAPAS Bank Code (Required)
            AddSub(NapasQrConstants.BANK_CODE, r.BankCode);
            
            // Account Number (Required)
            AddSub(NapasQrConstants.ACCOUNT_NUMBER, r.AccountNumber);

            // Add Merchant Account Information
            Add(NapasQrConstants.MERCHANT_ACCOUNT_INFORMATION, merchantInfo);

            // Merchant Category Code (Optional)
            Add(NapasQrConstants.MERCHANT_CATEGORY_CODE, r.MerchantCategoryCode ?? NapasQrConstants.DEFAULT_MERCHANT_CATEGORY_CODE);

            // Transaction Currency (Mandatory)
            Add(NapasQrConstants.TRANSACTION_CURRENCY, r.TransactionCurrency ?? NapasQrConstants.DEFAULT_TRANSACTION_CURRENCY);

            // Transaction Amount (Optional) - Format as VND (no decimal places)
            if (r.Amount.HasValue && r.Amount.Value > 0)
            {
                // Convert to VND format (no decimal places)
                var amountInVND = (long)Math.Round(r.Amount.Value);
                Add(NapasQrConstants.TRANSACTION_AMOUNT, amountInVND.ToString());
            }

            // Country Code (Mandatory)
            Add(NapasQrConstants.COUNTRY_CODE, r.CountryCode ?? NapasQrConstants.DEFAULT_COUNTRY_CODE);

            // Merchant Name (Optional)
            var merchantName = r.MerchantName ?? r.AccountName ?? "";
            Add(NapasQrConstants.MERCHANT_NAME, merchantName);

            // Merchant City (Optional)
            var merchantCity = r.MerchantCity ?? r.BankName ?? "";
            Add(NapasQrConstants.MERCHANT_CITY, merchantCity);

            // Additional Data Field Template (Optional)
            if (!string.IsNullOrEmpty(r.Description) || 
                !string.IsNullOrEmpty(r.Purpose) ||
                !string.IsNullOrEmpty(r.ReferenceLabel) ||
                !string.IsNullOrEmpty(r.CustomerLabel) ||
                !string.IsNullOrEmpty(r.TerminalLabel) ||
                !string.IsNullOrEmpty(r.AdditionalConsumerDataRequest))
            {
                string additionalData = "";
                void AddAdditional(string id, string val)
                {
                    if (string.IsNullOrEmpty(val)) return;
                    additionalData += id + val.Length.ToString("D2") + val;
                }
                
                AddAdditional(NapasQrConstants.PURPOSE, r.Description ?? ""); // Purpose/Description
                AddAdditional(NapasQrConstants.PURPOSE_ALT, r.Purpose ?? ""); // Purpose
                AddAdditional(NapasQrConstants.REFERENCE_LABEL, r.ReferenceLabel ?? ""); // Reference Label
                AddAdditional(NapasQrConstants.CUSTOMER_LABEL, r.CustomerLabel ?? ""); // Customer Label
                AddAdditional(NapasQrConstants.TERMINAL_LABEL, r.TerminalLabel ?? ""); // Terminal Label
                AddAdditional(NapasQrConstants.ADDITIONAL_CONSUMER_DATA_REQUEST, r.AdditionalConsumerDataRequest ?? ""); // Additional Consumer Data Request
                
                Add(NapasQrConstants.ADDITIONAL_DATA_FIELD_TEMPLATE, additionalData);
            }

            // Add custom fields if provided
            if (r.CustomFields != null && r.CustomFields.Count > 0)
            {
                foreach (var field in r.CustomFields)
                {
                    if (!string.IsNullOrEmpty(field.Key) && !string.IsNullOrEmpty(field.Value))
                    {
                        Add(field.Key, field.Value);
                    }
                }
            }

            // CRC will be calculated after all fields
            var partial = sb.ToString() + NapasQrConstants.CRC + "04";
            var crc = CRC16_CCITT(partial).ToUpper();
            sb.Append(NapasQrConstants.CRC);
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
} 