using Scalar.AspNetCore;
using ServiceTracker.Api.ExceptionHandling;
using ServiceTracker.Application.Interfaces.Services;
using ServiceTracker.Application.Services;
using ServiceTracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddExceptionHandler<GlobalExceptionHandling>();
builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddControllers();



builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();



app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

// Тимчасовий тест: при переході на /break-server код видасть помилку
app.MapGet("/break-server", () => { throw new Exception("Упс! Щось пішло не так у базі даних!"); });

app.Run();