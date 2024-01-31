namespace Models.Town;

using Models.Employee;

// using System.Runtime.Serialization;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

public class Town
{
  public Guid? Id { get; set; }

  public string? Name { get; set; }

  public string? Province { get; set; }

  public string? CodiceCatastale { get; set; }

  public List<Employee>? Employees { get; set; }
}
