using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bibliotheque.Models;

public partial class BibliothequeContext : DbContext
{
    public BibliothequeContext()
    {
    }

    public BibliothequeContext(DbContextOptions<BibliothequeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonne> Abonnes { get; set; }

    public virtual DbSet<Auteur> Auteurs { get; set; }

    public virtual DbSet<Emprunt> Emprunts { get; set; }

    public virtual DbSet<Livre> Livres { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abonne>(entity =>
        {
            entity.HasKey(e => e.AbonneId).HasName("PK__Abonne__08689B3521710430");

            entity.ToTable("Abonne");

            entity.Property(e => e.AbonneId)
                .ValueGeneratedNever()
                .HasColumnName("AbonneID");
            entity.Property(e => e.Adresse)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telephone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Auteur>(entity =>
        {
            entity.HasKey(e => e.AuteurId).HasName("PK__Auteur__757A49A239553129");

            entity.ToTable("Auteur");

            entity.Property(e => e.AuteurId)
                .ValueGeneratedNever()
                .HasColumnName("AuteurID");
            entity.Property(e => e.Nationalite)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Emprunt>(entity =>
        {
            entity.HasKey(e => e.EmpruntId).HasName("PK__Emprunt__629ED27775499F72");

            entity.ToTable("Emprunt");

            entity.Property(e => e.EmpruntId)
                .ValueGeneratedNever()
                .HasColumnName("EmpruntID");
            entity.Property(e => e.AbonneId).HasColumnName("AbonneID");
            entity.Property(e => e.LivreId).HasColumnName("LivreID");
            entity.Property(e => e.Statut)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Abonne).WithMany(p => p.Emprunts)
                .HasForeignKey(d => d.AbonneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emprunt_Abonne");

            entity.HasOne(d => d.Livre).WithMany(p => p.Emprunts)
                .HasForeignKey(d => d.LivreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Emprunt_Livre");
        });

        modelBuilder.Entity<Livre>(entity =>
        {
            entity.HasKey(e => e.LivreId).HasName("PK__Livre__562AE7E70555A239");

            entity.ToTable("Livre");

            entity.Property(e => e.LivreId)
                .ValueGeneratedNever()
                .HasColumnName("LivreID");
            entity.Property(e => e.Editeur)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Titre)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasMany(d => d.Auteurs).WithMany(p => p.Livres)
                .UsingEntity<Dictionary<string, object>>(
                    "LivreAuteur",
                    r => r.HasOne<Auteur>().WithMany()
                        .HasForeignKey("AuteurId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LivreAuteur_Auteur"),
                    l => l.HasOne<Livre>().WithMany()
                        .HasForeignKey("LivreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_LivreAuteur_Livre"),
                    j =>
                    {
                        j.HasKey("LivreId", "AuteurId");
                        j.ToTable("LivreAuteur");
                        j.IndexerProperty<int>("LivreId").HasColumnName("LivreID");
                        j.IndexerProperty<int>("AuteurId").HasColumnName("AuteurID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
