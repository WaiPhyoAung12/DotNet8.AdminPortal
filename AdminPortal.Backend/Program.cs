using AdminPortal.Backend;
using AdminPortal.Database.AppDbContextModels;
using AdminPortal.Domain.AdminUser;
using AdminPortal.Shared.Extensions;
using AdminPortal.Shared.Models.CustomSetting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration.AddStageConfig(builder.Environment.ContentRootPath);
builder.Services.Configure<CustomSettingModel>(configuration);  

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpoints(typeof(Program).Assembly);
builder.Services.AddScoped<IAdminUserService, AdminUserService>();
builder.Services.AddScoped<AdminUserRepo>();

//DBConnection
var connectionString = configuration.GetSection("DbConnection").Value;
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapEndpoints();
app.UseHttpsRedirection();
app.Run();

