using CodeChallenge1.DbContexts;
using CodeChallenge1.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using UserInfo.API;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
   .WriteTo.Console()
   .WriteTo.File("logs/userInfo.log", rollingInterval: RollingInterval.Day)
   .CreateLogger();



var builder = WebApplication.CreateBuilder(args);

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

//tell Asp.net to use Serilog
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers(options =>
{

    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register services

#if DEBUG
builder.Services.AddTransient<IMailService, CustomMailService>();
#else
builder.Services.AddTransient<IMailService, Custom2MailService>();
#endif
builder.Services.AddSingleton<UsersDataStore>();

//register context i.e. UserInfoContext

builder.Services.AddDbContext<UserInfoContext>(dbContextOptions => dbContextOptions.UseSqlite("Data Source=UserInfo.db"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
