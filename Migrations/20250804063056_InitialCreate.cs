using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Equinox.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassCategories",
                columns: table => new
                {
                    ClassCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCategories", x => x.ClassCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCoach = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "EquinoxClasses",
                columns: table => new
                {
                    EquinoxClassId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ClassPicture = table.Column<string>(type: "TEXT", nullable: false),
                    ClassDay = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    ClassCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquinoxClasses", x => x.EquinoxClassId);
                    table.ForeignKey(
                        name: "FK_EquinoxClasses_ClassCategories_ClassCategoryId",
                        column: x => x.ClassCategoryId,
                        principalTable: "ClassCategories",
                        principalColumn: "ClassCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquinoxClasses_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquinoxClasses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquinoxClassId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_EquinoxClasses_EquinoxClassId",
                        column: x => x.EquinoxClassId,
                        principalTable: "EquinoxClasses",
                        principalColumn: "EquinoxClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassCategories",
                columns: new[] { "ClassCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Yoga" },
                    { 2, "HIIT" },
                    { 3, "Cardio" },
                    { 4, "Strength" }
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "ClubId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Chicago Loop", "(123) 456-7890" },
                    { 2, "West Chicago", "(987) 654-3210" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DOB", "Email", "IsCoach", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "coach1", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane@example.com", true, "Jane Coach", "(555) 123-4567" },
                    { "coach2", new DateTime(1988, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah@example.com", true, "Sarah", "(555) 234-5678" },
                    { "coach3", new DateTime(1985, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "george@example.com", true, "George", "(555) 345-6789" },
                    { "coach4", new DateTime(1982, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "henry@example.com", true, "Henry", "(555) 456-7890" },
                    { "coach5", new DateTime(1991, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "lena@example.com", true, "Lena", "(555) 567-8901" }
                });

            migrationBuilder.InsertData(
                table: "EquinoxClasses",
                columns: new[] { "EquinoxClassId", "ClassCategoryId", "ClassDay", "ClassPicture", "ClubId", "Name", "Time", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Monday", "yoga2.jpg", 1, "Morning Yoga", "8 AM – 9 AM", "coach1" },
                    { 2, 2, "Wednesday", "hiit1.jpg", 2, "Power HIIT", "6 PM – 7 PM", "coach1" },
                    { 3, 3, "Friday", "barre-fusion.jpg", 1, "Cardio Blast", "7 AM – 8 AM", "coach2" },
                    { 4, 4, "Saturday", "strength-training.jpg", 2, "Strength Training", "10 AM – 11 AM", "coach3" },
                    { 5, 1, "Sunday", "hatha-yoga.jpg", 1, "Yoga 202", "5 PM – 6 PM", "coach4" },
                    { 6, 1, "Sunday", "boxing-101.jpg", 1, "Power Yoga", "3 PM – 4 PM", "coach5" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "EquinoxClassId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EquinoxClassId",
                table: "Bookings",
                column: "EquinoxClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EquinoxClasses_ClassCategoryId",
                table: "EquinoxClasses",
                column: "ClassCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EquinoxClasses_ClubId",
                table: "EquinoxClasses",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_EquinoxClasses_UserId",
                table: "EquinoxClasses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "EquinoxClasses");

            migrationBuilder.DropTable(
                name: "ClassCategories");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
