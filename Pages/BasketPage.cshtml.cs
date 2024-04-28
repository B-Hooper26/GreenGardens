using GreenGardens.Data;
using GreenGardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenGardens.Pages
{
    public class BasketPage : PageModel
    {
        private readonly AppDbContext _db;

        public List<customer> Customer { get; set; }
        public List<product> Product { get; set; }
        public List<order> Order { get; set; }

        public BasketPage(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Customer = _db.customer.ToList();
            var email = HttpContext.Session.GetString("UserEmail");
            if (!string.IsNullOrEmpty(email))
            {
                Customer = _db.customer.Where(c => c.email == email).ToList();
            }
            Product = _db.product.ToList();
            Order = _db.order.ToList();
        }


    }

}