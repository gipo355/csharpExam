namespace Controllers.Employee;

using Data;
using Models.Employee;
using Models.Town;

public static partial class EmployeesController
{
  public static async Task<IResult> UpdateOneEmployee(
    Employee employee,
    string id,
    HttpContext context,
    AppDbContext db
  )
  {
    try
    {
      var oldEmployee = db.Employees.Find(Guid.Parse(id));
      if (employee == null || oldEmployee == null)
      {
        // context.Response.StatusCode = 404;
        Results.StatusCode(404);
        // context.Response.WriteAsJsonAsync(new { ok = false, message = "Employee not found!" });
        return Results.Json(new { ok = false, message = "Employee not found!" });
      }

      // maintain the current id
      employee.Id = oldEmployee.Id;

      // town logic = town must exist
      // BUG:  object cycle detected when updating FK

      // if user inputs town ||
      // if (employee.Town?.Name is not null)
      // {
      //   // check if exists
      //   var town = db.Towns.Where(t => t.Name == employee.Town.Name).FirstOrDefault();

      //   Console.WriteLine(town?.Id);
      //   Console.WriteLine(oldEmployee.TownId);
      //   if (town == null)
      //   {
      //     // context.Response.StatusCode = 404;
      //     Results.StatusCode(404);
      //     // context.Response.WriteAsJsonAsync(new { ok = false, message = "Town not found!" });
      //     return Results.Json(
      //       new { ok = false, message = "Town not found! Create the town before inserting" }
      //     );
      //   }

      //   // if exists, update the town id
      //   oldEmployee.TownId = town.Id;
      // }

      // update if the value if not null
      oldEmployee.Name = employee.Name ?? oldEmployee.Name;
      oldEmployee.Surname = employee.Surname ?? oldEmployee.Surname;
      oldEmployee.Email = employee.Email ?? oldEmployee.Email;
      oldEmployee.BirthDate =
        default == employee.BirthDate.ToUniversalTime
          ? oldEmployee.BirthDate
          : employee.BirthDate.ToUniversalTime();

      // update
      // db.Entry(oldEmployee).CurrentValues.SetValues(employee);

      // save
      var result = await db.SaveChangesAsync();

      return Results.Json(new GetOneResponse { ok = true, data = oldEmployee });
    }
    catch (Exception e)
    {
      Log.Logger.Error(e, "Error getting one employee");

      // context.Response.StatusCode = 500;

      Results.StatusCode(500);

      // await context.Response.WriteAsJsonAsync(new { ok = false, message = e.Message });

      return Results.Json(new { ok = false, message = e.Message });
    }
  }
}
