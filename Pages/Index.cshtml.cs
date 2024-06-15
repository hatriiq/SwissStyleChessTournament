using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SwissStyleChessTournament.Models;
using SwissStyleChessTournament.Services;

namespace SwissStyleChessTournament.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Logic _logic;

        public List<Player> Players => _logic.Players;
        public List<Match> Matches => _logic.Matches;

        public IndexModel(Logic logic)
        {
            _logic = logic;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostCreatePairings()
        {
            _logic.CreatePairings();
            return RedirectToPage();
        }

        public IActionResult OnPostRecordMatchResult(int matchIndex, int winnerId)
        {
            var match = _logic.Matches[matchIndex];
            var winner = _logic.Players.First(p => p.Id == winnerId);
            _logic.RecordMatchResult(winner, match);
            _logic.RankPlayers();
            return RedirectToPage();
        }
    }
}
