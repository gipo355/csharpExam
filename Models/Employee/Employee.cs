namespace Models.Employee;

using FluentValidation;
using Models.Town;

public class Employee
{
  public Guid? Id { get; set; }

  public string? Name { get; set; }

  public string? Surname { get; set; }

  public DateTimeOffset BirthDate { get; set; }

  public string? Gender { get; set; }

  public string? Email { get; set; }

  public Guid? TownId { get; set; }
  public Town? Town { get; set; }
}

public class EmployeeValidator : AbstractValidator<Employee>
{
  public EmployeeValidator()
  {
    RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name is required!");
    RuleFor(x => x.Email)
      .NotEmpty()
      // .NotNull()
      .EmailAddress()
      .WithMessage("A valid email is required!");
    RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Email is required!");
    RuleFor(x => x.BirthDate)
      .NotEmpty()
      // .NotNull()
      .WithMessage("BirthDate is required as UTC DateTime!");

    RuleFor(x => x.Town.Name).NotEmpty().NotNull().WithMessage("Town Name is required!");
  }
}
