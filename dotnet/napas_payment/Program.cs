using napas_payment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Register QR code services
builder.Services.AddScoped<INapasQrService, NapasQrService>();
builder.Services.AddScoped<INapasQrServiceV2, NapasQrServiceV2>();
builder.Services.AddScoped<IQrCodeServiceFactory, QrCodeServiceFactory>();
builder.Services.AddScoped<IQrImageService, QrImageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
