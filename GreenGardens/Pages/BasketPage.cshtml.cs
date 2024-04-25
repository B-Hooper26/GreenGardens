using GreenGardens.Data;
using GreenGardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenGardens.Pages
{
    public class BasketPage : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly AppDbContext _dbConnection;

        public BasketPage(ILogger<IndexModel> logger, AppDbContext _db)
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
            products = _dbConnection.product.ToList();
            customers = _dbConnection.customer.ToList();
            admins = _dbConnection.admin.ToList();
            orders = _dbConnection.order.ToList();


        }

    }

}