using CostAccount_BAL.Services;
using CostAccount_BAL.Services.Interfaces;
using CostAccount_DAL.Data;
using CostAccount_DAL.Repositories;
using CostAccount_DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton(new MemoryDB());
builder.Services.AddSingleton<ISaleRepository, SaleRepository>();
builder.Services.AddSingleton<ISharesLotRepository, SharesLotRepository>();
builder.Services.AddSingleton<IMarketService, MarketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
