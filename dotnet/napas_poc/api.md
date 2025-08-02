![N|Solid](/files/assets/files/api-landing18.svg)

## Signature

@des_signature3

## Sample API Oauth2

| STT | Field Name    | Content                          |
| --- | ------------- | -------------------------------- |
| 1   | client_id     | rkvnjv6gcy8bu9wdegrx8xr3         |
| 2   | client_secret | MBRpDEysZRffuPMWJKAvbC83svjNh2zX |
| 3   | grant_type    | password                         |
| 4   | password      | gW3Zk39v7c                       |
| 5   | username      | t43mz48s3jgyfccyfdqdsa46         |

> Signature input : rkvnjv6gcy8bu9wdegrx8xr3MBRpDEysZRffuPMWJKAvbC83svjNh2zXpasswordgW3Zk39v7ct43mz48s3jgyfccyfdqdsa46

## Oauth2 V2.0

```
POST: /api/core/v1/oauth/token
```

## @purpose2

@purpose_auth2

## Header Parameters

| Parameters    | Type              | Description            |
| ------------- | ----------------- | ---------------------- |
| Authorization | string `required` | @des_authorization_ach |

## Query Parameters

| Parameters    | Type              | Description        |
| ------------- | ----------------- | ------------------ |
| grant_type    | string `required` | @des_grant_type    |
| client_id     | string `required` | @des_client_id     |
| client_secret | string `required` | @des_client_secret |
| username      | string `required` | @des_username      |
| password      | string `required` | @des_password      |
| Signature     | string `required` | @des_signature     |

## Sample Request

```
curl --location --request POST 'https://@domain/api/core/v1/oauth/token'
--header 'Content-Type: application/json' --data-raw '{
"grant_type": "password",
"client_id": "PSP_9PAYTEST",
"client_secret": "Napas$01#2021!",
"username": "userPSP_9PAYTEST",
"password": "12345",
"Signature": "dQsI6ytwNrY45EngFzMkrJR82xZM0t_TW3DrvBg9bhsEQU4zTRvH7KkC24oEO45KSr39mwV09haMYFDuMu0_bh1-OIprlD3KxqRmx7ltjWuzNUsjh28Wi301sgngiuNSP_SRsixUMh9rjEvjWRG_byW_Pb0f5b0x1jxuc51TAnwkPP1Ft1JL1679lbGTZakPLroplPiwcagyx1_qgPWsAEXTErpAJXSJiMhW8e5B8EcIw95-qKhvrzKsHfVtgiCS06gdJoJoPr6Dujcf3uWiXYnbyM9OmbZS4WIAsP2q7pWCwc4-rRDrO7C1Ltqcycn1Yc643TvSre3JxyGwTx-4YA"
}'
```

## Example Response

```javascript
{
  "result": "SUCCESS",
  "access_token": "3cxfrnc8wjanxt6g3w972382",
  "token_type": "bearer",
  "refresh_token": "jgwnejv8cdn76a9uupcewnea",
  "expies_in": "300",
  "Signature": "AuB6Rtha2f4dLmqwdwkQedsOUbulfmke_cGQzlTIgymauGQUTWZSVdxhaDGik4KhGIfbVZklRfHoOvz0QLiF2rhU2SKNWzySDmQ9BJMwffe1Ib4livhNIIIXqZzP2TkUmkOAMqmGzFMn101f6v3_hyHrdo7ZRoUJM0-t7CdfQgeAKtPb0ED4s9iYPoxZ4MF9XshC4HPyMC1ervfl4h57QFbU32vToMMfEkK62rjU1qVCSAjKlgp_uIVoSDOLmyf6jAA0ke_XJj1FxuoAFvDKlW1OlmTcwDXsXN7J8bpDTdpXgEMsi5rggsYEeuqBu-JR6sSmQ6y-NfkAYp2A8y28cw"
}
```

## Note

@npcore_note
| STT | Field Name |
| ------ | ------ |  
| 1 | client_id |
| 2 | client_secret |
| 3 | grant_type |
| 4 | password |
| 5 | username |

## API Response Codes

#### 200 Success

@des_200

| Field         | Type              | Description       |
| ------------- | ----------------- | ----------------- |
| result        | string `required` | @des_result       |
| ErrCode       | string `optional` | @des_ErrCode      |
| ErrDesc       | string `optional` | @des_ErrDesc      |
| access_token  | Object `optional` | @des_access_token |
| token_type    | string `optional` | @des_token_type   |
| refresh_token | string `required` | @des_access_token |
| expires_in    | string `optional` | @des_expires_in   |
| scope         | string `required` | @des_scope        |
| Signature     | string `required` | @des_signature2   |

#### 400 Bad Request

@des_400

#### 401 Unauthorized

@des_401

#### 404 Not Found

@des_400

#### 500 Internal Server Error

@des_400

## Refresh Token

```
POST: /api/core/v1/oauth/refresh-token
```

## @purpose2

@purpose_refresh_token

## Header Parameters

| Parameters    | Type              | Description            |
| ------------- | ----------------- | ---------------------- |
| Authorization | string `required` | @des_authorization_ach |

## Query Parameters

| Parameters    | Type              | Description        |
| ------------- | ----------------- | ------------------ |
| grant_type    | string `required` | @des_grant_type    |
| client_id     | string `required` | @des_client_id     |
| client_secret | string `required` | @des_client_secret |
| refresh_token | string `required` | @des_refresh_token |
| Signature     | string `required` | @des_signature     |

## Sample Request

```
curl --location 'https://developer.napas.com.vn/api/core/v1/oauth/refresh-token' \
--header 'Content-Type: application/json' \
--data '{
  "Signature": "nEijR0IbdzoVPKMVpAI3fzqv41x16y1HgMlrDHrQHiw5s8yPoK7cjx6R6ltqNak8hWSPWxsc8yGQ69s8cjtWw7HR0wD/+xl6fEW91YaXjNYZwOIRYEkW2FSTL/r+EMr7QhJyYSly4vCyz3Z7sqtGTyRpYcRd1UCQEkJzPVDYhuuXEkakCPKrbft/fbpYKkuWUBTc/lR8EWF+tAOlUYV9zUDGwQAoH/BBMuzrBy7zZD5DYJL2j1b8cSHPptZsu6hux3KcdPxStP7BZ3NDZfc+i6pSX3bd7rB19xgBDPKFGu/Xc+ISKCtyNpbAvItZEK4MSSBtwjWh3l7KcMkOGkWmdQ==",
  "client_id": "VIETPAY",
  "client_secret": "X4F73C1102A0CE915BD97506211XA74B",
  "grant_type": "refresh_token",
  "refresh_token": "v3effdnffmnyw9z8xnv5h8ky"
}'
```

## Example Response

```javascript
{
  "result": "SUCCESS",
  "access_token": "3cxfrnc8wjanxt6g3w972382",
  "token_type": "bearer",
  "refresh_token": "jgwnejv8cdn76a9uupcewnea",
  "expies_in": "300",
  "Signature": "AuB6Rtha2f4dLmqwdwkQedsOUbulfmke_cGQzlTIgymauGQUTWZSVdxhaDGik4KhGIfbVZklRfHoOvz0QLiF2rhU2SKNWzySDmQ9BJMwffe1Ib4livhNIIIXqZzP2TkUmkOAMqmGzFMn101f6v3_hyHrdo7ZRoUJM0-t7CdfQgeAKtPb0ED4s9iYPoxZ4MF9XshC4HPyMC1ervfl4h57QFbU32vToMMfEkK62rjU1qVCSAjKlgp_uIVoSDOLmyf6jAA0ke_XJj1FxuoAFvDKlW1OlmTcwDXsXN7J8bpDTdpXgEMsi5rggsYEeuqBu-JR6sSmQ6y-NfkAYp2A8y28cw"
}
```

## Note

@npcore_note
| STT | Field Name |
| ------ | ------ |  
| 1 | client_id |
| 2 | client_secret |
| 3 | grant_type |
| 4 | refresh_token |

## API Response Codes

#### 200 Success

@des_200

| Field         | Type              | Description        |
| ------------- | ----------------- | ------------------ |
| result        | string `required` | "SUCCESS"          |
| access_token  | Object `optional` | @des_access_token  |
| token_type    | string `optional` | @des_token_type    |
| refresh_token | string `required` | @des_refresh_token |
| expires_in    | string `optional` | @des_expires_in    |
| Signature     | string `required` | @des_signature2    |

#### 400 Bad Request

| Field      | Description                          |
| ---------- | ------------------------------------ |
| statusCode | 400                                  |
| message    | ${Filed Name} exceeds the max length |
| ------     | ${Filed Name} wrong formats          |
| ------     | ${Filed Name}is null                 |
| ------     | Signature could not be verified      |
| ------     | Request API Over Quota Limit         |
| ------     | Invalid JSON Request                 |

#### 500 Internal Server Error

| Field      | Description           |
| ---------- | --------------------- |
| statusCode | 500                   |
| message    | Internal server error |

## API GetTransaction

```
POST: /api/core/v1/transaction
```

## @purpose2

@purpose_g_t

## Path Parameters

| Parameters    | Type              | Description        |
| ------------- | ----------------- | ------------------ |
| merchantId    | string `required` | @des_merchantId    |
| orderid       | string `required` | @des_orderid       |
| transactionid | string `required` | @des_transactionid |

## Header Parameters

| Parameters    | Type              | Description            |
| ------------- | ----------------- | ---------------------- |
| Authorization | string `required` | @des_authorization_ach |

## Query Parameters

| Parameters       | Type              | Description           |
| ---------------- | ----------------- | --------------------- |
| TranxCode        | string `optional` | @des_TranxCode        |
| ServiceCode      | string `required` | @des_serviceCode2     |
| PartnerTranxCode | string `required` | @des_PartnerTranxCode |
| CardScheme       | string `required` | @des_CardScheme       |
| GatewayOrderId   | string `required` | @des_GatewayOrderId   |
| Signature        | string `required` | @des_signature3       |

## Sample Request

```
curl --location --request POST 'https://@domain/api/core/v1/transaction' --header 'Content-Type: application/json'
--data-raw '{
  "TranxInfo": {
  "ServiceCode": "ECOM",
  "CardScheme": "AtmCard",
  "Signature": "GdOrfFnmTdaZEalBl0MaLRehnVP3qnbZowlDkuqAc7Dv8jAhrmK-zglF61kP_xmF-IdNZ-KSkilLlE_-9xQk7PqDPWjekgw4vaN_jRwyKIjPrurOaIA5aiyfRe-HSV4GwyWGAz_Es7U3Kn9CsKk5yGrY5P_q7jUOCZv6QJwjwFG7s-7x_Prx7wyi0Po8Sj2N5yCK8F3jOQ_WlgxDAQhyJ99V4wPgHnkIpXsO1NFgzNxOKpxhr4DXXcn_CGvY6O5qmm8GX47nnQstKkgIxYQnja7Lt3s6953T6Ac4BaP2MMxgB7UViUbgYi3_Gr1XJa7r0pnBmvpaeEQrycllSfjsmQ",
  "TranxCode": "835599909",
  "PartnerTranxCode": "",
  "GatewayOrderId": ""
  }
}'
```

## Example Response

```javascript
{
  "ResponseInf": {
    "Status": "SUCCESS"
  },
  "DomTransaction": {
    "TransactionID": "835599909",
    "AcquirerCode": "STB",
    "CardNumber": "rReq1h3zqmUN7JUh4mZHze8kH+KtXZJR5SZJlgR/VxsnMiFwHR7MLu5qbNRcq8EuEmIJxiEDTiJOaGmw",
    "Amount": "2100000",
    "IssuerCode": "SML",
    "CardName": "x0c0zsG7JiAf55YKiToq8DVP13nrMu+HN6yLCUfDXPmcYV6oxIt027CI/TacrzJ1eAcn2I25WVw=",
    "SettleAmount": "2100000",
    "ExpDate": "gylumvHtgsgnNhg8VfbisC7L47r0XhSfrbf2JBQYIYHW9i/sYwaH3kiYPW/Nr5zH5DYQ",
    "Currency": "VND",
    "TransactionRef": 7980173,
    "ResponseCode": "0",
    "MerchantCode": "BEGROUP_M_STG",
    "TransactionInfo": "Thanh toan hoa don",
    "IP": "27.71.207.170",
    "ServiceType": "ECOM"
  },
  "IntTransaction": {
    "CreatedDate": "",
    "UpdateDate": ""
  },
  "Timestamp": "07/01/2022 11:26:50",
  "Signature": "PAwT0uQJKDhhwFL77VHLgrrTxAgqBTGGCktuoEzWWfbZsKfpS0QtS-j-UKLUkbbDajVTBYye3rMi0iq8ERHI0yjOKgXp2qnT_wUJxp2PL-bpinAUh4ma7LJ8vZl1qYpislsBVM05CK07P6ejsjQS4PrbEomitHtp2-LpryxCza5UtgoY66dESdzZaaJ7Tu75Re__S4TxR2JXRQXkzRSmDtY2clRU5kythicg_DGSo0Qnp_IZLvY3qiTrZrPOxkcjD2q0mv9laJ9kZcxhMLLYe0k-Ipp6hr9HD7SIXlds8zC-MDLmFS-nCOhPli-RS2WR_CSewDi-2BT08YLeIj20Bw"
}
```

## Note

@npcore_note
| STT | Field Name |
| ------ | ------ |  
| 1 | CardScheme |
| 2 | GatewayOrderId |
| 3 | PartnerTranxCode |
| 4 | ServiceCode |
| 5 | TranxCode |

## API Response Codes

#### 200 Success

@des_200

| Parameters                       | Type              | Description                           |
| -------------------------------- | ----------------- | ------------------------------------- |
| ResponseInfo.Status              | string `required` | @des_result                           |
| ResponseInfo.ErrCode             | string `optional` | @des_ErrCode                          |
| ResponseInfo.ErrDesc             | string `optional` | @des_ErrDesc                          |
| DomTransaction                   | Object `optional` | @des_DomTransaction                   |
| DomTransaction.TransactionID     | string `optional` | @des_DomTransaction_TransactionID     |
| DomTransaction.AcquirerCode      | string `required` | @des_DomTransaction_AcquirerCode      |
| DomTransaction.CardNumber        | string `optional` | @des_DomTransaction_CardNumber        |
| DomTransaction.Amount            | string `optional` | @des_DomTransaction_Amount            |
| DomTransaction.IssuerCode        | string `optional` | @des_DomTransaction_IssuerCode        |
| DomTransaction.CardName          | string `optional` | @des_DomTransaction_CardName          |
| DomTransaction.SettleAmount      | string `optional` | @des_DomTransaction_SettleAmount      |
| DomTransaction.BankID            | string `optional` | @des_DomTransaction_BankID            |
| DomTransaction.ExpDate           | string `optional` | @des_DomTransaction_ExpDate           |
| DomTransaction.Currency          | string `optional` | @des_DomTransaction_Currency          |
| DomTransaction.TransactionRef    | string `optional` | @des_DomTransaction_TransactionRef    |
| DomTransaction.ResponseCode      | string `optional` | @des_DomTransaction_ResponseCode      |
| DomTransaction.MerchantCode      | string `optional` | @des_DomTransaction_MerchantCode      |
| DomTransaction.TransactionInfo   | string `optional` | @des_DomTransaction_TransactionInfo   |
| DomTransaction.IP                | string `optional` | @des_DomTransaction_IP                |
| DomTransaction.ServiceType       | string `optional` | @des_DomTransaction_ServiceType       |
| DomTransaction.CardFundMethod    | string `optional` | @des_DomTransaction_CardFundMethod    |
| IntTransaction                   | Object `optional` | @des_IntTransaction                   |
| IntTransaction.MerchantId        | string `optional` | @des_IntTransaction_MerchantId        |
| IntTransaction.AcquirerId        | string `optional` | @des_IntTransaction_AcquirerId        |
| IntTransaction.TransactionId     | string `optional` | @des_IntTransaction_TransactionId     |
| IntTransaction.OrdId             | string `optional` | @des_IntTransaction_OrdId             |
| IntTransaction.GroupId           | string `optional` | @des_IntTransaction_GroupId           |
| IntTransaction.GatewayTranxId    | string `optional` | @des_IntTransaction_GatewayTranxId    |
| IntTransaction.GatewayOrdId      | string `optional` | @des_IntTransaction_GatewayOrdId      |
| IntTransaction.CreatedDate       | Date `optional`   | @des_IntTransaction_CreatedDate       |
| IntTransaction.UpdateDate        | Date `optional`   | @des_IntTransaction_UpdateDate        |
| IntTransaction.TransactionType   | string `optional` | @des_IntTransaction_TransactionType   |
| IntTransaction.PaymentType       | string `optional` | @des_IntTransaction_PaymentType       |
| IntTransaction.ServiceCode       | string `optional` | @des_IntTransaction_ServiceCode       |
| IntTransaction.Amount            | Number `optional` | @des_IntTransaction_Amount            |
| IntTransaction.RefundAmount      | Number `optional` | @des_IntTransaction_RefundAmount      |
| IntTransaction.Currency          | string `optional` | @des_DomTransaction_Currency          |
| IntTransaction.OrderRef          | string `optional` | @des_IntTransaction_OrderRef          |
| IntTransaction.BatchNumber       | string `optional` | @des_IntTransaction_BatchNumber       |
| IntTransaction.AuthorizationCode | string `optional` | @des_IntTransaction_AuthorizationCode |
| IntTransaction.IP                | string `optional` | @des_IntTransaction_IP                |
| IntTransaction.Result            | string `optional` | @des_IntTransaction_Result            |
| IntTransaction.GatewayCode       | string `optional` | @des_IntTransaction_GatewayCode       |
| IntTransaction.ResponseCode      | string `optional` | @des_IntTransaction_ResponseCode      |
| IntTransaction.ResponseDesc      | string `optional` | @des_IntTransaction_ResponseDesc      |
| IntTransaction.CardFundMethod    | string `optional` | @des_DomTransaction_CardFundMethod    |
| IntTransaction.CardNumber        | string `optional` | @des_IntTransaction_CardNumber        |
| IntTransaction.CardBrand         | string `optional` | @des_IntTransaction_CardBrand         |
| IntTransaction.ExpDate           | string `optional` | @des_DomTransaction_ExpDate           |
| IntTransaction.CSC               | string `optional` | @des_IntTransaction_CSC               |
| IntTransaction.CSCResp           | string `optional` | @des_IntTransaction_CSCResp           |
| IntTransaction.Token             | string `optional` | @des_IntTransaction_Token             |
| IntTransaction.TokenExp          | string `optional` | @des_IntTransaction_TokenExp          |
| IntTransaction.AuthStatus        | string `optional` | @des_IntTransaction_AuthStatus        |
| IntTransaction.EnrollStatus      | string `optional` | @des_IntTransaction_EnrollStatus      |
| IntTransaction.XID               | string `optional` | @des_IntTransaction_XID               |
| IntTransaction.ECI               | string `optional` | @des_IntTransaction_ECI               |
| Timestamp                        | Date `required`   | @des_timestamp                        |
| Signature                        | string `required` | @des_signature2                       |

#### 400 Bad Request

@des_400

#### 401 Unauthorized

@des_401

#### 404 Not Found

@des_400

#### 500 Internal Server Error

@des_400

## API GetTransactions

```
POST: /api/core/v1/transactions
```

## @purpose2

@purpose_g_t_s

## Header Parameters

| Parameters    | Type              | Description        |
| ------------- | ----------------- | ------------------ |
| Authorization | string `required` | @des_authorization |

## Query Parameters

| Parameters        | Type              | Description            |
| ----------------- | ----------------- | ---------------------- |
| FromDate          | string `required` | @des_FromDate          |
| ToDate            | string `required` | @des_ToDate            |
| TransactionStatus | string `optional` | @des_TransactionStatus |
| CardScheme        | string `required` | @des_CardScheme        |
| MerchantCode      | string `optional` | @des_MerchantCode      |
| IssuerCode        | string `optional` | @des_IssuerCode        |
| AccquireCode      | string `optional` | @des_AccquireCode      |
| OrderId           | string `optional` | @des_orderId2          |
| OrderRef          | string `optional` | @des_orderRef          |
| PSPCode           | string `optional` | @des_PSPCode           |
| Signature         | string `required` | @des_signature3        |

## Sample Request

```
curl --location --request POST 'https://@domain/api/core/v1/transactions' --header 'Content-Type: application/json'
--data-raw '{
  "QueryInfo": {
    "FromDate": "14/12/2020 00:00:59",
    "ToDate": "16/12/2020 01:00:00",
    "TransactionStatus": "SUCCESS",
    "CardScheme": "AtmCard",
    "MerchantCode": "",
    "IssuerCode": "",
    "AccquireCode": "ACQ_VCB",
    "OrderId": "835560515",
    "OrderRef": "ORDER-2000010530",
    "PSPCode": "MOCA",
    "Signature": "AvJm1fRrsfeX3yZDnhZbrv5CPdU9TVUO7sSgEbglCh4_YhAh5kAn36mdauYucutqzp43DKbys2kaIbmx6cBsrGLr7gClOs1ecAgBbOQ7Sr6Kks2rTC5TUbGc0-QsHsiCPW9PnHr_ESUriv66y4b74ExIA7EWBKxx81XxG83RycPS97peiS0tUZeba0Gs4bU7SBjDSAoLzYu9e4fRgSJmMFnzK8BKIpd_hb1G2STPYoPyUMq1jj2sYS5XOv63X-qwSR1ljX83PYEKt8fY9oB2N7P34bMwd9y6h5yH_MyoT0UuIq_GTCY2rxhivS7D8-D-mhB-zHt9er4yphjSguJtcA"
    }
}'
```

## Example Response

```javascript
{
  "ResponseInf": {
    "Status": "SUCCESS"
  },
  "IntTranxList": [
    {
      "MerchantId": "9PAYWL"
    }, {
      "MerchantId": "9PAYWL",
      "CardNumber": "KYtDwD1Tu4b2AqrXxoliFbnkFdAgvxl2JIxkVUuyUVHHCbQ23dLvIdDZypEmxk25/BwkJkNqMahYME6V",
    }, {
      "MerchantId": "9PAYWL",
      "Token": "9704000177960018"
    }
  ],
  "Timestamp": "08/01/2022 14:35:51",
  "Signature": "G6sB0wyBJi_LdHXvmaW4DjSODI3unfyqTX38DD_SrkbANkPwZpwvq-iqw4t0hMFbwF4khziyR_jixoMIPj1ss8X5mTML1PES8nOaugzMVYVSTx1RPVUyTnc4iuMOdHNPZErieXWNHUv-LV3Xz8-AT44iylfsxPJkSzdJ7tujwgOUIWi21jurM4WUvxRaF97qnbtONFwbrCqWB6B2DVv86-2ML5lpPHlvdYYwrIMGwrV1s2dQkofPmEfgusWI1Xus3kQ0hagJWNxGwAI5BdU7D-leP8muly1H6isddozBZp5qlMk8OVnZ-Wg5W4zjdtut_kWcgRkGGp78vecFLcrgSw"
}
```

## Note

@npcore_note
| STT | Field Name |
| ------ | ------ |  
| 1 | AccquireCode |
| 2 | CardScheme |
| 3 | FromDate |
| 3 | IssuerCode |
| 4 | MerchantCode |
| 5 | OrderId |
| 6 | OrderRef |
| 7 | PSPCode |
| 8 | ToDate |
| 9 | TransactionStatus |

## API Response Codes

#### 200 Success

@des_200

| Field                          | Type              | Description                           |
| ------------------------------ | ----------------- | ------------------------------------- |
| ResponseInfo.Status            | string `required` | @des_result                           |
| ResponseInfo.ErrCode           | string `optional` | @des_ErrCode                          |
| ResponseInfo.ErrDesc           | string `optional` | @des_ErrDesc                          |
| DomTranxList.CardNumber        | string `optional` | @des_DomTransaction_CardNumber        |
| DomTranxList.Amount            | string `optional` | @des_DomTransaction_Amount            |
| DomTranxList.IssuerCode        | string `optional` | @des_DomTransaction_IssuerCode        |
| DomTranxList.CardName          | string `optional` | @des_DomTransaction_CardName          |
| DomTranxList.SettleAmount      | string `optional` | @des_DomTransaction_SettleAmount      |
| DomTranxList.BankID            | string `optional` | @des_DomTransaction_BankID            |
| DomTranxList.ExpDate           | string `optional` | @des_DomTransaction_ExpDate           |
| DomTranxList.Currency          | string `optional` | @des_DomTransaction_Currency          |
| DomTranxList.TransactionRef    | string `optional` | @des_DomTransaction_TransactionRef    |
| DomTranxList.ResponseCode      | string `optional` | @des_DomTransaction_ResponseCode      |
| DomTranxList.MerchantCode      | string `optional` | @des_DomTransaction_MerchantCode      |
| DomTranxList.TransactionInfo   | string `optional` | @des_DomTransaction_TransactionInfo   |
| DomTranxList.IP                | string `optional` | @des_DomTransaction_IP                |
| DomTranxList.ServiceType       | string `optional` | @des_DomTransaction_ServiceType       |
| DomTranxList.CardFundMethod    | string `optional` | @des_DomTransaction_CardFundMethod    |
| IntTranxList                   | Object `optional` | @des_IntTransaction                   |
| IntTranxList.MerchantId        | string `optional` | @des_IntTransaction_MerchantId        |
| IntTranxList.AcquirerId        | string `optional` | @des_IntTransaction_AcquirerId        |
| IntTranxList.TransactionId     | string `optional` | @des_IntTransaction_TransactionId     |
| IntTranxList.OrdId             | string `optional` | @des_IntTransaction_OrdId             |
| IntTranxList.GroupId           | string `optional` | @des_IntTransaction_GroupId           |
| IntTranxList.GatewayTranxId    | string `optional` | @des_IntTransaction_GatewayTranxId    |
| IntTranxList.GatewayOrdId      | string `optional` | @des_IntTransaction_GatewayOrdId      |
| IntTranxList.CreatedDate       | Date `optional`   | @des_IntTransaction_CreatedDate       |
| IntTranxList.UpdateDate        | Date `optional`   | @des_IntTransaction_UpdateDate        |
| IntTranxList.TransactionType   | string `optional` | @des_IntTransaction_TransactionType   |
| IntTranxList.PaymentType       | string `optional` | @des_IntTransaction_PaymentType       |
| IntTranxList.ServiceCode       | string `optional` | @des_IntTransaction_ServiceCode       |
| IntTranxList.Amount            | Number `optional` | @des_IntTransaction_Amount            |
| IntTranxList.RefundAmount      | Number `optional` | @des_IntTransaction_RefundAmount      |
| IntTranxList.Currency          | string `optional` | @des_DomTransaction_Currency          |
| IntTranxList.OrderRef          | string `optional` | @des_IntTransaction_OrderRef          |
| IntTranxList.BatchNumber       | string `optional` | @des_IntTransaction_BatchNumber       |
| IntTranxList.AuthorizationCode | string `optional` | @des_IntTransaction_AuthorizationCode |
| IntTranxList.IP                | string `optional` | @des_IntTransaction_IP                |
| IntTranxList.Result            | string `optional` | @des_IntTransaction_Result            |
| IntTranxList.GatewayCode       | string `optional` | @des_IntTransaction_GatewayCode       |
| IntTranxList.ResponseCode      | string `optional` | @des_IntTransaction_ResponseCode      |
| IntTranxList.ResponseDesc      | string `optional` | @des_IntTransaction_ResponseDesc      |
| IntTranxList.CardFundMethod    | string `optional` | @des_DomTransaction_CardFundMethod    |
| IntTranxList.CardNumber        | string `optional` | @des_IntTransaction_CardNumber        |
| IntTranxList.CardBrand         | string `optional` | @des_IntTransaction_CardBrand         |
| IntTranxList.ExpDate           | string `optional` | @des_DomTransaction_ExpDate           |
| IntTranxList.CSC               | string `optional` | @des_IntTransaction_CSC               |
| IntTranxList.CSCResp           | string `optional` | @des_IntTransaction_CSCResp           |
| IntTranxList.Token             | string `optional` | @des_IntTransaction_Token             |
| IntTranxList.TokenExp          | string `optional` | @des_IntTransaction_TokenExp          |
| IntTranxList.AuthStatus        | string `optional` | @des_IntTransaction_AuthStatus        |
| IntTranxList.EnrollStatus      | string `optional` | @des_IntTransaction_EnrollStatus      |
| IntTranxList.XID               | string `optional` | @des_IntTransaction_XID               |
| IntTranxList.ECI               | string `optional` | @des_IntTransaction_ECI               |
| Timestamp                      | Date `required`   | @des_timestamp                        |
| Signature                      | string `required` | @des_signature2                       |

#### 400 Bad Request

@des_400

#### 401 Unauthorized

@des_401

#### 404 Not Found

@des_400

#### 500 Internal Server Error

@des_400

## API ListFiles

```
POST: /api/core/v1/files
```

## @purpose2

@purpose_l_f

## Header Parameters

| Parameters    | Type              | Description        |
| ------------- | ----------------- | ------------------ |
| Authorization | string `required` | @des_authorization |

## Query Parameters

| Parameters  | Type              | Description                         |
| ----------- | ----------------- | ----------------------------------- |
| ServiceCode | string `required` | Mã dịch vụ. Mặc định là ECOM        |
| CreatedDate | string `required` | Ngày tạo file, định dạng DD/MM/YYYY |
| Signature   | string `required` | @des_signature3                     |

## Sample Request

```
curl --location --request POST 'https://@domain/api/core/v1/files' --header 'Content-Type: application/json'
--data-raw '{
  "InputInfo": {
  "ServiceCode": "ECOM",
  "Signature": "D4zHVsP1V9hMnKrwmlnx0iKH46rcFnaWThEFwIjsipFKWYpNzmeC8ykgPmPFdCCdXyDV3XC0isazN4b3xJFcjZ5_Qi2y1YEGnaVgb400Ejcrw9aeY5a1jEchdRkeEYLdi4NqMTue3VI5gdPS0m5X3KbodBo6iyXjGeXtP7Rbq6syI3-V4UEsLogyuUvqey1L4nbulnMsW85MDra_pEn7p55gQ06RbChMDWhpt-tOks7pxfaHImYdhiZLap4QRG-kCWZgsGRAwIaC1g4wtSegeasozeD7KmeLXSeccgpBwkQWHgkMjkQP15exEEun414F2o4a31hvQXoydUiIaGbTvQ",
  "CreatedDate": "17/12/2021"
  }
}'
```

## Example Response

```javascript
{
  "ResponseInf": {
    "Status": "SUCCESS"
  },
  "FileNames": {
    "FileName": [
      ""
    ]
  },
  "Timestamp": "07/01/2022 10:05:10",
  "Signature": "FcotlYePRGhrmGl7TI7mWd7VSHOMKzqkjEcCF7uNhBRJW8kjA86eYLZb-iv6pZzu9oFV0EpEZGGyEaVk6l_ViNBWpRyfnLNXfHKr1cqJcK6emQnBT5auwUN1DbDZk0gVjV_GQ6d08_2dCwpKrRhFCbRZ-FipkKxhScbQfp6ImhV0Xyz-GaUR20If6JswE0lIlxhh71aBBAUKSQSoorkpPRaOvwpR-KBYBItLZlGiW51EkLP-LPd5X600yJxKbhUxjV2PoE4g5Tj8EuJQ2AJMWevmUaUXlOPfUYeBC6Gdus5Uikn7Ac1H131z_GaDq0l1KVKatmynYo_rkI3mqw48fA"
}
```

## Note

@npcore_note
| STT | Field Name |
| ------ | ------ |  
| 1 | CreatedDate |
| 2 | ServiceCode |

## API Response Codes

#### 200 Success

@des_200

| Field                | Type              | Description             |
| -------------------- | ----------------- | ----------------------- |
| ResponseInfo.Status  | string `required` | @des_result             |
| ResponseInfo.ErrCode | string `optional` | @des_ErrCode            |
| ResponseInfo.ErrDesc | string `optional` | @des_ErrDesc            |
| FileNames            | Object `optional` | @des_FileNames          |
| FileNames.FileName   | string `optional` | @des_FileNames_FileName |
| Timestamp            | Date `required`   | @des_timestamp          |
| Signature            | string `required` | @des_signature2         |

#### 400 Bad Request

@des_400

#### 401 Unauthorized

@des_401

#### 404 Not Found

@des_400

#### 500 Internal Server Error

@des_400

## API GetFile

```
POST: /api/core/v1/file
```

## @purpose2

@purpose_g_f

## Header Parameters

| Parameters    | Type              | Description        |
| ------------- | ----------------- | ------------------ |
| Authorization | string `required` | @des_authorization |

## Query Parameters

| Parameters | Type              | Description             |
| ---------- | ----------------- | ----------------------- |
| FileName   | string `required` | @des_FileNames_FileName |
| Signature  | string `required` | @des_signature3         |

## Sample Request

```
curl --location --request POST 'https://@domain/api/core/v1/file'
--header 'Content-Type: application/json'
--data-raw ' {
  "FileName": "512MB.zip",
  "Signature": "OqBuljg0iMDMSTgJhvyUTIVRWKtLnZ3jw6CWMleAE7ADQ9iWars9-eBH-GfehfDIGHdXzcnIX7IWNhU8qiXylAnyZyjatZIIxEKb_cQlN8OGGj4XjsCyUrP1PfRSnSQeTi1SgtWg69J1Ydp7QZZuGhjEb1DQDEzK3d_1YwDHHgRNvyJm8AfF1iCqFpMTRGd-Mg0LgwiErmQWs0mXCPjZLh6Lg71cmAOhYWzdIidz6SPk2R9MHvm1NLcLcl2Vdd-3T_ZHeNBv04UzDJlX8DzhaPPuspH5VjutWgXsCK3ekIN5vRRzq5eAMaY8ahpTs_VKEOUVkXm56roAq0QkeMFUag"
} '
```

## Example Response

```javascript
{
  "ResponseInf": {
    "Status": "SUCCESS"
  },
  "FileName": "10MB.zip.zip",
  "FileContent": ""nội dung base 64 của file (do nội dung file dài nên không thể copy được vào đây)"",
  "Timestamp": "07/01/2022 10:29:11",
  "Signature": "Y7mbwNt2K28daEcyYUxha7RFNvIgJ3ivlL3LUB6Eh7S2pVpcKPopF4besHMGgQdDbsh_OgbmII8YBl2pMf6N3azvMb_xY0rYYrjF_hJr21Re9bbLH1n6QmtV1dgkkLTVgfdLR8-L8rniFrdKqEZLC1m_hFJ9iFbGK-DjAglHqc4LMs5zG3sm7_AzlAixqDxqi106PcKDRMNkhLV9EoVUPdHhRLbBMvSH5h_IgpgmT377SjauA54Ls6xRJcgAMoC76m09wk7L8ALqbRhIjRxzHHqSAu9stZ0Jj8BBz2Bbiz2T9NzWwt9FOfiQqdlO7ShTw6snzX2_cJM_nye_Fxsy-Q"
}
```

## Note

@npcore_note
| STT | Field Name |
| ------ | ------ |  
| 1 | FileName |

## API Response Codes

#### 200 Success

@des_200

| Field                | Type              | Description             |
| -------------------- | ----------------- | ----------------------- |
| ResponseInfo.Status  | string `required` | @des_result             |
| ResponseInfo.ErrCode | string `optional` | @des_ErrCode            |
| ResponseInfo.ErrDesc | string `optional` | @des_ErrDesc            |
| FileName             | Object `optional` | @des_FileNames_FileName |
| FileContent          | string `optional` | @des_FileContent        |
| Timestamp            | Date `required`   | @des_timestamp          |
| Signature            | string `required` | @des_signature4         |

#### 400 Bad Request

@des_400

#### 401 Unauthorized

@des_401

#### 404 Not Found

@des_400

#### 500 Internal Server Error

@des_400

## API GetMerchant

```
POST: /api/core/v1/merchant
```

## @purpose2

@purpose_g_m

## Header Parameters

| Parameters    | Type              | Description        |
| ------------- | ----------------- | ------------------ |
| Authorization | string `required` | @des_authorization |

## Query Parameters

| Parameters   | Type              | Description        |
| ------------ | ----------------- | ------------------ |
| MerchantCode | string `required` | @des_MerchantCode2 |
| Signature    | string `required` | @des_signature3    |

## Sample Request

```
curl --location --request POST 'https://@domain/api/core/v1/merchant'
--header 'Content-Type: application/json'
--data-raw '{
  "MerchantCode": "merchantTest",
  "Signature": "O-gl4k4sfTwqRwE1ehz3nyR1h_v9J6OJixxDsNkEf-sJOzdye8zghYKzCMOKzRAEP8gsFEV2NX5FmUVbzSzLACECUxj5hdxsbWKZZhMWmxLg8hVaYfS3YphPdQQF8_bwaRpbb4os3eGaiD9sdgSrvDllLnbHFLbCRC5YDOFiqpvxqHpgLpFcbH69viQpWKamYw7Y9MBEUPjTkH0rHjxno0NbL0fIGEft4w_CY5BvKiHJDNaQlT00Pmri4eogf-Bjybu6nYuOecvdqnW9hD5gnefKkDo4-y6RQKoBPIdsss8u9XSjCiTVgG43IbPQt8ixcFWvRrbKI_QscVHCYKHsDg"
}'
```

## Example Response

```javascript
{
  "ResponseInf": {
    "Status": "SUCCESS"
  },
  "BasicInfo": {
    "MerchantName": "TEST TCTT WL",
    "IntAcquirer": "ACQ_STB"
  },
  "ServiceDetails": {
    "DomVersion": "ECOM3.0",
    "MerchantUsername": "TCTTWL",
    "PPT": "DMS",
    "DomCardToken": "MANY",
    "IntCardToken": "MANY"
  },
  "Domestic": {
    "ModelDom": "SERVER_HOSTED",
    "MerchantCode": "0002",
    "LocalAcqId": "06800000686",
    "EcomTranxType": "PURCHASE, REFUND, VERIFY_CARD, VERIFY_OTP",
    "TokeTranxType": "DELETE_TOKEN, PURCHASE, RETRIEVE, TOKEN, VERIFY_CARD, VERIFY_OTP",
    "Currency": "VND",
    "PostPay": "NONE"
  },
  "EcomIssuer": {
    "IssuerCode": "CTG",
    "AccountInfo": "6868"
  },
  "International": {
    "DeloyInt": "ALL",
    "MerchantCode": "4784",
    "MpgsId": "TESTTCTTWL",
    "TransactionType": "AUTHORIZE, CAPTURE, CHECK_3DS_ENROLLMENT, DELETE_TOKEN, PAY, PROCESS_ACS_RESULT, REFUND, RETRIEVE, TOKEN, VOID",
    "AuthService": "AUTOPAY, ONE-TIME",
    "AuthTransaction": "PayCard, PayCreate, PaySave, PayToken",
    "MpgsMso": ",,,,,,,"
  },
  "Timestamp": "07/01/2022 17:16:10",
  "Signature": "h-05GuwBXny5V9B4mGr98i-j6dCZkzHShV8jDGNDwtMLq2HtUpttMyeLHXWrBhS6mC2cfjpLXDOqbH53Ts7vtKvmQwyS7bb5z2BsUu9RsQ2yNPZfVqpLjqIfGJr44PLSQNmwpdfBIEJinv0CdEracPcZR7D80nk6yR7Mq-XgH6KGS-7VrNOZCthfSaAuF1ivk9Q7TdEAxPjEfF-TgBz5iiC8cfMEYBXABB1EYX4-2Wiy2skp4fd1c0RZqROIUxEDGNvYnuuGnTDkTdmWeuZvIlmReq5xDJFGvI-cIa-iDUR6HQa3QqtAqpGA1SpC2BWTrYoDfY5XWEqh4hUnnyQ2Nw"
}
```

## Note

@npcore_note
| STT | Field Name |
| ------ | ------ |  
| 1 | MerchantCode |

## API Response Codes

#### 200 Success

@des_200

| Field                               | Type              | Description                              |
| ----------------------------------- | ----------------- | ---------------------------------------- |
| ResponseInfo.Status                 | string `required` | @des_result                              |
| ResponseInfo.ErrCode                | string `optional` | @des_ErrCode                             |
| ResponseInfo.ErrDesc                | string `optional` | @des_ErrDesc                             |
| BasicInfo.MerchantName              | Object `optional` | @des_BasicInfo_MerchantName              |
| BasicInfo.PSPCode                   | string `optional` | @des_BasicInfo_PSPCode                   |
| BasicInfo.MerCode                   | string `optional` | @des_client_id                           |
| BasicInfo.BusinessName              | string `optional` | @des_BasicInfo_BusinessName              |
| BasicInfo.Page                      | string `optional` | @des_BasicInfo_Page                      |
| BasicInfo.Tel                       | string `optional` | @des_BasicInfo_Tel                       |
| BasicInfo.Fax                       | string `optional` | @des_BasicInfo_Fax                       |
| BasicInfo.Email                     | string `optional` | Email                                    |
| BasicInfo.GoliveDate                | string `optional` | @des_BasicInfo_GoliveDate                |
| BasicInfo.Category                  | string `optional` | @des_BasicInfo_Category                  |
| BasicInfo.EncryStatus               | string `optional` | @des_BasicInfo_EncryStatus               |
| BasicInfo.City                      | string `optional` | @des_BasicInfo_City                      |
| BasicInfo.PartnerID                 | string `optional` | @des_BasicInfo_PartnerID                 |
| BasicInfo.DomesAcq                  | string `optional` | @des_BasicInfo_DomesAcq                  |
| BasicInfo.IntAcquirer               | string `optional` | @des_BasicInfo_IntAcquirer               |
| BasicInfo.Service                   | string `optional` | @des_BasicInfo_Service                   |
| BasicInfo.MerchantContractName      | string `optional` | @des_BasicInfo_MerchantContractName      |
| BasicInfo.MerchantContractCode      | string `optional` | @des_BasicInfo_MerchantContractCode      |
| ServiceDetails.DomVersion           | string `optional` | @des_ServiceDetails_DomVersion           |
| ServiceDetails.MerchantUsername     | string `optional` | @des_ServiceDetails_MerchantUsername     |
| ServiceDetails.ClientSecret         | string `optional` | @des_ServiceDetails_ClientSecret         |
| ServiceDetails.PPN3.0               | string `optional` | @des_ServiceDetails_PPN3_0               |
| ServiceDetails.IPNUrl               | string `optional` | @des_ServiceDetails_IPNUrl               |
| ServiceDetails.LocalDefault         | string `optional` | @des_ServiceDetails_LocalDefault         |
| ServiceDetails.UrlLogoDesk          | string `optional` | @des_ServiceDetails_UrlLogoDesk          |
| ServiceDetails.UrlLogoMobi          | string `optional` | @des_ServiceDetails_UrlLogoMobi          |
| ServiceDetails.UrlIssuer            | string `optional` | @des_ServiceDetails_UrlIssuer            |
| ServiceDetails.IpUrlRsa             | string `optional` | @des_ServiceDetails_IpUrlRsa             |
| ServiceDetails.Currency             | string `optional` | @des_ServiceDetails_Currency             |
| ServiceDetails.ReportSubAcc         | string `optional` | @des_ServiceDetails_ReportSubAcc         |
| ServiceDetails.CardType             | string `optional` | @des_ServiceDetails_CardType             |
| ServiceDetails.MerAlias             | string `optional` | @des_ServiceDetails_MerAlias             |
| ServiceDetails.OrderExp             | string `optional` | @des_ServiceDetails_OrderExp             |
| ServiceDetails.TokenStatus          | string `optional` | @des_ServiceDetails_TokenStatus          |
| ServiceDetails.TokenFormat          | string `optional` | @des_ServiceDetails_TokenFormat          |
| ServiceDetails.VerificationType     | string `optional` | @des_ServiceDetails_VerificationType     |
| ServiceDetails.VerificationStrategy | string `optional` | @des_ServiceDetails_VerificationStrategy |
| ServiceDetails.Respository          | string `optional` | @des_ServiceDetails_Respository          |
| ServiceDetails.PPT                  | string `optional` | @des_ServiceDetails_PPT                  |
| ServiceDetails.DomCardToken         | string `optional` | @des_ServiceDetails_DomCardToken         |
| ServiceDetails.IntCardToken         | string `optional` | @des_ServiceDetails_IntCardToken         |
| Domestic                            | Object `optional` |                                          |
| Domestic.ModelDom                   | string `optional` | @des_Domestic_ModelDom                   |
| Domestic.MerchantCode               | string `optional` | @des_Domestic_MerchantCode               |
| Domestic.LocalAcqId                 | string `optional` | @des_Domestic_LocalAcqId                 |
| Domestic.EcomTranxType              | string `optional` | @des_Domestic_EcomTranxType              |
| Domestic.TokeTranxType              | string `optional` | @des_Domestic_TokeTranxType              |
| Domestic.Currency                   | string `optional` | @des_Domestic_Currency                   |
| Domestic.WhitelistCard              | string `optional` | @des_Domestic_WhitelistCard              |
| Domestic.PostPay                    | string `optional` | @des_Domestic_PostPay                    |
| Domestic.FastpayAmount              | string `optional` | @des_Domestic_FastpayAmount              |
| Domestic.EcomIssuer.IssuerCode      | string `optional` | @des_Domestic_EcomIssuer_IssuerCode      |
| Domestic.EcomIssuer.AccountInfo     | string `optional` | @des_Domestic_EcomIssuer_AccountInfo     |
| Domestic.EcomIssuer.WhilelistCard   | string `optional` | @des_Domestic_EcomIssuer_WhilelistCard   |
| International                       | Object `optional` |                                          |
| International.DeloyInt              | string `optional` | @des_International_DeloyInt              |
| International.MerchantCode          | string `optional` | @des_Domestic_MerchantCode               |
| International.MpgsId                | string `optional` | @des_International_MpgsId                |
| International.MpgsAccount           | string `optional` | @des_International_MpgsAccount           |
| International.TransactionType       | string `optional` | @des_International_TransactionType       |
| Domestic.AuthService                | string `optional` | @des_International_AuthService           |
| Domestic.AuthTransaction            | string `optional` | @des_International_AuthTransaction       |
| Domestic.MpgsMso                    | string `optional` | @des_International_MpgsMso               |
| Timestamp                           | Date `required`   | @des_timestamp                           |
| Signature                           | string `required` | @des_signature2                          |

#### 400 Bad Request

@des_400

#### 401 Unauthorized

@des_401

#### 404 Not Found

@des_400

#### 500 Internal Server Error

@des_400

## API GetMerchants

```
POST: /api/core/v1/merchants
```

## @purpose2

@purpose_g_m_s

## Path Parameters

| Parameters | Type              | Description     |
| ---------- | ----------------- | --------------- |
| merchantId | string `required` | @des_merchantId |
| orderid    | string `required` | @des_orderid    |

## Header Parameters

| Parameters    | Type              | Description        |
| ------------- | ----------------- | ------------------ |
| Authorization | string `required` | @des_authorization |

## Query Parameters

| Parameters | Type              | Description     |
| ---------- | ----------------- | --------------- |
| Signature  | string `required` | @des_signature5 |

## Sample Request

```
curl --location --request POST 'https://@domain/api/core/v1/merchants'
--header 'Content-Type: application/json'
--data-raw '{
  "Signature": "O-gl4k4sfTwqRwE1ehz3nyR1h_v9J6OJixxDsNkEf-sJOzdye8zghYKzCMOKzRAEP8gsFEV2NX5FmUVbzSzLACECUxj5hdxsbWKZZhMWmxLg8hVaYfS3YphPdQQF8_bwaRpbb4os3eGaiD9sdgSrvDllLnbHFLbCRC5YDOFiqpvxqHpgLpFcbH69viQpWKamYw7Y9MBEUPjTkH0rHjxno0NbL0fIGEft4w_CY5BvKiHJDNaQlT00Pmri4eogf-Bjybu6nYuOecvdqnW9hD5gnefKkDo4-y6RQKoBPIdsss8u9XSjCiTVgG43IbPQt8ixcFWvRrbKI_QscVHCYKHsDg"
}'
```

## Example Response

```javascript
{
  "ResponseInf": {
    "Status": "SUCCESS"
  },
  "MerchantList": [
    {
      "BasicInfo": {
        "DomAcquier": "ACQ_VCB"
      },
      "ServiceDetails": {
        "DomCardToken": "MANY",
        "IntCardToken": "MANY"
      },
      "Domestic": {
        "ModelDom": "SERVER_HOSTED",
        "MerchantCode": "0002"
      },
      "EcomIssuer": {
        "WhitelistCard": ""
      },
      "International": {
        "MerchantCode": "4784"
      }
    }
  ],
  "Timestamp": "08/01/2022 19:03:02",
  "Signature": "JWSiz-h0YAiS4bAzxLBjPGisVCQdoCx16skQ9gs2PGWoC_cT5UJyUfK_TMOMKagdEisxW4eEa5MkV984NJbHIbKvXHGCpTqwceI2GRbXjq6fhOeG51Uj4jfQuAo-4rUE61_r0qU7JHiHOmQTUWEDwtUWyuPqCMa-aLX9SsBWVd8Qki50AWhfKZkS1HEwODG1P7h9CcRq2r6jMA1BchZcnSgIfhj2KnyMKdiK02jZ9FouJMEv5eKkM9C0jHhq_TSXCie142KkF_9YlH_cK_6_YVSnpgGZzcWPSHvcCwAzxvUuPXbxQQx4YMZc9o73u34zsL_eRt7jpixRnSYvJDCXkQ"
}
```

## API Response Codes

#### 200 Success

@des_200

| Field                               | Type              | Description                              |
| ----------------------------------- | ----------------- | ---------------------------------------- |
| ResponseInfo.Status                 | string `required` | @des_result                              |
| ResponseInfo.ErrCode                | string `optional` | @des_ErrCode                             |
| ResponseInfo.ErrDesc                | string `optional` | @des_ErrDesc                             |
| BasicInfo.MerchantName              | Object `optional` | @des_BasicInfo_MerchantName              |
| BasicInfo.PSPCode                   | string `optional` | @des_BasicInfo_PSPCode                   |
| BasicInfo.MerchantCode              | string `optional` | @des_client_id                           |
| BasicInfo.BusinessName              | string `optional` | @des_BasicInfo_BusinessName              |
| BasicInfo.Page                      | string `optional` | @des_BasicInfo_Page                      |
| BasicInfo.Tel                       | string `optional` | @des_BasicInfo_Tel                       |
| BasicInfo.Fax                       | string `optional` | @des_BasicInfo_Fax                       |
| BasicInfo.Email                     | string `optional` | Email                                    |
| BasicInfo.GoliveDate                | string `optional` | @des_BasicInfo_GoliveDate                |
| BasicInfo.Category                  | string `optional` | @des_BasicInfo_Category                  |
| BasicInfo.City                      | string `optional` | @des_BasicInfo_City                      |
| BasicInfo.PartnerID                 | string `optional` | @des_BasicInfo_PartnerID                 |
| BasicInfo.DomAcquier                | string `optional` | @des_BasicInfo_DomesAcq                  |
| BasicInfo.IntAcquirer               | string `optional` | @des_BasicInfo_IntAcquirer               |
| BasicInfo.Service                   | string `optional` | @des_BasicInfo_Service                   |
| BasicInfo.MerchantContractName      | string `optional` | @des_BasicInfo_MerchantContractName      |
| BasicInfo.MerchantContractCode      | string `optional` | @des_BasicInfo_MerchantContractCode      |
| ServiceDetails.DomVersion           | string `optional` | @des_ServiceDetails_DomVersion           |
| ServiceDetails.MerchantUser         | string `optional` | @des_ServiceDetails_MerchantUsername     |
| ServiceDetails.PPN3.0               | string `optional` | @des_ServiceDetails_PPN3_0               |
| ServiceDetails.IPNUrl               | string `optional` | @des_ServiceDetails_IPNUrl               |
| ServiceDetails.LocalDefault         | string `optional` | @des_ServiceDetails_LocalDefault         |
| ServiceDetails.UrlLogoDesk          | string `optional` | @des_ServiceDetails_UrlLogoDesk          |
| ServiceDetails.UrlLogoMobi          | string `optional` | @des_ServiceDetails_UrlLogoMobi          |
| ServiceDetails.UrlIssuer            | string `optional` | @des_ServiceDetails_UrlIssuer            |
| ServiceDetails.IpUrlRsa             | string `optional` | @des_ServiceDetails_IpUrlRsa             |
| ServiceDetails.Currency             | string `optional` | @des_ServiceDetails_Currency             |
| ServiceDetails.ReportSubAcc         | string `optional` | @des_ServiceDetails_ReportSubAcc         |
| ServiceDetails.CardType             | string `optional` | @des_ServiceDetails_CardType             |
| ServiceDetails.MerchantAlias        | string `optional` | @des_ServiceDetails_MerAlias             |
| ServiceDetails.OrderExp             | string `optional` | @des_ServiceDetails_OrderExp             |
| ServiceDetails.TokenStatus          | string `optional` | @des_ServiceDetails_TokenStatus          |
| ServiceDetails.TokenFormat          | string `optional` | @des_ServiceDetails_TokenFormat          |
| ServiceDetails.VerificationType     | string `optional` | @des_ServiceDetails_VerificationType     |
| ServiceDetails.VerificationStrategy | string `optional` | @des_ServiceDetails_VerificationStrategy |
| ServiceDetails.Respository          | string `optional` | @des_ServiceDetails_Respository          |
| ServiceDetails.PPT                  | string `optional` | @des_ServiceDetails_PPT                  |
| ServiceDetails.DomCardToken         | string `optional` | @des_ServiceDetails_DomCardToken         |
| ServiceDetails.IntCardToken         | string `optional` | @des_ServiceDetails_IntCardToken         |
| Domestic                            | Object `optional` |                                          |
| Domestic.ModelDom                   | string `optional` | @des_Domestic_ModelDom                   |
| Domestic.MerchantCode               | string `optional` | @des_Domestic_MerchantCode               |
| Domestic.LocalAcqId                 | string `optional` | @des_Domestic_LocalAcqId                 |
| Domestic.EcomTranxType              | string `optional` | @des_Domestic_EcomTranxType              |
| Domestic.TokeTranxType              | string `optional` | @des_Domestic_TokeTranxType              |
| Domestic.Cur                        | string `optional` | @des_Domestic_Currency                   |
| Domestic.WhitelistCard              | string `optional` | @des_Domestic_WhitelistCard              |
| Domestic.PostPay                    | string `optional` | @des_Domestic_PostPay                    |
| Domestic.FastpayAmount              | string `optional` | @des_Domestic_FastpayAmount              |
| Domestic.EcomIssuer.IssuerCode      | string `optional` | @des_Domestic_EcomIssuer_IssuerCode      |
| Domestic.EcomIssuer.AccountInfo     | string `optional` | @des_Domestic_EcomIssuer_AccountInfo     |
| Domestic.EcomIssuer.WhilelistCard   | string `optional` | @des_Domestic_EcomIssuer_WhilelistCard   |
| International                       | Object `optional` |                                          |
| International.DeloyInt              | string `optional` | @des_International_DeloyInt              |
| International.MerchantCode          | string `optional` | @des_Domestic_MerchantCode               |
| International.MpgsId                | string `optional` | @des_International_MpgsId                |
| International.MpgsAccount           | string `optional` | @des_International_MpgsAccount           |
| International.TransactionType       | string `optional` | @des_International_TransactionType       |
| Domestic.AuthService                | string `optional` | @des_International_AuthService           |
| Domestic.AuthTransaction            | string `optional` | @des_International_AuthTransaction       |
| Domestic.MpgsMso                    | string `optional` | @des_International_MpgsMso               |
| Timestamp                           | Date `required`   | @des_timestamp                           |
| Signature                           | string `required` | @des_signature2                          |

#### 400 Bad Request

@des_400

#### 401 Unauthorized

@des_401

#### 404 Not Found

@des_400

#### 500 Internal Server Error

@des_400

## API GenerateQR

```
POST: /api/core/v1/gen-viet-qr
```

## @purpose2

@purpose_g_qr

## Query Parameters

| Parameters   | Type               | Description       |
| ------------ | ------------------ | ----------------- |
| BenId        | Number `required`  | @des_BenId        |
| AcountNumber | Number `required`  | @des_AcountNumber |
| AccountName  | string `required`  | @des_AccountName  |
| Amount       | Number `optional`  | @des_Amount       |
| Remark       | string `optional`  | @des_Remark       |
| IsMask       | Boolean `required` | @des_IsMask       |
| Logo         | `optional`         | @des_Logo         |
| Signature    | string `required`  | @des_signature_qr |

## Sample Request

```
curl --location --request POST --url https://@domain/api/core/v1/gen-viet-qr
  --header `Content-Type: application/json`
  --data-raw `--form BenId="970416"
  --form AcountNumber="123456"
  --form AccountName="nguyen"
  --form Amount=""
  --form Remark="ck tien hang"
  --form IsMask="true"
  --form Logo=@"/path/to/file"
  --form Signature="EgaBfzesQYiJ_x-1ddoZ5ychTK4Egkyc6gRBOvzpmgKeVriW9te_7H5gfvWansH4d6uKuvq4WjdnJrFqGrdi3RDlIyiC8rr2YqU85ZyUtwGiHppJWV1AnX_7XBq-81AmclenTHEAz156iQevx0r3IFfq-sHO5j5DeYWXqpq-jmQ9hC7wIuIA5hCrPhhIklpYkZAxHYg9CZ7MoAzYsF0iltLd-s1MZwiNJu7qdT-smQ9HrJln9hIBfhQqnBX2r6XD3YMzxdpWpXP_hcxvQNNyussl86MlqzkbFIsKlzHqSzeOJL6mVPN8FaXV1JWZL6R0MAPv1i-CrVJLJeWrdAdzeeQ"`
```

## Example Response

```javascript
{
  "ResponseInf": {
    "Status": "SUCCESS"
  },
  "Result": "nội dung base 64 của ảnh Qrcode (do nội dung Qrcode dài nên không thể copy được vào đây)",
  "Timestamp": "12/01/2022 09:56:19",
  "Signature": "fSaWuPgNNdaxiao4cV4c0X2gWEjAKv7JHMjuwN2b8ZaAJqJYvfhKpm8xkCjvTRaQxh_EXZ15PwOJefirpv796bQeW7gP5YJltxt1WNGFOHcdEc1wCvmBoj2x92GZciP5lUhXhDCSZsWLad7Xc2_s9pri3nnCZ9XksM9mwg3P0OfvcbplDh2kNhhaYQD2RBCv_SLvGUSvqVWV2gY4sr6EcWKTQIa2ZrSXKZrFHA4sYJ4eErgHyCc5MfpcwaYWkRWj-Agylgz6fzhMY5WuRV8h5Gf2vYwBW8E1FXNPTmY9F-21kHBb78D8VaAE1lLsU91Le4ixeRY9mAV7KzphsbvlNw"
}
```

## Note

@npcore_note
| STT | Field Name |
| ------ | ------ |  
| 1 | AccountName |
| 2 | AcountNumber |
| 3 | Amount |
| 4 | BenId |
| 5 | IsMask |
| 6 | Logo |
| 6 | Remark |

## API Response Codes

#### 200 Success

@des_200

| Field                      | Type              | Description     |
| -------------------------- | ----------------- | --------------- |
| ResponseInfo.Status        | string `required` | @des_result     |
| ResponseInfo.ErrCode       | string `optional` | @des_ErrCode    |
| ResponseInfo.ErrDesc       | string `optional` | @des_ErrDesc    |
| @des_IntTransaction_Result | Base64 `required` |                 |
| Timestamp                  | Date `required`   | @des_timestamp  |
| Signature                  | string `required` | @des_signature6 |

#### 400 Bad Request

@des_400

#### 401 Unauthorized

@des_401

#### 404 Not Found

@des_400

#### 500 Internal Server Error

@des_400

## API GetVietQRInfo

```
POST: /api/core/v1/get-vietqr-info
```

## @purpose2

@purpose_log_qr

## Query Parameters

| Parameters | Type              | Description     |
| ---------- | ----------------- | --------------- |
| BenId      | string `required` | @des_BenId      |
| FromDate   | string `required` | @des_FromDate   |
| ToDate     | string `required` | @des_ToDate     |
| Signature  | string `required` | @des_signature3 |

## Sample Request

```
curl --location 'https://developer.napas.com.vn/api/core/v1/get-vietqr-info' \
--header 'Content-Type: application/json' \
--header 'Authorization: Bearer p8tn8m4gqkeeak2r7wwq7y8n' \
--data '{
  "BenId" : "970434",
  "FromDate": "01/06/2023 06:40:00",
  "ToDate": "01/06/2023 06:50:01",
  "Signature": "S4NZ5xMsZzxJZXcmczKbcVPLBSXQWwGKEi6TTQ0wqVJ7v0KHvNS//Y+ssdq9fktyqQuMtxW2yQqS68AjgO3sTVUiPYPLnoqA+bxm93kUAjSM8BteWyqk19yvNnQi6fqEmvbDH+i/jrP3yeCgUt6L328Dh5rb8z1iCywLynJiCyGsMhSvkxFQnUlsPGuf9yQaK8CzE/fr4uKE81x+yDqofhzrZm583ntwG+3ICzo0BG5Tsbv+XH/J5kLc//EOS/mHC7FvG/ZiMYG74S3fMNkwBGOfGhDuDbD+wwxTiBmEIO4Lo3Xbm4AE9oIYqmP6BzctAmfhT8e9urMaCqk4dfbkAg=="
}'
```

## Example Response

```javascript
{
  "ResponseInfo": {
  "Status": "SUCCESS"
},
  "Results": [
  {
    "VietQRInfo": {
      "Bin": "970434",
      "AccountNo": "xxxxxx9001",
      "AccountName": "CTY CP GIAI PHAP THANH TOAN VIET NAM - C/A - VND",
      "CreateDate": "2023-06-01T06:41:19+07:00"
    }
  },
  {
    "VietQRInfo": {
      "Bin": "970434",
      "AccountNo": "xxxxxx9005",
      "AccountName": "CTY CP GIAI PHAP THANH TOAN VN-C/A-VND",
      "CreateDate": "2023-06-01T06:46:01+07:00"
    }
  },
  {
    "VietQRInfo": {
      "Bin": "970434",
      "AccountNo": "xxxxxx9006",
      "AccountName": "CTY CP GIAI PHAP THANH TOAN VN-VND-C/A",
      "CreateDate": "2023-06-01T06:47:12+07:00"
    }
  }
],
  "Timestamp": "02/08/2023 09:50:22",
  "Signature": "b+5/tNFaS33+e0HxaXu95liHx95bgZsLdf5JtYTYwpA7BtpvtMDTZ3gh6mOUjcQQ6xLBJF4DhGr52mip8L8Qf+x1bPCE4fSgMmSair6CI5sayfLE3djGpCn1VUlH+TRiMUa4KBmFSUW0p/9tF4HR4sTI7IHGcWMWabq7+xfXgPXrSs5nly7h7/+hE6NumjfZ2KXZd8p9IePF2a2GWgslTNEx5/+QyaesKUwn4fcuz0y5GN/6Zu4WnaaQPzxmUcJ83Q06+m0NoamJ4o5ZPu230nyAyQlynTSDkwsctuO8fprDr26YetKHEvCdkeIRtd3qK1d/Ix4WMZpaYgqtKSaUdw=="
}
```

## Note

@npcore_note
| STT | Field Name |
| ------ | ------ |  
| 1 | BenId |
| 2 | FromDate |
| 3 | ToDate |

## API Response Codes

#### 200 Success

@des_200
| Field | Type | Description |
| ------ | ------ | ------ |
| ResponseInfo | | |
| ResponseInfo.Status | string `required` | "SUCCESS" |
| Results | | |
| Results.VietQRInfo | | |
| VietQRInfo.Bin | string `required` | @des_BenIdLog |
| VietQRInfo.AccountNo | string `required` | @des_AcountNumberLog |
| VietQRInfo.AccountName | string `required` | @des_AccountNameLog |
| VietQRInfo.Amount | string `optional` | @des_AmountLog |
| VietQRInfo.AddInfo | string `optional` | @des_AddInfoLog |
| VietQRInfo.CreateDate | string `required` | @des_CreatedDateLog |
| Timestamp | Date `required` | @des_timestamp |
| Signature | string `required` | @des_signature2 |

#### 400 Bad Request

| Field      | Description                                       |
| ---------- | ------------------------------------------------- |
| statusCode | 400                                               |
| message    | FromDate is null                                  |
| ------     | FromDate wrong formats DD/MM/YYYY HH24:MM:SS      |
| ------     | FromDate over 3 months with today                 |
| ------     | FromDate cannot be a future date                  |
| ------     | ToDate is null                                    |
| ------     | ToDate wrong formats DD/MM/YYYY HH24:MM:SS        |
| ------     | ToDate over 3 months with today                   |
| ------     | ToDate cannot be a future date                    |
| ------     | ToDate must not be less than or equal to FromDate |
| ------     | Signature could not be verified                   |
| ------     | No authorization                                  |
| ------     | BenId does not exist                              |
| ------     | BenId wrong formats (0-9)                         |
| ------     | BenId exceeds the max length                      |

#### 500 Internal Server Error

| Field      | Description           |
| ---------- | --------------------- |
| statusCode | 500                   |
| message    | Internal server error |
