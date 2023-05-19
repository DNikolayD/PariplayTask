using Services.Dtos.Interfaces;

namespace Services.Dtos
{
    public class MatchDto : IMatchDto
    {
        public string Id { get; set; }
        public string IdOfWinner { get; set; }
        public string IdOfFirstTeam { get; set; }

        public string IdOfSecondTeam { get; set; }
    }
}
