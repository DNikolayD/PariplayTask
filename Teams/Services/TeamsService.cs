using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Services.Dtos;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class TeamsService : ITeamsService
    {
        private readonly ILogger<TeamsService> _logger;

        private readonly ITeamsRepository _repository;

        private readonly IMatchesService _matchesService;

        private readonly IMatchesRepository _matchesRepository;

        public TeamsService(ITeamsRepository repository, ILogger<TeamsService> logger, IMatchesService matchesService, IMatchesRepository matchesRepository)
        {
            _logger = logger;
            _repository = repository;
            _matchesService = matchesService;
            _matchesRepository = matchesRepository;
        }

        public List<TeamsDto> GetTeamsOrderedByRanking()
        {
            var result = new List<TeamsDto>();
            try
            {
                var teams = _repository.GetTeams();
                result.AddRange(teams.Select(team => new TeamsDto
                {
                    Id = team.Id,
                    Name = team.Name,
                    Matches = _matchesService.GetMatchesByTeamId(team.Id),
                    Score = team.Score
                }));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return result.OrderByDescending(x => x.Score).ToList();
        }

        public List<TeamsDto> GetTeams()
        {
            var result = new List<TeamsDto>();
            try
            {
                var teams = _repository.GetTeams();
                result.AddRange(teams.Select(team => new TeamsDto
                {
                    Id = team.Id,
                    Name = team.Name,
                    Matches = _matchesService.GetMatchesByTeamId(team.Id),
                    Score = team.Score
                }));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return result;
        }

        public async Task<TeamsDto> GetByIdAsync(string id)
        {
            var team = await _repository.GetByIdAsync(id);
            try
            {
                var teamDto = new TeamsDto
                {
                    Id = team.Id,
                    Name = team.Name,
                    Matches = _matchesService.GetMatchesByTeamId(team.Id),
                    Score = team.Score
                };
                return teamDto;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new TeamsDto();
        }

        public async Task CreateAsync(TeamsDto entity)
        {
            try
            {
                var team = new Team
                {
                    Matches = _matchesRepository.GetMatches()
                        .Where(x => x.IdOfFirstTeam == entity.Id || x.IdOfSecondTeam == entity.Id).ToList(),
                    Id = entity.Id,
                    Score = entity.Score,
                    Name = entity.Name
                };
                await _repository.CreateAsync(team);
                await _repository.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public async Task Update(TeamsDto entity)
        {
            try
            {
                var team = new Team
                {
                    Matches = _matchesRepository.GetMatches()
                        .Where(x => x.IdOfFirstTeam == entity.Id || x.IdOfSecondTeam == entity.Id).ToList(),
                    Id = entity.Id,
                    Score = entity.Score,
                    Name = entity.Name
                };
                _repository.Update(team);
                await _repository.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                await _repository.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}
