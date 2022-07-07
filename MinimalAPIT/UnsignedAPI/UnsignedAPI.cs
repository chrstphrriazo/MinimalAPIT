namespace MinimalAPIT.UnsignedAPI
{
    public class UnsignedAPI
    {
        public async Task<string> getTickerPrice()
        {
            //Code for calling Binance API general endpoints
            HttpClient httpclient = new HttpClient();
            string response = await httpclient.GetStringAsync(
                "https://testnet.binance.vision/api/v3/ticker/price");
            return response;
        }

        public async Task<string> getDepth()
        {
            //Code for calling Binance API general endpoints
            HttpClient httpclient = new HttpClient();
            string response = await httpclient.GetStringAsync(
                "https://testnet.binance.vision/api/v3/depth?symbol=BTCUSDT");
            return response;
        }

        public async Task<string> getConnectivityStatus()
        {
            //Code for calling Binance API general endpoints
            HttpClient httpclient = new HttpClient();
            string response = await httpclient.GetStringAsync(
                "https://testnet.binance.vision/api/v3/ping");
            return response;
        }
    }
}
