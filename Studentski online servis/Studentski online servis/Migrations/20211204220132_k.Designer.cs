﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Studentski_online_servis.Data;

namespace Studentski_online_servis.Migrations
{
    [DbContext(typeof(DLWMS_dbContext))]
    [Migration("20211204220132_k")]
    partial class k
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Studentski_online_servis.IB190057.Models.AutentifikacijaToken", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IP_Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("Vrijednost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("KorisnickiNalogId");

                    b.ToTable("AutentifikacijaToken");
                });

            modelBuilder.Entity("Studentski_online_servis.IB190057.Models.Fakultet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FakultetID")
                        .HasColumnType("int");

                    b.Property<string>("Grad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FakultetID");

                    b.ToTable("Fakulteti");
                });

            modelBuilder.Entity("Studentski_online_servis.IB190057.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("KorisnickiNalog");

                    b.HasDiscriminator<string>("Discriminator").HasValue("KorisnickiNalog");
                });

            modelBuilder.Entity("Studentski_online_servis.IB190057.Models.Korisnik", b =>
                {
                    b.HasBaseType("Studentski_online_servis.IB190057.Models.KorisnickiNalog");

                    b.Property<string>("DLWMS_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumPrijave")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("FakultetID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Privatni_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vrsta_Korisnika")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Korisnik");
                });

            modelBuilder.Entity("Studentski_online_servis.IB190057.Models.AutentifikacijaToken", b =>
                {
                    b.HasOne("Studentski_online_servis.IB190057.Models.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Studentski_online_servis.IB190057.Models.Fakultet", b =>
                {
                    b.HasOne("Studentski_online_servis.IB190057.Models.Korisnik", null)
                        .WithMany("Fakultet")
                        .HasForeignKey("FakultetID");
                });
#pragma warning restore 612, 618
        }
    }
}
