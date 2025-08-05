using System.Text;
using System.Text.RegularExpressions;
using NapasPayment.Constants;

public interface IVietQRService
{
  string Generate(double amount, string bankBin, string accountNumber, string note);
  string Create(bool onetime, string serviceType, double amount, string bankBin, string accountNumber, string note);

  string GenerateWithParams(bool onetime, string serviceType, double amount, string bankBin,
    string accountNumber, string note, string currency, string countryCode);

  string GenerateWithAllParams(VietQRFullRequest request);
}

public class VietQRService : IVietQRService
{
  private static readonly IReadOnlyDictionary<char, char> VnMap = NapasQrConstants.VnCharactersMap;

  private static readonly IReadOnlyDictionary<string, string> CountryCodes = NapasQrConstants.CountryCodes;

  private static readonly IReadOnlyDictionary<string, string> CurrencyMap = NapasQrConstants.CurrencyMap;

  private static readonly ushort[] IsoIec13239Data = new ushort[256];
  private const ushort CrcInit = 0xFFFF;
  private const ushort CrcPoly = 0x1021;

  static VietQRService()
  {
    InitCrcTable();
  }

  public string Generate(double amount, string bankBin, string accountNumber, string note)
  {
    return GenerateWithParams(true, NapasQrConstants.DEFAULT_SERVICE_TYPE, amount, bankBin, accountNumber, note, NapasQrConstants.DEFAULT_TRANSACTION_CURRENCY, NapasQrConstants.DEFAULT_COUNTRY_CODE);
  }

  public string Create(bool onetime, string serviceType, double amount, string bankBin, string accountNumber,
    string note)
  {
    return GenerateWithParams(true, NapasQrConstants.DEFAULT_SERVICE_TYPE, amount, bankBin, accountNumber, note, NapasQrConstants.DEFAULT_TRANSACTION_CURRENCY, NapasQrConstants.DEFAULT_COUNTRY_CODE);
  }

  public string GenerateWithParams(bool onetime, string serviceType, double amount, string bankBin,
    string accountNumber, string note, string currency, string countryCode)
  {
    // Validate inputs
    if (string.IsNullOrEmpty(bankBin) || string.IsNullOrEmpty(accountNumber)) return "";
    if (double.IsNaN(amount) || amount < 0) return "";

    var contents = new Dictionary<string, string>
    {
      [NapasQrConstants.PAYLOAD_FORMAT_INDICATOR] = "01",
      [NapasQrConstants.POINT_OF_INITIATION_METHOD] = onetime ? NapasQrConstants.STATIC_QR : NapasQrConstants.DYNAMIC_QR,
      ["3800"] = "A000000727",
      ["380100"] = bankBin,
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
      contents[NapasQrConstants.TRANSACTION_CURRENCY] = currencyCode;
    }
    else
    {
      contents[NapasQrConstants.TRANSACTION_CURRENCY] = NapasQrConstants.DEFAULT_TRANSACTION_CURRENCY; // Default to VND
    }

    // Add country code
    if (!string.IsNullOrEmpty(countryCode) && CountryCodes.ContainsKey(countryCode))
    {
      contents[NapasQrConstants.COUNTRY_CODE] = countryCode;
    }
    else
    {
      contents[NapasQrConstants.COUNTRY_CODE] = "VN"; // Default to VN
    }

    // Add amount if greater than 0
    if (!double.IsNaN(amount) && amount >= 0)
    {
      contents[NapasQrConstants.TRANSACTION_AMOUNT] = ((int)amount).ToString();
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

    if (double.IsNaN(request.TransactionAmount) ||  request.TransactionAmount < 0) return "";

    var contents = new Dictionary<string, string>();

    // Payload Format Indicator (00)
    contents[NapasQrConstants.PAYLOAD_FORMAT_INDICATOR] = request.PayloadFormatIndicator ?? NapasQrConstants.DEFAULT_PAYLOAD_FORMAT;

    // Point of Initiation Method (01)
    contents[NapasQrConstants.POINT_OF_INITIATION_METHOD] = request.PointOfInitiationMethod ?? (request.OneTime ? NapasQrConstants.STATIC_QR : NapasQrConstants.DYNAMIC_QR);

    // Merchant Category Code (52)
    if (!string.IsNullOrEmpty(request.MerchantCategoryCode))
    {
      contents[NapasQrConstants.MERCHANT_CATEGORY_CODE] = request.MerchantCategoryCode;
    }

    // Transaction Currency (53)
    if (!string.IsNullOrEmpty(request.TransactionCurrency))
    {
      var currencyCode = CurrencyMap.GetValueOrDefault(request.TransactionCurrency, request.TransactionCurrency);
      contents[NapasQrConstants.TRANSACTION_CURRENCY] = currencyCode;
    }
    else
    {
      contents[NapasQrConstants.TRANSACTION_CURRENCY] = NapasQrConstants.DEFAULT_TRANSACTION_CURRENCY; // Default VND
    }

    // Transaction Amount (54)
    if (request.TransactionAmount >= 0)
    {
      contents[NapasQrConstants.TRANSACTION_AMOUNT] = ((int)request.TransactionAmount).ToString();
    }

    // Country Code (58)
    contents[NapasQrConstants.COUNTRY_CODE] = request.CountryCode ?? NapasQrConstants.DEFAULT_COUNTRY_CODE;

    // Merchant Name (59)
    if (!string.IsNullOrEmpty(request.MerchantName))
    {
      contents[NapasQrConstants.MERCHANT_NAME] = ToAscii(request.MerchantName);
    }

    // Merchant City (60)
    if (!string.IsNullOrEmpty(request.MerchantCity))
    {
      contents[NapasQrConstants.MERCHANT_CITY] = ToAscii(request.MerchantCity);
    }

    // Purpose (62)
    if (!string.IsNullOrEmpty(request.Purpose))
    {
      contents[NapasQrConstants.ADDITIONAL_DATA_FIELD_TEMPLATE] = request.Purpose;
    }

    // Reference Label (63)
    if (!string.IsNullOrEmpty(request.ReferenceLabel))
    {
      contents[NapasQrConstants.CRC] = request.ReferenceLabel;
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