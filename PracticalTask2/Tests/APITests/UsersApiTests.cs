using FluentAssertions;
using NUnit.Framework;
using PracticalTask2.Core.APIClient;
using PracticalTask2.Core.Configuration;

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
            var response = await _usersClient.GetUsers();

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var users = response.Data!;
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
        }

        [Test]
        public async Task Task2_GetUsers_ShouldValidateContentTypeHeader()
        {
            var response = await _usersClient.GetUsers();

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            response.ContentType.Should().Be("application/json; charset=utf-8");
        }

        [Test]
        public async Task Task3_GetUsers_ShouldValidateUniqueIdsAndNonEmptyFields()
        {
            var response = await _usersClient.GetUsers();

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var users = response.Data!;
            users.Should().NotBeNull();
            users.Count.Should().Be(10);
            users.Select(u => u.Id).Distinct().Count().Should().Be(10);

            users.Should().AllSatisfy(user =>
            {
                user.Name.Should().NotBeNullOrEmpty();
                user.Username.Should().NotBeNullOrEmpty();
                user.Company.Should().NotBeNull();
                user.Company.Name.Should().NotBeNullOrEmpty();
            });
        }

        [Test]
        public async Task Task4_CreateUser_ShouldReturnCreatedUserWithId()
        {
            var newUser = new Business.Models.API.User
            {
                Name = "John Doe",
                Username = "johndoe"
            };

            var response = await _usersClient.CreateUser(newUser);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            var createdUser = response.Data!;
            createdUser.Should().NotBeNull();
            createdUser.Id.Should().BeGreaterThan(0);
            createdUser.Name.Should().Be(newUser.Name);
            createdUser.Username.Should().Be(newUser.Username);
        }

        [Test]
        public async Task Task5_InvalidEndpoint_ShouldReturn404()
        {
            var response = await _usersClient.GetInvalidEndpoint();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}
