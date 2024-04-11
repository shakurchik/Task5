using Microsoft.AspNetCore.Mvc;
using Task_5.DataBase;
using Task_5.Models;

namespace Task_5.Controllers;
[ApiController]
[Route("[controller]")]
public class AnimalsController :ControllerBase
{
    private readonly MockDb _db;

    public AnimalsController(MockDb db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_db.Animals);
    }

    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _db.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
        _db.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
    {
        var animal = _db.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();
        animal.Name = updatedAnimal.Name;
        animal.Category = updatedAnimal.Category;
        animal.Weight = updatedAnimal.Weight;
        animal.FurColor = updatedAnimal.FurColor;
        return Ok(animal);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = _db.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();
        _db.Animals.Remove(animal);
        return NoContent();
    }
    
}