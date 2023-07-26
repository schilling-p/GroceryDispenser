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
        public ActionResult<APIGroceryResponse?> Get()
        {
            APIGroceryResponse? apiGroceryResponse = ReadGroceryItemsFromJson();
            //return Task.FromResult<IEnumerable<GroceryItem>?>(apiGroceryResponse?.GroceryItems);
            return apiGroceryResponse;
        }
        
        [HttpGet("{itemName}")]
        public ActionResult<GroceryItem> GetItem(string itemName)
        {
            var apiGroceryResponse = ReadGroceryItemsFromJson();
            if (apiGroceryResponse == null || apiGroceryResponse.GroceryItems == null) return NotFound();
    
            var item = apiGroceryResponse.GroceryItems.FirstOrDefault(i => String.Equals(i.Name, itemName, StringComparison.CurrentCultureIgnoreCase));
            if (item == null) return NotFound();
    
            return item;
        }

        private APIGroceryResponse? ReadGroceryItemsFromJson()
        {
            try
            {
                string jsonString = System.IO.File.ReadAllText("Data/grocery_items.json");
                Console.WriteLine(jsonString);
                
                var apiGroceryResponse = JsonSerializer.Deserialize<APIGroceryResponse>(jsonString);
                Console.WriteLine(apiGroceryResponse);
                
                return apiGroceryResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in ReadGroceryItemsFromJson " + e.Message);
                return null;
            }
            
        }
    }
}

