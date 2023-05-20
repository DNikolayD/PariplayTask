using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using Services.Dtos;
using Services.Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Match = Data.Entities.Match;

namespace Tests
{
    internal class MatchesServiceTests
    {
        private Mock<IMatchesRepository> _repositoryMock;
        private Mock<ITeamsRepository> _teamsRepositoryMock;

        private MatchesService _service;
        [SetUp]
        public void Setup()
        {
            _teamsRepositoryMock = new Mock<ITeamsRepository>();
            _repositoryMock = new Mock<IMatchesRepository>();
            _service = new MatchesService(_repositoryMock.Object, new NullLogger<MatchesService>(),
                _teamsRepositoryMock.Object);
        }

        [Test]
        public void GetMatchesByTeamId_ReturnsMatches()
        {
            //Arrange
            var dbMatchesList = new List<Match>
            {
                new()
                {
                    Id = "",
                    IdOfSecondTeam = "IdOne"
                },
                new()
                {
                    Id = "",
                    IdOfSecondTeam = "IdOne"
                    
                },
                new()
                {

                }
            };
            _repositoryMock.Setup(x => x.GetMatches()).Returns(dbMatchesList);
            var matchOne = new MatchDto
            {
                Id = "",
                IdOfSecondTeam = "IdOne"
            };
            var matchTwo = new MatchDto
            {
                Id = "",
                IdOfSecondTeam = "IdOne"
            };
            var expected = new List<MatchDto>
            {
                matchOne,
                matchTwo
            };
            //Act
            var actual = _service.GetMatchesByTeamId("IdOne");
            //Assert
            Assert.That(actual, Has.Count.EqualTo(expected.Count));
        }

        [Test]
        public void GetAllMatches_ReturnsMatches()
        {
            //Arrange
            var dbMatchesList = new List<Match>
            {
                new()
                {
                    Id = "",
                    IdOfSecondTeam = "IdOne"
                },
                new()
                {
                    Id = "",
                    IdOfSecondTeam = "IdOne"
                    
                },
            };
            _repositoryMock.Setup(x => x.GetMatches()).Returns(dbMatchesList);
            var matchOne = new MatchDto
            {
                Id = "",
                IdOfSecondTeam = "IdOne"
            };
            var matchTwo = new MatchDto
            {
                Id = "",
                IdOfSecondTeam = "IdOne"
            };
            var expected = new List<MatchDto>
            {
                matchOne,
                matchTwo
            };
            //Act
            var actual = _service.GetAllMatches();
            //Assert
            Assert.That(actual, Has.Count.EqualTo(expected.Count));
        }
        
        [Test]
        public async Task GetByIdAsync_ReturnsMatch()
        {
            //Arrange
            var dbMatch = new Match
            {
                Id = ""
            };
            _repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(dbMatch);
            var expected = new MatchDto
            {
                Id = "",
            };
            
            //Act
            var actual = await _service.GetByIdAsync(string.Empty);
            //Assert
            Assert.That(actual.Id, Is.EqualTo(expected.Id));
        }
    
    }
}
