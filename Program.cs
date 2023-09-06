using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NossoERP.WebApi.Nuvem.Clinica.Context;
using NossoERP.WebApi.Nuvem.Clinica.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseIISIntegration();

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IConfigurationRoot configuration = new ConfigurationBuilder()
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json")
   .Build();

builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    var connectionString = configuration.
           GetConnectionString("DefaultConnection");

    optionsBuilder.UseSqlServer(connectionString);
});

//JWT
//adiciona o manipulador de autenticacao e define o 
//esquema de autenticacao usado : Bearer
//valida o emissor, a audiencia e a chave
//usando a chave secreta valida a assinatura
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options =>
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidAudience = configuration["TokenConfiguration:Audience"],
         ValidIssuer = configuration["TokenConfiguration:Issuer"],
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(
             System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
     });

var app = builder.Build();

app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader());

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//adiciona o middleware de autenticacao
app.UseAuthentication();

//adiciona o middleware que habilita a autorizacao
app.UseAuthorization();

app.MapControllers();

app.Run();

