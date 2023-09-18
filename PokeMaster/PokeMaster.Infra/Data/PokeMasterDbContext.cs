using Microsoft.EntityFrameworkCore;
using PokeMaster.Domain.Entities;
using PokeMaster.Infra.Data.Mappings;

namespace PokeMaster.Infra.Data;

public class PokeMasterDbContext : DbContext
{
    public PokeMasterDbContext(DbContextOptions<PokeMasterDbContext> options) : base(options) { }
    public DbSet<Master> Masters { get; set; }
    public DbSet<CapturedPokemon> CapturedPokemons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MasterMapping());
        modelBuilder.ApplyConfiguration(new CapturedPokemonMapping());
    }
}