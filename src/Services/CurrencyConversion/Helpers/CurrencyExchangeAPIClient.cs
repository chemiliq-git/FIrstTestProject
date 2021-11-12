using CurrencyConversion.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyConversion.Helpers
{
    public class CurrencyExchangeAPIClient
    {
        private readonly string url;

        public CurrencyExchangeAPIClient(string url)
        {
            this.url = url;
        }

        public async Task<CurrencyExchangeResult> InvokeCurrencyExchangeAPIAsync(CurrencyExchangeInput inputData)
        {
            try
            {
                var json = JsonSerializer.Serialize(inputData);
                //construct content to send
                var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(this.url),
                    Content = content
                };

                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var fileContent = await response.Content.ReadAsStringAsync();
                    var stream = await response.Content.ReadAsStreamAsync();

                    JsonSerializerOptions options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };

                    var parseResponse = await JsonSerializer.DeserializeAsync<CurrencyExchangeResult>(stream, options);
                    return parseResponse;
                }

                return new CurrencyExchangeResult() { ErrorMessage = "Can not connect to service" };
            }
            catch (HttpRequestException ex)
            {
                return new CurrencyExchangeResult() { ErrorMessage = ex.Message };
            }
        }
    }
}
