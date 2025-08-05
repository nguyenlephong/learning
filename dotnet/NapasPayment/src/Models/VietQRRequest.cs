public class VietQRRequest
{
    public double Amount { get; set; }

    public string BankBIN { get; set; } = string.Empty;

    public string AccountNumber { get; set; } = string.Empty;

    public string Note { get; set; } = string.Empty;

    public bool OneTime { get; set; } = true;

    public string ServiceType { get; set; } = "QRIBFTTA";

    public string Currency { get; set; } = "VND";

    public string CountryCode { get; set; } = "VN";

    public VietQRRequest()
    {
        BankBIN = string.Empty;
        AccountNumber = string.Empty;
        Note = string.Empty;
        ServiceType = "QRIBFTTA";
        Currency = "VND";
        CountryCode = "VN";
    }
}

