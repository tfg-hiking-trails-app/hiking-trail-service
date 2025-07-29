﻿using System.Net;
using System.Text.Json;

namespace HikingTrailService.Middlewares;

public class InternalErrorMiddleware : IHikingTrailServiceMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestException> _logger;
    private readonly IHostEnvironment _environment;
    
    public InternalErrorMiddleware(RequestDelegate next, ILogger<RequestException> logger,  IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            
            var response = _environment.IsDevelopment()
                ? new RequestException(context.Response.StatusCode, ex.Message, ex.StackTrace)
                : new RequestException(context.Response.StatusCode, "Internal server error");
            
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            
            var responseJson = JsonSerializer.Serialize(response, options);
            
            await context.Response.WriteAsync(responseJson);
        }
    }
    
}