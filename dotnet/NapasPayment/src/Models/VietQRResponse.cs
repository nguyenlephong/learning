public class VietQRResponse
{
    public string QRCode { get; set; } = string.Empty;
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;

    public VietQRResponse()
    {
        QRCode = string.Empty;
        Message = string.Empty;
    }
}