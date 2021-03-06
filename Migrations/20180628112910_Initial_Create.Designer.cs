﻿// <auto-generated />
using System;
using MarriageHall.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarriageHall.Migrations
{
    [DbContext(typeof(HallBookingContext))]
    [Migration("20180628112910_Initial_Create")]
    partial class Initial_Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarriageHall.BOL.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("MarriageHall.BOL.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CustomerId");

                    b.Property<int>("HallOwnerId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("HallOwnerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("MarriageHall.BOL.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AadharNo")
                        .HasMaxLength(20);

                    b.Property<string>("Address");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MarriageHall.BOL.FeaturePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("BanjoPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("CateringPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("FlowerPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("HallOwnerId");

                    b.Property<decimal>("HallPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("HallOwnerId");

                    b.ToTable("FeaturePrices");
                });

            modelBuilder.Entity("MarriageHall.BOL.HallDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HallCapacity");

                    b.Property<string>("HallName")
                        .IsRequired();

                    b.Property<int>("HallOwnerId");

                    b.HasKey("Id");

                    b.HasIndex("HallOwnerId");

                    b.ToTable("HallDetails");
                });

            modelBuilder.Entity("MarriageHall.BOL.HallOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("HallOwners");
                });

            modelBuilder.Entity("MarriageHall.BOL.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MarriageHall.BOL.Admin", b =>
                {
                    b.HasOne("MarriageHall.BOL.User", "User")
                        .WithOne()
                        .HasForeignKey("MarriageHall.BOL.Admin", "UserId")
                        .HasConstraintName("FK_AdminUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MarriageHall.BOL.Booking", b =>
                {
                    b.HasOne("MarriageHall.BOL.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_BookingCustomerId");

                    b.HasOne("MarriageHall.BOL.HallOwner", "HallOwner")
                        .WithMany()
                        .HasForeignKey("HallOwnerId")
                        .HasConstraintName("FK_BookingOwnerId");
                });

            modelBuilder.Entity("MarriageHall.BOL.Customer", b =>
                {
                    b.HasOne("MarriageHall.BOL.User", "User")
                        .WithOne()
                        .HasForeignKey("MarriageHall.BOL.Customer", "UserId")
                        .HasConstraintName("FK_CustomerUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MarriageHall.BOL.FeaturePrice", b =>
                {
                    b.HasOne("MarriageHall.BOL.HallOwner", "HallOwner")
                        .WithMany()
                        .HasForeignKey("HallOwnerId")
                        .HasConstraintName("FK_PricingHallOwnerId");
                });

            modelBuilder.Entity("MarriageHall.BOL.HallDetail", b =>
                {
                    b.HasOne("MarriageHall.BOL.HallOwner", "HallOwner")
                        .WithMany()
                        .HasForeignKey("HallOwnerId")
                        .HasConstraintName("FK_HallOwnerId");
                });

            modelBuilder.Entity("MarriageHall.BOL.HallOwner", b =>
                {
                    b.HasOne("MarriageHall.BOL.User", "User")
                        .WithOne()
                        .HasForeignKey("MarriageHall.BOL.HallOwner", "UserId")
                        .HasConstraintName("FK_OwnerUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
