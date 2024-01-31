namespace Controllers.Employee;

using Data;
using Models.Employee;

// using Models.Town;

public record UpdateOneRequest
{
  // public Guid? Id { get; set; }

  public string? Name { get; set; }

  public string? Surname { get; set; }

  // public DateTime BirthDate { get; set; }

  public string? Gender { get; set; }

  public string? Email { get; set; }

  // public string? FiscalCode { get; set; }

  // public string? Town { get; set; }
}

public static partial class EmployeesController
{
  public static async Task<IResult> UpdateOneEmployee(
    UpdateOneRequest employee,
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

      // prepare the new class
      var newEmployee = new Employee { };

      // maintain the current id
      // employee.Id = oldEmployee.Id;
      // newEmployee.Id = oldEmployee.Id;

      // town logic = town must exist
      // BUG:  object cycle detected when updating FK

      // if user inputs town ||
      // if (employee.Town is not null)
      // {
      //   Console.WriteLine(employee.Town);
      //   // check if exists
      //   var town = db.Towns.Where(t => t.Name == employee.Town).FirstOrDefault();

      //   // Console.WriteLine(town?.Name);

      //   // Console.WriteLine(town?.Id);
      //   // Console.WriteLine(oldEmployee.TownId);
      //   if (town == null)
      //   {
      //     // context.Response.StatusCode = 404;
      //     Results.StatusCode(404);
      //     // context.Response.WriteAsJsonAsync(new { ok = false, message = "Town not found!" });
      //     return Results.Json(
      //       new { ok = false, message = "Town not found! Create the town before inserting" }
      //     );
      //   }

      //   // if exists, update the town
      //   // oldEmployee.Town = town;
      //   // newEmployee.Town = town;
      //   // oldEmployee.Town = town;
      //   // newEmployee.TownId = town.Id;
      // }
      // else
      // {
      //   // newEmployee.Town = oldEmployee.Town;
      // }

      // update if the value if not null
      oldEmployee.Name = employee.Name ?? oldEmployee.Name;
      // newEmployee.Name = employee.Name ?? oldEmployee.Name;
      oldEmployee.Surname = employee.Surname ?? oldEmployee.Surname;
      // newEmployee.Surname = employee.Surname ?? oldEmployee.Surname;
      oldEmployee.Email = employee.Email ?? oldEmployee.Email;
      // newEmployee.Email = employee.Email ?? oldEmployee.Email;
      oldEmployee.Gender = employee.Gender ?? oldEmployee.Gender;
      // newEmployee.Gender = employee.Gender ?? oldEmployee.Gender;
      // oldEmployee.BirthDate =
      //   default == employee.BirthDate.ToUniversalTime
      //     ? oldEmployee.BirthDate
      //     : employee.BirthDate.ToUniversalTime();
      // newEmployee.BirthDate =
      //   default == employee.BirthDate.ToUniversalTime
      //     ? oldEmployee.BirthDate
      //     : employee.BirthDate.ToUniversalTime();

      // oldEmployee.TownId = oldEmployee.TownId;
      // var town = db.Towns.Where(t => t.Name == employee.Town).FirstOrDefault();
      // oldEmployee.Town = null;
      // oldEmployee.Town = town;
      // oldEmployee.TownId = town.Id;

      // update
      // db.Entry(oldEmployee).CurrentValues.SetValues(employee);
      // db.Entry(oldEmployee).CurrentValues.SetValues(newEmployee);

      // save
      var result = await db.SaveChangesAsync();

      return Results.Json(new GetOneResponse { ok = true, data = oldEmployee });
    }
    catch (Exception e)
    {
      Log.Logger.Error(e, "Error updating one employee");

      // context.Response.StatusCode = 500;

      Results.StatusCode(500);

      // await context.Response.WriteAsJsonAsync(new { ok = false, message = e.Message });

      return Results.Json(new { ok = false, message = e.Message });
    }
  }
}
