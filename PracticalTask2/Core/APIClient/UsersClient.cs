using System.Text.Json;
using System.Text.Json.Serialization;
using PracticalTask2.Business.Models.API;
using RestSharp;
using RestSharp.Serializers.Json;

namespace PracticalTask2.Core.APIClient
{
    public class UsersClient
    {
        private readonly IRestClient _client;
        private const string Endpoint = "users";

        public UsersClient(string endpoint)
        {
            var serializerOptions = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            _client = new RestClient(
                options: new() { BaseUrl = new(endpoint) },
                configureSerialization: s => s.UseSystemTextJson(serializerOptions));
        }

        public async Task<RestResponse<List<User>>> GetUsers()
        {
            var request = new RestRequest(Endpoint, Method.Get);
            var response = await _client.ExecuteAsync<List<User>>(request);
            return response;
        }

        public async Task<RestResponse<User>> CreateUser(User user)
        {
            var request = new RestRequest(Endpoint, Method.Post);
            request.AddJsonBody(user);
            var response = await _client.ExecuteAsync<User>(request);
            return response;
        }
        public async Task<RestResponse<User>> UpdateUser(string userId, User user)
        {
            var request = new RestRequest($"{Endpoint}/{userId}", Method.Put);
            request.AddJsonBody(user);

            var response = await _client.ExecuteAsync<User>(request);
            return response;
        }
        public async Task<RestResponse> DeleteUser(string userId)
        {
            var request = new RestRequest($"{Endpoint}/{userId}", Method.Delete);
            var response = await _client.ExecuteAsync(request);
            return response;
        }

        public async Task<RestResponse> GetInvalidEndpoint()
        {
            var request = new RestRequest("invalidendpoint", Method.Get);
            var response = await _client.ExecuteAsync(request);
            return response;
        }
    }
}
