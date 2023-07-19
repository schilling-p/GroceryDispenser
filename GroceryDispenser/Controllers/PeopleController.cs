using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using GroceryDispenser.Models;

namespace GroceryDispenser.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Person>? Get()
        {
            var jsonString = System.IO.File.ReadAllText(
                "Data/people.json");
            
            return JsonSerializer.Deserialize<IEnumerable<Person>>(jsonString);
        }
    }
}
