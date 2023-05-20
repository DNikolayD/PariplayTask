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
    public class MatchesService : IMatchesService
    {

        private readonly IMatchesRepository _repository;

        private readonly ILogger<MatchesService> _logger;

        private readonly ITeamsRepository _teamsRepository;

        public MatchesService(IMatchesRepository repository, ILogger<MatchesService> logger, ITeamsRepository teamsRepository)
        {
            _repository = repository;
            _logger = logger;
            _teamsRepository = teamsRepository;
        }

        public List<MatchDto> GetMatchesByTeamId(string id)
        {
            var result = new List<MatchDto>();
            var matches = _repository.GetMatches().Where(x => x.IdOfFirstTeam == id || x.IdOfSecondTeam == id);
            try
            {
                result.AddRange(matches.Select(match => new MatchDto
                {
                    Id = match.Id,
                    IdOfFirstTeam = match.IdOfFirstTeam,
                    IdOfSecondTeam = match.IdOfSecondTeam,
                    IdOfWinner = match.IdOfWinner
                }));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return result;
        }

        public List<MatchDto> GetAllMatches()
        {
            var result = new List<MatchDto>();
            var matches = _repository.GetMatches();
            try
            {
                result.AddRange(matches.Select(match => new MatchDto
                {
                    Id = match.Id,
                    IdOfFirstTeam = match.IdOfFirstTeam,
                    IdOfSecondTeam = match.IdOfSecondTeam,
                    IdOfWinner = match.IdOfWinner
                }));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return result;
        }

        public async Task<MatchDto> GetByIdAsync(string id)
        {
            var match = await _repository.GetByIdAsync(id);
            try
            {
                var matchDto = new MatchDto
                {
                    Id = match.Id,
                    IdOfFirstTeam = match.IdOfFirstTeam,
                    IdOfSecondTeam = match.IdOfSecondTeam,
                    IdOfWinner = match.IdOfWinner
                };
                return matchDto;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
 
            return new MatchDto();
        }

        public async Task CreateAsync(MatchDto entity)
        {
            try
            {
                var match = new Match
                {
                    Id = entity.Id,
                    IdOfSecondTeam = entity.IdOfSecondTeam,
                    IdOfFirstTeam = entity.IdOfFirstTeam,
                    IdOfWinner = entity.IdOfWinner
                };
                var teamOne = await _teamsRepository.GetByIdAsync(match.IdOfFirstTeam);
                var teamTwo = await _teamsRepository.GetByIdAsync(match.IdOfSecondTeam);
                if (string.IsNullOrWhiteSpace(match.IdOfWinner))
                {
                    teamOne.Score += 1;
                    teamTwo.Score += 1;
                }
                else
                {
                    if (teamOne.Id == match.IdOfWinner)
                    {
                        teamOne.Score += 3;
                    }
                    else
                    {
                        teamTwo.Score += 3;
                    }
                }
                _teamsRepository.Update(teamOne);
                _teamsRepository.Update(teamTwo);
                await _repository.CreateAsync(match);
                await _repository.SaveAsync();
                await _teamsRepository.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public async Task Update(MatchDto entity)
        {
            try
            {
                var match = new Match
                {
                    Id = entity.Id,
                    IdOfSecondTeam = entity.IdOfSecondTeam,
                    IdOfFirstTeam = entity.IdOfFirstTeam,
                    IdOfWinner = entity.IdOfWinner
                };
                _repository.Update(match);
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
