using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddScholarshipProgramTracingAgreementDescription1Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScholarshipProgramTracingAgreementDescription1",
                table: "ScholarshipProgramTracingAgreementDescription",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScholarshipProgramTracingAgreementDescription1",
                table: "ScholarshipProgramTracingAgreementDescription");
        }
    }
}
