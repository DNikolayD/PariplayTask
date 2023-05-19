using System.Collections.Generic;

namespace Data.Entities.Interfaces
{
    public interface ITeam
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }

        public List<Match> Matches { get; set; }
    }
}
