using AddToTable.Model;
using GreenGardens.Data;
using GreenGardens.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GreenGardens.Pages
{
    public class BasketPage : PageModel
    {
        private readonly AppDbContext _db;

        public List<BasketProductViewModel> BasketItems { get; set; }

        public class BasketProductViewModel
        {
            public int BasketId { get; set; }
            public int Quantity { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
        }

        public async Task OnGetAsync()
        {
            string userId = HttpContext.Session.GetString("Customerid");
            if (!string.IsNullOrEmpty(userId))
            {
                BasketItems = await _db.Baskets
                    .Where(b => b.UserId == userId)
                    .Select(b => new BasketProductViewModel
                    {
                        BasketId = b.BasketId,
                        Quantity = b.Quantity,
                        ProductName = b.product.Name,
                        Price = b.product.Price,
                    })
                    .ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            string userId = HttpContext.Session.GetString("Customerid");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/Login");
            }

            var basketItems = await _db.Baskets.Where(b => b.UserId == userId).ToListAsync();
            if (!basketItems.Any())
            {
                return Page(); // No items in the basket
            }

            // Create a new order
            var Order = new order { UserId = userId };
            _db.Orders.Add(Order);
            await _db.SaveChangesAsync(); // Save to get OrderId

            // Add items to OrderItems
            foreach (var item in basketItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = Order.OrderId,
                    ProductId_ = item.productid,
                    Quantity = item.Quantity
                };
                _db.OrderItems.Add(orderItem);

                // Remove the item from the basket
                _db.Baskets.Remove(item);
            }

            await _db.SaveChangesAsync(); // Final save to update database

            return RedirectToPage("/OrderConfirmation", new { orderId = Order.OrderId });
        }


    }

}