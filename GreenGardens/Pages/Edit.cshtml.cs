using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenGardens.Data;
using GreenGardens.Model;
using System.Linq;
using System.Threading.Tasks;

namespace GreenGardens.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _dbConnection;

        [BindProperty]
        public product Item { get; set; }

        public EditModel(AppDbContext context)
        {
            _dbConnection = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Item = await _dbConnection.product.FindAsync(id);

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

            var itemToUpdate = await _dbConnection.product.FindAsync(Item.Productid);

            if (itemToUpdate == null)
            {
                return NotFound();
            }

            // Update the properties of the item
            itemToUpdate.Name = Item.Name;
            itemToUpdate.Price = Item.Price;
            itemToUpdate.Description = Item.Description;
            itemToUpdate.Stock_Quantity = Item.Stock_Quantity;
            itemToUpdate.Expected_Stock = Item.Expected_Stock;


            // Save the changes
            await _dbConnection.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
