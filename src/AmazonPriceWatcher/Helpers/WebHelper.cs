using System.Net;

namespace AmazonPriceWatcher.Helpers;

internal static class WebHelper
{
    private static readonly HttpClient client = new HttpClient(new HttpClientHandler
    {
        AutomaticDecompression = DecompressionMethods.All,
    });

    public static async Task<string> GetHtml(string url)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        HttpResponseMessage response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
}
