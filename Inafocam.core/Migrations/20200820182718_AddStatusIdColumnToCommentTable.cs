using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddStatusIdColumnToCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "Comment",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_StatusId",
                table: "Comment",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_status_StatusId",
                table: "Comment",
                column: "StatusId",
                principalTable: "status",
                principalColumn: "status_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_status_StatusId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_StatusId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Comment");
        }
    }
}
