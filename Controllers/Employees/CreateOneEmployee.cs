namespace Controllers.Employee;

using System.Text.Json;
using Data;
using Models.Employee;

public record EmployeeResponse
{
  public bool ok { get; set; }
  public string message { get; set; }

  public Guid? id { get; set; }
}

public static partial class EmployeesController
{
  public static async Task<IResult> CreateOneEmployee(
    Employee employee,
    HttpContext context,
    AppDbContext db
  )
  {
    try
    {
      Console.WriteLine(JsonSerializer.Serialize(employee));

      db.Employees.Add(employee);
      await db.SaveChangesAsync();

      return Results.Json(
        new EmployeeResponse
        {
          ok = true,
          message = "Employee created successfully!",
          id = employee.Id
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
