using Microsoft.EntityFrameworkCore.Migrations;

namespace Students.Domain.Migrations
{
    public partial class AddedOwnsMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectItem_Subjects_SubjectId",
                table: "SubjectItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectItem",
                table: "SubjectItem");

            migrationBuilder.DropIndex(
                name: "IX_SubjectItem_SubjectId",
                table: "SubjectItem");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectItem",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectItem_Subjects_SubjectId",
                table: "SubjectItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectItem",
                table: "SubjectItem");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "SubjectItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectItem",
                table: "SubjectItem",
                column: "SubjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectItem_SubjectId",
                table: "SubjectItem",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectItem_Subjects_SubjectId",
                table: "SubjectItem",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
