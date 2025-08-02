using napas_poc.Interfaces;
using napas_poc.Models;
using Microsoft.Extensions.Logging;

namespace napas_poc.Services
{
    public class NapasPaymentService : IPaymentService
    {
        private readonly ILogger<NapasPaymentService> _logger;
        private readonly IConfiguration _config;

        public NapasPaymentService(ILogger<NapasPaymentService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public Task<PaymentInitResponse> InitPaymentAsync(PaymentInitRequest request)
        {
            // TODO: Build payload Napas, ký HMAC, tạo URL thanh toán
            _logger.LogInformation("InitPayment Napas for OrderId={OrderId}", request.OrderId);

            var paymentUrl = "https://sandbox.napas.com.vn/payment?...";
            return Task.FromResult(new PaymentInitResponse
            {
                PaymentUrl = paymentUrl,
                OrderId = request.OrderId
            });
        }

        public object HandleReturnCallback(Dictionary<string, string> queryParams)
        {
            // TODO: Verify signature + parse status
            return new { Status = "SUCCESS", Data = queryParams };
        }

        public Task<object> HandleNotifyAsync(PaymentNotifyRequest request)
        {
            // TODO: Verify signature + update DB
            return Task.FromResult<object>(new { Status = "RECEIVED" });
        }

        public Task<PaymentStatusResponse> QueryTransactionStatusAsync(string orderId)
        {
            // TODO: Call Napas status API
            return Task.FromResult(new PaymentStatusResponse
            {
                OrderId = orderId,
                Status = "SUCCESS"
            });
        }

        public Task<object> RefundAsync(RefundRequest request)
        {
            // TODO: Call Napas refund API
            return Task.FromResult<object>(new { Status = "REFUND_REQUESTED" });
        }
    }
}