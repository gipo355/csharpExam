namespace Controllers.Employee;

public interface IEmployeeResponse
{
  bool ok { get; set; }
  string? message { get; set; }
}

public static partial class EmployeesController
{
  public static RouteGroupBuilder MapEmployeesApi(this RouteGroupBuilder group)
  {
    group.MapGet("/", GetAllEmployees).CacheOutput(x => x.Expire(TimeSpan.FromMicroseconds(5)));

    group.MapGet("/{id}", GetOneEmployee);

    group.MapPost("/", CreateOneEmployee);

    group.MapPatch("/{id}", UpdateOneEmployee);

    group.MapDelete("/{id}", DeleteOneEmployee);

    return group;
  }
}
