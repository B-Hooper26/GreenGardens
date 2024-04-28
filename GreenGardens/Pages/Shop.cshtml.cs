using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenGardens.Data;
using GreenGardens.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;
using AddToTable.Model;
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


        [BindProperty]
        public product Product { get; set; }

        public List<product> Products { get; set; } = new List<product>();
        public List<customer> Customer { get; set; }
        public List<order> Order { get; set; }
        public async Task OnGetAsync()
        {
            Products = await _db.Products.ToListAsync();
        }
        public void OnGet()
        {
     
            Customer = _db.Users.ToList();
            Order = _db.Orders.ToList();
        }
        public async Task<IActionResult> OnPostAddProductAsync()
        {
            if (!ModelState.IsValid)
            {
                Products = await _db.Products.ToListAsync(); // Re-load products if form is invalid
                return Page();
            }

            _db.Products.Add(Product);
            await _db.SaveChangesAsync();
            return RedirectToPage(); // Refresh the page or redirect to a confirmation page
        }

        public async Task<IActionResult> OnPostAddToBasketAsync(int productId)
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/Login");
            }

            var productToAdd = await _db.Products.FindAsync(productId);
            if (productToAdd == null)
            {
                return NotFound();
            }

            var basketItem = new Basket { productid = productToAdd.Productid, UserId = userId };
            _db.Baskets.Add(basketItem);
            await _db.SaveChangesAsync();
            return RedirectToPage(); // Refresh the page or redirect to a confirmation page
        }
    }
}
