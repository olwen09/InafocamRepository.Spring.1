using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class relationshipcorrection_CommentAndUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Usuarios_CreatorId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CreatorId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Comment");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreatorUserId",
                table: "Comment",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Usuarios_CreatorUserId",
                table: "Comment",
                column: "CreatorUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Usuarios_CreatorUserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CreatorUserId",
                table: "Comment");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Comment",
                type: "varchar(767)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreatorId",
                table: "Comment",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Usuarios_CreatorId",
                table: "Comment",
                column: "CreatorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
