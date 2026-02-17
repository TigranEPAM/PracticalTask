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

        public async Task<List<User>> GetUsers()
        {
            var request = new RestRequest(Endpoint, Method.Get);
            var response = await _client.GetAsync<List<User>>(request);
            return response!;
        }

        public async Task<User> CreateUser(User user)
        {
            var request = new RestRequest(Endpoint, Method.Post);
            request.AddJsonBody(user);

            var response = await _client.PostAsync<User>(request);
            return response!;
        }

        public async Task<User> UpdateUser(string userId, User user)
        {
            var request = new RestRequest($"{Endpoint}/{userId}", Method.Put);
            request.AddJsonBody(user);

            var response = await _client.PutAsync<User>(request);
            return response!;
        }
        public async Task<bool> DeleteUser(string userId)
        {
            var request = new RestRequest($"{Endpoint}/{userId}", Method.Delete);
            var response = await _client.DeleteAsync(request);

            // Returns true if the status code is 200 or 204
            return response.IsSuccessful;
        }
    }
}
