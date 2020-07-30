using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class DrompForeingKeyUniversityFromTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teacher_university_UniversityId",
                table: "teacher");

            migrationBuilder.DropIndex(
                name: "IX_teacher_UniversityId",
                table: "teacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_teacher_UniversityId",
                table: "teacher",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_university_UniversityId",
                table: "teacher",
                column: "UniversityId",
                principalTable: "university",
                principalColumn: "university_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
