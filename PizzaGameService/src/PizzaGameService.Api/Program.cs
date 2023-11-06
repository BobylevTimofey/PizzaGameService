using PizzaGameService.Data.Extensions;
using PizzaGameService.Data.Settings;
using PizzaGameService.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddData()
    .AddDomain();

builder.Services.Configure<ConnectionStringSettings>(
    builder.Configuration.GetSection(nameof(ConnectionStringSettings)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();