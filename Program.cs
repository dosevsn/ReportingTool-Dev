using AngularReporting.Data;
using AngularReporting.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


string conn = builder.Configuration.GetConnectionString("ReportingDb");

builder.Services.AddSqlServer<FMCContext>(conn);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
