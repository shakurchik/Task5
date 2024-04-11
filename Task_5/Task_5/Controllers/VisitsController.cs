﻿using Microsoft.AspNetCore.Mvc;
using Task_5.DataBase;
using Task_5.Models;

namespace Task_5.Controllers;
[ApiController]
[Route("[controller]")]
public class VisitsController : ControllerBase
{
    private readonly MockDb _db;

    public VisitsController(MockDb db)
    {
        _db = db;
    }

    [HttpGet("{animalId}")]
    public IActionResult GetVisitsForAnimal(int animalId)
    {
        var visits = _db.Visits.Where(v => v.AnimalId == animalId).ToList();
        if (!visits.Any()) return NotFound("No visits found for the specified animal.");
        return Ok(visits);
    }

    [HttpPost]
    public IActionResult AddVisit([FromBody] Visit visit)
    {
        _db.Visits.Add(visit);
        return CreatedAtAction("GetVisitsForAnimal", new { animalId = visit.AnimalId }, visit);
    }
}