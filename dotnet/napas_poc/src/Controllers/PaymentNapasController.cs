using Microsoft.AspNetCore.Mvc;
using napas_poc.Interfaces;
using napas_poc.Models;

namespace napas_poc.Controllers
{
    [ApiController]
    [Route("api/payment/napas")]
    public class PaymentNapasController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentNapasController> _logger;

        public PaymentNapasController(IPaymentService paymentService, ILogger<PaymentNapasController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        /// <summary>
        /// 1. Khởi tạo giao dịch Napas
        /// </summary>
        [HttpPost("init")]
        public async Task<IActionResult> InitPayment([FromBody] PaymentInitRequest request)
        {
            var result = await _paymentService.InitPaymentAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// 2. Callback khi user hoàn tất thanh toán (Synchronous)
        /// </summary>
        [HttpGet("return")]
        public IActionResult ReturnCallback([FromQuery] Dictionary<string, string> queryParams)
        {
            _logger.LogInformation("Return URL Napas: {@QueryParams}", queryParams);

            var result = _paymentService.HandleReturnCallback(queryParams);
            return Ok(result);
        }

        /// <summary>
        /// 3. Webhook notify từ Napas (Asynchronous)
        /// </summary>
        [HttpPost("notify")]
        public async Task<IActionResult> Notify([FromForm] PaymentNotifyRequest request)
        {
            _logger.LogInformation("Notify Napas: {@Request}", request);

            var result = await _paymentService.HandleNotifyAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// 4. Query trạng thái giao dịch
        /// </summary>
        [HttpGet("status/{orderId}")]
        public async Task<IActionResult> GetStatus(string orderId)
        {
            var result = await _paymentService.QueryTransactionStatusAsync(orderId);
            return Ok(result);
        }

        /// <summary>
        /// 5. Hoàn tiền giao dịch
        /// </summary>
        [HttpPost("refund")]
        public async Task<IActionResult> Refund([FromBody] RefundRequest request)
        {
            var result = await _paymentService.RefundAsync(request);
            return Ok(result);
        }
    }
}