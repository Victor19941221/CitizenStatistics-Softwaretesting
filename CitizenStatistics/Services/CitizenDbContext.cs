using CitizenStatistics.Models;
using Microsoft.EntityFrameworkCore;

namespace CitizenStatistics.Services;

public sealed class CitizenDbContext : DbContext
{
    public DbSet<Citizen> Citizens { get; set; }

    public CitizenDbContext(DbContextOptions<CitizenDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=citizensData.db");
    }
}