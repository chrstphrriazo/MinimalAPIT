using MinimalAPIT.SignedAPI;

Class classic = new Class();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/myTrades", () => classic.myTrades());

app.Run();
