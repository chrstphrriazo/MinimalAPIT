using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http;

namespace MinimalAPIT.SignedAPI
{
    public class SignedAPI
    {
        public async Task<string> getAccount(string API_Key, String API_Secret)
        {
            string baseurl = "https://testnet.binance.vision/api/v3/account?";
            string timestamp = Math.Round(Convert.ToDecimal(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds), 0).ToString();
            string dataQueryString = "recvWindow=15000&timestamp=" + timestamp;
            string signature = "&signature=" + BitConverter.ToString(new HMACSHA256(Encoding.ASCII.GetBytes(API_Secret)).ComputeHash(Encoding.ASCII.GetBytes(dataQueryString))).Replace("-", string.Empty).ToLower();
            string finalQuery = baseurl + dataQueryString + signature;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", API_Key);
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            HttpResponseMessage response = await client.GetAsync(finalQuery);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;

        }

        public async Task<string> getTrades(string API_Key, String API_Secret)
        {
            string baseurl = "https://testnet.binance.vision/api/v3/rateLimit/order?";
            string timestamp = Math.Round(Convert.ToDecimal(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds), 0).ToString();
            string dataQueryString = "timestamp=" + timestamp;
            string signature = "&signature=" + BitConverter.ToString(new HMACSHA256(Encoding.ASCII.GetBytes(API_Secret)).ComputeHash(Encoding.ASCII.GetBytes(dataQueryString))).Replace("-", string.Empty).ToLower();
            string finalQuery = baseurl + dataQueryString + signature;
            
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", API_Key);
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            HttpResponseMessage response = await client.GetAsync(finalQuery);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;

        }

        public async Task<string> getAllOrders(string API_Key, String API_Secret)
        {
            string baseurl = "https://testnet.binance.vision/api/v3/allOrders?"; 
            string timestamp = Math.Round(Convert.ToDecimal(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds), 0).ToString();
            string dataQueryString = "symbol=BTCUSDT&timestamp=" + timestamp;
            string signature = "&signature=" + BitConverter.ToString(new HMACSHA256(Encoding.ASCII.GetBytes(API_Secret)).ComputeHash(Encoding.ASCII.GetBytes(dataQueryString))).Replace("-", string.Empty).ToLower();
            string finalQuery = baseurl + dataQueryString + signature;
            

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", API_Key);
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            HttpResponseMessage response = await client.GetAsync(finalQuery);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;


        }

    }
}
