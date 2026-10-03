using Scalar.AspNetCore;
using ServiceTracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Тимчасовий тест: при переході на /break-server код видасть помилку
app.MapGet("/break-server", () => { throw new Exception("Упс! Щось пішло не так у базі даних!"); });

app.Run();