namespace Controllers.Animals;

using System.Text.Json;
using Data;
using Models.Animal;

public record AnimalResponse
{
  public bool ok { get; set; }
  public string message { get; set; }

  // public Animal animal { get; set; }
  public Guid? id { get; set; }
}

public static partial class AnimalsController
{
  public static async Task<IResult> CreateOneAnimal(
    Animal animal,
    HttpContext context,
    AppDbContext db
  )
  // public static void CreateOneAnimal(Animal animal)
  {
    try
    {
      // Console.WriteLine(animal);

      // context.Request.EnableBuffering();

      // var body = await new StreamReader(context.Request.Body, Encoding.UTF8).ReadToEndAsync();

      // Console.WriteLine($"Request body: {body}");

      // var animal = await body.ReadToEndAsync();

      Console.WriteLine(JsonSerializer.Serialize(animal));

      // var newAnimal = new Animal { Name = animal.Name };
      // var newCountry = new Country { Name = animal.Country.Name };

      // db.Countries.Add(new Country { Name = "testCountry", });
      // db.Animals.Add(new Animal { Name = "testAnimal", });
      db.Animals.Add(animal);
      await db.SaveChangesAsync();

      // await context.Response.WriteAsync("Hello World!");
      // await context.Response.WriteAsJsonAsync(body);
      return Results.Json(
        new AnimalResponse
        {
          ok = true,
          message = "Animal created successfully!",
          id = animal.Id
          // animal = new Animal
          // {
          //   Id = animal.Id,
          //   Name = animal.Name,
          //   Country = new Country { Id = animal.Country?.Id, Name = animal.Country?.Name }
          // },
        }
      );
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return Results.BadRequest(ex.Message);
    }
  }
}
