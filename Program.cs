using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.data;
using DotNetEnv;
using ZapAgenda_api_aspnet.repositories.interfaces;
using ZapAgenda_api_aspnet.repositories.implementations;
using Newtonsoft.Json;
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
builder.Services.AddDbContext<CoreDBContext>(options => { options.UseMySql(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION_STRING"), new MySqlServerVersion(new Version(8, 0, 32))); });
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

var app = builder.Build();

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


