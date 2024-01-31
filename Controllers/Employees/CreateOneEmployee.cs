namespace Controllers.Employee;

using System.Text.Json;
using Data;
using Models.Employee;

public record CreateOneResponse : IEmployeeResponse
{
  public bool ok { get; set; }
  public string? message { get; set; }

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

      var validator = new EmployeeValidator();

      var validationResult = validator.Validate(employee);
      if (!validationResult.IsValid)
      {
        var message = "";
        foreach (var fail in validationResult.Errors)
        {
          message += string.Format("{0}", fail.ErrorMessage);
        }
        Results.StatusCode(400);
        return Results.Json(
          new CreateOneResponse { ok = false, message = "Invalid employee data!" + message }
        );
      }

      employee.BirthDate = new DateTimeOffset(new DateTime());

      // if (employee.Name is "" or null || employee.Email is "" or null)
      // {
      //   Results.StatusCode(400);
      //   return Results.Json(new CreateOneResponse { ok = false, message = "Name is required!" });
      // }
      // {
      // }

      db.Employees.Add(employee);
      await db.SaveChangesAsync();

      return Results.Json(
        new CreateOneResponse
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
      // return Results.BadRequest(ex.Message);
      Results.StatusCode(500);
      return Results.Json(
        new CreateOneResponse
        {
          ok = false,
          message = "There was an error creating the employee! " + ex.Message,
        }
      );
    }
  }
}
