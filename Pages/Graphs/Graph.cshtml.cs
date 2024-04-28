using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using GreenGardens.Data;
using GreenGardens.Model;


namespace GreenGardens.Pages.Graphs
{
    public class GraphModel : PageModel
    {

        private readonly AppDbContext _dbConnection;

        public string ProductJson { get; set; }

        public GraphModel(AppDbContext db)
        {
            _dbConnection = db;
        }

        public List<product> Products { get; set; }
        public void OnGet()
        {
            var items = _dbConnection.product.ToList();
            ProductJson = JsonSerializer.Serialize(items.Select(t => new { t.Name, t.Price, t.Stock_Quantity, t.Expected_Stock }));


            Products = _dbConnection.product.ToList();
        }





    }
}
