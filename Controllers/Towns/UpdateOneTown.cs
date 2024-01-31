namespace Controllers.Animals;

public static partial class AnimalsController
{
  public static void UpdateOneAnimal(string id, HttpContext context)
  {
    Console.WriteLine(id);
    context.Response.WriteAsync("Hello World!");
  }
}
