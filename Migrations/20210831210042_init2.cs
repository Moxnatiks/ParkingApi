using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ParkingApi.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password", "StoredSalt" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 41, 14, DateTimeKind.Unspecified).AddTicks(6332), new TimeSpan(0, 3, 0, 0, 0)), "+Z4l4oyrs0krAHYGJi0R0YLfrN0VXslFl4p5xGcR2fk=", new byte[] { 44, 106, 55, 86, 92, 107, 92, 49, 225, 13, 200, 33, 202, 9, 99, 111 } });

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 41, 62, DateTimeKind.Unspecified).AddTicks(2761), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "First_name", "IsAccess", "Last_name", "Password", "Phone", "StoredSalt" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 41, 94, DateTimeKind.Unspecified).AddTicks(5477), new TimeSpan(0, 3, 0, 0, 0)), "user@gmail.com", "John", true, "Doe", "86H0U0gbLT0fO64VIJFYApp3CXEcZ2RPrk3chE5XCHY=", "+380994444333", new byte[] { 186, 121, 65, 167, 195, 56, 147, 18, 52, 179, 1, 219, 63, 162, 242, 17 } });

            migrationBuilder.UpdateData(
                table: "Valets",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password", "StoredSalt" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 41, 40, DateTimeKind.Unspecified).AddTicks(9504), new TimeSpan(0, 3, 0, 0, 0)), "5yZPpMErxV9m70UYhvrZMw5N6Ts2u1fDgcQD0QYUIGM=", new byte[] { 33, 52, 186, 25, 49, 207, 62, 177, 32, 65, 120, 115, 102, 41, 0, 227 } });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "CreatedDate", "IsDefaulte", "Model", "Number", "UserId" },
                values: new object[] { 1L, "green", new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 41, 103, DateTimeKind.Unspecified).AddTicks(6558), new TimeSpan(0, 3, 0, 0, 0)), true, "Volga", "AA1234BB", 1L });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "CreatedDate", "Model", "Number", "UserId" },
                values: new object[] { 2L, "red", new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 41, 103, DateTimeKind.Unspecified).AddTicks(6596), new TimeSpan(0, 3, 0, 0, 0)), "Nissan", "AA4321BB", 1L });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "CarId", "CreatedDate", "EndTime", "ParkingId", "StartTime" },
                values: new object[] { 1L, 1L, new DateTimeOffset(new DateTime(2021, 9, 1, 0, 0, 41, 107, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2021, 9, 1, 1, 0, 41, 107, DateTimeKind.Local).AddTicks(6851), 1L, new DateTime(2021, 9, 1, 0, 0, 41, 107, DateTimeKind.Local).AddTicks(5467) });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

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
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password", "StoredSalt" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 25, 13, 52, 28, 174, DateTimeKind.Unspecified).AddTicks(259), new TimeSpan(0, 3, 0, 0, 0)), "NPi50qQAnRznSLghjYNF+BVUyAAd6wK0NQALwO2s1x4=", new byte[] { 163, 163, 136, 33, 52, 115, 110, 175, 109, 141, 140, 181, 218, 179, 137, 55 } });

            migrationBuilder.UpdateData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2021, 8, 25, 13, 52, 28, 192, DateTimeKind.Unspecified).AddTicks(5258), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Valets",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Password", "StoredSalt" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 25, 13, 52, 28, 180, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 3, 0, 0, 0)), "NPi50qQAnRznSLghjYNF+BVUyAAd6wK0NQALwO2s1x4=", new byte[] { 163, 163, 136, 33, 52, 115, 110, 175, 109, 141, 140, 181, 218, 179, 137, 55 } });
        }
    }
}
