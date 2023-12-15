using System.Text;
using Dapper.FluentMap;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PizzaGameService.Data.Extensions;
using PizzaGameService.Data.Mappers;
using PizzaGameService.Data.Settings;
using PizzaGameService.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection($"{nameof(AppSettings)}:Token").Value ??
                throw new InvalidOperationException())),
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddData()
    .AddDomain();

builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection(nameof(AppSettings)));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

FluentMapper.Initialize(config =>
{
    config.AddMap(app.Services.GetRequiredService<RegisteredPlayerMapper>());
    config.AddMap(app.Services.GetRequiredService<PlayerWithRefreshTokenMapper>());
    config.AddMap(app.Services.GetRequiredService<PlayerGameDataMapper>());
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();