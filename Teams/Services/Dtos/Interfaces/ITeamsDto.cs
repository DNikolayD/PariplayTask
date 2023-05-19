using System.Collections.Generic;

namespace Services.Dtos.Interfaces
{
    public interface ITeamsDto
    {
        public string Id { get; set; }

        public string Name { get; set; }


        public int Score { get; set; }

        public List<MatchDto> Matches { get; set; }
    }
}
