using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BookmarkWeb.API.Database;

namespace BookmarkWeb.API.Services
{
    public interface IApiService
    {
        Task<HttpResponseMessage> GetAsync(string path, NameValueCollection query, bool isStreaming = false, string fromClass = "", string fromMethod = "");
        Task<HttpResponseMessage> PostAsync(string path, object? body, bool isStreaming = false, string fromClass = "", string fromMethod = "");
        void Setting(string baseUrl);
    }
    public class ApiService : IApiService
    {
        private readonly DataContext _context;
        private readonly ILogger<ApiService> _logger;
        private string _className = "";
        private string _baseUrl = "";

        public ApiService(
            DataContext context,
            IConfiguration configuration,
            ILogger<ApiService> logger
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _className = GetType().Name;
        }
        static string GetActualAsyncMethodName([CallerMemberName] string name = null) => name;

        public void Setting(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public async Task<HttpResponseMessage> GetAsync(string path, NameValueCollection query, bool isStreaming = false, string fromClass = "", string fromMethod = "")
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                HttpResponseMessage response = await CallAPI(path, query, isStreaming, fromClass, fromMethod, "GET");
                _logger.LogInformation($"[{_className}][{method}] End");
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                return null;
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string path, object? body, bool isStreaming = false, string fromClass = "", string fromMethod = "")
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                HttpResponseMessage response = await CallAPI(path, null, isStreaming, fromClass, fromMethod, "POST", Newtonsoft.Json.JsonConvert.SerializeObject(body));
                _logger.LogInformation($"[{_className}][{method}] End");
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                return null;
            }
        }

        private async Task<HttpResponseMessage> CallAPI(string path,
            NameValueCollection? query,
            bool isStreaming = false,
            string fromClass = "",
            string fromMethod = "",
            string apiMethod = "GET",
            string body = "")
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                if (String.IsNullOrEmpty(fromClass))
                {
                    fromClass = _className;
                }
                if (String.IsNullOrEmpty(fromMethod))
                {
                    fromMethod = method;
                }
                UriBuilder builder = new UriBuilder(_baseUrl + path + ToQueryString(query));
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0 AppleWebKit/537.11(KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11");

                HttpRequestMessage request = null;
                HttpResponseMessage response = null;
                if (apiMethod == "GET")
                {
                    request = new HttpRequestMessage(HttpMethod.Get, builder.ToString());
                }
                else if (apiMethod == "POST")
                {
                    request = new HttpRequestMessage(HttpMethod.Post, builder.ToString())
                    {
                        Content = new StringContent(body, Encoding.UTF8, "application/json")
                    };
                }
                var completionOption = isStreaming ? HttpCompletionOption.ResponseHeadersRead : HttpCompletionOption.ResponseContentRead;
                response = await client.SendAsync(request, completionOption);
                
                _logger.LogInformation($"[{_className}][{method}] End");
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                return null;
            }
        }

        private string ToQueryString(NameValueCollection nvc)
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                if (nvc == null) return string.Empty;
                StringBuilder sb = new StringBuilder();
                foreach (string key in nvc.Keys)
                {
                    if (string.IsNullOrWhiteSpace(key)) continue;
                    string[] values = nvc?.GetValues(key) ?? Array.Empty<string>();
                    if (values == null) continue;
                    foreach (string value in values)
                    {
                        sb.Append(sb.Length == 0 ? "?" : "&");
                        sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));
                    }
                }
                _logger.LogInformation($"[{_className}][{method}] End");
                return sb.ToString();
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                return "";
            }
        }
    }
}