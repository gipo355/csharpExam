namespace Controllers.Employee;

public static partial class EmployeesController
{
  public static void GetOneEmployee(string id, HttpContext context)
  {
    Console.WriteLine(id);
    context.Response.WriteAsync("Hello World!");
  }
}
