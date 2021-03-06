using CurrencyExchange.Infrastructure.Data.DbContexts;
using CurrencyExchange.Infrastructure.Mappings;
using CurrencyExchange.Infrastructure.Repositories;
using CurrencyExchange.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CurrencyExchangeDbContext>(opt => opt
    .UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection")));

builder.Services.AddAutoMapper(typeof(Mappings));

builder.Services.AddScoped<ICurrencyExchanger, CurrencyExchanger>();
builder.Services.AddScoped<ICurrencyHistory, CurrencyHistory>();
builder.Services.AddScoped<ICurrencyHistoryRepository, CurrencyHistoryRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
