using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace apw.Helpers
{
    public static class WebHelper
    {
        private static readonly HttpClient _client = new HttpClient(new HttpClientHandler
        {
            AutomaticDecompression = (DecompressionMethods)0xFF
        });

        public static async Task<string> GetHtml(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await _client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}