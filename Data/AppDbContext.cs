namespace Data;

// TODO: how to make fields required, unique, other props on db?

// using System.Collections.Generic;
using Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Animal;
using Models.Country;

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

  // protected override void OnModelCreating(ModelBuilder modelBuilder)
  // {
  //   // modelBuilder.Entity<Blog>().Property(e => e.BlogId).HasDefaultValueSql("now()");
  //   // modelBuilder.Entity<Blog>().ComplexProperty
  // }

  // public DbSet<Post> Posts { get; set; }
  // public DbSet<Blog> Blogs { get; set; }
  public DbSet<Country> Countries { get; set; }
  public DbSet<Animal> Animals { get; set; }
}
