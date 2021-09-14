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
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 312, DateTimeKind.Unspecified).AddTicks(1100), new TimeSpan(0, 3, 0, 0, 0)), "admin@gmail.com", "John Doe", "TyhMDFKBArJu716n88z9vYCju+OOxj75f/tdg5KlCC4=", new byte[] { 188, 16, 131, 115, 241, 184, 193, 81, 53, 222, 197, 66, 219, 252, 227, 233 } });

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Address", "CreatedDate", "Price", "SecondFrom", "SecondTo" },
                values: new object[,]
                {
                    { 1L, "564 Letha Pines, Aileenhaven, Palau", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 6.0910316957584731, 10378L, 19410L },
                    { 2L, "9006 Brando Fall, Hartmannborough, Thailand", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 6.0677095298039303, 19991L, 14032L },
                    { 3L, "6522 Julien Knoll, Lydaside, Croatia", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 7.6916030946614233, 13798L, 15125L },
                    { 4L, "3661 Bartoletti Mission, Predovicstad, Estonia", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 5.7840557586327455, 17815L, 12655L },
                    { 5L, "5548 Dayna Courts, Taraport, Faroe Islands", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 5.818217841823687, 18501L, 11478L },
                    { 6L, "984 Friedrich Place, Kovacekborough, New Zealand", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 9.7358093921727544, 19760L, 10248L },
                    { 7L, "413 Eryn Pine, Port Chasity, Cocos (Keeling) Islands", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 8.8549677812750289, 14435L, 11237L },
                    { 8L, "46466 Lowe Alley, Madisynview, Nicaragua", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 5.819535009013272, 19041L, 14798L },
                    { 9L, "826 Mayert Turnpike, West Blanca, Hungary", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 7.1510426523867263, 17794L, 11228L },
                    { 10L, "395 Ernest Roads, South Mohamed, Qatar", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 423, DateTimeKind.Unspecified).AddTicks(6746), new TimeSpan(0, 3, 0, 0, 0)), 9.378280874517877, 18004L, 17120L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "First_name", "IsAccess", "Last_name", "Password", "Phone", "StoredSalt" },
                values: new object[,]
                {
                    { 1L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 482, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 3, 0, 0, 0)), "string", "John", true, "Doe", "EJ7NO1W/KN+KOAcmt+i08BZPQWZiKjuEgLo6ujJyFbk=", "+380994444333", new byte[] { 186, 238, 98, 48, 43, 11, 19, 71, 203, 165, 173, 53, 210, 154, 14, 10 } },
                    { 2L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 482, DateTimeKind.Unspecified).AddTicks(5558), new TimeSpan(0, 3, 0, 0, 0)), "user@gmail.com", "Ruslan", true, "Tonus", "EJ7NO1W/KN+KOAcmt+i08BZPQWZiKjuEgLo6ujJyFbk=", "+380993334444", new byte[] { 186, 238, 98, 48, 43, 11, 19, 71, 203, 165, 173, 53, 210, 154, 14, 10 } }
                });

            migrationBuilder.InsertData(
                table: "Valets",
                columns: new[] { "Id", "CreatedDate", "Email", "Full_name", "IsAccess", "Jetton", "Password", "Phone", "StoredSalt" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 332, DateTimeKind.Unspecified).AddTicks(7885), new TimeSpan(0, 3, 0, 0, 0)), "valet@gmail.com", "Valet Doe", true, "123456", "z2AMTzemMDqgn18wKFZiiGjDPK4P9x1QxW4ZLHWOEvc=", "+380994444333", new byte[] { 5, 12, 192, 77, 234, 108, 177, 82, 119, 74, 243, 223, 59, 115, 112, 84 } });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "CreatedDate", "Model", "Number", "UserId" },
                values: new object[,]
                {
                    { 2L, "#295e3b", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "RMUEBVDL", "BE1387PW", 1L },
                    { 3L, "#2e724f", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "JDPDBMKN", "TL4821XF", 1L },
                    { 9L, "#23486a", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "OEIULTBK", "CF9919ET", 1L },
                    { 10L, "#000a79", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "OIGNEDTK", "RO0132BL", 1L },
                    { 1L, "#1d6a4d", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "SEBQHBON", "LE6850NA", 2L },
                    { 4L, "#71580f", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "WCLHBGXS", "IP6435GO", 2L },
                    { 5L, "#562d08", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "KOPNQFCS", "SK5410DG", 2L },
                    { 6L, "#3a724f", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "NQEETAMR", "UJ3670XH", 2L },
                    { 7L, "#343c64", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "EEXWBGJH", "JA9563XS", 2L },
                    { 8L, "#5c200f", new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 494, DateTimeKind.Unspecified).AddTicks(5808), new TimeSpan(0, 3, 0, 0, 0)), "QIWJCVQB", "BT8772OI", 2L }
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
                values: new object[,]
                {
                    { 2L, 2L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 1L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) },
                    { 3L, 3L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 2L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) },
                    { 9L, 9L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 1L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) },
                    { 10L, 10L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 2L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) },
                    { 1L, 1L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 2L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) },
                    { 4L, 4L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 2L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) },
                    { 5L, 5L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 2L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) },
                    { 6L, 6L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 2L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) },
                    { 7L, 7L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 2L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) },
                    { 8L, 8L, new DateTimeOffset(new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 13, 26, 47, 508, DateTimeKind.Local).AddTicks(6919), 2L, new DateTime(2021, 9, 14, 12, 26, 47, 508, DateTimeKind.Local).AddTicks(754) }
                });

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
