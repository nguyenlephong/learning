using Microsoft.AspNetCore.Mvc;
using NapasPayment.Services;

[ApiController]
[Route("api/napas")]
[ApiExplorerSettings(IgnoreApi = true)]
public class NapasQrController : ControllerBase
{
    private readonly INapasQrServiceV2 _qrService;

    public NapasQrController(INapasQrServiceV2 qrService)
    {
        _qrService = qrService;
    }

    /// <summary>
    /// Generate NAPAS QR code according to EMVCo standards
    /// </summary>
    /// <param name="request">QR code generation request</param>
    /// <returns>QR code raw data</returns>
    [HttpPost("qr")]
    public ActionResult<QRDataResponse> GenerateNapasQr([FromBody] QRDataRequest request)
    {
        if (request == null)
        {
            return BadRequest(new QRDataResponse 
            { 
                IsValid = false, 
                ErrorMessage = "Request cannot be null" 
            });
        }

        var result = _qrService.GenerateNapasQr(request);
        
        if (!result.IsValid)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
} 