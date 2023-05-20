using Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITeamsService
    {
        List<TeamsDto> GetTeamsOrderedByRanking();

        List<TeamsDto> GetTeams();

        Task<TeamsDto> GetByIdAsync(string id);

        Task CreateAsync(TeamsDto entity);

        Task Update(TeamsDto entity);

        Task DeleteAsync(string id);
    }
}
