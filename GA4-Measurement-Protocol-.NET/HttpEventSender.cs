using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Keyoti.GA4
{
    public class HttpEventSender
    {
        HttpClient client;
        //TODO put all GA paramters in an easy to modify object
        string baseGAUrl = "https://www.google-analytics.com/mp/collect";
        public HttpEventSender()
        {
            client = new HttpClient();
        }

        public async Task<HttpResponseMessage> SendAsync(string measurementId, string apiSecret, string payload)
        {
            UriBuilder endPoint = new UriBuilder(baseGAUrl);
            endPoint.Query = $"measurement_id={measurementId}&api_secret={apiSecret}";
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var resp = await client.PostAsync(endPoint.Uri, content);
            string body = await resp.Content.ReadAsStringAsync();
            return resp;
        }
    }
}