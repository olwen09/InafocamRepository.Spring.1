using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddScholarshipProgramUniversityAgreementColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescripcionDelAvance",
                table: "scholarship_program_university_agreement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescripcionQueEvidencieElCumplimiento",
                table: "scholarship_program_university_agreement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "scholarship_program_university_agreement",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionDelAvance",
                table: "scholarship_program_university_agreement");

            migrationBuilder.DropColumn(
                name: "DescripcionQueEvidencieElCumplimiento",
                table: "scholarship_program_university_agreement");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "scholarship_program_university_agreement");
        }
    }
}
