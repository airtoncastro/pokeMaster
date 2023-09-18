﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokeMaster.Infra.Data;

#nullable disable

namespace PokeMaster.Infra.Migrations
{
    [DbContext(typeof(PokeMasterDbContext))]
    partial class PokeMasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("PokeMaster.Domain.Entities.CapturedPokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CaptureDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("MasterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("CapturedPokemons");
                });

            modelBuilder.Entity("PokeMaster.Domain.Entities.Master", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<short>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Masters");
                });

            modelBuilder.Entity("PokeMaster.Domain.Entities.CapturedPokemon", b =>
                {
                    b.HasOne("PokeMaster.Domain.Entities.Master", "Master")
                        .WithMany("CapturedPokemons")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Master");
                });

            modelBuilder.Entity("PokeMaster.Domain.Entities.Master", b =>
                {
                    b.Navigation("CapturedPokemons");
                });
#pragma warning restore 612, 618
        }
    }
}
