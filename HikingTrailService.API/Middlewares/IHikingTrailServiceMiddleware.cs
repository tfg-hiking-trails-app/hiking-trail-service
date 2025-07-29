namespace HikingTrailService.Middlewares;

public interface IHikingTrailServiceMiddleware
{
    Task InvokeAsync(HttpContext context);
}