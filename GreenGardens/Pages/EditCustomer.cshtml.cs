using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenGardens.Data;
using GreenGardens.Model;
using System.Linq;
using System.Threading.Tasks;

namespace GreenGardens.Pages
{
    public class CustomerEditModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        [BindProperty]
        public customer Item { get; set; }

        public CustomerEditModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public async Task<IActionResult> OnGetAsync(Guid Customerid)
        {
            Item = await _dbConnection.customer.FindAsync(Customerid);

            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var itemToUpdate = await _dbConnection.customer.FindAsync(Item.Customerid);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            // Update the properties of the customer

            itemToUpdate.f_name = Item.f_name;
            itemToUpdate.s_name = Item.s_name;
            itemToUpdate.email = Item.email;
            itemToUpdate.loyalty_points = Item.loyalty_points;





            // Save the changes
            await _dbConnection.SaveChangesAsync();

            return RedirectToPage("Products");
        }
    }
}
