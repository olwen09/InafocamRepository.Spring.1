using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class addAgreementWithInstitutionsRelatedToCurricularActivitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgreementsInstitutionRelatedCoCurricularActivities",
                columns: table => new
                {
                    AgreementsInstitutionRelatedCoCurricularActivitiesId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Institution = table.Column<string>(nullable: true),
                    ActivityDescription = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    NumberOfParticipatingStudents = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    TracingId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    StatusId1 = table.Column<long>(nullable: true),
                    TracingScholarshipProgramTracingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreementsInstitutionRelatedCoCurricularActivities", x => x.AgreementsInstitutionRelatedCoCurricularActivitiesId);
                    table.ForeignKey(
                        name: "FK_AgreementsInstitutionRelatedCoCurricularActivities_status_St~",
                        column: x => x.StatusId1,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgreementsInstitutionRelatedCoCurricularActivities_scholarsh~",
                        column: x => x.TracingScholarshipProgramTracingId,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgreementWithInstitutionsRelatedToCurricularActivities",
                columns: table => new
                {
                    AgreementWithInstitutionsRelatedToCurricularActivitiesId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Institution = table.Column<string>(nullable: true),
                    ActivityDescription = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    NumberOfParticipatingStudents = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    TracingId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    StatusId1 = table.Column<long>(nullable: true),
                    TracingScholarshipProgramTracingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreementWithInstitutionsRelatedToCurricularActivities", x => x.AgreementWithInstitutionsRelatedToCurricularActivitiesId);
                    table.ForeignKey(
                        name: "FK_AgreementWithInstitutionsRelatedToCurricularActivities_statu~",
                        column: x => x.StatusId1,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgreementWithInstitutionsRelatedToCurricularActivities_schol~",
                        column: x => x.TracingScholarshipProgramTracingId,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgreementsInstitutionRelatedCoCurricularActivities_StatusId1",
                table: "AgreementsInstitutionRelatedCoCurricularActivities",
                column: "StatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_AgreementsInstitutionRelatedCoCurricularActivities_TracingSc~",
                table: "AgreementsInstitutionRelatedCoCurricularActivities",
                column: "TracingScholarshipProgramTracingId");

            migrationBuilder.CreateIndex(
                name: "IX_AgreementWithInstitutionsRelatedToCurricularActivities_Statu~",
                table: "AgreementWithInstitutionsRelatedToCurricularActivities",
                column: "StatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_AgreementWithInstitutionsRelatedToCurricularActivities_Traci~",
                table: "AgreementWithInstitutionsRelatedToCurricularActivities",
                column: "TracingScholarshipProgramTracingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgreementsInstitutionRelatedCoCurricularActivities");

            migrationBuilder.DropTable(
                name: "AgreementWithInstitutionsRelatedToCurricularActivities");
        }
    }
}
