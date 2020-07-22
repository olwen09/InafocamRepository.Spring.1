using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class addResultsFromThePreviousPeriodTablecorrection2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResultsFromThePreviousPeriod",
                columns: table => new
                {
                    PreviousPeriodId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: true),
                    Observations = table.Column<string>(nullable: true),
                    FileDescription = table.Column<string>(nullable: true),
                    TracingId = table.Column<long>(nullable: true),
                    ComponentFileTypeId = table.Column<long>(nullable: true),
                    StatusId = table.Column<long>(nullable: true),
                    FileId = table.Column<long>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    ComponentFileTypeId1 = table.Column<int>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResultsFromThePreviousPeriod");
        }
    }
}
