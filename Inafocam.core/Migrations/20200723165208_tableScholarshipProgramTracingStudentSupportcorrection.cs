using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class tableScholarshipProgramTracingStudentSupportcorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "answer",
                table: "scholarship_program_tracing_student_support");

            migrationBuilder.AddColumn<string>(
                name: "ComoLoHacenProcedimiento",
                table: "scholarship_program_tracing_student_support",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CuandoSeHacePeriodicidad",
                table: "scholarship_program_tracing_student_support",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cuálesutilizan",
                table: "scholarship_program_tracing_student_support",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuienEsElResponsable",
                table: "scholarship_program_tracing_student_support",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComoLoHacenProcedimiento",
                table: "scholarship_program_tracing_student_support");

            migrationBuilder.DropColumn(
                name: "CuandoSeHacePeriodicidad",
                table: "scholarship_program_tracing_student_support");

            migrationBuilder.DropColumn(
                name: "Cuálesutilizan",
                table: "scholarship_program_tracing_student_support");

            migrationBuilder.DropColumn(
                name: "QuienEsElResponsable",
                table: "scholarship_program_tracing_student_support");

            migrationBuilder.AddColumn<string>(
                name: "answer",
                table: "scholarship_program_tracing_student_support",
                type: "varchar(1024)",
                unicode: false,
                maxLength: 1024,
                nullable: true);
        }
    }
}
