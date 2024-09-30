using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Infrastructure.DbContext;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using Core.Domain.Entities;
using Application.Services;
using MediatR;
using Core.DTO.Entities;
using AutoMapper;
using Core.Enums;
using System.Text.Json;
using System.Text;
using FluentAssertions;


namespace API.Tests.Integration
{

    public class AnimeControllerIntegrationTest : IClassFixture<ProgramWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public AnimeControllerIntegrationTest(ProgramWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task CanCreateAndRetrieveAnime()
        {
            // Arrange
            var anime = new Anime
            {
                StudioId = Guid.NewGuid(),
                PictureId = Guid.NewGuid().ToString(),
                TitleInEnglish = "Title in English",
                TitleInJapanese = "Title in Japanese",
                TitleInUkrainian = "Title in Ukrainian",
                TitleInRussian = "Title in Russian",
                Type = TypeOfAnimeEnum.Undefined.ToString(),
                AnimeState = AnimeStateEnum.Undefined.ToString(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(7),
                ReleasedEpisodes = 1,
                ExpectedEpisodes = 24,
                OriginalSource = OriginalSourceEnum.Undefined.ToString(),
                Description = "Short desc.",
                AdminsNote = "Admins test note.",
            };
            // Act: Create a new Anime entry
            var createResponse = await _client.PostAsJsonAsync("/api/anime", anime);
            createResponse.EnsureSuccessStatusCode();

            var createdAnime = await createResponse.Content.ReadFromJsonAsync<Result<Unit>>();

            // Assert: Check that the Anime was created successfully
            Assert.NotNull(createdAnime);
            Assert.Equivalent(Result<Unit>.Success(Unit.Value), createdAnime);

        }
    }

}