namespace NapasPayment.Constants
{
  public static class NapasQrConstants
  {
    // EMVCo Field IDs
    public const string PAYLOAD_FORMAT_INDICATOR = "00";
    public const string POINT_OF_INITIATION_METHOD = "01";
    public const string MERCHANT_ACCOUNT_INFORMATION = "26";
    public const string MERCHANT_CATEGORY_CODE = "52";
    public const string TRANSACTION_CURRENCY = "53";
    public const string TRANSACTION_AMOUNT = "54";
    public const string COUNTRY_CODE = "58";
    public const string MERCHANT_NAME = "59";
    public const string MERCHANT_CITY = "60";
    public const string ADDITIONAL_DATA_FIELD_TEMPLATE = "62";
    public const string CRC = "63";

    // EMVCo Sub-field IDs for Merchant Account Information
    public const string BANK_CODE = "00";
    public const string ACCOUNT_NUMBER = "01";

    // EMVCo Sub-field IDs for Additional Data Field Template
    public const string PURPOSE = "01";
    public const string PURPOSE_ALT = "02";
    public const string REFERENCE_LABEL = "03";
    public const string CUSTOMER_LABEL = "04";
    public const string TERMINAL_LABEL = "05";
    public const string ADDITIONAL_CONSUMER_DATA_REQUEST = "06";

    // Default Values
    public const string DEFAULT_PAYLOAD_FORMAT = "01";
    public const string DEFAULT_POINT_OF_INITIATION = "11"; // 11: Dynamic QR for personal use
    public const string DEFAULT_MERCHANT_CATEGORY_CODE = "0000";
    public const string DEFAULT_TRANSACTION_CURRENCY = "704";
    public const string DEFAULT_COUNTRY_CODE = "VN";
    public const string DEFAULT_SERVICE_TYPE = "QRIBFTTA";

    // Point of Initiation Method Values
    public const string STATIC_QR = "12";
    public const string DYNAMIC_QR = "11";


    public static readonly IReadOnlyDictionary<string, string> CountryCodes =
      new Dictionary<string, string>
      {
        { "JP", "Japan" }, { "KR", "Korea" }, { "MY", "Malaysia" }, { "RC", "China" },
        { "RI", "Indonesia" }, { "RP", "Philippines" }, { "SG", "Singapore" },
        { "TH", "Thailand" }, { "VN", "Viet Nam" }
      };

    public static readonly IReadOnlyDictionary<string, string> CurrencyMap =
      new Dictionary<string, string>
      {
        { "JPY", "392" }, { "KRW", "410" }, { "MYR", "458" }, { "CNY", "156" },
        { "IDR", "360" }, { "PHP", "608" }, { "SGD", "702" }, { "THB", "764" }, { "VND", "704" }
      };

    public static readonly Dictionary<char, char> VnCharactersMap = new()
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
  }
}