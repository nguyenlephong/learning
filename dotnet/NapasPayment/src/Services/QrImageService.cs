using QRCoder;

namespace NapasPayment.Services
{
    public interface IQrImageService
    {
        QrImageResponse GenerateQrImage(QrImageRequest request);
    }

    public class QrImageService : IQrImageService
    {
        public QrImageResponse GenerateQrImage(QrImageRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.QrData))
                {
                    return new QrImageResponse
                    {
                        IsValid = false,
                        ErrorMessage = "QR data cannot be empty"
                    };
                }

                // Validate size
                if (request.Size < 1 || request.Size > 50)
                {
                    return new QrImageResponse
                    {
                        IsValid = false,
                        ErrorMessage = "Size must be between 1 and 50"
                    };
                }

                // Validate error correction level
                if (request.ErrorCorrectionLevel < 0 || request.ErrorCorrectionLevel > 3)
                {
                    return new QrImageResponse
                    {
                        IsValid = false,
                        ErrorMessage = "Error correction level must be between 0 and 3"
                    };
                }

                // Convert error correction level to QRCoder enum
                var eccLevel = request.ErrorCorrectionLevel switch
                {
                    0 => QRCodeGenerator.ECCLevel.L,
                    1 => QRCodeGenerator.ECCLevel.M,
                    2 => QRCodeGenerator.ECCLevel.Q,
                    3 => QRCodeGenerator.ECCLevel.H,
                    _ => QRCodeGenerator.ECCLevel.Q
                };

                // Generate QR code
                using var qrGenerator = new QRCodeGenerator();
                using var qrData = qrGenerator.CreateQrCode(request.QrData, eccLevel);
                using var qrCode = new PngByteQRCode(qrData);
                var qrBytes = qrCode.GetGraphic(request.Size);

                // Convert to base64
                var base64Image = Convert.ToBase64String(qrBytes);
                var mimeType = request.Format.ToLower() switch
                {
                    "png" => "image/png",
                    "jpg" => "image/jpeg",
                    "jpeg" => "image/jpeg",
                    _ => "image/png"
                };

                return new QrImageResponse
                {
                    Base64Image = base64Image,
                    DataUrl = $"data:{mimeType};base64,{base64Image}",
                    IsValid = true,
                    ImageSize = qrBytes.Length
                };
            }
            catch (Exception ex)
            {
                return new QrImageResponse
                {
                    IsValid = false,
                    ErrorMessage = $"Error generating QR image: {ex.Message}"
                };
            }
        }
    }
} 