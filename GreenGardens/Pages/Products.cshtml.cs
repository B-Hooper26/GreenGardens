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

        public List<product> Products { get; set; }

        public ProductsModel (AppDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Products = _db.product.ToList();
        }
    }


}
