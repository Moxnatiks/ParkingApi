﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ParkingApi.Settings;

namespace ParkingApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20210825105228_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ParkingApi.Models.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Full_name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<byte[]>("StoredSalt")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 8, 25, 13, 52, 28, 174, DateTimeKind.Unspecified).AddTicks(259), new TimeSpan(0, 3, 0, 0, 0)),
                            Email = "admin@gmail.com",
                            Full_name = "John Doe",
                            Password = "NPi50qQAnRznSLghjYNF+BVUyAAd6wK0NQALwO2s1x4=",
                            StoredSalt = new byte[] { 163, 163, 136, 33, 52, 115, 110, 175, 109, 141, 140, 181, 218, 179, 137, 55 }
                        });
                });

            modelBuilder.Entity("ParkingApi.Models.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<long>("ParkingId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParkingId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Latitude = 789.45600000000002,
                            Longitude = 456.78899999999999,
                            ParkingId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Latitude = 789.45600000000002,
                            Longitude = 456.78899999999999,
                            ParkingId = 1L
                        });
                });

            modelBuilder.Entity("ParkingApi.Models.Parking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("double precision")
                        .HasDefaultValue(0.0);

                    b.Property<long>("SecondFrom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<long>("SecondTo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.HasKey("Id");

                    b.ToTable("Parkings");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "There and here?",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 8, 25, 13, 52, 28, 192, DateTimeKind.Unspecified).AddTicks(5258), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 5.4500000000000002,
                            SecondFrom = 123456L,
                            SecondTo = 654321L
                        });
                });

            modelBuilder.Entity("ParkingApi.Models.Valet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Full_name")
                        .HasColumnType("text");

                    b.Property<bool>("IsAccess")
                        .HasColumnType("boolean");

                    b.Property<string>("Jetton")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<byte[]>("StoredSalt")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Valets");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 8, 25, 13, 52, 28, 180, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 3, 0, 0, 0)),
                            Email = "valet@gmail.com",
                            Full_name = "Valet Doe",
                            IsAccess = true,
                            Jetton = "123456",
                            Password = "NPi50qQAnRznSLghjYNF+BVUyAAd6wK0NQALwO2s1x4=",
                            Phone = "+380994444333",
                            StoredSalt = new byte[] { 163, 163, 136, 33, 52, 115, 110, 175, 109, 141, 140, 181, 218, 179, 137, 55 }
                        });
                });

            modelBuilder.Entity("ParkingApi.Models.Location", b =>
                {
                    b.HasOne("ParkingApi.Models.Parking", "Parking")
                        .WithMany("Locations")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parking");
                });

            modelBuilder.Entity("ParkingApi.Models.Parking", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
