public class QRDataResponse
{
    public string RawData { get; set; }        // Chuỗi QR chuẩn NAPAS (EMVCo)
    public string Base64QrImage { get; set; }  // Ảnh QR base64 (nếu cần)
}