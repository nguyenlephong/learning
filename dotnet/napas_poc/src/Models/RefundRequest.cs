namespace napas_poc.Models
{
    /// <summary>
    /// Yêu cầu hoàn tiền giao dịch
    /// </summary>
    public class RefundRequest
    {
        /// <summary>
        /// Mã đơn hàng nội bộ
        /// </summary>
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// Mã giao dịch Napas cần hoàn tiền
        /// </summary>
        public string TransactionId { get; set; } = string.Empty;

        /// <summary>
        /// Số tiền cần hoàn (VND)
        /// </summary>
        public decimal RefundAmount { get; set; }

        /// <summary>
        /// Lý do hoàn tiền
        /// </summary>
        public string Reason { get; set; } = string.Empty;
    }
}