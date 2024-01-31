namespace Data;

// TODO: how to make fields required, unique, other props on db?

// using System.Collections.Generic;
using Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Employee;
using Models.Town;

public class AppDbContext : DbContext
{
  protected readonly IConfiguration Configuration;

  private readonly string connectionString =
    $"Host={Environment.EnvVars["HOST"]};Database={Environment.EnvVars["DATABASE"]};Username={Environment.EnvVars["USERNAME"]};Password={Environment.EnvVars["PASSWORD"]}";

  public AppDbContext(IConfiguration configuration) => this.Configuration = configuration;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    // this reads the connectin string from appsettings.json (bad? pushes to git)
    // optionsBuilder.UseNpgsql(this.Configuration.GetConnectionString("DefaultConnection"));

    optionsBuilder.UseNpgsql(this.connectionString);

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // modelBuilder.Entity<Blog>().Property(e => e.BlogId).HasDefaultValueSql("now()");
    // modelBuilder.Entity<Blog>().ComplexProperty
    // SEED town data
    //
    var padovaId = Guid.NewGuid();
    var vicenzaId = Guid.NewGuid();
    var trevisoId = Guid.NewGuid();
    modelBuilder
      .Entity<Town>()
      .HasData(
        new Town
        {
          Id = padovaId,
          Name = "Padova",
          Province = "PD",
          CodiceCatastale = "G224"
        }
      );
    modelBuilder
      .Entity<Town>()
      .HasData(
        new Town
        {
          Id = vicenzaId,
          Name = "Vicenza",
          Province = "VI",
          CodiceCatastale = "L840"
        }
      );
    modelBuilder
      .Entity<Town>()
      .HasData(
        new Town
        {
          Id = trevisoId,
          Name = "Treviso",
          Province = "TV",
          CodiceCatastale = "L407"
        }
      );
    // SEED employee data
    modelBuilder
      .Entity<Employee>()
      .HasData(
        new Employee
        {
          Id = Guid.NewGuid(),
          Name = "John1",
          Surname = "Doe",
          BirthDate = new DateOnly(),
          Gender = "Male",
          Email = "ok@gipo.dev",
          TownId = padovaId
        }
      );
    modelBuilder
      .Entity<Employee>()
      .HasData(
        new Employee
        {
          Id = Guid.NewGuid(),
          Name = "John2",
          Surname = "Doe",
          BirthDate = new DateOnly(),
          Gender = "Male",
          Email = "ok@gipo.dev",
          TownId = vicenzaId
        }
      );
    modelBuilder
      .Entity<Employee>()
      .HasData(
        new Employee
        {
          Id = Guid.NewGuid(),
          Name = "John3",
          Surname = "Doe",
          BirthDate = new DateOnly(),
          Gender = "Male",
          Email = "ok@gipo.dev",
          TownId = trevisoId
        }
      );
  }

  public DbSet<Employee> Employees { get; set; }
  public DbSet<Town> Towns { get; set; }
}
