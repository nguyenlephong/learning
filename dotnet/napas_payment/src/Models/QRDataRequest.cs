public class QRDataRequest
{
    public string BankCode { get; set; }       // Mã ngân hàng NAPAS
    public string AccountNumber { get; set; }  // Số tài khoản nhận
    public string BankName { get; set; }       // Tên ngân hàng
    public string AccountName { get; set; }    // Tên chủ tài khoản
    public decimal Amount { get; set; }        // Số tiền
    public string Description { get; set; }    // Nội dung chuyển khoản (optional)
}