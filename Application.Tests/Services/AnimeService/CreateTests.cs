using Application.Services;
using Application.Services.AnimeService;
using Core.Domain.Entities;
using Core.Enums;
using FluentAssertions;
using Infrastructure.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests.Services.AnimeService
{
    public class CreateTests
    {
        private static DataContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new DataContext(options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        [Fact]
        public async void Create_CreateAnimeWithoutAllTitles_ReturnsFailure()
        {
            //Arrange
            var anime = new Anime
            {
                StudioId = Guid.NewGuid(),
                PictureId = Guid.NewGuid().ToString(),
                TitleInEnglish = null,
                TitleInJapanese = null,
                TitleInUkrainian = null,
                TitleInRussian = null,
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
            var dataContext = GetDbContext();

            //Act
            var createCommand = new Create.Command
            {
                Anime = anime
            };

            var handler = new Create.Handler(dataContext);

            var result = await handler.Handle(createCommand, CancellationToken.None);

            //Assert
            result.Should().BeEquivalentTo(Result<Unit>.Failure("Failed to create an anime."));
        }
        [Fact]
        public async void Create_CreateAnimeWhereStartDateLaterThenEndDate_ReturnsFailure()
        {
            //Arrange
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
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow,
                ReleasedEpisodes = 1,
                ExpectedEpisodes = 24,
                OriginalSource = OriginalSourceEnum.Undefined.ToString(),
                Description = "Short desc.",
                AdminsNote = "Admins test note.",
            };
            var dataContext = GetDbContext();

            //Act
            var createCommand = new Create.Command
            {
                Anime = anime
            };

            var handler = new Create.Handler(dataContext);

            var result = await handler.Handle(createCommand, CancellationToken.None);

            //Assert
            result.Should().BeEquivalentTo(Result<Unit>.Failure("Failed to create an anime."));
        }
        [Fact]
        public async void Create_CreateAnimeWhereTypeIsNonEnumEquivalent_ReturnsFailure()
        {
            //Arrange
            var anime = new Anime
            {
                StudioId = Guid.NewGuid(),
               PictureId = Guid.NewGuid().ToString(),
                TitleInEnglish = "Title in English",
                TitleInJapanese = "Title in Japanese",
                TitleInUkrainian = "Title in Ukrainian",
                TitleInRussian = "Title in Russian",
                Type = "Some type of anime. Test type. Be happy.",
                AnimeState = AnimeStateEnum.Undefined.ToString(),
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow,
                ReleasedEpisodes = 1,
                ExpectedEpisodes = 24,
                OriginalSource = OriginalSourceEnum.Undefined.ToString(),
                Description = "Short desc.",
                AdminsNote = "Admins test note.",
            };
            var dataContext = GetDbContext();

            //Act
            var createCommand = new Create.Command
            {
                Anime = anime
            };

            var handler = new Create.Handler(dataContext);

            var result = await handler.Handle(createCommand, CancellationToken.None);

            //Assert
            result.Should().BeEquivalentTo(Result<Unit>.Failure("Failed to create an anime."));
        }
        [Fact]
        public async void Create_CreateAnimeWhereAnimeStateIsNonEnumEquivalent_ReturnsFailure()
        {
            //Arrange
            var anime = new Anime
            {
                StudioId = Guid.NewGuid(),
                PictureId = Guid.NewGuid().ToString(),
                TitleInEnglish = "Title in English",
                TitleInJapanese = "Title in Japanese",
                TitleInUkrainian = "Title in Ukrainian",
                TitleInRussian = "Title in Russian",
                Type = TypeOfAnimeEnum.Undefined.ToString(),
                AnimeState = "Anime state. Don't worry",
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow,
                ReleasedEpisodes = 1,
                ExpectedEpisodes = 24,
                OriginalSource = OriginalSourceEnum.Undefined.ToString(),
                Description = "Short desc.",
                AdminsNote = "Admins test note.",
            };
            var dataContext = GetDbContext();

            //Act
            var createCommand = new Create.Command
            {
                Anime = anime
            };

            var handler = new Create.Handler(dataContext);

            var result = await handler.Handle(createCommand, CancellationToken.None);

            //Assert
            result.Should().BeEquivalentTo(Result<Unit>.Failure("Failed to create an anime."));
        }
        [Fact]
        public async void Create_CreateAnimeWhereOriginalSourceIsNonEnumEquivalent_ReturnsFailure()
        {
            //Arrange
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
                StartDate = DateTime.UtcNow.AddDays(1),
                EndDate = DateTime.UtcNow,
                ReleasedEpisodes = 1,
                ExpectedEpisodes = 24,
                OriginalSource = "We are don't know about original source. We don't like anime.",
                Description = "Short desc.",
                AdminsNote = "Admins test note.",
            };
            var dataContext = GetDbContext();

            //Act
            var createCommand = new Create.Command
            {
                Anime = anime
            };

            var handler = new Create.Handler(dataContext);

            var result = await handler.Handle(createCommand, CancellationToken.None);

            //Assert
            result.Should().BeEquivalentTo(Result<Unit>.Failure("Failed to create an anime."));
        }
    }
}