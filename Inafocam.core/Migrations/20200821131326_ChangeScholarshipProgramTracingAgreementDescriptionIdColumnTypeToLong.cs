using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class ChangeScholarshipProgramTracingAgreementDescriptionIdColumnTypeToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ScholarshipProgramTracingAgreementDescriptionId",
                table: "ScholarshipProgramTracingAgreementDescription",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(767)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ScholarshipProgramTracingAgreementDescriptionId",
                table: "ScholarshipProgramTracingAgreementDescription",
                type: "varchar(767)",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }
    }
}
