using PracticalTask2.Business.Models.API;
using RestSharp;
using Serilog;

namespace PracticalTask2.Core.APIClient
{
    public class UsersClient
    {
        private readonly ApiClient _apiClient;
        private readonly ILogger _logger;

        public UsersClient(string baseUrl)
        {
            _apiClient = new ApiClient(baseUrl);
            _logger = Log.Logger;
        }

        public async Task<RestResponse<List<User>>> GetUsers()
        {
            var request = new RequestBuilder()
                .WithEndpoint("users")
                .WithMethod(Method.Get)
                .Build();

            return await _apiClient.SendAsync<List<User>>(request);
        }

        public async Task<RestResponse<User>> CreateUser(User user)
        {
            var request = new RequestBuilder()
                .WithEndpoint("users")
                .WithMethod(Method.Post)
                .WithJsonBody(user)
                .Build();

            return await _apiClient.SendAsync<User>(request);
        }

        public async Task<RestResponse> GetInvalidEndpoint()
        {
            var request = new RequestBuilder()
                .WithEndpoint("invalidendpoint")
                .WithMethod(Method.Get)
                .Build();

            return await _apiClient.SendAsync(request);
        }
    }
}
