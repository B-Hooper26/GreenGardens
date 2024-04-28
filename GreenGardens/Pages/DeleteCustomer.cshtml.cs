using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenGardens.Data;
using GreenGardens.Model;
using System.Threading.Tasks;
using System.Linq;

namespace GreenGardens.Pages
{
    public class DeleteCustomer : PageModel
    {
        private readonly AppDbContext _dbConnection;

        public customer Item { get; set; }

        public DeleteCustomer(AppDbContext context)
        {
            _dbConnection = context;
        }

        public void OnGet(Guid Customerid)
        {
            // Retrieve the item to be deleted
            Item = _dbConnection.Users.FirstOrDefault(t => t.Customerid == Customerid);
        }

        public async Task<IActionResult> OnPostAsync(Guid Customerid)
        {
            var itemToDelete = _dbConnection.Users.FirstOrDefault(t => t.Customerid == Customerid);
            if (itemToDelete != null)
            {
                _dbConnection.Users.Remove(itemToDelete);
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
