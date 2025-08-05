using Microsoft.AspNetCore.Mvc;
using napas_payment.Services;

[ApiController]
[Route("api/viet-qr")]
public class VietQRController : ControllerBase
{
    private readonly IVietQRService _vietQRService;

    public VietQRController(IVietQRService vietQRService)
    {
        _vietQRService = vietQRService;
    }

    [HttpPost("generate")]
    public ActionResult<VietQRResponse> Generate([FromBody] VietQRRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.BankBIN) || string.IsNullOrEmpty(request.AccountNumber))
            {
                return BadRequest(new VietQRResponse
                {
                    Success = false,
                    Message = "Please provide a valid Bank BIN and account number."
                });
            }

            var qrCode = _vietQRService.Create(
                request.OneTime,
                request.ServiceType,
                request.Amount,
                request.BankBIN,
                request.AccountNumber,
                request.Note
            );

            return Ok(new VietQRResponse
            {
                QRCode = qrCode,
                Success = true,
                Message = "SUCCESS"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new VietQRResponse
            {
                Success = false,
                Message = $"Error: {ex.Message}"
            });
        }
    }

    [HttpPost("generate-full")]
    public ActionResult<VietQRResponse> GenerateFull([FromBody] VietQRFullRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.BankBIN) || string.IsNullOrEmpty(request.AccountNumber))
            {
                return BadRequest(new VietQRResponse
                {
                    Success = false,
                    Message = "Please provide a valid Bank BIN and account number."
                });
            }

            var qrCode = _vietQRService.GenerateWithAllParams(request);

            return Ok(new VietQRResponse
            {
                QRCode = qrCode,
                Success = true,
                Message = "SUCCESS"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new VietQRResponse
            {
                Success = false,
                Message = $"Error: {ex.Message}"
            });
        }
    }

}