﻿// <auto-generated />
using System;
using Clinique.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinique.EntityFramework.Migrations
{
    [DbContext(typeof(CliniqueDbContext))]
    partial class CliniqueDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clinique.Domain.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnostic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDocteur")
                        .HasColumnType("int");

                    b.Property<int>("IdDossierpatient")
                        .HasColumnType("int");

                    b.Property<int>("IdOrdonnance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("IdDocteur", "IdDossierpatient", "DateC");

                    b.HasIndex("IdDossierpatient");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Docteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSpecialite")
                        .HasColumnType("int");

                    b.Property<int>("Matricule")
                        .HasColumnType("int");

                    b.Property<int>("NbrPatients")
                        .HasColumnType("int");

                    b.Property<string>("Niveau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrenomM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdSpecialite");

                    b.ToTable("Docteurs");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Dossierpatient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateC")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNaiss")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDocteur")
                        .HasColumnType("int");

                    b.Property<string>("NomP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumAS")
                        .HasColumnType("int");

                    b.Property<string>("PrenomP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDocteur");

                    b.ToTable("Dossierpatients");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Medicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCategorie")
                        .HasColumnType("int");

                    b.Property<string>("NomMed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdCategorie");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateC")
                        .HasColumnType("datetime2");

                    b.Property<string>("Recommandations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ordonnances");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnancechirurgie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdOrdonnance")
                        .HasColumnType("int");

                    b.Property<string>("NomChirurgie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rang")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdOrdonnance");

                    b.ToTable("Ordonnancechirurgies");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnancemedicament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdOrdonnance")
                        .HasColumnType("int");

                    b.Property<int>("NbBoites")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMedicament");

                    b.HasIndex("IdOrdonnance");

                    b.ToTable("Ordonnancemedicaments");
                });

            modelBuilder.Entity("Clinique.Domain.Models.RendezVous", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRdv")
                        .HasColumnType("datetime2");

                    b.Property<double>("Duree")
                        .HasColumnType("float");

                    b.Property<int>("IdDocteur")
                        .HasColumnType("int");

                    b.Property<int>("IdDossierpatient")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("DateRdv", "IdDocteur", "IdDossierpatient");

                    b.HasIndex("IdDocteur");

                    b.HasIndex("IdDossierpatient");

                    b.ToTable("RendezVous");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Specialite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialites");
                });

            modelBuilder.Entity("Clinique.Domain.Models.Consultation", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Docteur", null)
                        .WithMany("Consultations")
                        .HasForeignKey("IdDocteur")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Clinique.Domain.Models.Dossierpatient", null)
                        .WithMany("Consultations")
                        .HasForeignKey("IdDossierpatient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Clinique.Domain.Models.Docteur", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Specialite", "Specialite")
                        .WithMany("Docteurs")
                        .HasForeignKey("IdSpecialite")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clinique.Domain.Models.Dossierpatient", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Docteur", "Docteur")
                        .WithMany("Dossierspatients")
                        .HasForeignKey("IdDocteur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clinique.Domain.Models.Medicament", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Categorie", "Categorie")
                        .WithMany("Medicaments")
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnancechirurgie", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Ordonnance", "Ordonnance")
                        .WithMany("Ordonnancechirurgies")
                        .HasForeignKey("IdOrdonnance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clinique.Domain.Models.Ordonnancemedicament", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Medicament", "Medicament")
                        .WithMany("Ordonnancemedicaments")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinique.Domain.Models.Ordonnance", "Ordonnance")
                        .WithMany("Ordonnancemedicaments")
                        .HasForeignKey("IdOrdonnance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clinique.Domain.Models.RendezVous", b =>
                {
                    b.HasOne("Clinique.Domain.Models.Docteur", null)
                        .WithMany("RendezVous")
                        .HasForeignKey("IdDocteur")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Clinique.Domain.Models.Dossierpatient", null)
                        .WithMany("RendezVous")
                        .HasForeignKey("IdDossierpatient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
