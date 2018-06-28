using System;
using MarriageHall.BOL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarriageHall.DAL
{

  public partial class HallBookingContext : DbContext
  {
    public HallBookingContext()
    {
    }

    public HallBookingContext(DbContextOptions<HallBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Booking> Bookings { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<FeaturePrice> FeaturePrices { get; set; }
    public virtual DbSet<HallDetail> HallDetails { get; set; }
    public virtual DbSet<HallOwner> HallOwners { get; set; }
    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Admin>(entity =>
      {
        entity.HasKey(e => e.AdminId);

        entity.Property(e => e.Email).HasMaxLength(50);

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        entity.HasOne(d => d.User)
            .WithOne()
            .HasForeignKey<Admin>(d => d.UserId)
            .HasConstraintName("FK_AdminUserId");
      });

      modelBuilder.Entity<Booking>(entity =>
      {
        entity.HasKey(e => e.BookingId);

        entity.Property(e => e.BookingDate).HasColumnType("datetime");

        entity.HasOne(d => d.Customer)
            .WithMany()
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BookingCustomerId");

        entity.HasOne(d => d.HallOwner)
            .WithMany()
            .HasForeignKey(d => d.HallOwnerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BookingOwnerId");
      });

      modelBuilder.Entity<Customer>(entity =>
      {
        entity.HasKey(e => e.CustomerId);

        entity.Property(e => e.AadharNo).HasMaxLength(20);

        entity.Property(e => e.Email).HasMaxLength(50);

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        entity.HasOne(d => d.User)
            .WithOne()
            .HasForeignKey<Customer>(d => d.UserId)
            .HasConstraintName("FK_CustomerUserId");
      });

      modelBuilder.Entity<FeaturePrice>(entity =>
      {
        entity.Property(e => e.BanjoPrice).HasColumnType("decimal(10, 2)");

        entity.Property(e => e.CateringPrice).HasColumnType("decimal(10, 2)");

        entity.Property(e => e.FlowerPrice).HasColumnType("decimal(10, 2)");

        entity.Property(e => e.HallPrice).HasColumnType("decimal(10, 2)");

        entity.HasOne(d => d.HallOwner)
            .WithMany()
            .HasForeignKey(d => d.HallOwnerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PricingHallOwnerId");
      });

      modelBuilder.Entity<HallDetail>(entity =>
      {
        entity.HasKey(e => e.HallDetailId);

        entity.Property(e => e.HallName).IsRequired();

        entity.HasOne(d => d.HallOwner)
            .WithMany()
            .HasForeignKey(d => d.HallOwnerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_HallOwnerId");
      });

      modelBuilder.Entity<HallOwner>(entity =>
      {
        entity.HasKey(e => e.HallOwnerId);

        entity.HasOne(d => d.User)
            .WithOne()
            .HasForeignKey<HallOwner>(d => d.UserId)
            .HasConstraintName("FK_OwnerUserId");
      });

      modelBuilder.Entity<User>(entity =>
      {
        entity.HasKey(e => e.UserId);

        entity.Property(e => e.MobileNo)
            .IsRequired()
            .HasMaxLength(15);

        entity.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Role)
            .IsRequired()
            .HasMaxLength(20);

        entity.Property(e => e.UserName)
            .IsRequired()
            .HasMaxLength(50);
      });
    }
  }
}
