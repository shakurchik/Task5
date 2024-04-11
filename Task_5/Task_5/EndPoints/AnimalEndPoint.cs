using Task_5.Models;

namespace Task_5.EndPoints;

public static class AnimalEndPoint
{
    public static void MapAnimalsEndPoints(this WebApplication app)
    {
        //GET
        app.MapGet("/animals-minimal.api/{id}", (int id) =>
        {
            if (id != 1)
            {
                Results.NotFound();
            }
    
            //process data
            Results.Ok();


        });
//200 - Ok
//201 - Created
//400 - Bad Request

//POST
        app.MapPost("/animals-minimal.api", (Animal animal) =>
        {
            return Results.Created(" ",animal);
            
        });
        
    }
}