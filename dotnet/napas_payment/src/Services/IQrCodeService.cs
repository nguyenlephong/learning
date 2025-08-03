namespace napas_payment.Services
{
    /// <summary>
    /// Generic QR code service interface for different QR code standards
    /// </summary>
    public interface IQrCodeService
    {
        /// <summary>
        /// Generate QR code raw data
        /// </summary>
        /// <param name="request">QR code generation request</param>
        /// <returns>QR code response with raw data</returns>
        QRDataResponse GenerateQrCode(QRDataRequest request);
    }

    /// <summary>
    /// NAPAS specific QR code service interface
    /// </summary>
    public interface INapasQrService : IQrCodeService
    {
        /// <summary>
        /// Generate NAPAS QR code according to EMVCo standards
        /// </summary>
        /// <param name="request">NAPAS QR code request</param>
        /// <returns>NAPAS QR code response</returns>
        QRDataResponse GenerateNapassQr(QRDataRequest request);
    }
} 