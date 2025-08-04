using Microsoft.AspNetCore.Mvc;
using napas_payment.Services;

[ApiController]
[Route("api/[controller]")]
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
                    Message = "BankBIN và AccountNumber không được để trống"
                });
            }

            var qrCode = _vietQRService.GenerateWithParams(
                request.OneTime,
                request.ServiceType,
                request.Amount,
                request.BankBIN,
                request.AccountNumber,
                request.Note,
                request.Currency,
                request.CountryCode
            );

            return Ok(new VietQRResponse
            {
                QRCode = qrCode,
                Success = true,
                Message = "Tạo mã QR thành công"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new VietQRResponse
            {
                Success = false,
                Message = $"Lỗi: {ex.Message}"
            });
        }
    }

    [HttpPost("generate-simple")]
    public ActionResult<VietQRResponse> GenerateSimple([FromBody] VietQRRequest request)
    {
        try
        {
            if (string.IsNullOrEmpty(request.BankBIN) || string.IsNullOrEmpty(request.AccountNumber))
            {
                return BadRequest(new VietQRResponse
                {
                    Success = false,
                    Message = "BankBIN và AccountNumber không được để trống"
                });
            }

            var qrCode = _vietQRService.Generate(
                request.Amount,
                request.BankBIN,
                request.AccountNumber,
                request.Note
            );

            return Ok(new VietQRResponse
            {
                QRCode = qrCode,
                Success = true,
                Message = "Tạo mã QR thành công"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new VietQRResponse
            {
                Success = false,
                Message = $"Lỗi: {ex.Message}"
            });
        }
    }
}