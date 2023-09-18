using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeMaster.Domain.Entities;
using System;
namespace PokeMaster.Infra.Data.Mappings;

public class MasterMapping : IEntityTypeConfiguration<Master>
{
    public void Configure(EntityTypeBuilder<Master> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasMany(b => b.CapturedPokemons)
            .WithOne(b => b.Master)
            .HasForeignKey(b => b.MasterId);
    }
}
