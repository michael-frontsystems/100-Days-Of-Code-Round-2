using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PrismDemoR2.Services.Interface;

namespace PrismDemoR2.Services
{
    public class HttpService : IHttpService
    {
        private static HttpClient httpClient;
        private JsonSerializer _serializer;

        public HttpService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            _serializer = new JsonSerializer();
        }

        public async Task<T> GetAsync<T>(string resource, CancellationToken? ct)
        {
            var requestUri = new Uri(resource);

            var token = ct ?? new CancellationTokenSource(new TimeSpan(0, 0, 100)).Token;

            var response = await httpClient.GetAsync(requestUri.AbsoluteUri, HttpCompletionOption.ResponseHeadersRead, token);

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(content);
                    Console.WriteLine(json);

                    return _serializer.Deserialize<T>(json);
                }

                throw new ApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = await response.Content.ReadAsStringAsync()
                };
            }
        }

        public void SetTimeOut(int seconds)
        {
            httpClient.Timeout = TimeSpan.FromSeconds(seconds);
        }
    }
}
