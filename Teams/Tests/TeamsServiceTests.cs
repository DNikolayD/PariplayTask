using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Services;
using Services.Dtos;
using Services.Interfaces;

namespace Tests
{
    public class TeamsServiceTests
    {
        private Mock<ITeamsRepository> _repositoryMock;
        private Mock<IMatchesService> _matchesServiceMock;
        private Mock<IMatchesRepository> _matchesRepositoryMock;

        private TeamsService _service;
        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<ITeamsRepository>();
            _matchesServiceMock = new Mock<IMatchesService>();
            _matchesRepositoryMock = new Mock<IMatchesRepository>();
            _service = new TeamsService(_repositoryMock.Object, new NullLogger<TeamsService>(),
                _matchesServiceMock.Object, _matchesRepositoryMock.Object);
        }

        [Test]
        public void GetTeamsOrderedByRanking_ReturnsTeams()
        {
            //Arrange
            var dbTeamsList = new List<Team>
            {
                new()
                {
                    Score = 10
                },
                new()
                {
                    Score = 20
                }
            };
            _repositoryMock.Setup(x => x.GetTeams()).Returns(dbTeamsList);
            var teamOne = new TeamsDto
            {
                Score = 20
            };
            var teamTwo = new TeamsDto
            {
                Score = 10
            };
            var expected = new List<TeamsDto>
            {
                teamOne,
                teamTwo
            };
            //Act
            var actual = _service.GetTeamsOrderedByRanking();
            Assert.Multiple(() =>
            {
                //Assert
                Assert.That(actual, Has.Count.EqualTo(expected.Count));
                Assert.That(expected[0].Score, Is.EqualTo(actual[0].Score));
            });
        }

        [Test]
        public void GetTeams_ReturnsTeams()
        {
            //Arrange
            var dbTeamsList = new List<Team>
            {
                new()
                {
                    Score = 10
                },
                new()
                {
                    Score = 20
                }
            };
            _repositoryMock.Setup(x => x.GetTeams()).Returns(dbTeamsList);
            var teamOne = new TeamsDto
            {
                Score = 20
            };
            var teamTwo = new TeamsDto
            {
                Score = 10
            };
            var expected = new List<TeamsDto>
            {
                teamOne,
                teamTwo
            };
            //Act
            var actual = _service.GetTeams();
            Assert.Multiple(() =>
            {
                //Assert
                Assert.That(actual, Has.Count.EqualTo(expected.Count));
                Assert.That(expected[0].Score, !Is.EqualTo(actual[0].Score));
            });
        }

        [Test]
        public async Task GetByIdAsync_ReturnsTeam()
        {
            //Arrange
            var dbTeam = new Team
            {
                Score = 20
            };
            _repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(dbTeam);
            var expected = new TeamsDto
            {
                Score = 20
            };
            //Act
            var actual = await _service.GetByIdAsync(string.Empty);
            //Assert
            Assert.That(expected.Score, Is.EqualTo(actual.Score));
        }
    }
}