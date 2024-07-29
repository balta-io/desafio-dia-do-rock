using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace DesafioDiaDoRock.Aspire.Teste.Tests
{
    public class IntegrationTest1
    {
        [Fact]
        public async Task GetWebResourceRootReturnsOkStatusCode()
        {
            // Arrange
            var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.DesafioDiaDoRock_Aspire_AppHost>();
            await using var app = await appHost.BuildAsync();
            await app.StartAsync();

            // Act
            var httpClient = app.CreateHttpClient("DesafioDiaDoRockApi");
            var response = await httpClient.GetAsync("/");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetEventReturnsOkStatusCode()
        {
            // Arrange
            var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.DesafioDiaDoRock_Aspire_AppHost>();
            await using var app = await appHost.BuildAsync();
            await app.StartAsync();

            // Act
            var httpClient = app.CreateHttpClient("DesafioDiaDoRockApi");
            var response = await httpClient.GetAsync("/Event");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task SearchEventReturnsOkStatusCode()
        {
            // Arrange
            var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.DesafioDiaDoRock_Aspire_AppHost>();
            await using var app = await appHost.BuildAsync();
            await app.StartAsync();

            // Act
            var httpClient = app.CreateHttpClient("DesafioDiaDoRockApi");
            var response = await httpClient.GetAsync("/Event/some-search-term");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateEventReturnsOkStatusCode()
        {
            // Arrange
            var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.DesafioDiaDoRock_Aspire_AppHost>();
            await using var app = await appHost.BuildAsync();
            await app.StartAsync();

            var newEvent = new
            {
                Name = "Rock Concert",
                Date = "2024-07-19",
                Location = "Stadium",
                Description = "A rock concert event."
            };

            // Act
            var httpClient = app.CreateHttpClient("DesafioDiaDoRockApi");
            var response = await httpClient.PostAsJsonAsync("/Event", newEvent);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
