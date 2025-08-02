using napas_poc.Models;

namespace napas_poc.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentInitResponse> InitPaymentAsync(PaymentInitRequest request);
        object HandleReturnCallback(Dictionary<string, string> queryParams);
        Task<object> HandleNotifyAsync(PaymentNotifyRequest request);
        Task<PaymentStatusResponse> QueryTransactionStatusAsync(string orderId);
        Task<object> RefundAsync(RefundRequest request);
    }
}