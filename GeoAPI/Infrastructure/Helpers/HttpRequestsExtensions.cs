using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public static class HttpRequestsExtensions
    {
        public static async Task<T> GetRequest<T>(this IHttpClientFactory clientFactory, string url, string queryParams = null)
        {
            var uri = url + (queryParams != null ? $"?{queryParams}" : "");
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode) throw new HttpRequestException();

            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }

}