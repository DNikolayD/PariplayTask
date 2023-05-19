using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TeamsRepository> _logger;

        public TeamsRepository(ApplicationDbContext dbContext, ILogger<TeamsRepository> logger)
        {
            _context = dbContext;
            _logger = logger;
        }

        public ICollection<Team> GetTeams()
        {
            try
            {
                return _context.Teams.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new List<Team>();
        }

        public async Task<Team> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Teams.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new Team();
        }

        public async Task CreateAsync(Team entity)
        {
            try
            {
                await _context.Teams.AddAsync(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

        }

        public void Update(Team entity)
        {
            try
            {
                _context.Teams.Update(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            try
            {
                _context.Teams.Remove(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

        }
    }
}
