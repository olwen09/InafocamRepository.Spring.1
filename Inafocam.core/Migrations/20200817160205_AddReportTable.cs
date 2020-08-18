using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class AddReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comment",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentScreen",
                table: "Comment",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpgradeDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<string>(nullable: true),
                    TracingId = table.Column<long>(nullable: false),
                    FileId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Report_Usuarios_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_file_FileId",
                        column: x => x.FileId,
                        principalTable: "file",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_scholarship_program_tracing_TracingId",
                        column: x => x.TracingId,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Report_CreatorUserId",
                table: "Report",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_FileId",
                table: "Report",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_TracingId",
                table: "Report",
                column: "TracingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Comment",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommentScreen",
                table: "Comment",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
