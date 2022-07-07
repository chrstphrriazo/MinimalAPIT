using MinimalAPIT.SignedAPI;
using MinimalAPIT.UnsignedAPI;

MyTrades mytrades = new MyTrades();
TickerPrice tickerprice = new TickerPrice();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/myTrades", () => mytrades.myTrades());
app.MapGet("/ticker/price", () => tickerprice.getTickerPrice());

app.Run();
