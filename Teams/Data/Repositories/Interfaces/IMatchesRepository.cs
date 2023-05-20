using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IMatchesRepository
    {
        List<Match> GetMatches();

        Task<Match> GetByIdAsync(string id);

        Task CreateAsync(Match entity);

        void Update(Match entity);

        Task DeleteAsync(string id);

        Task SaveAsync();
    }
}
