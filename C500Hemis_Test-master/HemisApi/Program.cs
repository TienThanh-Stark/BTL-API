using C500Hemis;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// C?u hình DbContext cho SQL Server
builder.Services.AddDbContext<HemisContext>(options =>
    options.UseSqlServer("Server=10.0.28.54;Database=dbHemisC500;Trusted_Connection=True;Encrypt=false;User Id=c500;Password=@Abc1234")
    //options.UseSqlServer("Server=tcp:c500sv.database.windows.net,1433;Database=dbHemisC500;User Id=c500;Password=@Abc1234")
);

// C?u hình localization ?? h? tr? ti?ng Vi?t
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("vi-VN") };
    options.DefaultRequestCulture = new RequestCulture("vi-VN");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Thêm các d?ch v? vào container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// C?u hình pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
