using System;
using System.Net;
using System.Net.Http;
using AutoFixture;
using FluentAssertions;
using FuzzyDollop.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xbehave;
using Xunit;

namespace FuzzyDollop.IntegrationTests
{
    public class GetTrainerByIdScenarios : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly IFixture _fixture;
        private readonly HttpClient _httpClient;

        public GetTrainerByIdScenarios(WebApplicationFactory<Startup> factory)
        {
            _fixture = new Fixture();
            _httpClient = factory.CreateDefaultClient();
        }

        [Scenario]
        public void TrainerDoesNotExist(Guid trainerId, HttpResponseMessage response)
        {
            "Given the trainerId does not match any existing records"
                .x(() => { trainerId = _fixture.Create<Guid>(); });

            "When the trainer is requested"
                .x(async () => response = await _httpClient.GetAsync($"trainers/{trainerId}"));

            "Then the response should be 404 Not Found"
                .x(() => { response.StatusCode.Should().Be(HttpStatusCode.NotFound); });
        }
    }
}
