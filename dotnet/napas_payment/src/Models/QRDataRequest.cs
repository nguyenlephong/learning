using System.ComponentModel.DataAnnotations;

public class QRDataRequest
{
    [Required(ErrorMessage = "Bank code is required")]
    [StringLength(10, ErrorMessage = "Bank code cannot exceed 10 characters")]
    public string BankCode { get; set; } = string.Empty;       // NAPAS bank code

    [Required(ErrorMessage = "Account number is required")]
    [StringLength(20, ErrorMessage = "Account number cannot exceed 20 characters")]
    public string AccountNumber { get; set; } = string.Empty;  // Account number to receive payment

    [StringLength(100, ErrorMessage = "Bank name cannot exceed 100 characters")]
    public string? BankName { get; set; }       // Bank name

    [StringLength(100, ErrorMessage = "Account name cannot exceed 100 characters")]
    public string? AccountName { get; set; }    // Account holder name

    [Range(0, double.MaxValue, ErrorMessage = "Amount must be greater than or equal to 0")]
    public decimal Amount { get; set; }        // Payment amount

    [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
    public string? Description { get; set; }    // Payment description (optional)
}