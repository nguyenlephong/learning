using System.ComponentModel.DataAnnotations;

public class QRDataRequest
{
    // Required fields
    public string BankCode { get; set; } = string.Empty;       // NAPAS bank code
    public string AccountNumber { get; set; } = string.Empty;  // Account number to receive payment

    // Optional fields with defaults
    public string? PayloadFormatIndicator { get; set; } = "02"; // EMV QR Code format
    public string? PointOfInitiationMethod { get; set; } = "12"; // 12: Static QR, 11: Dynamic QR
    public string? MerchantCategoryCode { get; set; } = "0000"; // MCC code
    public string? TransactionCurrency { get; set; } = "704";   // VND currency code
    public string? CountryCode { get; set; } = "VN";           // Vietnam country code
    
    // Transaction details
    public decimal? Amount { get; set; }                       // Payment amount
    public string? AccountName { get; set; }                   // Account holder name
    public string? BankName { get; set; }                      // Bank name
    public string? Description { get; set; }                   // Payment description
    
    // Additional merchant information
    public string? MerchantName { get; set; }                  // Merchant name (overrides AccountName)
    public string? MerchantCity { get; set; }                  // Merchant city (overrides BankName)
    
    // Additional data fields
    public string? Purpose { get; set; }                       // Purpose of transaction
    public string? ReferenceLabel { get; set; }                // Reference label
    public string? CustomerLabel { get; set; }                 // Customer label
    public string? TerminalLabel { get; set; }                 // Terminal label
    public string? AdditionalConsumerDataRequest { get; set; } // Additional consumer data request
    
    // Custom fields for specific use cases
    public Dictionary<string, string>? CustomFields { get; set; } // Custom EMVCo fields
}