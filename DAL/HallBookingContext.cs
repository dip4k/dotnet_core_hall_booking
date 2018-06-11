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

    // Add this
    public HallBookingContext(DbContextOptions<HallBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customer { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{

    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Customer>(entity =>
      {
        entity.Property(e => e.Email)
            .HasMaxLength(30)
            .IsUnicode(false);

        entity.Property(e => e.MobileNo)
            .HasMaxLength(20)
            .IsUnicode(false);

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(20)
            .IsUnicode(false);

        entity.Property(e => e.UserName)
            .IsRequired()
            .HasMaxLength(30)
            .IsUnicode(false);
      });
    }
  }
}
