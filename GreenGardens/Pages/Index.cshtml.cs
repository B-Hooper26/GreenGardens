using GreenGardens.Data;
using GreenGardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenGardens.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly AppDbContext _dbConnection;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext _db)
        {
            _logger = logger;

            _dbConnection = _db;
        }
        //stores the list of tasks
        public List<product>products{ get; set; } 
        public List<customer> customers { get; set; }
        public List<admin> admins { get; set; }
        public List<order> orders { get; set; }






        public void OnGet()
        {
            products = _dbConnection.Products.ToList();
            customers = _dbConnection.Users.ToList();
            orders = _dbConnection.Orders.ToList();


        }

    }

}