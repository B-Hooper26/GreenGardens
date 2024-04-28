using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenGardens.Data;
using GreenGardens.Model;
using System.Threading.Tasks;
using System.Linq;

namespace GreenGardens.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        public product Item { get; set; }

        public DeleteModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public void OnGet(int Productid)
        {
            // Retrieve the item to be deleted
            Item = _dbConnection.product.FirstOrDefault(t => t.Productid == Productid);
        }

        public async Task<IActionResult> OnPostAsync(int Productid)
        {
            var itemToDelete = _dbConnection.product.FirstOrDefault(t => t.Productid == Productid);
            if (itemToDelete != null)
            {
                _dbConnection.product.Remove(itemToDelete);
                await _dbConnection.SaveChangesAsync();
                return RedirectToPage("Products");
            }
            else
            {
                // Handle the case where the item does not exist
                return NotFound();
            }
        }
    }
}
