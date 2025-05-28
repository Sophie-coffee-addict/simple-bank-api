using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

        logger.LogError(exceptionHandlerPathFeature?.Error, "Unhandled exception occurred!");

        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(new
        {
            error = "An unexpected error occurred. Please try again later."
        });

        await context.Response.WriteAsync(result);
    });
});


app.UseAuthorization();

app.MapControllers();

app.Run();
