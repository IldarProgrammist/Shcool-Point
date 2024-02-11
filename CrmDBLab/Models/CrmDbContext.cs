using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrmDBLab.Models;

public partial class CrmDbContext : DbContext
{
    public CrmDbContext()
    {
    }

    public CrmDbContext(DbContextOptions<CrmDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Database=TestDB;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("address_pkey");

            entity.ToTable("address");

            entity.Property(e => e.AddressId)
                .ValueGeneratedNever()
                .HasColumnName("address_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.Building)
                .HasMaxLength(50)
                .HasColumnName("building");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.Construction)
                .HasMaxLength(30)
                .HasColumnName("construction");
            entity.Property(e => e.StreetId).HasColumnName("street_id");

            entity.HasOne(d => d.Area).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("address_area_id_fkey");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("address_city_id_fkey");

            entity.HasOne(d => d.Street).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StreetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_street_id_fkey");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("area_pkey");

            entity.ToTable("area");

            entity.Property(e => e.AreaId)
                .ValueGeneratedNever()
                .HasColumnName("area_id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(150)
                .HasColumnName("area_name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("city_pkey");

            entity.ToTable("city");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(150)
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("street_pkey");

            entity.ToTable("street");

            entity.Property(e => e.StreetId)
                .ValueGeneratedNever()
                .HasColumnName("street_id");
            entity.Property(e => e.StreetName)
                .HasMaxLength(150)
                .HasColumnName("street_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(90)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(60)
                .HasColumnName("lastname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
