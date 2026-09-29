using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ServiceTracker.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();


// Datebase connection
builder.Services.AddDbContext<ServiceTrackerDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});


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