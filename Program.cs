using Microsoft.EntityFrameworkCore;
using ZapAgenda_api_aspnet.data;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
Env.Load();
builder.Services.AddDbContext<CoreDBContext>(options =>{options.UseMySql(Environment.GetEnvironmentVariable("DEFAULT_CONNECTION_STRING"),new MySqlServerVersion(new Version(8, 0, 32)));});


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


app.Run();


