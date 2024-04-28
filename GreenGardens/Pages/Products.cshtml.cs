using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenGardens.Data;
using GreenGardens.Model;

//Add-Migration AddProductTable
//Update-Database
namespace GreenGardens.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly AppDbContext _db;

        public List<product> Products { get; set; } = new List<product>();
        public List<customer> user { get; set; }



        public ProductsModel (AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Products = _db.Products.ToList();
            user = _db.Users.ToList();

        }
    }


}
