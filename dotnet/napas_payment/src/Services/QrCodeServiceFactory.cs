namespace napas_payment.Services
{
    /// <summary>
    /// Factory for creating QR code services based on type
    /// </summary>
    public interface IQrCodeServiceFactory
    {
        /// <summary>
        /// Get QR code service by type
        /// </summary>
        /// <param name="qrType">Type of QR code service</param>
        /// <returns>QR code service instance</returns>
        IQrCodeService GetService(QrCodeType qrType);
    }

    /// <summary>
    /// QR code types supported by the system
    /// </summary>
    public enum QrCodeType
    {
        NAPAS,
        EMVCo,
        VietQR,
        Custom
    }

    /// <summary>
    /// Factory implementation for QR code services
    /// </summary>
    public class QrCodeServiceFactory : IQrCodeServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QrCodeServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IQrCodeService GetService(QrCodeType qrType)
        {
            return qrType switch
            {
                QrCodeType.NAPAS => _serviceProvider.GetRequiredService<INapasQrService>(),
                QrCodeType.EMVCo => _serviceProvider.GetRequiredService<INapasQrService>(), // Same as NAPAS for now
                QrCodeType.VietQR => _serviceProvider.GetRequiredService<INapasQrService>(), // Same as NAPAS for now
                QrCodeType.Custom => _serviceProvider.GetRequiredService<INapasQrService>(), // Default to NAPAS
                _ => throw new ArgumentException($"Unsupported QR code type: {qrType}")
            };
        }
    }
} 