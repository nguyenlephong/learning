using System.Text;
using System.Text.RegularExpressions;

public interface IVietQRService
{
  string Generate(double amount, string bankBIN, string accountNumber, string note);
  string Create(bool onetime, string serviceType, double amount, string bankBIN, string accountNumber, string note);

  string GenerateWithParams(bool onetime, string serviceType, double amount, string bankBIN,
    string accountNumber, string note, string currency, string countryCode);

  string GenerateWithAllParams(VietQRFullRequest request);
}

public class VietQRService : IVietQRService
{
  private static readonly Dictionary<char, char> VnMap = new()
  {
    { 'ạ', 'a' }, { 'ả', 'a' }, { 'ã', 'a' }, { 'à', 'a' }, { 'á', 'a' }, { 'â', 'a' }, { 'ậ', 'a' }, { 'ầ', 'a' },
    { 'ấ', 'a' },
    { 'ẩ', 'a' }, { 'ẫ', 'a' }, { 'ă', 'a' }, { 'ắ', 'a' }, { 'ằ', 'a' }, { 'ặ', 'a' }, { 'ẳ', 'a' }, { 'ẵ', 'a' },
    { 'ó', 'o' }, { 'ò', 'o' }, { 'ọ', 'o' }, { 'õ', 'o' }, { 'ỏ', 'o' }, { 'ô', 'o' }, { 'ộ', 'o' }, { 'ổ', 'o' },
    { 'ỗ', 'o' },
    { 'ồ', 'o' }, { 'ố', 'o' }, { 'ơ', 'o' }, { 'ờ', 'o' }, { 'ớ', 'o' }, { 'ợ', 'o' }, { 'ở', 'o' }, { 'ỡ', 'o' },
    { 'é', 'e' }, { 'è', 'e' }, { 'ẻ', 'e' }, { 'ẹ', 'e' }, { 'ẽ', 'e' }, { 'ê', 'e' }, { 'ế', 'e' }, { 'ề', 'e' },
    { 'ệ', 'e' }, { 'ể', 'e' }, { 'ễ', 'e' },
    { 'ú', 'u' }, { 'ù', 'u' }, { 'ụ', 'u' }, { 'ủ', 'u' }, { 'ũ', 'u' }, { 'ư', 'u' }, { 'ự', 'u' }, { 'ữ', 'u' },
    { 'ử', 'u' }, { 'ừ', 'u' }, { 'ứ', 'u' },
    { 'í', 'i' }, { 'ì', 'i' }, { 'ị', 'i' }, { 'ỉ', 'i' }, { 'ĩ', 'i' },
    { 'ý', 'y' }, { 'ỳ', 'y' }, { 'ỷ', 'y' }, { 'ỵ', 'y' }, { 'ỹ', 'y' },
    { 'đ', 'd' },
    { 'Ạ', 'A' }, { 'Ả', 'A' }, { 'Ã', 'A' }, { 'À', 'A' }, { 'Á', 'A' }, { 'Â', 'A' }, { 'Ậ', 'A' }, { 'Ầ', 'A' },
    { 'Ấ', 'A' },
    { 'Ẩ', 'A' }, { 'Ẫ', 'A' }, { 'Ă', 'A' }, { 'Ắ', 'A' }, { 'Ằ', 'A' }, { 'Ặ', 'A' }, { 'Ẳ', 'A' }, { 'Ẵ', 'A' },
    { 'Ó', 'O' }, { 'Ò', 'O' }, { 'Ọ', 'O' }, { 'Õ', 'O' }, { 'Ỏ', 'O' }, { 'Ô', 'O' }, { 'Ộ', 'O' }, { 'Ổ', 'O' },
    { 'Ỗ', 'O' },
    { 'Ồ', 'O' }, { 'Ố', 'O' }, { 'Ơ', 'O' }, { 'Ờ', 'O' }, { 'Ớ', 'O' }, { 'Ợ', 'O' }, { 'Ở', 'O' }, { 'Ỡ', 'O' },
    { 'É', 'E' }, { 'È', 'E' }, { 'Ẻ', 'E' }, { 'Ẹ', 'E' }, { 'Ẽ', 'E' }, { 'Ê', 'E' }, { 'Ế', 'E' }, { 'Ề', 'E' },
    { 'Ệ', 'E' }, { 'Ể', 'E' }, { 'Ễ', 'E' },
    { 'Ú', 'U' }, { 'Ù', 'U' }, { 'Ụ', 'U' }, { 'Ủ', 'U' }, { 'Ũ', 'U' }, { 'Ư', 'U' }, { 'Ự', 'U' }, { 'Ữ', 'U' },
    { 'Ử', 'U' }, { 'Ừ', 'U' }, { 'Ứ', 'U' },
    { 'Í', 'I' }, { 'Ì', 'I' }, { 'Ị', 'I' }, { 'Ỉ', 'I' }, { 'Ĩ', 'I' },
    { 'Ý', 'Y' }, { 'Ỳ', 'Y' }, { 'Ỷ', 'Y' }, { 'Ỵ', 'Y' }, { 'Ỹ', 'Y' },
    { 'Đ', 'D' }
  };

  private static readonly Dictionary<string, string> CountryCodes = new()
  {
    { "JP", "Japan" }, { "KR", "Korea" }, { "MY", "Malaysia" }, { "RC", "China" },
    { "RI", "Indonesia" }, { "RP", "Philippines" }, { "SG", "Singapore" },
    { "TH", "Thailand" }, { "VN", "Viet Nam" }
  };

  private static readonly Dictionary<string, string> CurrencyMap = new()
  {
    { "JPY", "392" }, { "KRW", "410" }, { "MYR", "458" }, { "CNY", "156" },
    { "IDR", "360" }, { "PHP", "608" }, { "SGD", "702" }, { "THB", "764" }, { "VND", "704" }
  };

  private static readonly ushort[] IsoIec13239Data = new ushort[256];
  private const ushort CrcInit = 0xFFFF;
  private const ushort CrcPoly = 0x1021;

  static VietQRService()
  {
    InitCrcTable();
  }

  public string Generate(double amount, string bankBIN, string accountNumber, string note)
  {
    return GenerateWithParams(true, "QRIBFTTA", amount, bankBIN, accountNumber, note, "VND", "VN");
  }

  public string Create(bool onetime, string serviceType, double amount, string bankBIN, string accountNumber,
    string note)
  {
    return GenerateWithParams(true, "QRIBFTTA", amount, bankBIN, accountNumber, note, "VND", "VN");
  }

  public string GenerateWithParams(bool onetime, string serviceType, double amount, string bankBIN,
    string accountNumber, string note, string currency, string countryCode)
  {
    // Validate inputs
    if (string.IsNullOrEmpty(bankBIN) || string.IsNullOrEmpty(accountNumber)) return "";

    var contents = new Dictionary<string, string>
    {
      ["00"] = "01",
      ["01"] = onetime ? "12" : "11",
      ["3800"] = "A000000727",
      ["380100"] = bankBIN,
      ["380101"] = accountNumber
    };

    // Add service type if provided
    if (!string.IsNullOrEmpty(serviceType))
    {
      contents["3802"] = serviceType;
    }

    // Add currency
    if (!string.IsNullOrEmpty(currency) && CurrencyMap.TryGetValue(currency, out var currencyCode))
    {
      contents["53"] = currencyCode;
    }
    else
    {
      contents["53"] = "704"; // Default to VND
    }

    // Add country code
    if (!string.IsNullOrEmpty(countryCode) && CountryCodes.ContainsKey(countryCode))
    {
      contents["58"] = countryCode;
    }
    else
    {
      contents["58"] = "VN"; // Default to VN
    }

    // Add amount if greater than 0
    if (!double.IsNaN(amount) && amount > 0)
    {
      contents["54"] = ((int)amount).ToString();
    }

    // Add note if provided
    if (!string.IsNullOrEmpty(note?.Trim()))
    {
      contents["6208"] = ToAscii(note.Trim());
    }

    try
    {
      var output = GenerateObject(GetDefaults(), "", "", contents) + "6304";
      return output + CrcChecksum(output);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"output generate err:  {ex.Message}");
      return string.Empty;
    }
  }

  public string GenerateWithAllParams(VietQRFullRequest request)
  {
    if (request == null) return "";

    var contents = new Dictionary<string, string>();

    // Payload Format Indicator (00)
    contents["00"] = request.PayloadFormatIndicator ?? "01";

    // Point of Initiation Method (01)
    contents["01"] = request.PointOfInitiationMethod ?? (request.OneTime ? "12" : "11");

    // Merchant Category Code (52)
    if (!string.IsNullOrEmpty(request.MerchantCategoryCode))
    {
      contents["52"] = request.MerchantCategoryCode;
    }

    // Transaction Currency (53)
    if (!string.IsNullOrEmpty(request.TransactionCurrency))
    {
      var currencyCode = CurrencyMap.GetValueOrDefault(request.TransactionCurrency, request.TransactionCurrency);
      contents["53"] = currencyCode;
    }
    else
    {
      contents["53"] = "704"; // Default VND
    }

    // Transaction Amount (54)
    if (request.TransactionAmount > 0)
    {
      contents["54"] = ((int)request.TransactionAmount).ToString();
    }

    // Country Code (58)
    contents["58"] = request.CountryCode ?? "VN";

    // Merchant Name (59)
    if (!string.IsNullOrEmpty(request.MerchantName))
    {
      contents["59"] = ToAscii(request.MerchantName);
    }

    // Merchant City (60)
    if (!string.IsNullOrEmpty(request.MerchantCity))
    {
      contents["60"] = ToAscii(request.MerchantCity);
    }

    // Purpose (62)
    if (!string.IsNullOrEmpty(request.Purpose))
    {
      contents["62"] = request.Purpose;
    }

    // Reference Label (63)
    if (!string.IsNullOrEmpty(request.ReferenceLabel))
    {
      contents["63"] = request.ReferenceLabel;
    }

    // Customer Label (64)
    if (!string.IsNullOrEmpty(request.CustomerLabel))
    {
      contents["64"] = request.CustomerLabel;
    }

    // Terminal Label (65)
    if (!string.IsNullOrEmpty(request.TerminalLabel))
    {
      contents["65"] = request.TerminalLabel;
    }

    // Additional Consumer Data Request (67)
    if (!string.IsNullOrEmpty(request.AdditionalConsumerDataRequest))
    {
      contents["67"] = request.AdditionalConsumerDataRequest;
    }

    // Merchant Account Information (38)
    if (!string.IsNullOrEmpty(request.BankBIN) && !string.IsNullOrEmpty(request.AccountNumber))
    {
      contents["3800"] = "A000000727";
      contents["380100"] = request.BankBIN;
      contents["380101"] = request.AccountNumber;

      if (!string.IsNullOrEmpty(request.ServiceType))
      {
        contents["3802"] = request.ServiceType;
      }
    }

    // Additional Data Field Template (62)
    if (!string.IsNullOrEmpty(request.Note))
    {
      contents["6208"] = ToAscii(request.Note.Trim());
    }

    // Custom Fields
    if (request.CustomFields != null)
    {
      foreach (var field in request.CustomFields)
      {
        if (!string.IsNullOrEmpty(field.Key) && !string.IsNullOrEmpty(field.Value))
        {
          contents[field.Key] = field.Value;
        }
      }
    }

    try
    {
      var output = GenerateObject(GetDefaults(), "", "", contents) + "6304";
      return output + CrcChecksum(output);
    }
    catch (Exception ex)
    {
      throw new Exception($"Error generating QR code: {ex.Message}", ex);
    }
  }

  private static string GenerateObject(ObjectDef[] defs, string prefixId, string id,
    Dictionary<string, string> contents)
  {
    if (defs == null || contents == null)
      return "";

    if (string.IsNullOrEmpty(id))
    {
      // Root level - process all defaults
      var content = "";
      foreach (var d in defs)
      {
        if (d != null && !string.IsNullOrEmpty(d.ID))
        {
          content += GenerateObject(defs, prefixId, d.ID, contents);
        }
      }

      return content;
    }

    var def = defs.FirstOrDefault(d => d?.ID == id);
    if (def == null) return "";

    // Compound object
    if (def.Sub != null && def.Sub.Length > 0)
    {
      var content = "";
      foreach (var sub in def.Sub)
      {
        if (sub != null && !string.IsNullOrEmpty(sub.ID))
        {
          content += GenerateObject(def.Sub, prefixId + id, sub.ID, contents);
        }
      }

      if (!string.IsNullOrEmpty(content))
      {
        return $"{def.ID}{content.Length:D2}{content}";
      }

      return "";
    }

    // Simple field
    var key = prefixId + id;
    if (!contents.ContainsKey(key) || string.IsNullOrEmpty(contents[key]))
      return "";

    var contentValue = ToAscii(contents[key]);
    if (string.IsNullOrEmpty(contentValue))
      return "";

    var length = contentValue.Length;
    if (def.MaxLen > 0 && length > def.MaxLen)
    {
      length = def.MaxLen;
    }

    if (length > 99)
    {
      length = 99;
    }

    contentValue = Substring(contentValue, length);
    return $"{id}{length:D2}{contentValue}";
  }

  private static ObjectDef[] GetDefaults()
  {
    return new[]
    {
      new ObjectDef { ID = "00" },
      new ObjectDef { ID = "01" },
      new ObjectDef { ID = "38", Sub = GetMerchantAccount() },
      new ObjectDef { ID = "53" },
      new ObjectDef { ID = "54", MaxLen = 13 },
      new ObjectDef { ID = "58" },
      new ObjectDef { ID = "62", Sub = GetAdditionalDataField() }
    };
  }

  private static ObjectDef[] GetMerchantAccount()
  {
    return new[]
    {
      new ObjectDef { ID = "00" },
      new ObjectDef { ID = "01", Sub = GetBeneficiaryOrg() },
      new ObjectDef { ID = "02" }
    };
  }

  private static ObjectDef[] GetBeneficiaryOrg()
  {
    return new[]
    {
      new ObjectDef { ID = "00" },
      new ObjectDef { ID = "01" }
    };
  }

  private static ObjectDef[] GetAdditionalDataField()
  {
    return new[]
    {
      new ObjectDef { ID = "08", MaxLen = 25 }
    };
  }

  private static string ToAscii(string text)
  {
    if (string.IsNullOrEmpty(text)) return "";

    var result = new StringBuilder();
    foreach (var c in text)
    {
      if (c <= 127) // ASCII
      {
        result.Append(c);
      }
      else if (VnMap.TryGetValue(c, out var replacement))
      {
        result.Append(replacement);
      }
      // Bỏ qua các ký tự không ASCII khác
    }

    return result.ToString();
  }

  private static string Substring(string s, int end)
  {
    if (string.IsNullOrEmpty(s)) return "";
    if (end >= s.Length) return s;
    return s[..end];
  }

  private static void InitCrcTable()
  {
    for (ushort n = 0; n < 256; n++)
    {
      ushort crc = (ushort)(n << 8);
      for (int i = 0; i < 8; i++)
      {
        bool bit = (crc & 0x8000) != 0;
        crc <<= 1;
        if (bit)
        {
          crc ^= CrcPoly;
        }
      }

      IsoIec13239Data[n] = crc;
    }
  }

  private static string CrcChecksum(string str)
  {
    var data = Encoding.UTF8.GetBytes(str);
    ushort crc = CrcInit;
    foreach (var d in data)
    {
      crc = (ushort)((crc << 8) ^ IsoIec13239Data[(byte)(crc >> 8) ^ d]);
    }

    return crc.ToString("X");
  }


  public class ObjectDef
  {
    public string ID { get; set; } = string.Empty;
    public int MaxLen { get; set; }
    public string Required { get; set; } = string.Empty;
    public ObjectDef[]? Sub { get; set; }

    public ObjectDef()
    {
      ID = string.Empty;
      Required = string.Empty;
    }
  }
}