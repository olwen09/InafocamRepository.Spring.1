using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class ScholarshipProgramTracingAgreementsWithPracticeCenterTableCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TracingId",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Institution",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StatusId1",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingAgreementsWithPracticeCenter_Status~",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter",
                column: "StatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ScholarshipProgramTracingAgreementsWithPracticeCenter_status~",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter",
                column: "StatusId1",
                principalTable: "status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScholarshipProgramTracingAgreementsWithPracticeCenter_status~",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter");

            migrationBuilder.DropIndex(
                name: "IX_ScholarshipProgramTracingAgreementsWithPracticeCenter_Status~",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter");

            migrationBuilder.DropColumn(
                name: "Institution",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter");

            migrationBuilder.DropColumn(
                name: "StatusId1",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter");

            migrationBuilder.AlterColumn<int>(
                name: "TracingId",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
