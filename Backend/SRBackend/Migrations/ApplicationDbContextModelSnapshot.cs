﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SRBackend.Data;

namespace SRBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SRBackend.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("SRBackend.Models.Favorites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SongID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SongID");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("SRBackend.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("SRBackend.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ArtristName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SongName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SongRating")
                        .HasColumnType("real");

                    b.Property<string>("SongUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Song_Category_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Song_Category_id");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("SRBackend.Models.SongCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryPic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SongCategory");
                });

            modelBuilder.Entity("SRBackend.Models.SongRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Song_id")
                        .HasColumnType("int");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Song_id");

                    b.ToTable("SongRating");
                });

            modelBuilder.Entity("SRBackend.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("SRBackend.ModelsAutentififkacija.AutentifikacijaToken", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ipAdresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("korisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("vrijednost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeEvideniranja")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("korisnickiNalogId");

                    b.ToTable("AutentificationToken");
                });

            modelBuilder.Entity("SRBackend.Models.User", b =>
                {
                    b.HasBaseType("SRBackend.Models.UserProfile");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("City_id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender_id")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("City_id");

                    b.HasIndex("Gender_id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SRBackend.Models.Favorites", b =>
                {
                    b.HasOne("SRBackend.Models.Song", "song")
                        .WithMany()
                        .HasForeignKey("SongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("song");
                });

            modelBuilder.Entity("SRBackend.Models.Song", b =>
                {
                    b.HasOne("SRBackend.Models.SongCategory", "songcategory")
                        .WithMany()
                        .HasForeignKey("Song_Category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("songcategory");
                });

            modelBuilder.Entity("SRBackend.Models.SongRating", b =>
                {
                    b.HasOne("SRBackend.Models.Song", "song")
                        .WithMany()
                        .HasForeignKey("Song_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("song");
                });

            modelBuilder.Entity("SRBackend.ModelsAutentififkacija.AutentifikacijaToken", b =>
                {
                    b.HasOne("SRBackend.Models.UserProfile", "korisnickiNalog")
                        .WithMany()
                        .HasForeignKey("korisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnickiNalog");
                });

            modelBuilder.Entity("SRBackend.Models.User", b =>
                {
                    b.HasOne("SRBackend.Models.City", "city")
                        .WithMany()
                        .HasForeignKey("City_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SRBackend.Models.Gender", "gender")
                        .WithMany()
                        .HasForeignKey("Gender_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SRBackend.Models.UserProfile", null)
                        .WithOne()
                        .HasForeignKey("SRBackend.Models.User", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("city");

                    b.Navigation("gender");
                });
#pragma warning restore 612, 618
        }
    }
}
