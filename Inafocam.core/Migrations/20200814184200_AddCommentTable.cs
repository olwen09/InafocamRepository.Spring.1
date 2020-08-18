using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class AddCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 60, nullable: true),
                    CommentScreen = table.Column<string>(maxLength: 60, nullable: true),
                    CreatorUserId = table.Column<string>(maxLength: 50, nullable: true),
                    ScholarshipProgramTracingId = table.Column<long>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpgradeDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Usuarios_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_scholarship_program_tracing_ScholarshipProgramTracin~",
                        column: x => x.ScholarshipProgramTracingId,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CreatorId",
                table: "Comment",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ScholarshipProgramTracingId",
                table: "Comment",
                column: "ScholarshipProgramTracingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");
        }
    }
}
