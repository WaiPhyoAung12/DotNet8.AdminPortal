using AdminPortal.Frontend.Data;
using AdminPortal.Frontend.Services;
using AdminPortal.Shared.Extensions;
using AdminPortal.Shared.Models.CustomSetting;
using AdminPortal.Shared.Services.ApiService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration.AddStageConfig(builder.Environment.ContentRootPath);
builder.Services.Configure<CustomSettingModel>(configuration);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<HttpClientService>();
builder.Services.AddRadzenComponents();
builder.Services.AddHttpContextAccessor();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IInjectionService,InjectionService>();
builder.Services.AddMudServices();
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
