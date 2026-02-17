using RestSharp;
using Serilog;

namespace PracticalTask2.Core.APIClient
{
    public class ApiClient
    {
        private readonly RestClient _client;
        private readonly ILogger _logger;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
            _logger = Log.Logger;
        }

        public async Task<RestResponse<T>> SendAsync<T>(RestRequest request)
        {
            _logger.Information($"[API] Sending request: {request.Method} {request.Resource}");

            var response = await _client.ExecuteAsync<T>(request);

            LogResponse(response);

            return response;
        }

        public async Task<RestResponse> SendAsync(RestRequest request)
        {
            _logger.Information($"[API] Sending request: {request.Method} {request.Resource}");

            var response = await _client.ExecuteAsync(request);

            LogResponse(response);

            return response;
        }

        private void LogResponse(RestResponse response)
        {
            _logger.Information($"[API] Response Status: {(int)response.StatusCode} {response.StatusCode}");
            _logger.Debug($"[API] Response Body: {response.Content}");

            if (!response.IsSuccessful)
                _logger.Error($"[API] Request failed: {response.ErrorMessage}");
        }
    }
}
