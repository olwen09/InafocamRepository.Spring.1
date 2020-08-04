using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddColumnMaleQuantityAndfemaleQuantityToTracingStudyPlanDevelopmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaleQuantity",
                table: "tracing_study_plan_development",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "femaleQuantity",
                table: "tracing_study_plan_development",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "answer",
                table: "scholarship_program_tracing_student_support",
                unicode: false,
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaleQuantity",
                table: "tracing_study_plan_development");

            migrationBuilder.DropColumn(
                name: "femaleQuantity",
                table: "tracing_study_plan_development");

            migrationBuilder.DropColumn(
                name: "answer",
                table: "scholarship_program_tracing_student_support");
        }
    }
}
