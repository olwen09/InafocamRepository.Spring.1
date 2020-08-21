using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddNormalizedDescriptionColumnToComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "NormalizedDescription",
                table: "Comment",
                maxLength: 100,
                nullable: true);




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "NormalizedDescription",
                table: "Comment");
        }
    }
}
