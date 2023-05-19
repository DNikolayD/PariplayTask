using Data.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Team : ITeam
    {
        public Team()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Match> Matches { get; set; }
    }
}
