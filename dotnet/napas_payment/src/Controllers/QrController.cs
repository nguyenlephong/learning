using Microsoft.AspNetCore.Mvc;
using napas_payment.Services;

[ApiController]
[Route("api/qr")]
public class QrController : ControllerBase
{
    private readonly INapasQrService _qrService;

    public QrController(INapasQrService qrService)
    {
        _qrService = qrService;
    }

    /// <summary>
    /// Generate NAPAS QR code according to EMVCo standards
    /// </summary>
    /// <param name="request">QR code generation request</param>
    /// <returns>QR code raw data</returns>
    [HttpPost("napas")]
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

        var result = _qrService.GenerateNapassQr(request);
        
        if (!result.IsValid)
        {
            return BadRequest(result);
        }

        try
        {
            var result2 = _qrService.GenerateNapassQr(request);
            return Ok(result2);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new QRDataResponse 
            { 
                IsValid = false, 
                ErrorMessage = $"Error generating QR code: {ex.Message}" 
            });
        }
        return Ok(result);
    }

    /// <summary>
    /// Get QR code information without generating image
    /// </summary>
    /// <param name="request">QR code generation request</param>
    /// <returns>QR code raw data only</returns>
    [HttpPost("napas/raw")]
    public ActionResult<QRDataResponse> GetNapasQrRaw([FromBody] QRDataRequest request)
    {
        // // Validate request
        // if (request == null)
        // {
        //     return BadRequest(new QRDataResponse 
        //     { 
        //         IsValid = false, 
        //         ErrorMessage = "Request cannot be null" 
        //     });
        // }

        // // Validate required fields
        // var validationResults = new List<ValidationResult>();
        // var validationContext = new ValidationContext(request);
        
        // if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
        // {
        //     var errors = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
        //     return BadRequest(new QRDataResponse 
        //     { 
        //         IsValid = false, 
        //         ErrorMessage = errors 
        //     });
        // }

        // try
        // {
        //     var result = _qrService.GenerateNapassQr(request);
        //     // Return only raw data without image
        //     return Ok(new QRDataResponse 
        //     { 
        //         RawData = result.RawData,
        //         IsValid = true
        //     });
        // }
        // catch (Exception ex)
        // {
        //     return StatusCode(500, new QRDataResponse 
        //     { 
        //         IsValid = false, 
        //         ErrorMessage = $"Error generating QR code: {ex.Message}" 
        //     });
        // }
        return Ok(200);
    }
}