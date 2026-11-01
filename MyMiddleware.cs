public class MyMiddleware
{
    private readonly RequestDelegate _next;

    public MyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("MyMiddleware: до");
        await _next(context);
        Console.WriteLine("MyMiddleware: после");
    }
}