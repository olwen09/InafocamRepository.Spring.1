using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class AddActionTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "action",
                table: "scholarship_program_tracing_practice_planning",
                unicode: false,
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldUnicode: false,
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ActionType",
                columns: table => new
                {
                    ActionTypeId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ActionTypeName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionType", x => x.ActionTypeId);
                    table.ForeignKey(
                        name: "FK_ActionType_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scholarship_program_tracing_practice_planning_action",
                table: "scholarship_program_tracing_practice_planning",
                column: "action");

            migrationBuilder.CreateIndex(
                name: "IX_ActionType_StatusId",
                table: "ActionType",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_tracing_practice_planning_ActionType_act~",
                table: "scholarship_program_tracing_practice_planning",
                column: "action",
                principalTable: "ActionType",
                principalColumn: "ActionTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_scholarship_program_tracing_practice_planning_ActionType_act~",
                table: "scholarship_program_tracing_practice_planning");

            migrationBuilder.DropTable(
                name: "ActionType");

            migrationBuilder.DropIndex(
                name: "IX_scholarship_program_tracing_practice_planning_action",
                table: "scholarship_program_tracing_practice_planning");

            migrationBuilder.AlterColumn<string>(
                name: "action",
                table: "scholarship_program_tracing_practice_planning",
                type: "varchar(64)",
                unicode: false,
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(long),
                oldUnicode: false,
                oldMaxLength: 64,
                oldNullable: true);
        }
    }
}
