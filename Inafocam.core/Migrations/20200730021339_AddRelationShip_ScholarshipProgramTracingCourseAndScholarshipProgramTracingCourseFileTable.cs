using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddRelationShip_ScholarshipProgramTracingCourseAndScholarshipProgramTracingCourseFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ScholarshipProgramTracingCourseId",
                table: "scholarship_program_tracing_course_file",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_scholarship_program_tracing_course_file_ScholarshipProgramTr~",
                table: "scholarship_program_tracing_course_file",
                column: "ScholarshipProgramTracingCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_tracing_course_file_scholarship_program_~",
                table: "scholarship_program_tracing_course_file",
                column: "ScholarshipProgramTracingCourseId",
                principalTable: "scholarship_program_tracing_course",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scholarship_program_tracing_course_file_scholarship_program_~",
                table: "scholarship_program_tracing_course_file");

            migrationBuilder.DropIndex(
                name: "IX_scholarship_program_tracing_course_file_ScholarshipProgramTr~",
                table: "scholarship_program_tracing_course_file");

            migrationBuilder.DropColumn(
                name: "ScholarshipProgramTracingCourseId",
                table: "scholarship_program_tracing_course_file");
        }
    }
}
