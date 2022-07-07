using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http;

namespace MinimalAPIT.SignedAPI
{
    public class MyTrades
    {
        public async Task<string> myTrades()
        {
            //Testnet Keys
            string API_Key = "C1QdD0R3LvdgFXFjKQSQUtbeHQVMBZAXW9XKs0eshOepUUiyw6c4840CfCXp1Z8x";
            string API_Secret = "5iNjgz7CZ1yUK5P3LqgswFRWqtkiraTUhWyyBGAEnMUHbSObzWLp5FWxfqDgmQGp";
            //API Keys
            //string API_Key = "jVWv9p2Ca2ynxFFx3fPel4uztkXUcBFt5tbuhg0vlMFMNOmCsD5VVQqkX3Pfhwtt";
            //string API_Secret = "LZw6njP1b8j0lExz8JlFAA2MH1i8cJ1I9oNClFZJEdIW1tWZebzmdmoCbxcs3Up4";
            string baseurl = "https://testnet.binance.vision/api/v3/account?";
            //string baseurl = "https://api.binance.com/api/v3/myTrades?";
            string dataQueryString = "recvWindow=15000&timestamp=" + Math.Round(Convert.ToDecimal(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds), 0).ToString();
            //string dataQueryString = "symbol=SLPBUSD&timestamp=" + Math.Round(Convert.ToDecimal(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds), 0).ToString();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", API_Key);
            client.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            HttpResponseMessage response = await client.GetAsync(baseurl + dataQueryString + "&signature=" + BitConverter.ToString(new HMACSHA256(Encoding.ASCII.GetBytes(API_Secret)).ComputeHash(Encoding.ASCII.GetBytes(dataQueryString))).Replace("-", string.Empty).ToLower());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;

        }

    }
}
