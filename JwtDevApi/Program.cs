using JwtDevApi;
using JwtDevApi.Infraestrutura;
using JwtDevApi.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//conexão com o banco de dados ----------------------------------------------------------------
builder.Services.AddDbContext<ConnectionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//INJEÇÃO DE DEPENDENCIA -------------------------------------------------------------------------
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

//Validação ou Autenticação  do TOKEN -------------------------------------------------------------
var key = Encoding.ASCII.GetBytes(JwtDevApi.Key.Secret);


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //conectar no SCALAR API REFERENCE--------------------------------------------------
    app.MapScalarApiReference();         
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
