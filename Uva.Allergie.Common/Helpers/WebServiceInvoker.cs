using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Uva.Allergie.Common.Helpers
{
    public interface IWebServiceInvoker
    {
        Task<HttpResponseMessage> Post(string url, string body);
        Task<HttpResponseMessage> Get(string url);
    }
    public class WebServiceInvoker : IWebServiceInvoker
    {
        private readonly HttpMessageHandler _httpMessageHandler;
        private readonly ILogger _logger;
        public WebServiceInvoker(HttpMessageHandler httpMessageHandler, ILogger logger)
        {
            _logger = logger;
            _httpMessageHandler = httpMessageHandler;
        }

        public async Task<HttpResponseMessage> Post(string url, string body)
        {
            try
            {
                using (var httpClient = new HttpClient(_httpMessageHandler, false))
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.Timeout = new TimeSpan(30, 0, 0);
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    _logger.LogInformation("StartingRequest");
                    return await httpClient.PostAsync(new Uri(url),
                         new StringContent(body, Encoding.UTF8, "application/json"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest, Content = new StringContent(ex.ToString()) };
            }
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            try
            {
                using (var httpClient = new HttpClient(_httpMessageHandler, false))
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.Timeout = new TimeSpan(30, 0, 0);
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    _logger.LogInformation("StartingRequest");
                    return await httpClient.GetAsync(new Uri(url));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest, Content = new StringContent(ex.ToString()) };
            }
        }
    }
}
