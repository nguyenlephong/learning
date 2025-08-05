public class VietQRFullRequest
{
    // Basic parameters
    public double TransactionAmount { get; set; }
    public string BankBIN { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public bool OneTime { get; set; } = true;
    public string ServiceType { get; set; } = "QRIBFTTA";

    // EMVCo QR Code fields
    public string? PayloadFormatIndicator { get; set; } = "01";
    public string? PointOfInitiationMethod { get; set; }
    public string? MerchantCategoryCode { get; set; }
    public string? TransactionCurrency { get; set; } = "VND";
    public string? CountryCode { get; set; } = "VN";
    public string? MerchantName { get; set; }
    public string? MerchantCity { get; set; }
    public string? Purpose { get; set; }
    public string? ReferenceLabel { get; set; }
    public string? CustomerLabel { get; set; }
    public string? TerminalLabel { get; set; }
    public string? AdditionalConsumerDataRequest { get; set; }

    // Custom fields for extensibility
    public Dictionary<string, string>? CustomFields { get; set; }

    public VietQRFullRequest()
    {
        BankBIN = string.Empty;
        AccountNumber = string.Empty;
        Note = string.Empty;
        ServiceType = "QRIBFTTA";
        TransactionCurrency = "VND";
        CountryCode = "VN";
    }
}