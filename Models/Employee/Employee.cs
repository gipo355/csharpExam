namespace Models.Employee;

using Models.Town;

public class Employee
{
  public Guid? Id { get; set; }

  public string? Name { get; set; }

  public string? Surname { get; set; }

  public DateTime BirthDate { get; set; }

  public string? Gender { get; set; }

  public string? Email { get; set; }

  public string? FiscalCode { get; set; }

  public Guid? TownId { get; set; }
  public Town? Town { get; set; }
}
