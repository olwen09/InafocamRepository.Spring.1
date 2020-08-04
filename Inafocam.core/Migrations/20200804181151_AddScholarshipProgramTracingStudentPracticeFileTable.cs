using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class AddScholarshipProgramTracingStudentPracticeFileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScholarshipProgramTracingStudentPracticeFile",
                columns: table => new
                {
                    ScholarshipProgramTracingStudentPracticeFileId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScholarshipProgramTracingStudentPracticeId = table.Column<long>(nullable: true),
                    FileDescription = table.Column<string>(nullable: true),
                    FileId = table.Column<long>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholarshipProgramTracingStudentPracticeFile", x => x.ScholarshipProgramTracingStudentPracticeFileId);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingStudentPracticeFile_file_FileId",
                        column: x => x.FileId,
                        principalTable: "file",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingStudentPracticeFile_scholarship_pro~",
                        column: x => x.ScholarshipProgramTracingStudentPracticeId,
                        principalTable: "scholarship_program_tracing_student_practice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScholarshipProgramTracingStudentPracticeFile_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingStudentPracticeFile_FileId",
                table: "ScholarshipProgramTracingStudentPracticeFile",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingStudentPracticeFile_ScholarshipProg~",
                table: "ScholarshipProgramTracingStudentPracticeFile",
                column: "ScholarshipProgramTracingStudentPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScholarshipProgramTracingStudentPracticeFile_StatusId",
                table: "ScholarshipProgramTracingStudentPracticeFile",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScholarshipProgramTracingStudentPracticeFile");
        }
    }
}
