using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Domain.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "DateOfBirth", "FirstName", "Lastname" },
                values: new object[] { 1, new DateTime(1996, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pera", "Peric" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "DateOfBirth", "FirstName", "Lastname" },
                values: new object[] { 2, new DateTime(1998, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mika", "Mikic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2);
        }
    }
}
