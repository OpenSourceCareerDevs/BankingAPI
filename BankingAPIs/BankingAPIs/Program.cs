using BankingAPIs.DATA;
using BankingAPIs.Interface;
using BankingAPIs.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

//add automappeerr
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ISignUp, Signup>();
builder.Services.AddScoped<ICustomerAccount, AccountRepo>();
builder.Services.AddScoped<IAdminLogin, Admin>();
var connectionString = builder.Configuration.GetConnectionString(name: "DefaultConnections");
//var cc = builder.Configuration.GetSection("DefaultConnections");
//var b = Environment.GetEnvironmentVariable("DefaultConnections");

builder.Services.AddControllers();
builder.Services.AddDbContext<DataBank>(opt =>
{
    

    //opt.UseMySql(b)
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //opt.UseMySql(Environment.GetEnvironmentVariable("Connectionstring"))connectionString
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policyBuilder => policyBuilder.AddDefaultPolicy(policy => policy.WithOrigins
("*").AllowAnyHeader().AllowAnyHeader()));

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
