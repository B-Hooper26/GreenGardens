using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenGardens.Data;
using GreenGardens.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

//Add-Migration AddProductTable
//Update-Database
namespace GreenGardens.Pages
{
    public class ShopModel : PageModel
    {
        private readonly AppDbContext _db;

        public ShopModel(AppDbContext db)
        {
            _db = db;
        }

        public List<product> Products { get; set; }

        public void OnGet() {

            Products = _db.product.ToList();
        }

        public async Task<IActionResult> Shop(string Name)
        {
            var searchItems = await _db.product.Where(s => s.Name.Contains(Name)).ToListAsync();
            return View(searchItems);
        }

        private IActionResult View(List<product> products)
        {
            throw new NotImplementedException();
        }
    }
}
