using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace inventariosmvc.Models;

public partial class ZapateriaContext : DbContext
{
    public ZapateriaContext(DbContextOptions<ZapateriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            // Definimos explícitamente la llave primaria para que el scaffolding funcione
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())", "DF_Productos_FechaRegistro")
                .HasColumnType("datetime");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
