# NAPAS QR Code Generator

This project implements NAPAS QR code generation according to EMVCo standards for Vietnamese banks.

## Features

- Generate NAPAS QR codes following EMVCo standards
- Support for both static and dynamic QR codes
- Comprehensive validation and error handling
- Base64 image generation
- Raw QR data output

## EMVCo QR Code Format

The implementation follows the EMVCo QR Code specification with the following structure:

### Required Fields
- **Payload Format Indicator (00)**: Set to "02" for EMV QR Code
- **Merchant Account Information (26)**: Contains bank code and account number
- **Transaction Currency (53)**: Set to "704" for VND
- **Country Code (58)**: Set to "VN" for Vietnam

### Optional Fields
- **Point of Initiation Method (01)**: "12" for static QR
- **Merchant Category Code (52)**: Default "0000"
- **Transaction Amount (54)**: Payment amount
- **Merchant Name (59)**: Account holder name
- **Merchant City (60)**: Bank name
- **Additional Data Field Template (62)**: Description/purpose

## API Endpoints

### Generate NAPAS QR Code
```
POST /api/qr/napas
```

**Request Body:**
```json
{
  "bankCode": "970416",
  "accountNumber": "1234567890",
  "bankName": "Vietcombank",
  "accountName": "Nguyen Van A",
  "amount": 100000.50,
  "description": "Payment for services"
}
```

**Response:**
```json
{
  "rawData": "00020101021226580010...",
  "base64QrImage": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAA...",
  "isValid": true,
  "errorMessage": null
}
```

### Get QR Code Raw Data
```
POST /api/qr/napas/raw
```

Returns only the raw QR code data without generating the image.

## Validation Rules

- **BankCode**: Required, max 10 characters
- **AccountNumber**: Required, max 20 characters
- **BankName**: Optional, max 100 characters
- **AccountName**: Optional, max 100 characters
- **Amount**: Optional, must be >= 0
- **Description**: Optional, max 200 characters

## Common Vietnamese Bank Codes

| Bank | Code |
|------|------|
| Vietcombank | 970436 |
| BIDV | 970418 |
| Agribank | 970403 |
| Techcombank | 970407 |
| MB Bank | 970422 |
| ACB | 970416 |
| Sacombank | 970403 |
| VIB | 970441 |
| TPBank | 970423 |
| VPBank | 970432 |

## Running the Application

1. Navigate to the project directory:
```bash
cd napas_payment
```

2. Run the application:
```bash
dotnet run
```

3. The API will be available at:
   - Swagger UI: https://localhost:7001/swagger
   - API Base: https://localhost:7001

## Testing

Use the provided `napas_payment.http` file to test the API endpoints with various scenarios including:
- Valid requests with all fields
- Minimal required fields
- Static QR codes (without amount)
- Validation error cases

## Dependencies

- .NET 8.0
- QRCoder 1.6.0
- Microsoft.AspNetCore.OpenApi
- Swashbuckle.AspNetCore

## Error Handling

The API returns structured error responses with:
- HTTP status codes (400 for validation errors, 500 for server errors)
- Detailed error messages
- Validation results for each field

## Security Considerations

- Input validation prevents injection attacks
- Error messages don't expose sensitive information
- Amount validation prevents negative values
- String length limits prevent buffer overflow

## EMVCo Compliance

This implementation follows EMVCo QR Code specifications:
- Correct field IDs and lengths
- Proper CRC16-CCITT calculation
- Standard QR code error correction level (Q)
- Vietnamese currency and country codes 