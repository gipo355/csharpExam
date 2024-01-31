namespace Data;

// TODO: how to make fields required, unique, other props on db?

// using System.Collections.Generic;
using Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.User;

public class UserDbContext : IdentityDbContext<User>
{
  protected readonly IConfiguration Configuration;

  private readonly string connectionString =
    $"Host={Environment.EnvVars["HOST"]};Database={Environment.EnvVars["DATABASE"]};Username={Environment.EnvVars["USERNAME"]};Password={Environment.EnvVars["PASSWORD"]}";

  public UserDbContext(IConfiguration configuration) => this.Configuration = configuration;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    // this reads the connectin string from appsettings.json (bad? pushes to git)
    // optionsBuilder.UseNpgsql(this.Configuration.GetConnectionString("DefaultConnection"));

    optionsBuilder.UseNpgsql(this.connectionString);

  // protected override void OnModelCreating(ModelBuilder modelBuilder)
  // {
  //   // modelBuilder.Entity<Blog>().Property(e => e.BlogId).HasDefaultValueSql("now()");
  //   // modelBuilder.Entity<Blog>().ComplexProperty
  // }
}
