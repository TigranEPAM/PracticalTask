using System.Net;
using FluentAssertions;
using NUnit.Framework;
using PracticalTask2.Core.APIClient;
using PracticalTask2.Core.Configuration;
using PracticalTask2.Core.Utilities;

namespace PracticalTask2.Tests.APITests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("API")]
    public class UsersApiTests
    {
        private UsersClient _usersClient = new(FrameworkConfig.ApiBaseUrl);

        [Test]
        public async Task Task1_GetUsers_ShouldReturnListOfUsers()
        {
            Log.Logger.Information("=== Task1 START ===");

            Log.Logger.Information("Step 1: Send GET /users request");
            var response = await _usersClient.GetUsers();

            Log.Logger.Information("Step 2: Validate status code");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            Log.Logger.Information("Step 3: Validate users response body");
            var users = response.Data!;
            users.Should().NotBeNullOrEmpty();

            foreach (var user in users)
            {
                user.Id.Should().BeGreaterThan(0);
                user.Name.Should().NotBeNullOrEmpty();
                user.Username.Should().NotBeNullOrEmpty();
                user.Email.Should().NotBeNullOrEmpty();
                user.Company.Should().NotBeNull();
                user.Company.Name.Should().NotBeNullOrEmpty();
                user.Address.Should().NotBeNull();
                user.Address.Street.Should().NotBeNullOrEmpty();
                user.Phone.Should().NotBeNullOrEmpty();
                user.Website.Should().NotBeNullOrEmpty();
            }

            Log.Logger.Information("=== Task1 PASSED ===");
        }

        [Test]
        public async Task Task2_GetUsers_ShouldValidateContentTypeHeader()
        {
            Log.Logger.Information("========== Task2 START ==========");

            Log.Logger.Information("Step 1: Sending GET /users request");
            var response = await _usersClient.GetUsers();

            Log.Logger.Information("Step 2: Validating status code is 200 OK");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            Log.Logger.Information("Step 3: Validating Content-Type header");
            response.ContentType.Should().Be("application/json");

            Log.Logger.Information("========== Task2 PASSED ==========");
        }

        [Test]
        public async Task Task3_GetUsers_ShouldValidateUniqueIdsAndNonEmptyFields()
        {
            Log.Logger.Information("========== Task3 START ==========");

            Log.Logger.Information("Step 1: Sending GET /users request");
            var response = await _usersClient.GetUsers();

            Log.Logger.Information("Step 2: Validating status code is 200 OK");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var users = response.Data!;

            Log.Logger.Information("Step 3: Validating users count equals 10");
            users.Count.Should().Be(10);

            Log.Logger.Information("Step 4: Validating unique IDs");
            users.Select(u => u.Id).Distinct().Count().Should().Be(10);

            Log.Logger.Information("Step 5: Validating required fields for each user");
            users.Should().AllSatisfy(user =>
            {
                user.Name.Should().NotBeNullOrEmpty();
                user.Username.Should().NotBeNullOrEmpty();
                user.Company.Should().NotBeNull();
                user.Company.Name.Should().NotBeNullOrEmpty();
            });

            Log.Logger.Information("========== Task3 PASSED ==========");
        }

        [Test]
        public async Task Task4_CreateUser_ShouldReturnCreatedUserWithId()
        {
            Log.Logger.Information("========== Task4 START ==========");

            Log.Logger.Information("Step 1: Preparing new user payload");
            var newUser = new Business.Models.API.User
            {
                Name = "John Doe",
                Username = "johndoe"
            };

            Log.Logger.Information("Step 2: Sending POST /users request");
            var response = await _usersClient.CreateUser(newUser);

            Log.Logger.Information("Step 3: Validating status code is 201 Created");
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            Log.Logger.Information("Step 4: Validating response body");
            var createdUser = response.Data!;
            createdUser.Should().NotBeNull();
            createdUser.Id.Should().BeGreaterThan(0);
            createdUser.Name.Should().Be(newUser.Name);
            createdUser.Username.Should().Be(newUser.Username);

            Log.Logger.Information("========== Task4 PASSED ==========");
        }

        [Test]
        public async Task Task5_InvalidEndpoint_ShouldReturn404()
        {
            Log.Logger.Information("=== Task5 START ===");

            Log.Logger.Information("Step 1: Send GET /invalidendpoint");
            var response = await _usersClient.GetInvalidEndpoint();

            Log.Logger.Information("Step 2: Validate 404 status code");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

            Log.Logger.Information("=== Task5 PASSED ===");
        }
    }
}
