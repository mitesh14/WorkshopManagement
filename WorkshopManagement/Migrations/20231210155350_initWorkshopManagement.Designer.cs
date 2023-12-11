﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkshopManagement.Models;

#nullable disable

namespace WorkshopManagement.Migrations
{
    [DbContext(typeof(WorkshopDbContext))]
    [Migration("20231210155350_initWorkshopManagement")]
    partial class initWorkshopManagement
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VehicleWorkshopSlot", b =>
                {
                    b.Property<int>("VehiclesVehicleID")
                        .HasColumnType("int");

                    b.Property<int>("WorkshopSlotsSlotID")
                        .HasColumnType("int");

                    b.HasKey("VehiclesVehicleID", "WorkshopSlotsSlotID");

                    b.HasIndex("WorkshopSlotsSlotID");

                    b.ToTable("VehicleWorkshopSlot");
                });

            modelBuilder.Entity("WorkshopManagement.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WorkshopManagement.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("WorkshopManagement.Models.WorkshopSlot", b =>
                {
                    b.Property<int>("SlotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SlotID"));

                    b.Property<DateTime>("SlotDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("SlotID");

                    b.ToTable("WorkshopSlots");
                });

            modelBuilder.Entity("VehicleWorkshopSlot", b =>
                {
                    b.HasOne("WorkshopManagement.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesVehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkshopManagement.Models.WorkshopSlot", null)
                        .WithMany()
                        .HasForeignKey("WorkshopSlotsSlotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkshopManagement.Models.Vehicle", b =>
                {
                    b.HasOne("WorkshopManagement.Models.Customer", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkshopManagement.Models.Customer", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
