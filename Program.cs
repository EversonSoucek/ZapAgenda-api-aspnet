using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DotNetEnv;
using ZapAgenda_api_aspnet.services;
using ZapAgenda_api_aspnet.interfaces;
using ZapAgenda_api_aspnet.data;
using ZapAgenda_api_aspnet.repositories.interfaces;
using ZapAgenda_api_aspnet.repositories.implementations;
using ZapAgenda_api_aspnet.Middlewares;
using ZapAgenda_api_aspnet.models;
using Microsoft.AspNetCore.Identity;
using ZapAgenda_api_aspnet.extensions;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CoreDBContext>(options =>
{
    options.UseMySql(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION_STRING"), new MySqlServerVersion(new Version(8, 0, 32)));
});

builder.Services.AddHttpClient<IIbgeService, IbgeService>();
builder.Services.AddProblemDetails();

builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IIbgeService, IbgeService>();
builder.Services.ConfigureAuthOptions(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<CustomExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo Api");
    });
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
