using Microsoft.EntityFrameworkCore.Migrations;

namespace Inafocam.core.Migrations
{
    public partial class AddRelationShip_TracingStudyPlanDevelopmentAndScholarshipProgramUniversityToSubjectMatterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teacher_subject_matter",
                table: "tracing_study_plan_development");

            //migrationBuilder.AddColumn<long>(
            //    name: "Creditos",
            //    table: "subject_matter",
            //    nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ScholarshipProgramUniversityId",
                table: "subject_matter",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TracingStudyPlanDevelopmentId",
                table: "subject_matter",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subject_matter_ScholarshipProgramUniversityId",
                table: "subject_matter",
                column: "ScholarshipProgramUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_subject_matter_TracingStudyPlanDevelopmentId",
                table: "subject_matter",
                column: "TracingStudyPlanDevelopmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_subject_matter_scholarship_program_university_ScholarshipPro~",
                table: "subject_matter",
                column: "ScholarshipProgramUniversityId",
                principalTable: "scholarship_program_university",
                principalColumn: "scholarship_program_university_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subject_matter_tracing_study_plan_development_TracingStudyPl~",
                table: "subject_matter",
                column: "TracingStudyPlanDevelopmentId",
                principalTable: "tracing_study_plan_development",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subject_matter_scholarship_program_university_ScholarshipPro~",
                table: "subject_matter");

            migrationBuilder.DropForeignKey(
                name: "FK_subject_matter_tracing_study_plan_development_TracingStudyPl~",
                table: "subject_matter");

            migrationBuilder.DropIndex(
                name: "IX_subject_matter_ScholarshipProgramUniversityId",
                table: "subject_matter");

            migrationBuilder.DropIndex(
                name: "IX_subject_matter_TracingStudyPlanDevelopmentId",
                table: "subject_matter");

            migrationBuilder.DropColumn(
                name: "Creditos",
                table: "subject_matter");

            migrationBuilder.DropColumn(
                name: "ScholarshipProgramUniversityId",
                table: "subject_matter");

            migrationBuilder.DropColumn(
                name: "TracingStudyPlanDevelopmentId",
                table: "subject_matter");

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_subject_matter",
                table: "tracing_study_plan_development",
                column: "subject_matter_id",
                principalTable: "subject_matter",
                principalColumn: "subject_matter_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
