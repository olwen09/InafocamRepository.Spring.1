using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class AddActivityTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "activity",
                table: "scholarship_program_tracing_practice",
                unicode: false,
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldUnicode: false,
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    ActivityTypeId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ActivityTypeName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.ActivityTypeId);
                    table.ForeignKey(
                        name: "FK_ActivityType_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scholarship_program_tracing_practice_activity",
                table: "scholarship_program_tracing_practice",
                column: "activity");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityType_StatusId",
                table: "ActivityType",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_tracing_practice_ActivityType_activity",
                table: "scholarship_program_tracing_practice",
                column: "activity",
                principalTable: "ActivityType",
                principalColumn: "ActivityTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scholarship_program_tracing_practice_ActivityType_activity",
                table: "scholarship_program_tracing_practice");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropIndex(
                name: "IX_scholarship_program_tracing_practice_activity",
                table: "scholarship_program_tracing_practice");

            migrationBuilder.AlterColumn<string>(
                name: "activity",
                table: "scholarship_program_tracing_practice",
                type: "varchar(128)",
                unicode: false,
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(long),
                oldUnicode: false,
                oldMaxLength: 128,
                oldNullable: true);
        }
    }
}
