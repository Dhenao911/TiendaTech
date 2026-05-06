using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TiendaTech.Backend.Models;

public partial class TiendaContext : DbContext
{
    public TiendaContext()
    {
    }

    public TiendaContext(DbContextOptions<TiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TiendaTechDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__19093A0B8500382C");

            entity.ToTable("categorias");

            entity.Property(e => e.Descripcion).HasMaxLength(80);
            entity.Property(e => e.NombreCategoria).HasMaxLength(80);
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.InventarioId).HasName("PK__inventar__FB8A24D725B5AF34");

            entity.ToTable("inventarios");

            entity.Property(e => e.UbicacionBodega).HasMaxLength(80);

            entity.HasOne(d => d.Producto).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__inventari__Produ__29572725");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__producto__A430AEA3240A4260");

            entity.ToTable("productos");

            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Ctegory).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CtegoryId)
                .HasConstraintName("FK__productos__Ctego__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
