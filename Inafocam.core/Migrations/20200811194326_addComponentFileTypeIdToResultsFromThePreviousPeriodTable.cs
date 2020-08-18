using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class addComponentFileTypeIdToResultsFromThePreviousPeriodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultsFromThePreviousPeriod_ComponentFileTypes_ComponentFil~",
                table: "ResultsFromThePreviousPeriod");

            migrationBuilder.DropIndex(
                name: "IX_ResultsFromThePreviousPeriod_ComponentFileTypeId1",
                table: "ResultsFromThePreviousPeriod");

            migrationBuilder.DropColumn(
                name: "ComponentFileTypeId1",
                table: "ResultsFromThePreviousPeriod");

            migrationBuilder.AlterColumn<int>(
                name: "ComponentFileTypeId",
                table: "ResultsFromThePreviousPeriod",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResultsFromThePreviousPeriod_ComponentFileTypeId",
                table: "ResultsFromThePreviousPeriod",
                column: "ComponentFileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_address_country_id",
                table: "address",
                column: "country_id");

            migrationBuilder.AddForeignKey(
                name: "FK_address_country_country_id",
                table: "address",
                column: "country_id",
                principalTable: "country",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsFromThePreviousPeriod_ComponentFileTypes_ComponentFil~",
                table: "ResultsFromThePreviousPeriod",
                column: "ComponentFileTypeId",
                principalTable: "ComponentFileTypes",
                principalColumn: "ComponentFileTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_country_country_id",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultsFromThePreviousPeriod_ComponentFileTypes_ComponentFil~",
                table: "ResultsFromThePreviousPeriod");

            migrationBuilder.DropIndex(
                name: "IX_ResultsFromThePreviousPeriod_ComponentFileTypeId",
                table: "ResultsFromThePreviousPeriod");

            migrationBuilder.DropIndex(
                name: "IX_address_country_id",
                table: "address");

            migrationBuilder.AlterColumn<long>(
                name: "ComponentFileTypeId",
                table: "ResultsFromThePreviousPeriod",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentFileTypeId1",
                table: "ResultsFromThePreviousPeriod",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResultsFromThePreviousPeriod_ComponentFileTypeId1",
                table: "ResultsFromThePreviousPeriod",
                column: "ComponentFileTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultsFromThePreviousPeriod_ComponentFileTypes_ComponentFil~",
                table: "ResultsFromThePreviousPeriod",
                column: "ComponentFileTypeId1",
                principalTable: "ComponentFileTypes",
                principalColumn: "ComponentFileTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
