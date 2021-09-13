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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    First_name = table.Column<string>(type: "text", nullable: true),
                    Last_name = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsAccess = table.Column<bool>(type: "boolean", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    StoredSalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Model = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    IsDefaulte = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ParkingId = table.Column<long>(type: "bigint", nullable: false),
                    CarId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Parkings_ParkingId",
                        column: x => x.ParkingId,
                        principalTable: "Parkings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "CreatedDate", "Email", "Full_name", "Password", "StoredSalt" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 488, DateTimeKind.Unspecified).AddTicks(4756), new TimeSpan(0, 3, 0, 0, 0)), "admin@gmail.com", "John Doe", "fVdaszZKAHRWH9Be+fSY+qPZ70QkF/Y/eJrflxj9BxE=", new byte[] { 221, 136, 6, 156, 33, 157, 117, 105, 22, 203, 20, 183, 126, 90, 53, 253 } });

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Address", "CreatedDate", "Price", "SecondFrom", "SecondTo" },
                values: new object[] { 1L, "There and here?", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 526, DateTimeKind.Unspecified).AddTicks(9021), new TimeSpan(0, 3, 0, 0, 0)), 5.4500000000000002, 123456L, 654321L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "First_name", "IsAccess", "Last_name", "Password", "Phone", "StoredSalt" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 549, DateTimeKind.Unspecified).AddTicks(8611), new TimeSpan(0, 3, 0, 0, 0)), "user@gmail.com", "John", true, "Doe", "q5T4WjHJfXF3bH2udyV7SfAO2Ttl/mTo21ByUluYP1k=", "+380994444333", new byte[] { 22, 104, 126, 155, 88, 178, 155, 17, 32, 62, 103, 120, 169, 179, 94, 20 } });

            migrationBuilder.InsertData(
                table: "Valets",
                columns: new[] { "Id", "CreatedDate", "Email", "Full_name", "IsAccess", "Jetton", "Password", "Phone", "StoredSalt" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 507, DateTimeKind.Unspecified).AddTicks(9338), new TimeSpan(0, 3, 0, 0, 0)), "valet@gmail.com", "Valet Doe", true, "123456", "N2Dip9tVqQO9bJ/ZtvmC9OhQ4PmY3IOHICUzZWs2gjc=", "+380994444333", new byte[] { 39, 240, 73, 131, 113, 10, 240, 133, 15, 231, 104, 154, 241, 18, 190, 13 } });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "CreatedDate", "Model", "Number", "UserId" },
                values: new object[,]
                {
                    { 1L, "#116867", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "LLBRPTVQ", "BB7061DD", 1L },
                    { 2L, "#131b52", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "JJQNEVAV", "AA2712AD", 1L },
                    { 3L, "#7f6575", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "PBONKPLE", "BD1679AB", 1L },
                    { 4L, "#61636f", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "VUOWUOEP", "CD6275CA", 1L },
                    { 5L, "#65050f", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "FWQQRWUM", "CD0800AB", 1L },
                    { 6L, "#7f1a12", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "RXFXUJQQ", "BA2837AC", 1L },
                    { 7L, "#740177", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "VXABPUOX", "CA5271CA", 1L },
                    { 8L, "#105d71", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "THAFMLGX", "CA9521CA", 1L },
                    { 9L, "#6c6d64", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "NDGKDMST", "CC7625AB", 1L },
                    { 10L, "#654971", new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 614, DateTimeKind.Unspecified).AddTicks(8991), new TimeSpan(0, 3, 0, 0, 0)), "MOIVWVOP", "BA0953AB", 1L }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude", "ParkingId" },
                values: new object[,]
                {
                    { 1L, 789.45600000000002, 456.78899999999999, 1L },
                    { 2L, 789.45600000000002, 456.78899999999999, 1L }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "CarId", "CreatedDate", "EndTime", "ParkingId", "StartTime" },
                values: new object[] { 1L, 1L, new DateTimeOffset(new DateTime(2021, 9, 13, 19, 5, 13, 632, DateTimeKind.Unspecified).AddTicks(5102), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 13, 20, 5, 13, 632, DateTimeKind.Local).AddTicks(4546), 1L, new DateTime(2021, 9, 13, 19, 5, 13, 632, DateTimeKind.Local).AddTicks(2848) });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ParkingId",
                table: "Locations",
                column: "ParkingId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CarId",
                table: "Sessions",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ParkingId",
                table: "Sessions",
                column: "ParkingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Valets");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
