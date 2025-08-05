# NAPAS QR Code Generator

> This project implements NAPAS QR code generation according to EMVCo standards for Vietnamese banks.

## Features

- Generate NAPAS QR codes following EMVCo standards
- Support for both static and dynamic QR codes
- Base64 image generation
- Raw QR data output

## More info

- Bank list: `https://api.vietqr.io/v2/banks`

## Testing data

```json
{
  "bankCode": "970423",
  "accountNumber": "033533176",
  "bankName": "Ngân hàng TMCP Tiên Phong",
  "accountName": "NGUYEN THI YEN NHI",
  "amount": 200000.12,
  "description": "Ngay moi vui ve"
}
```

---

```json

{
  "qrData": "0002020102122624000697042301100335331765204000053037045409200000.005802VN5918NGUYEN THI YEN NHI6025Ngân hàng TMCP Tiên Phong62190115Ngay moi vui ve6304E354",
  "size": 4,
  "format": "png",
  "errorCorrectionLevel": 3
}

```

---

```json


{
  "amount": 200000.12,
  "bankBIN": "970423",
  "accountNumber": "0316383176",
  "note": "Ngay moi vui ve",
  "oneTime": true,
  "serviceType": "QRIBFTTA"
}

```

---

```json

{
  "amount": 10000,
  "bankBIN": "970423",
  "accountNumber": "0921420107",
  "note": "Nếu mỗi người cho ta một nghìn là ta sẽ có ngay một tỷ đồng"
}
```

## Commands

```bash
dotnet --version

dotnet new webapi -n napas_poc

cd napas_poc

dotnet run

dotnet dev-certs https --trust
dotnet watch run

dotnet build

dotnet run --project . test.cs

dotnet run --no-build
```

## VietQR.IO verify output api

```bash

curl --location --request POST 'https://api.vietqr.io/v2/generate' \
--header 'Content-Type: application/json' \
--data-raw '{
    "accountNo": "9876543210",
    "accountName": "Testing Account",
    "acqId": "970436",
    "addInfo": "",
    "amount": "50000",
    "template": "compact"
}'
```