public class QRDataResponse
{
    public string RawData { get; set; } = string.Empty;        // NAPAS QR code string (EMVCo format)
    public bool IsValid { get; set; } = true;                  // Indicates if QR code generation was successful
    public string? ErrorMessage { get; set; }                  // Error message if generation failed
}