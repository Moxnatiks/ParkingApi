﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ParkingApi.Settings;

namespace ParkingApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 312, DateTimeKind.Unspecified).AddTicks(1100), new TimeSpan(0, 3, 0, 0, 0)),
                            Email = "admin@gmail.com",
                            Full_name = "John Doe",
                            Password = "TyhMDFKBArJu716n88z9vYCju+OOxj75f/tdg5KlCC4=",
                            StoredSalt = new byte[] { 188, 16, 131, 115, 241, 184, 193, 81, 53, 222, 197, 66, 219, 252, 227, 233 }
                        });
                });

            modelBuilder.Entity("ParkingApi.Models.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDefaulte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Color = "#1d6a4d",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "SEBQHBON",
                            Number = "LE6850NA",
                            UserId = 2L
                        },
                        new
                        {
                            Id = 2L,
                            Color = "#295e3b",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "RMUEBVDL",
                            Number = "BE1387PW",
                            UserId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            Color = "#2e724f",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "JDPDBMKN",
                            Number = "TL4821XF",
                            UserId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            Color = "#71580f",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "WCLHBGXS",
                            Number = "IP6435GO",
                            UserId = 2L
                        },
                        new
                        {
                            Id = 5L,
                            Color = "#562d08",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "KOPNQFCS",
                            Number = "SK5410DG",
                            UserId = 2L
                        },
                        new
                        {
                            Id = 6L,
                            Color = "#3a724f",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "NQEETAMR",
                            Number = "UJ3670XH",
                            UserId = 2L
                        },
                        new
                        {
                            Id = 7L,
                            Color = "#343c64",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "EEXWBGJH",
                            Number = "JA9563XS",
                            UserId = 2L
                        },
                        new
                        {
                            Id = 8L,
                            Color = "#5c200f",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "QIWJCVQB",
                            Number = "BT8772OI",
                            UserId = 2L
                        },
                        new
                        {
                            Id = 9L,
                            Color = "#23486a",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "OEIULTBK",
                            Number = "CF9919ET",
                            UserId = 1L
                        },
                        new
                        {
                            Id = 10L,
                            Color = "#000a79",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)),
                            IsDefaulte = false,
                            Model = "OIGNEDTK",
                            Number = "RO0132BL",
                            UserId = 1L
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
                            Address = "564 Letha Pines, Aileenhaven, Palau",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 6.0910316957584731,
                            SecondFrom = 10378L,
                            SecondTo = 19410L
                        },
                        new
                        {
                            Id = 2L,
                            Address = "9006 Brando Fall, Hartmannborough, Thailand",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 6.0677095298039303,
                            SecondFrom = 19991L,
                            SecondTo = 14032L
                        },
                        new
                        {
                            Id = 3L,
                            Address = "6522 Julien Knoll, Lydaside, Croatia",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 7.6916030946614233,
                            SecondFrom = 13798L,
                            SecondTo = 15125L
                        },
                        new
                        {
                            Id = 4L,
                            Address = "3661 Bartoletti Mission, Predovicstad, Estonia",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 5.7840557586327455,
                            SecondFrom = 17815L,
                            SecondTo = 12655L
                        },
                        new
                        {
                            Id = 5L,
                            Address = "5548 Dayna Courts, Taraport, Faroe Islands",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 5.818217841823687,
                            SecondFrom = 18501L,
                            SecondTo = 11478L
                        },
                        new
                        {
                            Id = 6L,
                            Address = "984 Friedrich Place, Kovacekborough, New Zealand",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 9.7358093921727544,
                            SecondFrom = 19760L,
                            SecondTo = 10248L
                        },
                        new
                        {
                            Id = 7L,
                            Address = "413 Eryn Pine, Port Chasity, Cocos (Keeling) Islands",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 8.8549677812750289,
                            SecondFrom = 14435L,
                            SecondTo = 11237L
                        },
                        new
                        {
                            Id = 8L,
                            Address = "46466 Lowe Alley, Madisynview, Nicaragua",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 5.819535009013272,
                            SecondFrom = 19041L,
                            SecondTo = 14798L
                        },
                        new
                        {
                            Id = 9L,
                            Address = "826 Mayert Turnpike, West Blanca, Hungary",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 7.1510426523867263,
                            SecondFrom = 17794L,
                            SecondTo = 11228L
                        },
                        new
                        {
                            Id = 10L,
                            Address = "395 Ernest Roads, South Mohamed, Qatar",
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)),
                            Price = 9.378280874517877,
                            SecondFrom = 18004L,
                            SecondTo = 17120L
                        });
                });

            modelBuilder.Entity("ParkingApi.Models.Session", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CarId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("ParkingId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("ParkingId");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CarId = 1L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 2L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        },
                        new
                        {
                            Id = 2L,
                            CarId = 2L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 1L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        },
                        new
                        {
                            Id = 3L,
                            CarId = 3L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 2L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        },
                        new
                        {
                            Id = 4L,
                            CarId = 4L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 2L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        },
                        new
                        {
                            Id = 5L,
                            CarId = 5L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 2L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        },
                        new
                        {
                            Id = 6L,
                            CarId = 6L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 2L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        },
                        new
                        {
                            Id = 7L,
                            CarId = 7L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 2L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        },
                        new
                        {
                            Id = 8L,
                            CarId = 8L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 2L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        },
                        new
                        {
                            Id = 9L,
                            CarId = 9L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 1L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        },
                        new
                        {
                            Id = 10L,
                            CarId = 10L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)),
                            EndTime = new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919),
                            ParkingId = 2L,
                            StartTime = new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754)
                        });
                });

            modelBuilder.Entity("ParkingApi.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("First_name")
                        .HasColumnType("text");

                    b.Property<bool>("IsAccess")
                        .HasColumnType("boolean");

                    b.Property<string>("Last_name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<byte[]>("StoredSalt")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 482, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 3, 0, 0, 0)),
                            Email = "string",
                            First_name = "John",
                            IsAccess = true,
                            Last_name = "Doe",
                            Password = "EJ7NO1W/KN+KOAcmt+i08BZPQWZiKjuEgLo6ujJyFbk=",
                            Phone = "+380994444333",
                            StoredSalt = new byte[] { 186, 238, 98, 48, 43, 11, 19, 71, 203, 165, 173, 53, 210, 154, 14, 10 }
                        },
                        new
                        {
                            Id = 2L,
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 482, DateTimeKind.Unspecified).AddTicks(5558), new TimeSpan(0, 3, 0, 0, 0)),
                            Email = "user@gmail.com",
                            First_name = "Ruslan",
                            IsAccess = true,
                            Last_name = "Tonus",
                            Password = "EJ7NO1W/KN+KOAcmt+i08BZPQWZiKjuEgLo6ujJyFbk=",
                            Phone = "+380993334444",
                            StoredSalt = new byte[] { 186, 238, 98, 48, 43, 11, 19, 71, 203, 165, 173, 53, 210, 154, 14, 10 }
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
                            CreatedDate = new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 332, DateTimeKind.Unspecified).AddTicks(7885), new TimeSpan(0, 3, 0, 0, 0)),
                            Email = "valet@gmail.com",
                            Full_name = "Valet Doe",
                            IsAccess = true,
                            Jetton = "123456",
                            Password = "z2AMTzemMDqgn18wKFZiiGjDPK4P9x1QxW4ZLHWOEvc=",
                            Phone = "+380994444333",
                            StoredSalt = new byte[] { 5, 12, 192, 77, 234, 108, 177, 82, 119, 74, 243, 223, 59, 115, 112, 84 }
                        });
                });

            modelBuilder.Entity("ParkingApi.Models.Car", b =>
                {
                    b.HasOne("ParkingApi.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
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

            modelBuilder.Entity("ParkingApi.Models.Session", b =>
                {
                    b.HasOne("ParkingApi.Models.Car", "Car")
                        .WithOne("Session")
                        .HasForeignKey("ParkingApi.Models.Session", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkingApi.Models.Parking", "Parking")
                        .WithMany("Sessions")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Parking");
                });

            modelBuilder.Entity("ParkingApi.Models.Car", b =>
                {
                    b.Navigation("Session");
                });

            modelBuilder.Entity("ParkingApi.Models.Parking", b =>
                {
                    b.Navigation("Locations");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ParkingApi.Models.User", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
