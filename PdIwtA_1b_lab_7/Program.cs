using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using test_7.Domain;
using test_7.DTOs.Validators;
using test_7.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddSingleton<IProductsRepository, ProductsInMemoryRepository>();

builder
    .Services
    .AddControllers()
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AddProductDTOValidator>());

builder
    .Services
    .AddAuthorization()
    .AddAuthentication(opt =>
    {
        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero, //zmiana domyslnego czasu istnienia tokenu na wartosc w generatorze
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidIssuer = "test",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("w+1alOGke7bSPTgeMVlDXS5FRg3jcjRxkBtG0u3NrOo="))
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication()
   .UseAuthorization();

app.MapControllers();

app.Run();