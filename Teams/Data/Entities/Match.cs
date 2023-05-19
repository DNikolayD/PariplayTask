using Data.Entities.Interfaces;
using System;

namespace Data.Entities
{
    public class Match : IMatch
    {
        public Match()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string IdOfWinner { get; set; }

        public string IdOfFirstTeam { get; set; }

        public string IdOfSecondTeam { get; set; }

    }
}
