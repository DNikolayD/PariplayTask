using Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMatchesService
    {
        List<MatchDto> GetMatchesByTeamId(string id);

        List<MatchDto> GetAllMatches();

        Task<MatchDto> GetByIdAsync(string id);

        Task CreateAsync(MatchDto entity);

        Task Update(MatchDto entity);

        Task DeleteAsync(string id);

    }
}
