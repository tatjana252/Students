using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Domain.Migrations
{
    public partial class AddedSubjectESPB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ESPB",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ESPB",
                table: "Subjects");
        }
    }
}
