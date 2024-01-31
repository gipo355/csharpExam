namespace Models.Country;

using Models.Animal;

// using System.Runtime.Serialization;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

public class Country
{
  public Guid? Id { get; set; }

  // [Index(IsUnique = true)]
  public string? Name { get; set; }

  // [IgnoreDataMember]
  // [JsonIgnore]
  public List<Animal>? Animals { get; set; }
}
