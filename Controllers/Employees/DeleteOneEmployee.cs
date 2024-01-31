namespace Controllers.Employee;

using Data;
using Models.Employee;

public static partial class EmployeesController
{
  public static async Task DeleteOneEmployee(Guid id, HttpContext context, AppDbContext db)
  {
    try
    {
      Console.WriteLine(id);

      db.Employees.Remove(new Employee { Id = id });

      await db.SaveChangesAsync();

      await context.Response.WriteAsJsonAsync(
        new { ok = true, message = "Employee deleted successfully!" }
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
