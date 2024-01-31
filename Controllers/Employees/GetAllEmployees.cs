namespace Controllers.Employee;

using System.Text.Json;
using Data;
using Models.Employee;

public record GetAllResponse : IEmployeeResponse
{
  public bool ok { get; set; }
  public string? message { get; set; }

  public List<Employee>? data { get; set; }
}

// TODO: hide some fields from the response
// TODO: add query params for filtering
public static partial class EmployeesController
{
  public static async Task GetAllEmployees(HttpContext context, AppDbContext db)
  {
    try
    {
      var employees = db.Employees.ToList();

      var cookies = context.Request.Cookies.ToList();
      // var headers = context.Request.Headers.ToList();

      Log.Logger.Information($"Cookies: {JsonSerializer.Serialize(cookies)}");
      // Log.Logger.Information($"Cookies: {JsonSerializer.Serialize(headers)}");
      // context.Response.Headers.ContentType = "application/json";
      context.Response.Headers.SetCookie = "testCookie=testValue";

      await context.Response.WriteAsJsonAsync(new { status = "success", data = employees });

      return;
    }
    catch (Exception e)
    {
      Log.Logger.Error(e, "Error getting all employees");

      context.Response.StatusCode = 500;

      await context.Response.WriteAsJsonAsync(new { ok = false, message = e.Message });

      return;
    }
  }
}
