using Microsoft.AspNetCore.Mvc;
using Task_5.DataBase;

namespace Task_5.Controllers;
[ApiController]
[Route("[controller]")]
public class AnimalsController :ControllerBase
{
    
    public AnimalsController() {
            
        }
    
[HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = new MockDb().Animals;
        return Ok();
    }

    
}