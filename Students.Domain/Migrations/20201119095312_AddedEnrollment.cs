using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Domain.Migrations
{
    public partial class AddedEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectItem_Subjects_SubjectId",
                table: "SubjectItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectItem",
                table: "SubjectItem");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "SubjectItem");

            migrationBuilder.AddColumn<int>(
                name: "SId",
                table: "Subjects",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SubjectSId",
                table: "SubjectItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "SId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectItem",
                table: "SubjectItem",
                columns: new[] { "SubjectSId", "SubjectItemId" });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_Enrollment_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_SubjectId",
                table: "Enrollment",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectItem_Subjects_SubjectSId",
                table: "SubjectItem",
                column: "SubjectSId",
                principalTable: "Subjects",
                principalColumn: "SId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectItem_Subjects_SubjectSId",
                table: "SubjectItem");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectItem",
                table: "SubjectItem");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectSId",
                table: "SubjectItem");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "SubjectItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectItem",
                table: "SubjectItem",
                columns: new[] { "SubjectId", "SubjectItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectItem_Subjects_SubjectId",
                table: "SubjectItem",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
