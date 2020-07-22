using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class removeResultsFromThePreviousPeriodTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultsFromThePreviousPeriod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultsFromThePreviousPeriod",
                columns: table => new
                {
                    PreviousPeriodId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ComponentFileTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ComponentFileTypeId1 = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FileDescription = table.Column<string>(type: "text", nullable: true),
                    FileId = table.Column<long>(type: "bigint", nullable: true),
                    Observations = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<long>(type: "bigint", nullable: true),
                    TracingId = table.Column<long>(type: "bigint", nullable: true),
                    UpgradeDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultsFromThePreviousPeriod", x => x.PreviousPeriodId);
                    table.ForeignKey(
                        name: "FK_ResultsFromThePreviousPeriod_ComponentFileTypes_ComponentFil~",
                        column: x => x.ComponentFileTypeId1,
                        principalTable: "ComponentFileTypes",
                        principalColumn: "ComponentFileTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultsFromThePreviousPeriod_file_FileId",
                        column: x => x.FileId,
                        principalTable: "file",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultsFromThePreviousPeriod_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResultsFromThePreviousPeriod_scholarship_program_tracing_Tra~",
                        column: x => x.TracingId,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultsFromThePreviousPeriod_ComponentFileTypeId1",
                table: "ResultsFromThePreviousPeriod",
                column: "ComponentFileTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsFromThePreviousPeriod_FileId",
                table: "ResultsFromThePreviousPeriod",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsFromThePreviousPeriod_StatusId",
                table: "ResultsFromThePreviousPeriod",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultsFromThePreviousPeriod_TracingId",
                table: "ResultsFromThePreviousPeriod",
                column: "TracingId");
        }
    }
}
