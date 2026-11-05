using Microsoft.EntityFrameworkCore;

public class ClubesAppContext(DbContextOptions<ClubesAppContext> options) : DbContext(options)
{

    public DbSet<ClubesApp.Models.Club> Club { get; set; } = default!;
    public DbSet<ClubesApp.Models.Jugador> Jugador { get; set; } = default!;
}
