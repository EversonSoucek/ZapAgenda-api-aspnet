using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DotNetEnv;
using Microsoft.AspNetCore.Http.Features;
using ZapAgenda_api_aspnet.services;
using ZapAgenda_api_aspnet.interfaces;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.repositories.interfaces;
using ZapAgenda_api_aspnet.repositories.implementations;
using ZapAgenda_api_aspnet.Middlewares;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Registra o serviço IbgeService com a interface IIbgeService
builder.Services.AddScoped<IIbgeService, IbgeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IIbgeService, IbgeService>();
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<CoreDBContext>(options =>
{
    options.UseMySql(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION_STRING"), new MySqlServerVersion(new Version(8, 0, 32)));
});
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

var app = builder.Build();
app.UseMiddleware<CustomExceptionMiddleware>();

// Obtém o serviço IbgeService e faz a chamada
var municipioService = app.Services.GetRequiredService<IIbgeService>();
var municipioId = await municipioService.GetMunicipioId("Cascavel", "PR"); // Passe um nome de município válido e a sigla
Console.WriteLine($"ID do município: {municipioId}");

// Configurações adicionais
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo Api");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
