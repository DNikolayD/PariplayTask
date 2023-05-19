namespace Services.Dtos.Interfaces
{
    public interface IMatchDto
    {
        public string Id { get; set; }

        public string IdOfWinner { get; set; }
        public string IdOfFirstTeam { get; set; }

        public string IdOfSecondTeam { get; set; }

    }
}
