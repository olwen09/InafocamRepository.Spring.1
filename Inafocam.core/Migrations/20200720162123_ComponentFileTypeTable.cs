using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class ComponentFileTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "ComponentFileTypes",
                columns: table => new
                {
                    ComponentFileTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ComponentFileTypeName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UpgradeDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentFileTypes", x => x.ComponentFileTypeId);
                    table.ForeignKey(
                        name: "FK_ComponentFileTypes_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });


        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_scholarship_program_tracing_quality_system_scholarship_progr~",
            //    table: "scholarship_program_tracing_quality_system");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_scholarship_program_tracing_quality_system_file_type_status_~",
            //    table: "scholarship_program_tracing_quality_system_file_type");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_tracing_study_plan_development_file_subject_matter_score_rep~",
            //    table: "tracing_study_plan_development");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Usuarios_university_UniversityId",
            //    table: "Usuarios");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "ComponentFileTypes");

            //migrationBuilder.DropIndex(
            //    name: "EmailIndex",
            //    table: "Usuarios");

            //migrationBuilder.DropIndex(
            //    name: "UserNameIndex",
            //    table: "Usuarios");

            //migrationBuilder.DropIndex(
            //    name: "IX_Usuarios_UniversityId",
            //    table: "Usuarios");

            //migrationBuilder.DropIndex(
            //    name: "IX_tracing_study_plan_development_subject_matter_score_report_f~",
            //    table: "tracing_study_plan_development");

            //migrationBuilder.DropIndex(
            //    name: "IX_scholarship_program_tracing_quality_system_file_type_status_~",
            //    table: "scholarship_program_tracing_quality_system_file_type");

            //migrationBuilder.DropIndex(
            //    name: "IX_scholarship_program_tracing_quality_system_file_type_id",
            //    table: "scholarship_program_tracing_quality_system");

            //migrationBuilder.DropIndex(
            //    name: "RoleNameIndex",
            //    table: "Roles");

            //migrationBuilder.DropColumn(
            //    name: "UniversityId",
            //    table: "Usuarios");

            //migrationBuilder.DropColumn(
            //    name: "usuario_id",
            //    table: "user_university");

            //migrationBuilder.DropColumn(
            //    name: "Creditos",
            //    table: "tracing_study_plan_development");

            //migrationBuilder.RenameColumn(
            //    name: "creditos",
            //    table: "tracing_study_plan_development",
            //    newName: "creation_user_id");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserName",
            //    table: "Usuarios",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 256,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "NormalizedUserName",
            //    table: "Usuarios",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 256,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "NormalizedEmail",
            //    table: "Usuarios",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 256,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Email",
            //    table: "Usuarios",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 256,
            //    oldNullable: true);

            //migrationBuilder.AddColumn<long>(
            //    name: "user_id",
            //    table: "user_university",
            //    type: "bigint",
            //    nullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "NormalizedName",
            //    table: "Roles",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 256,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "Roles",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 256,
            //    oldNullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "FK__user",
            //    table: "user_university",
            //    column: "user_id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK__user",
            //    table: "user_university",
            //    column: "user_id",
            //    principalTable: "user",
            //    principalColumn: "user_id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
