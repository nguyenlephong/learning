namespace napas_payment.Constants
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
        public const string DEFAULT_PAYLOAD_FORMAT = "02";
        public const string DEFAULT_POINT_OF_INITIATION = "11"; // 11: Dynamic QR for personal use
        public const string DEFAULT_MERCHANT_CATEGORY_CODE = "0000";
        public const string DEFAULT_TRANSACTION_CURRENCY = "704";
        public const string DEFAULT_COUNTRY_CODE = "VN";

        // Point of Initiation Method Values
        public const string STATIC_QR = "12";
        public const string DYNAMIC_QR = "11";
    }
} 