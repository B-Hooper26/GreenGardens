using GreenGardens.Data;
using GreenGardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GreenGardens.Pages
{
    public class AccountModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly AppDbContext _dbConnection;

        public AccountModel(ILogger<IndexModel> logger, AppDbContext _db)
        {
            _logger = logger;

            _dbConnection = _db;
        }
        //stores the list of tasks

        public List<customer> userinfo { get; set; }






        public void OnGet()
        {
            userinfo = _dbConnection.customer.ToList();
            var email = HttpContext.Session.GetString("UserEmail");
            if (!string.IsNullOrEmpty(email))
            {
                userinfo = _dbConnection.customer.Where(c => c.email == email).ToList();
            }



        }

    }

}