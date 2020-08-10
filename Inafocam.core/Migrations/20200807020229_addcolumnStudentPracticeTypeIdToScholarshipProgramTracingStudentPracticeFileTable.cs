using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class addcolumnStudentPracticeTypeIdToScholarshipProgramTracingStudentPracticeFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StudentPracticeTypeId",
                table: "ScholarshipProgramTracingStudentPracticeFile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentPracticeTypeId",
                table: "ScholarshipProgramTracingStudentPracticeFile");
        }
    }
}
