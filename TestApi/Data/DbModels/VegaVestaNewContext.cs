using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestApi.Data.DbModels;

public partial class VegaVestaNewContext : DbContext
{
    public VegaVestaNewContext()
    {
    }

    public VegaVestaNewContext(DbContextOptions<VegaVestaNewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VegaBrand> VegaBrands { get; set; }

    public virtual DbSet<VegaCategory> VegaCategories { get; set; }

    public virtual DbSet<VegaDiscount> VegaDiscounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Initial Catalog=VegaVestaNew;Persist Security Info=False;User ID=gor;Password=123;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VegaBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VegaBran__3214EC27FBC9699E");

            entity.ToTable("VegaBrand");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.VegaBrandName).HasMaxLength(50);
        });

        modelBuilder.Entity<VegaCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VegaCate__3214EC2762BF1C8D");

            entity.ToTable("VegaCategory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.VegaObject).HasMaxLength(50);
        });

        modelBuilder.Entity<VegaDiscount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VegaDiscount");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.VegaObjectId).HasColumnName("VegaObjectID");
            entity.Property(e => e.VegaPrice).HasColumnType("money");

            entity.HasOne(d => d.VegaBrandNavigation).WithMany()
                .HasForeignKey(d => d.VegaBrand)
                .HasConstraintName("FK__VegaDisco__VegaB__286302EC");

            entity.HasOne(d => d.VegaObject).WithMany()
                .HasForeignKey(d => d.VegaObjectId)
                .HasConstraintName("FK__VegaDisco__VegaO__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
