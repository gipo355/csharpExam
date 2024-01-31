namespace Controllers.Employee;

using System.Text.Json;
using Data;
using FluentValidation;
using Models.Employee;

public record CreateOneResponse : IEmployeeResponse
{
  public bool ok { get; set; }
  public string? message { get; set; }

  public Guid? id { get; set; }
}

public record CreateOneRequest
{
  public Guid? Id { get; set; }

  public string? Name { get; set; }

  public string? Surname { get; set; }

  public DateTime BirthDate { get; set; }

  public string? Gender { get; set; }

  public string? Email { get; set; }

  public string? FiscalCode { get; set; }

  public string? Town { get; set; }
}

public class CreateEmployeeValidator : AbstractValidator<CreateOneRequest>
{
  public CreateEmployeeValidator()
  {
    RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name is required!");

    RuleFor(x => x.Email)
      .NotEmpty()
      // .NotNull()
      .EmailAddress()
      .WithMessage("A valid email is required!");

    RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Email is required!");

    RuleFor(x => x.Gender).NotEmpty().NotNull().WithMessage("Gender is required!");

    RuleFor(x => x.BirthDate)
      .NotEmpty()
      // .NotNull()
      .WithMessage("BirthDate is required!");

    RuleFor(x => x.Town).NotEmpty().NotNull().WithMessage("Town Name is required!");
  }
}

public static partial class EmployeesController
{
  public static async Task<IResult> CreateOneEmployee(
    CreateOneRequest employee,
    HttpContext context,
    AppDbContext db
  )
  {
    try
    {
      Console.WriteLine(JsonSerializer.Serialize(employee));

      var validator = new CreateEmployeeValidator();

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

      // required for psql to convert to UTC
      employee.BirthDate = employee.BirthDate.ToUniversalTime();

      // if (employee.Name is "" or null || employee.Email is "" or null)
      // {
      //   Results.StatusCode(400);
      //   return Results.Json(new CreateOneResponse { ok = false, message = "Name is required!" });
      // }
      // {
      // }

      // find town, check if exists, add relationship
      var town = db.Towns.Where(t => t.Name == employee.Town).FirstOrDefault();

      if (town == null)
      {
        Results.StatusCode(404);
        return Results.Json(
          new CreateOneResponse
          {
            ok = false,
            message = "Town not found! Create the town before inserting"
          }
        );
      }

      var newEmployee = new Employee
      {
        Name = employee.Name,
        Surname = employee.Surname,
        BirthDate = employee.BirthDate,
        Gender = employee.Gender,
        Email = employee.Email,
        // TODO: calc fiscal code and add here as pre hook
        FiscalCode = employee.FiscalCode,
        TownId = town.Id
      };

      db.Employees.Add(newEmployee);

      await db.SaveChangesAsync();

      return Results.Json(
        new CreateOneResponse
        {
          ok = true,
          message = "Employee created successfully!",
          id = newEmployee.Id
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
