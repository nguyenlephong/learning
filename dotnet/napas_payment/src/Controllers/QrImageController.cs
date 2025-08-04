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
}