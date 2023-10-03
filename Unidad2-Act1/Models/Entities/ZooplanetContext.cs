using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Unidad2_Act1.Models.Entities;

public partial class ZooplanetContext : DbContext
{
    public ZooplanetContext()
    {
    }

    public ZooplanetContext(DbContextOptions<ZooplanetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clase> Clase { get; set; }

    public virtual DbSet<Especies> Especies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("password=root;user=root;server=localhost;database=zooplanet", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("clase")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(45);
        });

        modelBuilder.Entity<Especies>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("especies")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdClase, "fk_especie_clase_idx");

            entity.Property(e => e.Especie).HasMaxLength(45);
            entity.Property(e => e.Habitat).HasMaxLength(45);
            entity.Property(e => e.Observaciones).HasMaxLength(100);
            entity.Property(e => e.Peso).HasColumnType("double(7,2)");

            entity.HasOne(d => d.IdClaseNavigation).WithMany(p => p.Especies)
                .HasForeignKey(d => d.IdClase)
                .HasConstraintName("fk_especie_clase");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
