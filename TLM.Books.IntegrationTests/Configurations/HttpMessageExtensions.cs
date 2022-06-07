using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TLM.Books.IntegrationTests.Configurations;

public static class HttpMessageExtensions
{
    public static async Task<T> GetContentAsync<T>(this HttpResponseMessage httpResponse)
    {
        var content = await httpResponse.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(content, JsonExtensions.SerializerOptions());
    }
}