using MinimalAPIT.SignedAPI;
using MinimalAPIT.UnsignedAPI;

SignedAPI signedAPI = new SignedAPI();
UnsignedAPI unsignedAPI = new UnsignedAPI();

var builder = WebApplication.CreateBuilder(args);
string data_key = builder.Configuration.GetSection("keys").GetSection("API_Key").Value;
string data_secret = builder.Configuration.GetSection("keys").GetSection("SECRET_Key").Value;

Console.WriteLine(data_key);
Console.WriteLine(data_secret);
var app = builder.Build();

//Signed API Calls
app.MapGet("/rateLimit/order", () => signedAPI.getTrades(data_key, data_secret));
app.MapGet("/myAccount", () => signedAPI.getAccount(data_key, data_secret));
app.MapGet("/allOrders", () => signedAPI.getAllOrders(data_key, data_secret));

//Unsigned API Calls
app.MapGet("/ticker/price", () => unsignedAPI.getTickerPrice());
app.MapGet("/depth", () => unsignedAPI.getDepth());
app.MapGet("/ping", () => unsignedAPI.getConnectivityStatus());


app.Run();
