using Microsoft.EntityFrameworkCore;
using RemaxWebAPI.Models;
using RemaxWebApi.Middleware;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ProductDB");
builder.Services.AddDbContextPool<RelEstDbContext>(option =>
option.UseSqlServer(connectionString)
);

//builder.Services.a
//XmlConfigurator.Configure(new FileInfo("log4net.config"));

builder.Services.AddControllers();
//builder.Services.AddAuthentication(options => options. = new TokenValidationParameters
//{
//    ValidateIssuer = true,
//    ValidateAudience = true,
//    ValidateLifetime = true,
//    ValidateIssuerSigningKey = true,
//    //ValidIssuer = builder.Configuration["Jwt:Issuer"],
//    //ValidAudience = builder.Configuration["Jwt:Audience"],
//    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddLogging((builder) =>
{
    builder.AddConsole();
    builder.AddDebug();
});

var app = builder.Build();

var loggerFactory = app.Services.GetService<ILoggerFactory>();
//loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

//app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//test
