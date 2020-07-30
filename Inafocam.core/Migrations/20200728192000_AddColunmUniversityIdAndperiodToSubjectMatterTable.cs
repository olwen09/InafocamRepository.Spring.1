using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddColunmUniversityIdAndperiodToSubjectMatterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UniversityId",
                table: "subject_matter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "period",
                table: "subject_matter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subject_matter_UniversityId",
                table: "subject_matter",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_subject_matter_university_UniversityId",
                table: "subject_matter",
                column: "UniversityId",
                principalTable: "university",
                principalColumn: "university_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subject_matter_university_UniversityId",
                table: "subject_matter");

            migrationBuilder.DropIndex(
                name: "IX_subject_matter_UniversityId",
                table: "subject_matter");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "subject_matter");

            migrationBuilder.DropColumn(
                name: "period",
                table: "subject_matter");
        }
    }
}
