public class VietQRTestCase
{
  public string TestName { get; set; } = "";
  public string Description { get; set; } = "";
  public VietQRTestInput Input { get; set; } = new();
  public VietQRTestOutput Expected { get; set; } = new();
  public bool ShouldThrowException { get; set; } = false;
  public string ExpectedException { get; set; } = "";
}
public class VietQRTestInput
{
  public bool OneTime { get; set; }
  public string ServiceType { get; set; } = "";
    
  // Change to object to handle both double and string values
  public object Amount { get; set; } = 0.0;
    
  public string BankBIN { get; set; } = "";
  public string AccountNumber { get; set; } = "";
  public string Note { get; set; } = "";
  public string Currency { get; set; } = "";
  public string CountryCode { get; set; } = "";
    
  // Helper method to get double value
  public double GetAmountAsDouble()
  {
    if (Amount == null) return 0.0;
        
    if (Amount is double d) return d;
        
    if (Amount is string s)
    {
      if (s.Equals("NaN", StringComparison.OrdinalIgnoreCase))
        return double.NaN;
            
      if (double.TryParse(s, out var result))
        return result;
    }
        
    if (double.TryParse(Amount.ToString(), out var parsed))
      return parsed;
            
    return 0.0;
  }
}

public class VietQRTestOutput
{
  public string ExpectedQRCode { get; set; } = "";
}

public class VietQRTestSuite
{
  public string Version { get; set; } = "";
  public string Description { get; set; } = "";
  public VietQRTestCase[] TestCases { get; set; } = Array.Empty<VietQRTestCase>();
}