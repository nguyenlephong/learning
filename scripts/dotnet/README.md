# Learning Struct

## Command CLI

```bash

dotnet new sln -n Payment

dotnet new classlib -n Payment.Domain

dotnet sln Payment.sln add Payment.Domain/Payment.Domain.csproj

dotnet sln Payment.sln add Payment.API/Payment.API.csproj

dotnet add Payment.API/Payment.API.csproj reference Payment.Domain/Payment.Domain.csproj

dotnet watch run --project Payment.API

dotnet watch run --project src/Payment.API
```