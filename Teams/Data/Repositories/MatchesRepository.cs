using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MatchesRepository : IMatchesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MatchesRepository> _logger;

        public MatchesRepository(ApplicationDbContext context, ILogger<MatchesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Match> GetMatches()
        {
            try
            {
                return _context.Matches.ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new List<Match>();
        }

        public async Task<Match> GetByIdAsync(string id)
        {
            try
            {
                return await _context.Matches.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return new Match();
        }

        public async Task CreateAsync(Match entity)
        {
            try
            {
                await _context.Matches.AddAsync(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public void Update(Match entity)
        {
            try
            {
                _context.Matches.Update(entity);
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
                var entity = await GetByIdAsync(id);
                _context.Matches.Remove(entity);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
