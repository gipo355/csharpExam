namespace Controllers.Employee;

using Data;
using Models.Employee;

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

      // update if the value is not null
      oldEmployee.Name = employee.Name ?? oldEmployee.Name;
      oldEmployee.Surname = employee.Surname ?? oldEmployee.Surname;
      oldEmployee.Email = employee.Email ?? oldEmployee.Email;
      oldEmployee.BirthDate =
        default == employee.BirthDate ? oldEmployee.BirthDate : employee.BirthDate;

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
