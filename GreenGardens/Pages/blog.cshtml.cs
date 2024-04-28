using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenGardens.Pages
{
    public class blog : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public blog(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}