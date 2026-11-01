var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine("MW1: до");
    await next();            
    Console.WriteLine("MW1: после");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("MW2: до");
    await next(context);    
    Console.WriteLine("MW2: после");
});

app.UseMiddleware<MyMiddleware>();

app.Run(async context =>
{
    Console.WriteLine("Terminal: обработка запроса");
    await context.Response.WriteAsync("Hello from middleware demo!");
});

app.Run();