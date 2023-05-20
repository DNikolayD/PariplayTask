using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface ITeamsRepository
    {
        ICollection<Team> GetTeams();

        Task<Team> GetByIdAsync(string id);

        Task CreateAsync(Team entity);

        void Update(Team entity);

        Task DeleteAsync(string id);

        Task SaveAsync();
    }
}
