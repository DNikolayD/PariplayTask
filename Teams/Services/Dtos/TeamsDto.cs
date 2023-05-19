using Services.Dtos.Interfaces;
using System.Collections.Generic;

namespace Services.Dtos
{
    public class TeamsDto : ITeamsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public List<MatchDto> Matches { get; set; }
    }
}
