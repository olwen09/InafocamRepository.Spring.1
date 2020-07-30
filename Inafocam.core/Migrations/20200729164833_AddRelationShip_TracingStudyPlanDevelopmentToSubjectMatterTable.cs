using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddRelationShip_TracingStudyPlanDevelopmentToSubjectMatterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_subject_matter_TracingStudyPlanDevelopmentId",
            //    table: "subject_matter");

            //migrationBuilder.CreateIndex(
            //    name: "IX_subject_matter_TracingStudyPlanDevelopmentId",
            //    table: "subject_matter",
            //    column: "TracingStudyPlanDevelopmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_tracing_study_plan_development_subject_matter_subject_matter~",
                table: "tracing_study_plan_development",
                column: "subject_matter_id",
                principalTable: "subject_matter",
                principalColumn: "subject_matter_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tracing_study_plan_development_subject_matter_subject_matter~",
                table: "tracing_study_plan_development");

            migrationBuilder.DropIndex(
                name: "IX_subject_matter_TracingStudyPlanDevelopmentId",
                table: "subject_matter");

            migrationBuilder.CreateIndex(
                name: "IX_subject_matter_TracingStudyPlanDevelopmentId",
                table: "subject_matter",
                column: "TracingStudyPlanDevelopmentId",
                unique: true);
        }
    }
}
