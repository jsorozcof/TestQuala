using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestQuala.Data.Models;

public partial class ContextMain : DbContext
{
    public ContextMain()
    {
    }

    public ContextMain(DbContextOptions<ContextMain> options)
        : base(options)
    {
    }

    public virtual DbSet<MonedaSucursal> MonedaSucursals { get; set; }

    public virtual DbSet<Monedum> Moneda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:ins-dllo-test-01.public.33e082952ab4.database.windows.net,3342;Initial Catalog=TestDB;Persist Security Info=False;User ID=prueba;Password=pruebaconcepto;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MonedaSucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Moneda_S__3214EC07C5B87D5B");

            entity.ToTable("Moneda_Sucursal");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdModena).HasColumnName("Id_Modena");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdModenaNavigation).WithMany(p => p.MonedaSucursals)
                .HasForeignKey(d => d.IdModena)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK");
        });

        modelBuilder.Entity<Monedum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Moneda__3214EC07893725DC");

            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
