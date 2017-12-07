using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Should;
using SoundsUp.Domain.Entities;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace SoundsUp.WebHost.IntergrationTests
{
    public class AuthControllerTests
    {
        private const string RepositoryUrl = "https://soundsupwebhost.azurewebsites.net/auth/";

        private readonly RestClient _restClient;

        public AuthControllerTests()
        {
            _restClient = new RestClient(RepositoryUrl);
        }

        #region InstallationController Tests

        #region Register Tests

        [Fact, Trait("Category", "Integration")]
        public async Task<Login> Register_ValidParameter_Status200()
        {
            //Arrange
            var randomString = RandomString(3);

            var email = $"{randomString}@{randomString}.com";
            var entity = new RegisterViewModel
            {
                Email = email,
                Password = randomString,
                DisplayName = randomString
            };

            var request = new RestRequest("register",Method.POST);
            request.AddJsonBody(entity);

            // Act
            var result = await _restClient.ExecuteTaskAsync(request);

            // Assert
            result.StatusCode.ShouldEqual(HttpStatusCode.OK);
            JObject.Parse(result.Content)["token"].ShouldNotBeNull();

            return new Login
            {
                Email = email,
                Password = randomString
            };
        }

        [Fact, Trait("Category", "Integration")]
        public async Task Register_BodyIsNull_Status400()
        {
            //Arrange
            var request = new RestRequest("Register",Method.POST);
            request.AddJsonBody(null);

            // Act
            var result = await _restClient.ExecuteTaskAsync(request);

            // Assert
            result.StatusCode.ShouldEqual(HttpStatusCode.BadRequest);
            JObject.Parse(result.Content).ShouldNotBeNull();
        }

        #endregion Register Tests

        #region Login Tests

        [Fact, Trait("Category", "Integration")]
        public async Task Login_ValidParameter_Status200()
        {
            //Arrange
            var login = await Register_ValidParameter_Status200();
            var request = new RestRequest("login", Method.POST);
            request.AddJsonBody(login);

            // Act
            var result = await _restClient.ExecuteTaskAsync(request);

            // Assert
            result.StatusCode.ShouldEqual(HttpStatusCode.OK);
            JObject.Parse(result.Content)["token"].ShouldNotBeNull();
        }


        [Fact, Trait("Category", "Integration")]
        public async Task Login_BodyIsNull_Status400()
        {
            //Arrange
            var request = new RestRequest("login", Method.POST);
            request.AddJsonBody(null);

            // Act
            var result = await _restClient.ExecuteTaskAsync(request);

            // Assert
            result.StatusCode.ShouldEqual(HttpStatusCode.BadRequest);
            JObject.Parse(result.Content).ShouldNotBeNull();
        }


        #endregion Login Tests

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #endregion InstallationController Tests
    }
}