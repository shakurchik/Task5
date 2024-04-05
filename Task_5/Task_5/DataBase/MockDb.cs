using Microsoft.AspNetCore.Mvc;
using Task_5.Models;

namespace Task_5.DataBase;

public class MockDb
{
    public List<Animal> Animals { get; set; } = new List<Animal>();

    public MockDb()
    {
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        
    }
}