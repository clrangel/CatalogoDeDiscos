﻿// <auto-generated />
using System;
using CatalogoDeDiscos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatalogoDeDiscos.Migrations
{
    [DbContext(typeof(CatalogoDeDiscosContext))]
    [Migration("20240917192340_MusicGenreForeignKey")]
    partial class MusicGenreForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CatalogoDeDiscos.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ArtistBandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseYear")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistBandId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("CatalogoDeDiscos.Models.ArtistBand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FoundingDate")
                        .HasColumnType("int");

                    b.Property<int>("MusicGenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MusicGenreId");

                    b.ToTable("ArtistBand");
                });

            modelBuilder.Entity("CatalogoDeDiscos.Models.MusicGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MusicGenre");
                });

            modelBuilder.Entity("CatalogoDeDiscos.Models.Album", b =>
                {
                    b.HasOne("CatalogoDeDiscos.Models.ArtistBand", "ArtistBand")
                        .WithMany("Albuns")
                        .HasForeignKey("ArtistBandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtistBand");
                });

            modelBuilder.Entity("CatalogoDeDiscos.Models.ArtistBand", b =>
                {
                    b.HasOne("CatalogoDeDiscos.Models.MusicGenre", "MusicGenre")
                        .WithMany("ArtistBands")
                        .HasForeignKey("MusicGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicGenre");
                });

            modelBuilder.Entity("CatalogoDeDiscos.Models.ArtistBand", b =>
                {
                    b.Navigation("Albuns");
                });

            modelBuilder.Entity("CatalogoDeDiscos.Models.MusicGenre", b =>
                {
                    b.Navigation("ArtistBands");
                });
#pragma warning restore 612, 618
        }
    }
}
