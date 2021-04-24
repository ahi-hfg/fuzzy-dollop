using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using FuzzyDollop.Api;
using FuzzyDollop.Domain.Entities;
using FuzzyDollop.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xbehave;
using Xunit;

namespace FuzzyDollop.IntegrationTests
{
    public class GetTrainerByIdScenarios : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly IFixture _fixture;
        private DexContext _dbContext;
        private readonly HttpClient _httpClient;

        public GetTrainerByIdScenarios(WebApplicationFactory<Startup> factory)
        {
            _fixture = new Fixture();
            _httpClient = factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services =>
                    {
                        _dbContext = services.BuildServiceProvider().GetRequiredService<DexContext>();
                    });
                })
                .CreateClient();
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

        [Scenario]
        public void TrainerExists(Guid trainerId, HttpResponseMessage response)
        {
            "Given the trainerId does has a match to an existing record"
                .x(async () =>
                {
                    trainerId = _fixture.Create<Guid>();
                    await GivenExistingTrainer(trainerId);
                });

            "When the trainer is requested"
                .x(async () => response = await _httpClient.GetAsync($"trainers/{trainerId}"));

            "Then the response should be 200 OK"
                .x(() => { response.StatusCode.Should().Be(HttpStatusCode.OK); });
        }

        private async Task GivenExistingTrainer(Guid trainerId)
        {
            var trainer = _fixture.Build<Trainer>().With(x => x.Id, trainerId).Create();
            await _dbContext.AddAsync(trainer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
