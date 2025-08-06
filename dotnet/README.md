# NDS QR Code API

A modular .NET Core API for generating QR codes according to NAPAS/EMVCo standards, designed for easy maintenance and extensibility.

## 🏗️ Architecture

This project follows Clean Architecture principles with ABP Framework:

```
├── NDS.QRCode.API.sln
├── src/
│   ├── NDS.QRCode.Domain.Shared/          # Shared constants and enums
│   ├── NDS.QRCode.Domain/                 # Domain entities and business logic
│   ├── NDS.QRCode.Application.Contracts/  # DTOs and service interfaces
│   ├── NDS.QRCode.Application/            # Application services implementation
│   ├── NDS.QRCode.HttpApi/               # HTTP API controllers
│   ├── NDS.QRCode.HttpApi.Host/          # Web application host
│   └── NDS.QRCode.HttpApi.Client/        # HTTP client for external calls
```

## 🚀 Features

- **NAPAS QR Code Generation**: Generate QR codes according to NAPAS standards
- **EMVCo Compliance**: Follows EMVCo QR Code specifications
- **Multiple QR Types**: Support for NAPAS, EMVCo, and VietQR
- **Image Generation**: Generate QR code images in various formats
- **Amount Formatting**: Proper VND amount formatting (no decimal places)
- **Personal/Merchant Support**: Default to personal use, configurable for merchants
- **Extensible Design**: Easy to add new QR code types
- **Validation**: Comprehensive input validation
- **Error Handling**: Proper error responses and logging

## 📋 Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code
- SQLite (for development) or SQL Server (for production)

## 🛠️ Installation

1. **Clone the repository**

   ```bash
   git clone <repository-url>
   cd NDS.QRCode.API
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Build the solution**

   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   cd src/NDS.QRCode.HttpApi.Host
   dotnet run
   ```

## 🔧 Configuration

### Amount Formatting

- **Personal Use**: Default amount formatting without decimal places (e.g., 1000 VND)
- **Merchant Use**: Can specify `pointOfInitiationMethod: "12"` for static QR

### QR Code Types

- **NAPAS**: Vietnamese NAPAS standard
- **EMVCo**: International EMVCo standard
- **VietQR**: Vietnamese VietQR standard

### Image Options

- **Size**: 1-50 pixels per module (default: 10)
- **Format**: png, jpg, jpeg (default: png)
- **Error Correction**: 0-3 levels (default: 2)

## 🔒 Security

- Input validation for all parameters
- SQL injection protection through Entity Framework
- CORS configuration for cross-origin requests
- Authentication and authorization support (can be extended)

## 📈 Performance

- Async/await pattern for all operations
- Efficient QR code generation using QRCoder library
- Database optimization with proper indexing
- Caching support (can be extended)

## 🐛 Troubleshooting

### Common Issues

1. **Build Errors**: Ensure .NET 8.0 SDK is installed
2. **Runtime Errors**: Check database connection string in `appsettings.json`
3. **QR Code Not Scannable**: Verify amount formatting and field lengths
4. **Image Generation Fails**: Check QRCoder package installation

### Logs

Application logs are available in:

- Console output during development
- Log files in production (configurable)

## 📝 License

This project is licensed under the MIT License.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📞 Support

For support and questions:

- Create an issue in the repository
- Contact the development team
- Check the documentation

---

**Note**: This API is designed to generate QR codes that can be scanned by all Vietnamese bank applications. The generated QR codes follow NAPAS/EMVCo standards and are compatible with major banking apps in Vietnam.
