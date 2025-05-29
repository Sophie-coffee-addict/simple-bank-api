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

// Redirect all HTTP requests to HTTPS (for secure communication)
app.UseHttpsRedirection();

// Global error handling middleware
// Catches any unhandled exceptions during request processing
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        // Get the logger from the DI container
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

        // Get the exception details from the current request
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

        // Log the exception as an error
        logger.LogError(exceptionHandlerPathFeature?.Error, "Unhandled exception occurred!");

        // Set the response status and content type
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        // Return a standard JSON error message to the client
        var result = JsonSerializer.Serialize(new
        {
            error = "An unexpected error occurred. Please try again later."
        });

        await context.Response.WriteAsync(result);
    });
});

// Enables authorization middleware (currently doesn't restrict anything unless policies are added)
app.UseAuthorization();

// Maps controller endpoints based on routing attributes like [Route("api/[controller]")]
app.MapControllers();

// Starts the application and begins listening for incoming HTTP requests
app.Run();
