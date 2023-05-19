namespace Data.Entities.Interfaces
{
    public interface IMatch
    {
        public string Id { get; set; }

        public string IdOfWinner { get; set; }

        public string IdOfFirstTeam { get; set; }

        public string IdOfSecondTeam { get; set; }


    }
}
