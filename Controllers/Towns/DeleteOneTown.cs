namespace Controllers.Animals;

using Data;
using Models.Animal;

public static partial class AnimalsController
{
  public static async Task DeleteOneAnimal(Guid id, HttpContext context, AppDbContext db)
  {
    try
    {
      Console.WriteLine(id);

      db.Animals.Remove(new Animal { Id = id });

      await db.SaveChangesAsync();

      await context.Response.WriteAsJsonAsync(
        new { ok = true, message = "Animal deleted successfully!" }
      );

      return;

      // context.Response.WriteAsync("Hello World!");
    }
    catch (Exception e)
    {
      Console.WriteLine(e);

      context.Response.StatusCode = 500;

      await context.Response.WriteAsJsonAsync(
        new { ok = false, message = "Something went wrong!" }
      );

      return;
    }
  }
}
