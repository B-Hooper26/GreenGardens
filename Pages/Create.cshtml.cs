using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenGardens.Data;
using GreenGardens.Model;

namespace GreenGardens.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        public product Item { get; set; }

        public CreateModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public void OnGet()
        {
            Item = new product(); // Initialize Item
        }

        public IActionResult OnPost(product Item)
        {
            //if (!ModelState.IsValid)
            //{
            //    // Log validation errors or set a breakpoint here to inspect ModelState
            //    return Page();
            //}

            // Set a breakpoint here to inspect the 'Item' object
            _dbConnection.product.Add(Item);
            _dbConnection.SaveChanges();

            return RedirectToPage("Products");
        }
    }
}
