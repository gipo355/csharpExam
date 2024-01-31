namespace Controllers.Employee;

using Data;
using Models.Employee;

public record GetOneResponse : IEmployeeResponse
{
  public bool ok { get; set; }
  public string? message { get; set; }

  public Employee? data { get; set; }
}

public static partial class EmployeesController
{
  public static async Task<IResult> GetOneEmployee(string id, HttpContext context, AppDbContext db)
  {
    try
    {
      var employee = db.Employees.Find(Guid.Parse(id));

      if (employee == null)
      {
        // context.Response.StatusCode = 404;
        Results.StatusCode(404);
        // context.Response.WriteAsJsonAsync(new { ok = false, message = "Employee not found!" });
        return Results.Json(new { ok = false, message = "Employee not found!" });
      }

      return Results.Json(new GetOneResponse { ok = true, data = employee });
    }
    catch (Exception e)
    {
      Log.Logger.Error(e, "Error getting one employee");

      context.Response.StatusCode = 500;

      Results.StatusCode(500);

      // await context.Response.WriteAsJsonAsync(new { ok = false, message = e.Message });

      return Results.Json(new { ok = false, message = e.Message });
    }
  }
}
