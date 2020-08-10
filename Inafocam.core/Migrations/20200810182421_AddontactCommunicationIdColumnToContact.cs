using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddontactCommunicationIdColumnToContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<long>(
                name: "ContactCommunicationId",
                table: "contact",
                nullable: true);

       




            migrationBuilder.CreateIndex(
                name: "IX_contact_ContactCommunicationId",
                table: "contact",
                column: "ContactCommunicationId");


            migrationBuilder.AddForeignKey(
                name: "FK_contact_contact_communication_ContactCommunicationId",
                table: "contact",
                column: "ContactCommunicationId",
                principalTable: "contact_communication",
                principalColumn: "contact_communication_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agent_contact_contact_id",
                table: "agent");

            migrationBuilder.DropForeignKey(
                name: "FK_contact_contact_communication_ContactCommunicationId1",
                table: "contact");

            migrationBuilder.DropIndex(
                name: "IX_contact_ContactCommunicationId1",
                table: "contact");

            migrationBuilder.DropColumn(
                name: "ContactCommunicationId",
                table: "contact");

            migrationBuilder.DropColumn(
                name: "ContactCommunicationId1",
                table: "contact");

            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                table: "agent",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "contact_id",
                table: "agent",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "agent_type_id",
                table: "agent",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_agent_contact_contact_id",
                table: "agent",
                column: "contact_id",
                principalTable: "contact",
                principalColumn: "contact_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
