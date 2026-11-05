using Microsoft.EntityFrameworkCore;

public class ClubesAppContext(DbContextOptions<ClubesAppContext> options) : DbContext(options)
{
    public DbSet<ClubesApp.Models.Jugador> Jugador { get; set; } = default!;
}
