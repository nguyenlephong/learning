using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/qr")]
public class QrController : ControllerBase
{
    private readonly INapasQrService _qrService;

    public QrController(INapasQrService qrService)
    {
        _qrService = qrService;
    }

    [HttpPost("napas")]
    public ActionResult<QRDataResponse> GenerateNapasQr([FromBody] QRDataRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.BankCode) || string.IsNullOrEmpty(request.AccountNumber))
            return BadRequest("Thiếu thông tin bắt buộc");
        var result = _qrService.GenerateNapassQr(request);
        return Ok(result);
    }
}