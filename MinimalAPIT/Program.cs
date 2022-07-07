using MinimalAPIT.SignedAPI;
using MinimalAPIT.UnsignedAPI;

SignedAPI signedAPI = new SignedAPI();
UnsignedAPI unsignedAPI = new UnsignedAPI();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Signed API Calls
app.MapGet("/myTrades", () => signedAPI.getTrades());
app.MapGet("/myAccount", () => signedAPI.getAccount());
app.MapGet("/allOrders", () => signedAPI.getAllOrders());

//Unsigned API Calls
app.MapGet("/ticker/price", () => unsignedAPI.getTickerPrice());
app.MapGet("/depth", () => unsignedAPI.getDepth());
app.MapGet("/ping", () => unsignedAPI.getConnectivityStatus());


app.Run();
