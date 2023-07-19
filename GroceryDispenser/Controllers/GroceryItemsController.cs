using System.Text.Json;
using GroceryDispenser.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryDispenser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class GroceryItemsController : ControllerBase
    {
        [HttpGet]
        public Task<IEnumerable<GroceryItem>?> Get()
        {
            List<GroceryItem>? groceryItems = ReadGroceryItemsFromJson();
            return Task.FromResult<IEnumerable<GroceryItem>?>(groceryItems);
        }

        [HttpGet("{itemName}")]
        public ActionResult<GroceryItem> GetItem(string itemName)
        {
            var groceryItems = ReadGroceryItemsFromJson();
            if (groceryItems == null) return NotFound();
            
            var item = groceryItems.FirstOrDefault(i => String.Equals(i.Name, itemName, StringComparison.CurrentCultureIgnoreCase));
            if (item == null) return NotFound();
            
            return item;
        }

        private List<GroceryItem>? ReadGroceryItemsFromJson()
        {
            string jsonString = System.IO.File.ReadAllText("Data/grocery_items.json");
            var groceryItems = JsonSerializer.Deserialize<List<GroceryItem>>(jsonString);
            return groceryItems;
        }
    }
}

