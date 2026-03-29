using Infrastructure.Data;
using Infrastructure.Logging;
using Application.UseCases;



var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Services.AddCors(o => o.AddPolicy("bad", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

<<<<<<< HEAD
<<<<<<< HEAD
BadDb.ConnectionString =
   app.Configuration.GetConnectionString("bad");
=======
BadDb.ConnectionString = app.Configuration["ConnectionStrings:Sql"]
 ?? "Server=localhost;Database=master;User Id=sa;Password=SuperSecret123!;TrustServerCertificate=True";
>>>>>>> 9e31d8277ab97642fc6c5b62b022723f1dd60cd2
=======
BadDb.ConnectionString = app.Configuration["ConnectionStrings:Sql"]
 ?? "Server=localhost;Database=master;User Id=sa;Password=SuperSecret123!;TrustServerCertificate=True";
>>>>>>> 9e31d8277ab97642fc6c5b62b022723f1dd60cd2

app.UseCors("bad");

app.Use(async (ctx, next) =>
{
    try { await next(); } catch { await ctx.Response.WriteAsync("oops"); }
});

app.MapGet("/health", () =>
{
    Logger.Log("health ping");
    
    return "ok " ;
});

app.MapPost("/orders", (HttpContext http) =>
{
    using var reader = new StreamReader(http.Request.Body);
    var body = reader.ReadToEnd();
    var parts = (body ?? "").Split(',');
    var customer = parts.Length > 0 ? parts[0] : "anon";
    var product = parts.Length > 1 ? parts[1] : "unknown";
    var qty = parts.Length > 2 ? int.Parse(parts[2]) : 1;
    var price = parts.Length > 3 ? decimal.Parse(parts[3]) : 0.99m;

    var uc = new CreateOrderUseCase();
    var order = uc.Execute(customer, product, qty, price);

    return Results.Ok(order);
});

app.MapGet("/orders/last", () => Domain.Services.OrderService.LastOrders);

app.MapGet("/info", (IConfiguration cfg) => new
{
    sql = BadDb.ConnectionString,
    env = Environment.GetEnvironmentVariables(),
    version = "v0.0.1-unsecure"
});

<<<<<<< HEAD
<<<<<<< HEAD
await app.RunAsync();  
=======
app.Run();  
>>>>>>> 9e31d8277ab97642fc6c5b62b022723f1dd60cd2
=======
app.Run();  
>>>>>>> 9e31d8277ab97642fc6c5b62b022723f1dd60cd2
