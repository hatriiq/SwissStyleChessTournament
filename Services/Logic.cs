using SwissStyleChessTournament.Models;

namespace SwissStyleChessTournament.Services
{
    public class Logic
    {
        public List<Player> Players { get; private set; }
        public List<Match> Matches { get; private set; }

        public Logic()
        {
            Players = new List<Player>();
            Matches = new List<Match>();
        }

        public void AddPlayer(string name)
        {
            int id = Players.Count + 1;
            Players.Add(new Player(id, name));
        }

        public void CreatePairings()
        {
            var orderedPlayers = Players.OrderByDescending(p => p.Score).ThenBy(p => p.Ranking).ToList();
            for (int i = 0; i < orderedPlayers.Count; i += 2)
            {
                Matches.Add(new Match(orderedPlayers[i], orderedPlayers[i + 1]));
            }
        }

        public void RecordMatchResult(Player winner, Match match)
        {
            match.Winner = winner;
            winner.Score += 1;
        }

        public void RankPlayers()
        {
            Players = Players.OrderByDescending(p => p.Score).ThenBy(p => p.Ranking).ToList();
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Ranking = i + 1;
            }
        }
    }

}
