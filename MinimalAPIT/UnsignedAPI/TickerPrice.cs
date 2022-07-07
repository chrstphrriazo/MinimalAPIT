namespace MinimalAPIT.UnsignedAPI
{
    public class TickerPrice
    {
        public async Task<string> getTickerPrice()
        {
            //Code for calling Binance API general endpoints
            HttpClient httpclient = new HttpClient();
            string response = await httpclient.GetStringAsync(
                "https://testnet.binance.vision/api/v3/ticker/price");
            return response;
        }
    }
}
