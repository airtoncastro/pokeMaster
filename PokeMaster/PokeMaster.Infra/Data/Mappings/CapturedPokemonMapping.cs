using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeMaster.Domain.Entities;

namespace PokeMaster.Infra.Data.Mappings;

internal class CapturedPokemonMapping : IEntityTypeConfiguration<CapturedPokemon>
{
    public void Configure(EntityTypeBuilder<CapturedPokemon> builder)
    {
        builder.HasKey(b => b.Id);
    }
}
