using Microsoft.EntityFrameworkCore;
using Npgsql;
using SeatReservation.Domain.Venues;

namespace SeatReservation.Infrastructure.Postgre;

public class ReservertionServiceDbContext : DbContext
{
    private readonly string _connectionString;

    public ReservertionServiceDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReservertionServiceDbContext).Assembly);
    }

    public DbSet<Venue> Venues => Set<Venue>();
}