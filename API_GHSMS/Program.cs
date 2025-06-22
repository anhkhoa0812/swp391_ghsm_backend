using API_GHSMS.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OhBau.Service.CloudinaryService;
using Repository.Models;
using Repository.Repository;
using Service.Implement;
using Service.Interface;
using System.Text;
using API_GHSMS.Hubs;
using System.Text.Json.Serialization;
using PayOSService.Config;
using PayOSService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Swp391ghsmContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IDashBoardService,DashBoardService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TestRepository>();
builder.Services.AddScoped<DashBoardRepository>();
builder.Services.AddScoped<AuthenRepository>();
builder.Services.AddScoped<IAuthenService, AuthenService>();

builder.Services.AddScoped<ConsultantsRepository>();
builder.Services.AddScoped<IConsultantsService, ConsultantsService>();

builder.Services.AddScoped<BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddSignalR();

builder.Services.Configure<PayOSConfig>(
    builder.Configuration.GetSection(PayOSConfig.ConfigName));
builder.Services.AddHttpClient<IPayOSService, PayOSService.Services.PayOSService>();
builder.Services.Configure<PayOSConfig>(builder.Configuration.GetSection("PayOS"));



builder.Services.AddSingleton(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var account = new CloudinaryDotNet.Account(
        configuration["Cloudinary:CloudName"],
        configuration["Cloudinary:ApiKey"],
        configuration["Cloudinary:Secret"]);
    return account;
}   
);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true; 
    });

builder.Services.AddSingleton(sp =>
{
    var account = sp.GetRequiredService<CloudinaryDotNet.Account>();
    return new CloudinaryDotNet.Cloudinary(account);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("Jwt");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]))
    };
});

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<MessageHub>("hubs/message");
app.Run();
