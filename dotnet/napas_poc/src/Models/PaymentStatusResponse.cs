namespace napas_poc.Models
{
    /// <summary>
    /// Kết quả truy vấn trạng thái giao dịch Napas
    /// </summary>
    public class PaymentStatusResponse
    {
        public string OrderId { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;

        /// <summary>
        /// Trạng thái: SUCCESS / FAILED / PENDING
        /// </summary>
        public string Status { get; set; } = string.Empty;

        public string ResponseCode { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả hoặc lý do nếu thất bại
        /// </summary>
        public string Message { get; set; } = string.Empty;

        public decimal Amount { get; set; }
    }
}