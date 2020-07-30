using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddRelationShip_SubjectMatterAndTeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AssignedTeacherId",
                table: "subject_matter",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TeacherId",
                table: "subject_matter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subject_matter_AssignedTeacherId",
                table: "subject_matter",
                column: "AssignedTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_subject_matter_TeacherId",
                table: "subject_matter",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_subject_matter_teacher_AssignedTeacherId",
                table: "subject_matter",
                column: "AssignedTeacherId",
                principalTable: "teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subject_matter_teacher_TeacherId",
                table: "subject_matter",
                column: "TeacherId",
                principalTable: "teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subject_matter_teacher_AssignedTeacherId",
                table: "subject_matter");

            migrationBuilder.DropForeignKey(
                name: "FK_subject_matter_teacher_TeacherId",
                table: "subject_matter");

            migrationBuilder.DropIndex(
                name: "IX_subject_matter_AssignedTeacherId",
                table: "subject_matter");

            migrationBuilder.DropIndex(
                name: "IX_subject_matter_TeacherId",
                table: "subject_matter");

            migrationBuilder.DropColumn(
                name: "AssignedTeacherId",
                table: "subject_matter");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "subject_matter");
        }
    }
}
