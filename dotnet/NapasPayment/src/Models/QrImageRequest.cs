public class QrImageRequest
{
    public string QrData { get; set; } = string.Empty;  // QR code string data
    public int Size { get; set; } = 10;                 // QR code size (pixels per module)
    public string Format { get; set; } = "png";         // Image format (png, jpg, etc.)
    public int ErrorCorrectionLevel { get; set; } = 2;  // 0=L, 1=M, 2=Q, 3=H
} 