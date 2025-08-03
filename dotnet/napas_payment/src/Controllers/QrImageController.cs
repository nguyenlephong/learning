using Microsoft.AspNetCore.Mvc;
using napas_payment.Services;

[ApiController]
[Route("api/qr-image")]
public class QrImageController : ControllerBase
{
    private readonly IQrImageService _qrImageService;

    public QrImageController(IQrImageService qrImageService)
    {
        _qrImageService = qrImageService;
    }

    /// <summary>
    /// Generate QR code image from string data
    /// </summary>
    /// <param name="request">QR image generation request</param>
    /// <returns>QR code image in base64 format</returns>
    [HttpPost("generate")]
    public ActionResult<QrImageResponse> GenerateQrImage([FromBody] QrImageRequest request)
    {
        if (request == null)
        {
            return BadRequest(new QrImageResponse 
            { 
                IsValid = false, 
                ErrorMessage = "Request cannot be null" 
            });
        }

        var result = _qrImageService.GenerateQrImage(request);
        
        if (!result.IsValid)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    /// <summary>
    /// Generate QR code image from NAPAS QR data
    /// </summary>
    /// <param name="qrDataRequest">NAPAS QR data request</param>
    /// <param name="imageRequest">Image generation options</param>
    /// <returns>QR code image in base64 format</returns>
    [HttpPost("napas")]
    public ActionResult<QrImageResponse> GenerateNapasQrImage(
        [FromBody] QRDataRequest qrDataRequest,
        [FromQuery] int size = 10,
        [FromQuery] string format = "png",
        [FromQuery] int errorCorrectionLevel = 2)
    {
        if (qrDataRequest == null)
        {
            return BadRequest(new QrImageResponse 
            { 
                IsValid = false, 
                ErrorMessage = "QR data request cannot be null" 
            });
        }

        // First generate NAPAS QR data
        var napasService = HttpContext.RequestServices.GetRequiredService<INapasQrServiceV2>();
        var qrDataResponse = napasService.GenerateNapasQr(qrDataRequest);
        
        if (!qrDataResponse.IsValid)
        {
            return BadRequest(new QrImageResponse 
            { 
                IsValid = false, 
                ErrorMessage = $"Error generating NAPAS QR data: {qrDataResponse.ErrorMessage}" 
            });
        }

        // Then generate image from QR data
        var imageRequest = new QrImageRequest
        {
            QrData = qrDataResponse.RawData,
            Size = size,
            Format = format,
            ErrorCorrectionLevel = errorCorrectionLevel
        };

        var result = _qrImageService.GenerateQrImage(imageRequest);
        
        if (!result.IsValid)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
} 