using RestSharp;
using Serilog;

namespace PracticalTask2.Core.APIClient
{
    public class RequestBuilder
    {
        private readonly RestRequest _request;
        private readonly ILogger _logger;

        public RequestBuilder()
        {
            _request = new RestRequest();
            _logger = Log.Logger;
        }

        public RequestBuilder WithEndpoint(string endpoint)
        {
            _logger.Information($"[Builder] Set endpoint: {endpoint}");
            _request.Resource = endpoint;
            return this;
        }

        public RequestBuilder WithMethod(Method method)
        {
            _logger.Information($"[Builder] Set method: {method}");
            _request.Method = method;
            return this;
        }

        public RequestBuilder WithJsonBody(object body)
        {
            _logger.Information("[Builder] Adding JSON body");
            _request.AddJsonBody(body);
            return this;
        }

        public RequestBuilder WithHeader(string name, string value)
        {
            _logger.Information($"[Builder] Adding header: {name}");
            _request.AddHeader(name, value);
            return this;
        }

        public RestRequest Build()
        {
            _logger.Information("[Builder] Request build completed");
            return _request;
        }
    }
}
