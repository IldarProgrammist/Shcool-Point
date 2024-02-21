using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ModelDomain.Model;

public partial class SchoolPointContext : DbContext
{
    public SchoolPointContext()
    {
    }

    public SchoolPointContext(DbContextOptions<SchoolPointContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=UrazbakhtinIV;Database=SchoolPoint;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__0382FFC276142B5B");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasColumnName("Address_id");
            entity.Property(e => e.AreaId).HasColumnName("Area_id");
            entity.Property(e => e.Building)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CityId).HasColumnName("City_id");
            entity.Property(e => e.Construction)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StreetId).HasColumnName("Street_id");

            entity.HasOne(d => d.Area).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__Address__Area_id__2C3393D0");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Address__City_id__2B3F6F97");

            entity.HasOne(d => d.Street).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StreetId)
                .HasConstraintName("FK__Address__Street___2D27B809");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Area__425B5BC6F655D74E");

            entity.ToTable("Area");

            entity.Property(e => e.AreaId).HasColumnName("Area_id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Area_name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("City_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .HasColumnName("City_name");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("PK__Street__36CE631D33DACA8A");

            entity.ToTable("Street");

            entity.Property(e => e.StreetId).HasColumnName("Street_id");
            entity.Property(e => e.StreetName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Street_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
