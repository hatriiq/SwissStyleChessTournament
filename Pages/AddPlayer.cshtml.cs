using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SwissStyleChessTournament.Services;

namespace SwissStyleChessTournament.Pages
{
    public class AddPlayerModel : PageModel
    {
        private readonly Logic _logic;

        [BindProperty]
        public string PlayerName { get; set; }

        public AddPlayerModel(Logic logic)
        {
            _logic = logic;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(PlayerName))
            {
                _logic.AddPlayer(PlayerName);
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
