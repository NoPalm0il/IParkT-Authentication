﻿// <auto-generated />
using System;
using IParkT_Authentication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IParkT_Authentication.Migrations
{
    [DbContext(typeof(IParkTDB))]
    partial class IParkTDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IParkT_Authentication.Models.Car", b =>
                {
                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Utilizadorusername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int>("username")
                        .HasColumnType("int");

                    b.HasKey("LicensePlate");

                    b.HasIndex("Utilizadorusername");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("IParkT_Authentication.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GpsCoords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParkSpot")
                        .HasColumnType("int");

                    b.Property<string>("ParkSpotType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParkId");

                    b.ToTable("Park");
                });

            modelBuilder.Entity("IParkT_Authentication.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CarLicensePlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParkId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CarLicensePlate");

                    b.HasIndex("ParkId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("IParkT_Authentication.Models.Utilizador", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.ToTable("User");
                });

            modelBuilder.Entity("IParkT_Authentication.Models.Car", b =>
                {
                    b.HasOne("IParkT_Authentication.Models.Utilizador", null)
                        .WithMany("Cars")
                        .HasForeignKey("Utilizadorusername");
                });

            modelBuilder.Entity("IParkT_Authentication.Models.Reservation", b =>
                {
                    b.HasOne("IParkT_Authentication.Models.Car", null)
                        .WithMany("Reservations")
                        .HasForeignKey("CarLicensePlate");

                    b.HasOne("IParkT_Authentication.Models.Park", null)
                        .WithMany("Reservations")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
