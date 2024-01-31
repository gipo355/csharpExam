namespace Controllers.Animals;

using System.Text.Json;
using Data;

// TODO: hide some fields from the response
// TODO: add query params for filtering
public static partial class AnimalsController
{
  public static async Task GetAllAnimals(HttpContext context, AppDbContext db)
  {
    try
    {
      var animals = db.Animals.ToList();

      var cookies = context.Request.Cookies.ToList();
      // var headers = context.Request.Headers.ToList();

      Log.Logger.Information($"Cookies: {JsonSerializer.Serialize(cookies)}");
      // Log.Logger.Information($"Cookies: {JsonSerializer.Serialize(headers)}");
      // context.Response.Headers.ContentType = "application/json";
      context.Response.Headers.SetCookie = "testCookie=testValue";

      await context.Response.WriteAsJsonAsync(new { status = "success", data = animals });

      return;
    }
    catch (Exception e)
    {
      Log.Logger.Error(e, "Error getting all animals");

      context.Response.StatusCode = 500;

      await context.Response.WriteAsJsonAsync(
        new { ok = false, message = "Something went wrong!" }
      );

      return;
    }
  }
}
