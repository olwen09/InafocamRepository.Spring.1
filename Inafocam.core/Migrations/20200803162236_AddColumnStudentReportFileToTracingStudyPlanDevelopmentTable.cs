using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddColumnStudentReportFileToTracingStudyPlanDevelopmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StudentReportFileId",
                table: "tracing_study_plan_development",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tracing_study_plan_development_StudentReportFileId",
                table: "tracing_study_plan_development",
                column: "StudentReportFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_tracing_study_plan_development_file_StudentReportFileId",
                table: "tracing_study_plan_development",
                column: "StudentReportFileId",
                principalTable: "file",
                principalColumn: "file_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tracing_study_plan_development_file_StudentReportFileId",
                table: "tracing_study_plan_development");

            migrationBuilder.DropIndex(
                name: "IX_tracing_study_plan_development_StudentReportFileId",
                table: "tracing_study_plan_development");

            migrationBuilder.DropColumn(
                name: "StudentReportFileId",
                table: "tracing_study_plan_development");
        }
    }
}
