using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ParkingApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Full_name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    StoredSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "text", nullable: true),
                    SecondFrom = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    SecondTo = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Price = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Full_name = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Jetton = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsAccess = table.Column<bool>(type: "boolean", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    StoredSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    ParkingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedDate", "Email", "Full_name", "Password", "StoredSalt" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 8, 25, 13, 52, 28, 174, DateTimeKind.Unspecified).AddTicks(259), new TimeSpan(0, 3, 0, 0, 0)), "admin@gmail.com", "John Doe", "NPi50qQAnRznSLghjYNF+BVUyAAd6wK0NQALwO2s1x4=", new byte[] { 163, 163, 136, 33, 52, 115, 110, 175, 109, 141, 140, 181, 218, 179, 137, 55 } });

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Address", "CreatedDate", "Price", "SecondFrom", "SecondTo" },
                values: new object[] { 1L, "There and here?", new DateTimeOffset(new DateTime(2021, 8, 25, 13, 52, 28, 192, DateTimeKind.Unspecified).AddTicks(5258), new TimeSpan(0, 3, 0, 0, 0)), 5.4500000000000002, 123456L, 654321L });

            migrationBuilder.InsertData(
                table: "Valets",
                columns: new[] { "Id", "CreatedDate", "Email", "Full_name", "IsAccess", "Jetton", "Password", "Phone", "StoredSalt" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 8, 25, 13, 52, 28, 180, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 3, 0, 0, 0)), "valet@gmail.com", "Valet Doe", true, "123456", "NPi50qQAnRznSLghjYNF+BVUyAAd6wK0NQALwO2s1x4=", "+380994444333", new byte[] { 163, 163, 136, 33, 52, 115, 110, 175, 109, 141, 140, 181, 218, 179, 137, 55 } });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude", "ParkingId" },
                values: new object[,]
                {
                    { 1L, 789.45600000000002, 456.78899999999999, 1L },
                    { 2L, 789.45600000000002, 456.78899999999999, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ParkingId",
                table: "Locations",
                column: "ParkingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Valets");

            migrationBuilder.DropTable(
                name: "Parkings");
        }
    }
}
