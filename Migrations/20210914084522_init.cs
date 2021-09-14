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
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 836, DateTimeKind.Unspecified).AddTicks(6591), new TimeSpan(0, 3, 0, 0, 0)), "admin@gmail.com", "John Doe", "7bTTczM/7AFVoUaijA8ZzIr9aine/ZnqiKHhCHtreds=", new byte[] { 66, 59, 154, 42, 216, 126, 122, 108, 0, 79, 251, 115, 18, 27, 12, 155 } });

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Address", "CreatedDate", "Price", "SecondFrom", "SecondTo" },
                values: new object[,]
                {
                    { 1L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 7.5722123624627535, 17639L, 15889L },
                    { 2L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 8.4012710947549305, 18446L, 19965L },
                    { 3L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 5.3966689763575184, 13412L, 17260L },
                    { 4L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 9.6393418822620731, 14161L, 19332L },
                    { 5L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 6.5656667722229223, 10737L, 18698L },
                    { 6L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 8.6058167338398359, 17551L, 18411L },
                    { 7L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 8.3811668485315352, 12720L, 17749L },
                    { 8L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 6.1416014871288098, 12022L, 19409L },
                    { 9L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 9.9844671995306697, 19169L, 15358L },
                    { 10L, "en", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 934, DateTimeKind.Unspecified).AddTicks(3694), new TimeSpan(0, 3, 0, 0, 0)), 7.5691091327784159, 11052L, 18045L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "First_name", "IsAccess", "Last_name", "Password", "Phone", "StoredSalt" },
                values: new object[,]
                {
                    { 1L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 970, DateTimeKind.Unspecified).AddTicks(3153), new TimeSpan(0, 3, 0, 0, 0)), "string", "John", true, "Doe", "0es5Z6h0OhZFHJAZPnbrYecyXZvuXDhDjvVbau2ra2E=", "+380994444333", new byte[] { 241, 131, 49, 253, 172, 74, 73, 135, 2, 5, 23, 185, 11, 192, 70, 150 } },
                    { 2L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 970, DateTimeKind.Unspecified).AddTicks(3232), new TimeSpan(0, 3, 0, 0, 0)), "user@gmail.com", "Ruslan", true, "Tonus", "0es5Z6h0OhZFHJAZPnbrYecyXZvuXDhDjvVbau2ra2E=", "+380993334444", new byte[] { 241, 131, 49, 253, 172, 74, 73, 135, 2, 5, 23, 185, 11, 192, 70, 150 } }
                });

            migrationBuilder.InsertData(
                table: "Valets",
                columns: new[] { "Id", "CreatedDate", "Email", "Full_name", "IsAccess", "Jetton", "Password", "Phone", "StoredSalt" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 856, DateTimeKind.Unspecified).AddTicks(2149), new TimeSpan(0, 3, 0, 0, 0)), "valet@gmail.com", "Valet Doe", true, "123456", "UtYB7nSKpFSuGOP2RyWpVuvjpKqHhq3vHba7EW3nPKI=", "+380994444333", new byte[] { 242, 0, 129, 145, 253, 192, 234, 148, 33, 159, 232, 188, 110, 176, 80, 169 } });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "CreatedDate", "Model", "Number", "UserId" },
                values: new object[,]
                {
                    { 2L, "#491f1a", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "LCIMCGNP", "QW4529WV", 1L },
                    { 4L, "#6c7066", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "HNBPRXOL", "BF8511GM", 1L },
                    { 6L, "#5e7b6f", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "HHCOQPBE", "AT0208CV", 1L },
                    { 7L, "#221d35", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "SQVXMDFM", "KH5110UD", 1L },
                    { 9L, "#680876", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "JNSRETEX", "WX6557GS", 1L },
                    { 10L, "#1f144d", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "KTXPCPJT", "BG7118QO", 1L },
                    { 1L, "#602b14", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "XMIBUUES", "NE5840CK", 2L },
                    { 3L, "#156b7e", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "MXGLRWTE", "TN1133HU", 2L },
                    { 5L, "#755361", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "LJTCSGFW", "OC7726RX", 2L },
                    { 8L, "#390f0b", new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 981, DateTimeKind.Unspecified).AddTicks(1600), new TimeSpan(0, 3, 0, 0, 0)), "EAVTBKQK", "MT2972XO", 2L }
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
                    { 2L, 2L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 2L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) },
                    { 4L, 4L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 2L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) },
                    { 6L, 6L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 2L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) },
                    { 7L, 7L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 1L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) },
                    { 9L, 9L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 1L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) },
                    { 10L, 10L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 1L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) },
                    { 1L, 1L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 1L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) },
                    { 3L, 3L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 1L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) },
                    { 5L, 5L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 1L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) },
                    { 8L, 8L, new DateTimeOffset(new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Unspecified).AddTicks(8980), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 14, 12, 45, 21, 993, DateTimeKind.Local).AddTicks(8279), 1L, new DateTime(2021, 9, 14, 11, 45, 21, 993, DateTimeKind.Local).AddTicks(3362) }
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
