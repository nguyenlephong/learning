namespace napas_poc.Models
{
    /// <summary>
    /// Model nhận dữ liệu Notify từ Napas (Webhook asynchronous)
    /// </summary>
    public class PaymentNotifyRequest
    {
        /// <summary>
        /// Mã đơn hàng nội bộ (do hệ thống tạo)
        /// </summary>
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Số tiền giao dịch (đơn vị: VND)
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Mã giao dịch Napas
        /// </summary>
        public string TransactionId { get; set; } = string.Empty;

        /// <summary>
        /// Mã trạng thái giao dịch (ví dụ: 00 = thành công)
        /// </summary>
        public string ResponseCode { get; set; } = string.Empty;

        /// <summary>
        /// Thời gian Napas ghi nhận giao dịch (yyyyMMddHHmmss)
        /// </summary>
        public string TransactionDate { get; set; } = string.Empty;

        /// <summary>
        /// Chữ ký số Napas gửi kèm
        /// </summary>
        public string Signature { get; set; } = string.Empty;
    }
}