using Microsoft.EntityFrameworkCore;
using CheckWallet.Data;
using CheckWallet.API.V1.Services;
using CheckWallet.API.V1.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Database"))); 

builder.Services.AddScoped<IAccountWatcherService, AccountWatcherService>();
builder.Services.AddScoped<IWatcherSettingsService, WatcherSettingsService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();