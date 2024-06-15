namespace SwissStyleChessTournament.Models
{
    public class Match
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player Winner { get; set; }

        public Match(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}
