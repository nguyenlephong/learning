using Microsoft.AspNetCore.Mvc;
using napas_payment.Services;

[ApiController]
[Route("api/qrcode")]
public class QrCodeController : ControllerBase
{
    private readonly IQrCodeServiceFactory _qrServiceFactory;

    public QrCodeController(IQrCodeServiceFactory qrServiceFactory)
    {
        _qrServiceFactory = qrServiceFactory;
    }

    /// <summary>
    /// Generate QR code by type
    /// </summary>
    /// <param name="qrType">Type of QR code to generate</param>
    /// <param name="request">QR code generation request</param>
    /// <returns>QR code raw data</returns>
    [HttpPost("{qrType}")]
    public ActionResult<QRDataResponse> GenerateQrCode(
        [FromRoute] QrCodeType qrType,
        [FromBody] QRDataRequest request)
    {
        if (request == null)
        {
            return BadRequest(new QRDataResponse 
            { 
                IsValid = false, 
                ErrorMessage = "Request cannot be null" 
            });
        }

        try
        {
            var service = _qrServiceFactory.GetService(qrType);
            var result = service.GenerateQrCode(request);
            
            if (!result.IsValid)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new QRDataResponse 
            { 
                IsValid = false, 
                ErrorMessage = ex.Message 
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new QRDataResponse 
            { 
                IsValid = false, 
                ErrorMessage = $"Error generating QR code: {ex.Message}" 
            });
        }
    }

    /// <summary>
    /// Generate NAPAS QR code (alias for /napas endpoint)
    /// </summary>
    /// <param name="request">QR code generation request</param>
    /// <returns>QR code raw data</returns>
    [HttpPost("napas")]
    public ActionResult<QRDataResponse> GenerateNapasQr([FromBody] QRDataRequest request)
    {
        return GenerateQrCode(QrCodeType.NAPAS, request);
    }

    /// <summary>
    /// Generate EMVCo QR code
    /// </summary>
    /// <param name="request">QR code generation request</param>
    /// <returns>QR code raw data</returns>
    [HttpPost("emvco")]
    public ActionResult<QRDataResponse> GenerateEmvcoQr([FromBody] QRDataRequest request)
    {
        return GenerateQrCode(QrCodeType.EMVCo, request);
    }

    /// <summary>
    /// Generate VietQR code
    /// </summary>
    /// <param name="request">QR code generation request</param>
    /// <returns>QR code raw data</returns>
    [HttpPost("vietqr")]
    public ActionResult<QRDataResponse> GenerateVietQr([FromBody] QRDataRequest request)
    {
        return GenerateQrCode(QrCodeType.VietQR, request);
    }
} 