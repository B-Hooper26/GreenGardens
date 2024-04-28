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
        public customer Customer { get; set; }

        public CustomerEditModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public async Task<IActionResult> OnGetAsync(Guid Customerid)
        {
            Customer = await _dbConnection.customer.FindAsync(Customerid);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var itemToUpdate = await _dbConnection.customer.FindAsync(Customer.Customerid);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            // Update the properties of the customer

            itemToUpdate.f_name = Customer.f_name;
            itemToUpdate.s_name = Customer.s_name;
            itemToUpdate.email = Customer.email;
            itemToUpdate.loyalty_points = Customer.loyalty_points;







            // Save the changes
            await _dbConnection.SaveChangesAsync();

            return RedirectToPage("Products");
        }
    }
}
