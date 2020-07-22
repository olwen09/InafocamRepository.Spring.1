using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class AddScholarshipProgramTracingAgreementsWithPracticeCenterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScholarshipProgramTracingAgreementsWithPracticeCenter",
                columns: table => new
                {
                    AgreementsWithPracticeCenterId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ActivityDescription = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    NumberOfParticipatingStudents = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    TracingId = table.Column<int>(nullable: false),
                    TracingScholarshipProgramTracingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipProgramTracingAgreementsWithPracticeCenter", x => x.AgreementsWithPracticeCenterId);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingAgreementsWithPracticeCenter_schola~",
                        column: x => x.TracingScholarshipProgramTracingId,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingAgreementsWithPracticeCenter_Tracin~",
                table: "ScholarshipProgramTracingAgreementsWithPracticeCenter",
                column: "TracingScholarshipProgramTracingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScholarshipProgramTracingAgreementsWithPracticeCenter");
        }
    }
}
