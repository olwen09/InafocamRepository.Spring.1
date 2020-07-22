using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class AddStudentPracticeTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "practice_type",
                table: "scholarship_program_tracing_student_practice",
                unicode: false,
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldUnicode: false,
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StudentPracticeType",
                columns: table => new
                {
                    StudentPracticeTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentPracticeTypeTypeName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPracticeType", x => x.StudentPracticeTypeId);
                    table.ForeignKey(
                        name: "FK_StudentPracticeType_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scholarship_program_tracing_student_practice_practice_type",
                table: "scholarship_program_tracing_student_practice",
                column: "practice_type");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPracticeType_StatusId",
                table: "StudentPracticeType",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_tracing_student_practice_StudentPractice~",
                table: "scholarship_program_tracing_student_practice",
                column: "practice_type",
                principalTable: "StudentPracticeType",
                principalColumn: "StudentPracticeTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scholarship_program_tracing_student_practice_StudentPractice~",
                table: "scholarship_program_tracing_student_practice");

            migrationBuilder.DropTable(
                name: "StudentPracticeType");

            migrationBuilder.DropIndex(
                name: "IX_scholarship_program_tracing_student_practice_practice_type",
                table: "scholarship_program_tracing_student_practice");

            migrationBuilder.AlterColumn<string>(
                name: "practice_type",
                table: "scholarship_program_tracing_student_practice",
                type: "varchar(64)",
                unicode: false,
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(int),
                oldUnicode: false,
                oldMaxLength: 64,
                oldNullable: true);
        }
    }
}
