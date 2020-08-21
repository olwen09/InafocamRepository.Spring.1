using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddScholarshipProgramTracingAgreementDescriptionCorectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScholarshipProgramTracingAgreementDescription",
                columns: table => new
                {
                    ScholarshipProgramTracingAgreementDescriptionId = table.Column<string>(nullable: false),
                    ScholarshipProgramTracingId = table.Column<long>(nullable: true),
                    ScholarshipProgramUniversityAgreementId = table.Column<long>(nullable: true),
                    ScholarshipProgramTracingAgreementDescription2 = table.Column<string>(nullable: true),
                    ScholarshipProgramTracingAgreementDescription3 = table.Column<string>(nullable: true),
                    CommentedUserId = table.Column<string>(maxLength: 60, nullable: true),
                    CreationUserId = table.Column<string>(maxLength: 60, nullable: true),
                    UpgradeUserId = table.Column<string>(maxLength: 60, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipProgramTracingAgreementDescription", x => x.ScholarshipProgramTracingAgreementDescriptionId);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingAgreementDescription_Usuarios_Comme~",
                        column: x => x.CommentedUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingAgreementDescription_Usuarios_Creat~",
                        column: x => x.CreationUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingAgreementDescription_scholarship_pr~",
                        column: x => x.ScholarshipProgramTracingId,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingAgreementDescription_scholarship_p~1",
                        column: x => x.ScholarshipProgramUniversityAgreementId,
                        principalTable: "scholarship_program_university_agreement",
                        principalColumn: "scholarship_program_university_agreement_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingAgreementDescription_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingAgreementDescription_Usuarios_Upgra~",
                        column: x => x.UpgradeUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingAgreementDescription_CommentedUserId",
                table: "ScholarshipProgramTracingAgreementDescription",
                column: "CommentedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingAgreementDescription_CreationUserId",
                table: "ScholarshipProgramTracingAgreementDescription",
                column: "CreationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingAgreementDescription_ScholarshipPro~",
                table: "ScholarshipProgramTracingAgreementDescription",
                column: "ScholarshipProgramTracingId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingAgreementDescription_ScholarshipPr~1",
                table: "ScholarshipProgramTracingAgreementDescription",
                column: "ScholarshipProgramUniversityAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingAgreementDescription_StatusId",
                table: "ScholarshipProgramTracingAgreementDescription",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingAgreementDescription_UpgradeUserId",
                table: "ScholarshipProgramTracingAgreementDescription",
                column: "UpgradeUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScholarshipProgramTracingAgreementDescription");
        }
    }
}
