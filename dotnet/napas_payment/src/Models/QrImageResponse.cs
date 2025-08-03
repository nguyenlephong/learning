public class QrImageResponse
{
    public string Base64Image { get; set; } = string.Empty;  // QR code image in base64 format
    public string DataUrl { get; set; } = string.Empty;      // Complete data URL for web use
    public bool IsValid { get; set; } = true;                // Indicates if generation was successful
    public string? ErrorMessage { get; set; }                // Error message if generation failed
    public int ImageSize { get; set; }                       // Actual image size in bytes
} 