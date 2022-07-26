using MinimalAPIT.SignedAPI;
using MinimalAPIT.UnsignedAPI;
using MinimalAPIT;

SignedAPI signedAPI = new SignedAPI();
UnsignedAPI unsignedAPI = new UnsignedAPI();

var builder = WebApplication.CreateBuilder(args);
string data_key = builder.Configuration.GetSection("keys").GetSection("API_Key").Value;
string data_secret = builder.Configuration.GetSection("keys").GetSection("SECRET_Key").Value;

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.WithOrigins(
        "https://localhost:7064");
}));

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

async Task<List<AllOrder>> getAllOrders(DataContext context) =>
    await context.allOrders.ToListAsync();

//Signed API Calls
app.MapGet("/rateLimit/order", () => signedAPI.getTrades(data_key, data_secret));
app.MapGet("/myAccount", () => signedAPI.getAccount(data_key, data_secret));
app.MapGet("/allOrders", () => signedAPI.getAllOrders(data_key, data_secret));
app.MapGet("/allOrders/db", async (DataContext context) =>
    await context.allOrders.ToListAsync());
app.MapPost("/allOrders", async (DataContext context, AllOrder orders) =>
{
    Console.WriteLine(orders);
    context.allOrders.Add(orders);
    await context.SaveChangesAsync();
    return Results.Ok(await getAllOrders(context));
});

//Unsigned API Calls
app.MapGet("/ticker/price", () => unsignedAPI.getTickerPrice());
app.MapGet("/depth", () => unsignedAPI.getDepth());
app.MapGet("/ping", () => unsignedAPI.getConnectivityStatus());


app.Run();
