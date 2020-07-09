using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Inafocam.core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agreement_type",
                columns: table => new
                {
                    agreement_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    agreement_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    agreement_panel_class = table.Column<string>(unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agreement_type", x => x.agreement_type_id);
                });

            migrationBuilder.CreateTable(
                name: "marital_status",
                columns: table => new
                {
                    marital_status_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    marital_status_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marital_status", x => x.marital_status_id);
                });

            migrationBuilder.CreateTable(
                name: "migrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    migration = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    batch = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_migrations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_course_file_type",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    file_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing_course_file_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_quality_system_file_type",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    file_type_name = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing_quality_system_file_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_university_teacher_hiring",
                columns: table => new
                {
                    scholarship_program_university_teacher_hiring_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    teacher_hiring_type_id = table.Column<long>(nullable: true),
                    teacher_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_university_teacher_hiring", x => x.scholarship_program_university_teacher_hiring_id);
                });

            migrationBuilder.CreateTable(
                name: "spu_taught_subject",
                columns: table => new
                {
                    spu_taught_subject_id = table.Column<long>(nullable: true),
                    subject_matter_id = table.Column<long>(nullable: true),
                    Columna3 = table.Column<long>(name: "Columna 3", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    status_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    status_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    table_id = table.Column<long>(nullable: true),
                    table_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "study_plan_management",
                columns: table => new
                {
                    study_plan_management_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_program_university_id = table.Column<long>(nullable: true),
                    study_plan_management_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_plan_management", x => x.study_plan_management_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    email_verified_at = table.Column<DateTimeOffset>(nullable: true),
                    password = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    remember_token = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    created_at = table.Column<DateTimeOffset>(nullable: true),
                    updated_at = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "address_type",
                columns: table => new
                {
                    address_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    address_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_type", x => x.address_type_id);
                    table.ForeignKey(
                        name: "FK_address_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "agent_type",
                columns: table => new
                {
                    agent_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    agent_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agent_type", x => x.agent_type_id);
                    table.ForeignKey(
                        name: "FK_agent_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "company_type",
                columns: table => new
                {
                    company_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    company_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company_type", x => x.company_type_id);
                    table.ForeignKey(
                        name: "FK_company_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    country_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    country_name = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    country_short_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.country_id);
                    table.ForeignKey(
                        name: "FK_country_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "document_type",
                columns: table => new
                {
                    document_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    document_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    document_type_pattern = table.Column<string>(unicode: false, maxLength: 32, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_document_type", x => x.document_type_id);
                    table.ForeignKey(
                        name: "FK_document_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "education_type",
                columns: table => new
                {
                    education_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    education_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_education_type", x => x.education_type_id);
                    table.ForeignKey(
                        name: "FK_education_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "file_type",
                columns: table => new
                {
                    file_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    file_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file_type", x => x.file_type_id);
                    table.ForeignKey(
                        name: "FK_file_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menu_type",
                columns: table => new
                {
                    menu_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    menu_type_name = table.Column<string>(unicode: false, maxLength: 32, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu_type", x => x.menu_type_id);
                    table.ForeignKey(
                        name: "FK_menu_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nationality",
                columns: table => new
                {
                    nationality_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nationality_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationality", x => x.nationality_id);
                    table.ForeignKey(
                        name: "FK_nationality_status_status_id",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "object",
                columns: table => new
                {
                    object_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    object_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_object", x => x.object_id);
                    table.ForeignKey(
                        name: "FK_object_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_level",
                columns: table => new
                {
                    scholarship_level_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_level_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_level", x => x.scholarship_level_id);
                    table.ForeignKey(
                        name: "FK_scholarship_level_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teacher_file_type",
                columns: table => new
                {
                    teacher_file_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    teacher_file_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_file_type", x => x.teacher_file_type_id);
                    table.ForeignKey(
                        name: "FK_teacher_file_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teacher_hiring_type",
                columns: table => new
                {
                    teacher_hiring_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    teacher_hiring_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_hiring_type", x => x.teacher_hiring_type_id);
                    table.ForeignKey(
                        name: "FK_teacher_hiring_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    province_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    country_id = table.Column<long>(nullable: true),
                    province_name = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.province_id);
                    table.ForeignKey(
                        name: "FK_province_country",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_province_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contact_type",
                columns: table => new
                {
                    contact_type_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    contact_type_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    document_type_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_type", x => x.contact_type_id);
                    table.ForeignKey(
                        name: "FK_contact_type_document_type",
                        column: x => x.document_type_id,
                        principalTable: "document_type",
                        principalColumn: "document_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contact_type_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    menu_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    menu_parent_id = table.Column<long>(nullable: true),
                    menu_type_id = table.Column<long>(nullable: true),
                    menu_caption = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    menu_link = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    menu_icon = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    menu_position = table.Column<int>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.menu_id);
                    table.ForeignKey(
                        name: "FK_menu_menu",
                        column: x => x.menu_parent_id,
                        principalTable: "menu",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_menu_menu_type",
                        column: x => x.menu_type_id,
                        principalTable: "menu_type",
                        principalColumn: "menu_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_menu_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "object_mapping",
                columns: table => new
                {
                    object_mapping_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    object_id = table.Column<long>(nullable: true),
                    object_mapping_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<long>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_object_mapping", x => x.object_mapping_id);
                    table.ForeignKey(
                        name: "FK_object_mapping_object",
                        column: x => x.object_id,
                        principalTable: "object",
                        principalColumn: "object_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_object_mapping_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program",
                columns: table => new
                {
                    scholarship_program_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_program_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    scholarship_level_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(name: " creation_date", nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program", x => x.scholarship_program_id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_scholarship_level",
                        column: x => x.scholarship_level_id,
                        principalTable: "scholarship_level",
                        principalColumn: "scholarship_level_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    city_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    country_id = table.Column<long>(nullable: true),
                    province_id = table.Column<long>(nullable: true),
                    city_name = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    city_short_name = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.city_id);
                    table.ForeignKey(
                        name: "FK_city_country",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_city_province",
                        column: x => x.province_id,
                        principalTable: "province",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_city_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    company_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    contact_id = table.Column<long>(nullable: true),
                    address_id = table.Column<long>(nullable: true),
                    communication_id = table.Column<long>(nullable: true),
                    company_type_id = table.Column<long>(nullable: true),
                    manager_id = table.Column<long>(nullable: true),
                    owner_id = table.Column<long>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.company_id);
                    table.ForeignKey(
                        name: "FK_company_company_type",
                        column: x => x.company_type_id,
                        principalTable: "company_type",
                        principalColumn: "company_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_company_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contact_address",
                columns: table => new
                {
                    contact_address_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    contact_id = table.Column<long>(nullable: true),
                    address_id = table.Column<long>(nullable: true),
                    contact_address_comment = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_address", x => x.contact_address_id);
                    table.ForeignKey(
                        name: "FK_contact_address_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "office",
                columns: table => new
                {
                    office_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<long>(nullable: true),
                    office_name = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    address_id = table.Column<long>(nullable: true),
                    communication_id = table.Column<long>(nullable: true),
                    manager_id = table.Column<long>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office", x => x.office_id);
                    table.ForeignKey(
                        name: "FK_office_company",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_office_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "university",
                columns: table => new
                {
                    university_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    university_name = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    university_acronym = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    university_campus = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    address_id = table.Column<long>(nullable: true),
                    communication_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_university", x => x.university_id);
                    table.ForeignKey(
                        name: "FK_university_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    address_type_id = table.Column<long>(nullable: true),
                    country_id = table.Column<long>(nullable: true),
                    province_id = table.Column<long>(nullable: true),
                    city_id = table.Column<long>(nullable: true),
                    address1 = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    address2 = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    home_number = table.Column<string>(unicode: false, maxLength: 8, nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_address_address_type",
                        column: x => x.address_type_id,
                        principalTable: "address_type",
                        principalColumn: "address_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_address_city",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_address_province",
                        column: x => x.province_id,
                        principalTable: "province",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_address_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing",
                columns: table => new
                {
                    scholarship_program_tracing_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    university_id = table.Column<long>(nullable: true),
                    scholarship_program_university_id = table.Column<long>(nullable: true),
                    coordinator_id = table.Column<long>(nullable: true),
                    technical_id = table.Column<long>(nullable: true),
                    start_date = table.Column<DateTime>(nullable: true),
                    end_date = table.Column<DateTime>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing", x => x.scholarship_program_tracing_id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracking_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracing_university",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "university_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_course",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tracing_id = table.Column<long>(nullable: true),
                    course_name = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    hours_taken = table.Column<int>(nullable: true),
                    course_start_date = table.Column<DateTime>(type: "date", nullable: true),
                    course_end_date = table.Column<DateTime>(type: "date", nullable: true),
                    students_quantity = table.Column<int>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing_course", x => x.id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracing_plan_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracing_plan_scholarship_program_tracing",
                        column: x => x.tracing_id,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_practice",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tracing_id = table.Column<long>(nullable: true),
                    activity = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    coordinator = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    superviser = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    teacher = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    periodicity = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    creation_date = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    upgrade_date = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing_practice", x => x.id);
                    table.ForeignKey(
                        name: "FK_practice_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_practice_tracing",
                        column: x => x.tracing_id,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_practice_planning",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tracing_id = table.Column<long>(nullable: true),
                    action = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    started = table.Column<short>(type: "bit(1)", nullable: true),
                    finished = table.Column<short>(type: "bit(1)", nullable: true),
                    comment = table.Column<string>(unicode: false, maxLength: 512, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing_practice_planning", x => x.id);
                    table.ForeignKey(
                        name: "FK_planning_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_planning_tracing",
                        column: x => x.tracing_id,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_student_practice",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tracing_id = table.Column<long>(nullable: true),
                    practice_type = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    students_quantity = table.Column<int>(nullable: true),
                    practice_center_quantity = table.Column<int>(nullable: true),
                    supervisor_quantity = table.Column<int>(nullable: true),
                    teacher_quantity = table.Column<int>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing_student_practice", x => x.id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracing_student_practice_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_student_practice_tracing",
                        column: x => x.tracing_id,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_student_support",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tracing_id = table.Column<long>(nullable: false),
                    indicator_id = table.Column<long>(nullable: true),
                    question_id = table.Column<long>(nullable: true),
                    answer = table.Column<string>(unicode: false, maxLength: 1024, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing_student_support", x => x.id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracing_student_support_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_student_support_tracing",
                        column: x => x.tracing_id,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_university",
                columns: table => new
                {
                    scholarship_program_university_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_level_id = table.Column<long>(nullable: true),
                    scholarship_program_id = table.Column<long>(nullable: true),
                    university_id = table.Column<long>(nullable: true),
                    scat_program_id = table.Column<long>(nullable: true),
                    scat_program_code = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    active_students = table.Column<int>(nullable: true),
                    contract_number = table.Column<string>(unicode: false, maxLength: 16, nullable: true),
                    coordinator_id = table.Column<long>(nullable: true),
                    technical_id = table.Column<long>(nullable: true),
                    announcement_start_date = table.Column<DateTime>(type: "date", nullable: true),
                    announcement_end_date = table.Column<DateTime>(type: "date", nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_university", x => x.scholarship_program_university_id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_scholarship_level",
                        column: x => x.scholarship_level_id,
                        principalTable: "scholarship_level",
                        principalColumn: "scholarship_level_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_scholarship_program",
                        column: x => x.scholarship_program_id,
                        principalTable: "scholarship_program",
                        principalColumn: "scholarship_program_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_university",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "university_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_university_agent",
                columns: table => new
                {
                    scholarship_program_university_cordinator_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_program_university_id = table.Column<long>(nullable: true),
                    agent_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.scholarship_program_university_cordinator_id);
                    table.ForeignKey(
                        name: "FK_program_university",
                        column: x => x.scholarship_program_university_id,
                        principalTable: "scholarship_program_university",
                        principalColumn: "scholarship_program_university_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "agent",
                columns: table => new
                {
                    agent_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    agent_type_id = table.Column<long>(nullable: false),
                    user_id = table.Column<long>(nullable: false),
                    contact_id = table.Column<long>(nullable: false),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agent", x => x.agent_id);
                    table.ForeignKey(
                        name: "FK_agent_agent_type",
                        column: x => x.agent_type_id,
                        principalTable: "agent_type",
                        principalColumn: "agent_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cordinator_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_university_agreement",
                columns: table => new
                {
                    scholarship_program_university_agreement_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_program_university_id = table.Column<long>(nullable: true),
                    scholarship_program_university_agreement = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    agreement_type_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_university_agreement", x => x.scholarship_program_university_agreement_id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_agreement_agreement_type",
                        column: x => x.agreement_type_id,
                        principalTable: "agreement_type",
                        principalColumn: "agreement_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university",
                        column: x => x.scholarship_program_university_id,
                        principalTable: "scholarship_program_university",
                        principalColumn: "scholarship_program_university_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_agreement_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contact_communication",
                columns: table => new
                {
                    contact_communication_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    contact_id = table.Column<long>(nullable: true),
                    communication_id = table.Column<long>(nullable: true),
                    contact_communication_comment = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_communication", x => x.contact_communication_id);
                    table.ForeignKey(
                        name: "FK_contact_communication_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    company_id = table.Column<long>(nullable: true),
                    office_id = table.Column<long>(nullable: true),
                    contact_id = table.Column<long>(nullable: true),
                    user_login = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    user_password = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    user_role_id = table.Column<long>(nullable: true),
                    user_expire_password = table.Column<short>(type: "bit(1)", nullable: true),
                    user_date_expire_password = table.Column<DateTime>(nullable: true),
                    user_schedule_id = table.Column<long>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_company",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_user",
                        column: x => x.creation_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_office",
                        column: x => x.office_id,
                        principalTable: "office",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_user_2",
                        column: x => x.upgrade_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "communication",
                columns: table => new
                {
                    communication_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    communication_phone_number1 = table.Column<string>(unicode: false, maxLength: 16, nullable: true),
                    communication_phone_number2 = table.Column<string>(unicode: false, maxLength: 16, nullable: true),
                    communication_email = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    communication_website = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_communication", x => x.communication_id);
                    table.ForeignKey(
                        name: "FK_communication_user",
                        column: x => x.creation_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_communication_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_communication_user_2",
                        column: x => x.upgrade_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    contact_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    document_type_id = table.Column<long>(nullable: true),
                    contact_document_number = table.Column<string>(unicode: false, maxLength: 16, nullable: true),
                    contact_name = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    contact_lastname = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    contact_gender = table.Column<string>(type: "enum('female','male','none')", nullable: true),
                    contact_type_id = table.Column<long>(nullable: true),
                    contact_comment = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    contact_born_date = table.Column<DateTime>(type: "date", nullable: true),
                    contact_born_place = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    contact_nationality_id = table.Column<long>(nullable: true),
                    contact_marital_status_id = table.Column<long>(nullable: true),
                    contact_job_information_id = table.Column<long>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.contact_id);
                    table.ForeignKey(
                        name: "FK_contact_contact_type",
                        column: x => x.contact_type_id,
                        principalTable: "contact_type",
                        principalColumn: "contact_type_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_contact_user",
                        column: x => x.creation_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contact_document_type",
                        column: x => x.document_type_id,
                        principalTable: "document_type",
                        principalColumn: "document_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contact_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contact_user_2",
                        column: x => x.upgrade_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "file",
                columns: table => new
                {
                    file_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    file_type_id = table.Column<long>(nullable: true),
                    file_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    file_full_path = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    file_path = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    file_application_type = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file", x => x.file_id);
                    table.ForeignKey(
                        name: "FK_file_user",
                        column: x => x.creation_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_file_file_type",
                        column: x => x.file_type_id,
                        principalTable: "file_type",
                        principalColumn: "file_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_file_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_file_user_2",
                        column: x => x.upgrade_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    schedule_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    schedule_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    updating_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    updating_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.schedule_id);
                    table.ForeignKey(
                        name: "FK_schedule_user",
                        column: x => x.creation_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_schedule_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_schedule_user_2",
                        column: x => x.updating_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_agreement",
                columns: table => new
                {
                    scholarship_program_tracing_agreement_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_program_tracing_id = table.Column<long>(nullable: true),
                    scholarship_program_university_agreement_id = table.Column<long>(nullable: true),
                    scholarship_program_tracing_agreement_description = table.Column<string>(unicode: false, maxLength: 512, nullable: true),
                    scholarship_program_tracing_agreement_description2 = table.Column<string>(unicode: false, maxLength: 512, nullable: true),
                    scholarship_program_tracing_agreement_description3 = table.Column<string>(unicode: false, maxLength: 512, nullable: true),
                    commented_user_id = table.Column<long>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing_agreement", x => x.scholarship_program_tracing_agreement_id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracking_agreement_user_3",
                        column: x => x.commented_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracking_agreement_user",
                        column: x => x.creation_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tracking",
                        column: x => x.scholarship_program_tracing_id,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracing_agreement",
                        column: x => x.scholarship_program_university_agreement_id,
                        principalTable: "scholarship_program_university_agreement",
                        principalColumn: "scholarship_program_university_agreement_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracking_agreement_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracking_agreement_user_2",
                        column: x => x.upgrade_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subject_matter",
                columns: table => new
                {
                    subject_matter_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    subject_matter_code = table.Column<string>(unicode: false, maxLength: 32, nullable: false, defaultValueSql: "'0'"),
                    subject_matter_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject_matter", x => x.subject_matter_id);
                    table.ForeignKey(
                        name: "FK_subject_matter_user",
                        column: x => x.creation_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subject_matter_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subject_matter_user_2",
                        column: x => x.upgrade_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    user_role_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    office_id = table.Column<long>(nullable: false),
                    user_role_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    user_role_description = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => x.user_role_id);
                    table.ForeignKey(
                        name: "FK_user_role_user",
                        column: x => x.creation_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_office",
                        column: x => x.office_id,
                        principalTable: "office",
                        principalColumn: "office_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_user_2",
                        column: x => x.upgrade_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_university",
                columns: table => new
                {
                    user_university_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(nullable: true),
                    university_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    user_creation_id = table.Column<long>(nullable: true),
                    user_upgrade_id = table.Column<long>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_university", x => x.user_university_id);
                    table.ForeignKey(
                        name: "FK__status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__university",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "university_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_agreement_file",
                columns: table => new
                {
                    scholarship_program_tracing_agreement_file_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_program_tracing_agreement_id = table.Column<long>(nullable: false),
                    agreement_file_description = table.Column<string>(unicode: false, maxLength: 64, nullable: false, defaultValueSql: "'0'"),
                    file_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_tracing_agreement_file", x => x.scholarship_program_tracing_agreement_file_id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracking_agreement_file_file",
                        column: x => x.file_id,
                        principalTable: "file",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_tracking_agreement_file_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_course_file",
                columns: table => new
                {
                    course_file_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tracing_id = table.Column<long>(nullable: true),
                    file_type_id = table.Column<long>(nullable: true),
                    file_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.course_file_id);
                    table.ForeignKey(
                        name: "FK__tracing_plan_file",
                        column: x => x.file_id,
                        principalTable: "file",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_file_type",
                        column: x => x.file_type_id,
                        principalTable: "scholarship_program_tracing_course_file_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tracing_plan_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tracing_plan",
                        column: x => x.tracing_id,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_tracing_quality_system",
                columns: table => new
                {
                    quality_file_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tracing_id = table.Column<long>(nullable: true),
                    file_type_id = table.Column<long>(nullable: true),
                    file_id = table.Column<long>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.quality_file_id);
                    table.ForeignKey(
                        name: "FK_file_quality",
                        column: x => x.file_id,
                        principalTable: "file",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_status_quality",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_program_tracing",
                        column: x => x.tracing_id,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schedule_day",
                columns: table => new
                {
                    schedule_day_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    schedule_id = table.Column<long>(nullable: true),
                    schedule_day = table.Column<string>(type: "enum('SUNDAY','MONDAY')", nullable: true),
                    schedule_start_time = table.Column<TimeSpan>(nullable: true),
                    schedule_end_time = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule_day", x => x.schedule_day_id);
                    table.ForeignKey(
                        name: "FK_schedule_days_schedule",
                        column: x => x.schedule_id,
                        principalTable: "schedule",
                        principalColumn: "schedule_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_map_role",
                columns: table => new
                {
                    user_map_role_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(nullable: true),
                    user_role_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_map_role", x => x.user_map_role_id);
                    table.ForeignKey(
                        name: "FK_user_roles_user",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_roles_user_role",
                        column: x => x.user_role_id,
                        principalTable: "user_role",
                        principalColumn: "user_role_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_role_permission",
                columns: table => new
                {
                    user_role_permission_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_role_id = table.Column<long>(nullable: true),
                    object_id = table.Column<long>(nullable: true),
                    user_role_permission_name = table.Column<string>(type: "enum('INSERT','UPDATE','DELETE','QUERY','ALL')", nullable: true),
                    user_role_permission_value = table.Column<string>(type: "enum('GRANTED','DENIED','GRANTED INDIRECTLY')", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role_permission", x => x.user_role_permission_id);
                    table.ForeignKey(
                        name: "FK_user_role_permission_table",
                        column: x => x.object_id,
                        principalTable: "object",
                        principalColumn: "object_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_permission_user_role",
                        column: x => x.user_role_id,
                        principalTable: "user_role",
                        principalColumn: "user_role_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    teacher_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    contact_id = table.Column<long>(nullable: true),
                    higher_teacher_education_id = table.Column<long>(nullable: true),
                    teacher_hiring_type_id = table.Column<long>(nullable: true),
                    teacher_category = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    teacher_job_start_date = table.Column<DateTime>(type: "date", nullable: true),
                    teacher_is_pac = table.Column<short>(type: "bit(1)", nullable: true),
                    teacher_has_admin_functions = table.Column<short>(type: "bit(1)", nullable: true),
                    teacher_work_for_other_institutions = table.Column<short>(type: "bit(1)", nullable: true),
                    teacher_match_higher_title = table.Column<short>(type: "bit(1)", nullable: true),
                    teacher_research_process = table.Column<int>(nullable: true),
                    teacher_research_published = table.Column<int>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.teacher_id);
                    table.ForeignKey(
                        name: "FK_teacher_contact",
                        column: x => x.contact_id,
                        principalTable: "contact",
                        principalColumn: "contact_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_teacher_hiring_type_teacher_hiring_type_id",
                        column: x => x.teacher_hiring_type_id,
                        principalTable: "teacher_hiring_type",
                        principalColumn: "teacher_hiring_type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scholarship_program_university_subject_matter",
                columns: table => new
                {
                    scholarship_program_university_subject_matter_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_program_university_id = table.Column<long>(nullable: false),
                    subject_matter_id = table.Column<long>(nullable: true),
                    teacher_id = table.Column<long>(nullable: true),
                    predicted_teacher_id = table.Column<long>(nullable: true),
                    subject_matter_credits = table.Column<int>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scholarship_program_university_subject_matter", x => x.scholarship_program_university_subject_matter_id);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_subject_matter_teacher_2",
                        column: x => x.predicted_teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_spusm_scholarship_program_university",
                        column: x => x.scholarship_program_university_id,
                        principalTable: "scholarship_program_university",
                        principalColumn: "scholarship_program_university_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_subject_matter_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_subject_matter_subject_matter",
                        column: x => x.subject_matter_id,
                        principalTable: "subject_matter",
                        principalColumn: "subject_matter_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scholarship_program_university_subject_matter_teacher",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teacher_education",
                columns: table => new
                {
                    teacher_education_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    teacher_id = table.Column<long>(nullable: false),
                    teacher_education_title = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    education_type_id = table.Column<long>(nullable: true),
                    teacher_education_finish_date = table.Column<DateTime>(type: "date", nullable: true),
                    teacher_education_institution = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_education", x => x.teacher_education_id);
                    table.ForeignKey(
                        name: "FK_teacher_education_education_type",
                        column: x => x.education_type_id,
                        principalTable: "education_type",
                        principalColumn: "education_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_education_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_education_teacher",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teacher_research",
                columns: table => new
                {
                    teacher_research_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    teacher_id = table.Column<long>(nullable: false),
                    teacher_research_name = table.Column<string>(unicode: false, maxLength: 64, nullable: true),
                    teacher_research_quantity = table.Column<int>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_research", x => x.teacher_research_id);
                    table.ForeignKey(
                        name: "FK_teacher_research_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_research_teacher",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tracing_study_plan_development",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    scholarship_program_tracing_id = table.Column<long>(nullable: true),
                    subject_matter_id = table.Column<long>(nullable: true),
                    teacher_id = table.Column<long>(nullable: true),
                    assigned_teacher_id = table.Column<long>(nullable: true),
                    higher_title_support_matter_id = table.Column<long>(nullable: true),
                    score_average_students = table.Column<double>(nullable: true),
                    approved_students_quantity = table.Column<int>(nullable: true),
                    reproved_students_quantity = table.Column<int>(nullable: true),
                    deserted_students_quantity = table.Column<int>(nullable: true),
                    higher_title_match_assigned_matter = table.Column<short>(type: "bit(1)", nullable: true),
                    subject_matter_score_report_file_id = table.Column<long>(nullable: true),
                    subject_matter_time_start = table.Column<TimeSpan>(nullable: true),
                    subject_matter_time_end = table.Column<TimeSpan>(nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    creation_user_id = table.Column<long>(nullable: true),
                    upgrade_user_id = table.Column<long>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracing_study_plan_development", x => x.id);
                    table.ForeignKey(
                        name: "FK_teacher_teacher_2",
                        column: x => x.assigned_teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_education",
                        column: x => x.higher_title_support_matter_id,
                        principalTable: "teacher_education",
                        principalColumn: "teacher_education_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tracing",
                        column: x => x.scholarship_program_tracing_id,
                        principalTable: "scholarship_program_tracing",
                        principalColumn: "scholarship_program_tracing_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_status_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_subject_matter",
                        column: x => x.subject_matter_id,
                        principalTable: "subject_matter",
                        principalColumn: "subject_matter_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_teacher",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "teacher_file",
                columns: table => new
                {
                    teacher_file_id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    teacher_id = table.Column<long>(nullable: false),
                    teacher_research_id = table.Column<long>(nullable: true),
                    file_id = table.Column<long>(nullable: true),
                    teacher_file_type_id = table.Column<long>(nullable: true),
                    teacher_file_comment = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    creation_date = table.Column<DateTime>(nullable: true),
                    upgrade_date = table.Column<DateTime>(nullable: true),
                    status_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_file", x => x.teacher_file_id);
                    table.ForeignKey(
                        name: "FK_teacher_file_file",
                        column: x => x.file_id,
                        principalTable: "file",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_file_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_file_teacher_file_type",
                        column: x => x.teacher_file_type_id,
                        principalTable: "teacher_file_type",
                        principalColumn: "teacher_file_type_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_file_teacher",
                        column: x => x.teacher_id,
                        principalTable: "teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teacher_file_teacher_research",
                        column: x => x.teacher_research_id,
                        principalTable: "teacher_research",
                        principalColumn: "teacher_research_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_address_address_type",
                table: "address",
                column: "address_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_address_city",
                table: "address",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "FK_address_user",
                table: "address",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_address_province",
                table: "address",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "FK_address_status",
                table: "address",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_address_user_2",
                table: "address",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_address_type_status",
                table: "address_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_agent_agent_type",
                table: "agent",
                column: "agent_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_agent_contact_id",
                table: "agent",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "FK_cordinator_user",
                table: "agent",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_cordinator_status",
                table: "agent",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_cordinator_user_2",
                table: "agent",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_agent_user",
                table: "agent",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "FK_agent_type_status",
                table: "agent_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_city_country",
                table: "city",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "FK_city_province",
                table: "city",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "FK_city_status",
                table: "city",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_communication_user",
                table: "communication",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_communication_status",
                table: "communication",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_communication_user_2",
                table: "communication",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_address",
                table: "company",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_communication",
                table: "company",
                column: "communication_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_company_type",
                table: "company",
                column: "company_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_contact",
                table: "company",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_user_3",
                table: "company",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_user",
                table: "company",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_user_2",
                table: "company",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_status",
                table: "company",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_user_4",
                table: "company",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_company_type_status",
                table: "company_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "contact_document_number",
                table: "contact",
                column: "contact_document_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_contact_contact_type",
                table: "contact",
                column: "contact_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_user",
                table: "contact",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_document_type",
                table: "contact",
                column: "document_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_status",
                table: "contact",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_user_2",
                table: "contact",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_address_address",
                table: "contact_address",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_address_contact",
                table: "contact_address",
                column: "contact_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_contact_address_status",
                table: "contact_address",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_communication_communication",
                table: "contact_communication",
                column: "communication_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_communication_contact",
                table: "contact_communication",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_communication_status",
                table: "contact_communication",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_type_document_type",
                table: "contact_type",
                column: "document_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_contact_type_status",
                table: "contact_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_country_status",
                table: "country",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_document_type_status",
                table: "document_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_education_type_status",
                table: "education_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_file_user",
                table: "file",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_file_file_type",
                table: "file",
                column: "file_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_file_status",
                table: "file",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_file_user_2",
                table: "file",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_file_type_status",
                table: "file_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_menu_menu",
                table: "menu",
                column: "menu_parent_id");

            migrationBuilder.CreateIndex(
                name: "FK_menu_menu_type",
                table: "menu",
                column: "menu_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_menu_status",
                table: "menu",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_menu_type_status",
                table: "menu_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_nationality_status_id",
                table: "nationality",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_object_status",
                table: "object",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_object_mapping_object",
                table: "object_mapping",
                column: "object_id");

            migrationBuilder.CreateIndex(
                name: "FK_object_mapping_status",
                table: "object_mapping",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_office_address",
                table: "office",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "FK_office_communication",
                table: "office",
                column: "communication_id");

            migrationBuilder.CreateIndex(
                name: "FK_office_company",
                table: "office",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "FK_office_user_2",
                table: "office",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_office_user",
                table: "office",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "FK_office_status",
                table: "office",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_office_user_3",
                table: "office",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_province_country",
                table: "province",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "FK_province_status",
                table: "province",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_schedule_user",
                table: "schedule",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_schedule_status",
                table: "schedule",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_schedule_user_2",
                table: "schedule",
                column: "updating_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_schedule_days_schedule",
                table: "schedule_day",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_level_status",
                table: "scholarship_level",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_scholarship_level",
                table: "scholarship_program",
                column: "scholarship_level_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_status",
                table: "scholarship_program",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_agent",
                table: "scholarship_program_tracing",
                column: "coordinator_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_user",
                table: "scholarship_program_tracing",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_scholarship_program_university",
                table: "scholarship_program_tracing",
                column: "scholarship_program_university_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_status",
                table: "scholarship_program_tracing",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_agent_2",
                table: "scholarship_program_tracing",
                column: "technical_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracing_university",
                table: "scholarship_program_tracing",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_user_2",
                table: "scholarship_program_tracing",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_agreement_user_3",
                table: "scholarship_program_tracing_agreement",
                column: "commented_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_agreement_user",
                table: "scholarship_program_tracing_agreement",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_tracking",
                table: "scholarship_program_tracing_agreement",
                column: "scholarship_program_tracing_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracing_agreement",
                table: "scholarship_program_tracing_agreement",
                column: "scholarship_program_university_agreement_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_agreement_status",
                table: "scholarship_program_tracing_agreement",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_agreement_user_2",
                table: "scholarship_program_tracing_agreement",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_agreement_file_file",
                table: "scholarship_program_tracing_agreement_file",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracking_agreement_file_status",
                table: "scholarship_program_tracing_agreement_file",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracing_plan_status",
                table: "scholarship_program_tracing_course",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracing_plan_scholarship_program_tracing",
                table: "scholarship_program_tracing_course",
                column: "tracing_id");

            migrationBuilder.CreateIndex(
                name: "FK__tracing_plan_file",
                table: "scholarship_program_tracing_course_file",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "FK_file_type",
                table: "scholarship_program_tracing_course_file",
                column: "file_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_tracing_plan_status",
                table: "scholarship_program_tracing_course_file",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK__tracing_plan",
                table: "scholarship_program_tracing_course_file",
                column: "tracing_id");

            migrationBuilder.CreateIndex(
                name: "FK_practice_status",
                table: "scholarship_program_tracing_practice",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_practice_tracing",
                table: "scholarship_program_tracing_practice",
                column: "tracing_id");

            migrationBuilder.CreateIndex(
                name: "FK_planning_status",
                table: "scholarship_program_tracing_practice_planning",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_planning_tracing",
                table: "scholarship_program_tracing_practice_planning",
                column: "tracing_id");

            migrationBuilder.CreateIndex(
                name: "FK_file_quality",
                table: "scholarship_program_tracing_quality_system",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "FK_status_quality",
                table: "scholarship_program_tracing_quality_system",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_program_tracing",
                table: "scholarship_program_tracing_quality_system",
                column: "tracing_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracing_student_practice_status",
                table: "scholarship_program_tracing_student_practice",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_student_practice_tracing",
                table: "scholarship_program_tracing_student_practice",
                column: "tracing_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_tracing_student_support_status",
                table: "scholarship_program_tracing_student_support",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_student_support_tracing",
                table: "scholarship_program_tracing_student_support",
                column: "tracing_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_agent",
                table: "scholarship_program_university",
                column: "coordinator_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_scholarship_level",
                table: "scholarship_program_university",
                column: "scholarship_level_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_scholarship_program",
                table: "scholarship_program_university",
                column: "scholarship_program_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_status",
                table: "scholarship_program_university",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_agent_2",
                table: "scholarship_program_university",
                column: "technical_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_university",
                table: "scholarship_program_university",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_contact",
                table: "scholarship_program_university_agent",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "FK_program_university",
                table: "scholarship_program_university_agent",
                column: "scholarship_program_university_id");

            migrationBuilder.CreateIndex(
                name: "FK_status",
                table: "scholarship_program_university_agent",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_agreement_agreement_type",
                table: "scholarship_program_university_agreement",
                column: "agreement_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_agreement_user",
                table: "scholarship_program_university_agreement",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university",
                table: "scholarship_program_university_agreement",
                column: "scholarship_program_university_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_agreement_status",
                table: "scholarship_program_university_agreement",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_agreement_user_2",
                table: "scholarship_program_university_agreement",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_subject_matter_teacher_2",
                table: "scholarship_program_university_subject_matter",
                column: "predicted_teacher_id");

            migrationBuilder.CreateIndex(
                name: "FK_spusm_scholarship_program_university",
                table: "scholarship_program_university_subject_matter",
                column: "scholarship_program_university_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_subject_matter_status",
                table: "scholarship_program_university_subject_matter",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_subject_matter_subject_matter",
                table: "scholarship_program_university_subject_matter",
                column: "subject_matter_id");

            migrationBuilder.CreateIndex(
                name: "FK_scholarship_program_university_subject_matter_teacher",
                table: "scholarship_program_university_subject_matter",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "FK_subject_matter_user",
                table: "subject_matter",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_subject_matter_status",
                table: "subject_matter",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "subject_matter_code",
                table: "subject_matter",
                column: "subject_matter_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_subject_matter_user_2",
                table: "subject_matter",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_contact",
                table: "teacher",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_teacher_education",
                table: "teacher",
                column: "higher_teacher_education_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_status",
                table: "teacher",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_teacher_hiring_type",
                table: "teacher",
                column: "teacher_hiring_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_education_education_type",
                table: "teacher_education",
                column: "education_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_education_status",
                table: "teacher_education",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_education_teacher",
                table: "teacher_education",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_file_file",
                table: "teacher_file",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_file_status",
                table: "teacher_file",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_file_teacher_file_type",
                table: "teacher_file",
                column: "teacher_file_type_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_file_teacher",
                table: "teacher_file",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_file_teacher_research",
                table: "teacher_file",
                column: "teacher_research_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_file_type_status",
                table: "teacher_file_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_hiring_type_status",
                table: "teacher_hiring_type",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_research_status",
                table: "teacher_research",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_research_teacher",
                table: "teacher_research",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_teacher_2",
                table: "tracing_study_plan_development",
                column: "assigned_teacher_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_education",
                table: "tracing_study_plan_development",
                column: "higher_title_support_matter_id");

            migrationBuilder.CreateIndex(
                name: "FK_tracing",
                table: "tracing_study_plan_development",
                column: "scholarship_program_tracing_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_status_status",
                table: "tracing_study_plan_development",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_subject_matter",
                table: "tracing_study_plan_development",
                column: "subject_matter_id");

            migrationBuilder.CreateIndex(
                name: "FK_teacher_teacher",
                table: "tracing_study_plan_development",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "FK_university_address",
                table: "university",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "FK_university_communication",
                table: "university",
                column: "communication_id");

            migrationBuilder.CreateIndex(
                name: "FK_university_status",
                table: "university",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_company",
                table: "user",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_contact",
                table: "user",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_user",
                table: "user",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_office",
                table: "user",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_status",
                table: "user",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_user_2",
                table: "user",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_user_role",
                table: "user",
                column: "user_role_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_schedule",
                table: "user",
                column: "user_schedule_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_roles_user",
                table: "user_map_role",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_roles_user_role",
                table: "user_map_role",
                column: "user_role_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_role_user",
                table: "user_role",
                column: "creation_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_role_office",
                table: "user_role",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_role_status",
                table: "user_role",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_role_user_2",
                table: "user_role",
                column: "upgrade_user_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_role_permission_table",
                table: "user_role_permission",
                column: "object_id");

            migrationBuilder.CreateIndex(
                name: "FK_user_role_permission_user_role",
                table: "user_role_permission",
                column: "user_role_id");

            migrationBuilder.CreateIndex(
                name: "FK__status",
                table: "user_university",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "FK__university",
                table: "user_university",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "FK__user",
                table: "user_university",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_company_user_3",
                table: "company",
                column: "creation_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_user",
                table: "company",
                column: "manager_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_user_2",
                table: "company",
                column: "owner_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_user_4",
                table: "company",
                column: "upgrade_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_contact",
                table: "company",
                column: "contact_id",
                principalTable: "contact",
                principalColumn: "contact_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_address",
                table: "company",
                column: "address_id",
                principalTable: "address",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_company_communication",
                table: "company",
                column: "communication_id",
                principalTable: "communication",
                principalColumn: "communication_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_contact_address_contact_contact_id",
                table: "contact_address",
                column: "contact_id",
                principalTable: "contact",
                principalColumn: "contact_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_contact_address_address",
                table: "contact_address",
                column: "address_id",
                principalTable: "address",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_office_user_2",
                table: "office",
                column: "creation_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_office_user",
                table: "office",
                column: "manager_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_office_user_3",
                table: "office",
                column: "upgrade_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_office_address",
                table: "office",
                column: "address_id",
                principalTable: "address",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_office_communication",
                table: "office",
                column: "communication_id",
                principalTable: "communication",
                principalColumn: "communication_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_university_address",
                table: "university",
                column: "address_id",
                principalTable: "address",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_university_communication",
                table: "university",
                column: "communication_id",
                principalTable: "communication",
                principalColumn: "communication_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_address_user",
                table: "address",
                column: "creation_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_address_user_2",
                table: "address",
                column: "upgrade_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_tracking_user",
                table: "scholarship_program_tracing",
                column: "creation_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_tracking_user_2",
                table: "scholarship_program_tracing",
                column: "upgrade_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_tracking_agent",
                table: "scholarship_program_tracing",
                column: "coordinator_id",
                principalTable: "agent",
                principalColumn: "agent_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_tracking_agent_2",
                table: "scholarship_program_tracing",
                column: "technical_id",
                principalTable: "agent",
                principalColumn: "agent_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_tracking_scholarship_program_university",
                table: "scholarship_program_tracing",
                column: "scholarship_program_university_id",
                principalTable: "scholarship_program_university",
                principalColumn: "scholarship_program_university_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_university_agent",
                table: "scholarship_program_university",
                column: "coordinator_id",
                principalTable: "agent",
                principalColumn: "agent_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_university_agent_2",
                table: "scholarship_program_university",
                column: "technical_id",
                principalTable: "agent",
                principalColumn: "agent_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_contact",
                table: "scholarship_program_university_agent",
                column: "agent_id",
                principalTable: "agent",
                principalColumn: "agent_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cordinator_user",
                table: "agent",
                column: "creation_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cordinator_user_2",
                table: "agent",
                column: "upgrade_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_agent_user",
                table: "agent",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_agent_contact_contact_id",
                table: "agent",
                column: "contact_id",
                principalTable: "contact",
                principalColumn: "contact_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_university_agreement_user",
                table: "scholarship_program_university_agreement",
                column: "creation_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_scholarship_program_university_agreement_user_2",
                table: "scholarship_program_university_agreement",
                column: "upgrade_user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_contact_communication_contact",
                table: "contact_communication",
                column: "contact_id",
                principalTable: "contact",
                principalColumn: "contact_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_contact_communication_communication",
                table: "contact_communication",
                column: "communication_id",
                principalTable: "communication",
                principalColumn: "communication_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_contact",
                table: "user",
                column: "contact_id",
                principalTable: "contact",
                principalColumn: "contact_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_schedule",
                table: "user",
                column: "user_schedule_id",
                principalTable: "schedule",
                principalColumn: "schedule_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_user_role",
                table: "user",
                column: "user_role_id",
                principalTable: "user_role",
                principalColumn: "user_role_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_teacher_education",
                table: "teacher",
                column: "higher_teacher_education_id",
                principalTable: "teacher_education",
                principalColumn: "teacher_education_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_address_type",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_city",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_user",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_user_2",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_communication_user",
                table: "communication");

            migrationBuilder.DropForeignKey(
                name: "FK_communication_user_2",
                table: "communication");

            migrationBuilder.DropForeignKey(
                name: "FK_company_user_3",
                table: "company");

            migrationBuilder.DropForeignKey(
                name: "FK_company_user",
                table: "company");

            migrationBuilder.DropForeignKey(
                name: "FK_company_user_2",
                table: "company");

            migrationBuilder.DropForeignKey(
                name: "FK_company_user_4",
                table: "company");

            migrationBuilder.DropForeignKey(
                name: "FK_contact_user",
                table: "contact");

            migrationBuilder.DropForeignKey(
                name: "FK_contact_user_2",
                table: "contact");

            migrationBuilder.DropForeignKey(
                name: "FK_office_user_2",
                table: "office");

            migrationBuilder.DropForeignKey(
                name: "FK_office_user",
                table: "office");

            migrationBuilder.DropForeignKey(
                name: "FK_office_user_3",
                table: "office");

            migrationBuilder.DropForeignKey(
                name: "FK_schedule_user",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_schedule_user_2",
                table: "schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_user",
                table: "user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_user_role_user_2",
                table: "user_role");

            migrationBuilder.DropForeignKey(
                name: "FK_contact_status",
                table: "contact");

            migrationBuilder.DropForeignKey(
                name: "FK_contact_type_status",
                table: "contact_type");

            migrationBuilder.DropForeignKey(
                name: "FK_document_type_status",
                table: "document_type");

            migrationBuilder.DropForeignKey(
                name: "FK_education_type_status",
                table: "education_type");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_status",
                table: "teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_education_status",
                table: "teacher_education");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_hiring_type_status",
                table: "teacher_hiring_type");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_contact",
                table: "teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_education_teacher",
                table: "teacher_education");

            migrationBuilder.DropTable(
                name: "contact_address");

            migrationBuilder.DropTable(
                name: "contact_communication");

            migrationBuilder.DropTable(
                name: "marital_status");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "migrations");

            migrationBuilder.DropTable(
                name: "nationality");

            migrationBuilder.DropTable(
                name: "object_mapping");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "schedule_day");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_agreement");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_agreement_file");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_course");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_course_file");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_practice");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_practice_planning");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_quality_system");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_quality_system_file_type");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_student_practice");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_student_support");

            migrationBuilder.DropTable(
                name: "scholarship_program_university_agent");

            migrationBuilder.DropTable(
                name: "scholarship_program_university_subject_matter");

            migrationBuilder.DropTable(
                name: "scholarship_program_university_teacher_hiring");

            migrationBuilder.DropTable(
                name: "spu_taught_subject");

            migrationBuilder.DropTable(
                name: "study_plan_management");

            migrationBuilder.DropTable(
                name: "teacher_file");

            migrationBuilder.DropTable(
                name: "tracing_study_plan_development");

            migrationBuilder.DropTable(
                name: "user_map_role");

            migrationBuilder.DropTable(
                name: "user_role_permission");

            migrationBuilder.DropTable(
                name: "user_university");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "menu_type");

            migrationBuilder.DropTable(
                name: "scholarship_program_university_agreement");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing_course_file_type");

            migrationBuilder.DropTable(
                name: "file");

            migrationBuilder.DropTable(
                name: "teacher_file_type");

            migrationBuilder.DropTable(
                name: "teacher_research");

            migrationBuilder.DropTable(
                name: "scholarship_program_tracing");

            migrationBuilder.DropTable(
                name: "subject_matter");

            migrationBuilder.DropTable(
                name: "object");

            migrationBuilder.DropTable(
                name: "agreement_type");

            migrationBuilder.DropTable(
                name: "file_type");

            migrationBuilder.DropTable(
                name: "scholarship_program_university");

            migrationBuilder.DropTable(
                name: "agent");

            migrationBuilder.DropTable(
                name: "scholarship_program");

            migrationBuilder.DropTable(
                name: "university");

            migrationBuilder.DropTable(
                name: "agent_type");

            migrationBuilder.DropTable(
                name: "scholarship_level");

            migrationBuilder.DropTable(
                name: "address_type");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "office");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "communication");

            migrationBuilder.DropTable(
                name: "company_type");

            migrationBuilder.DropTable(
                name: "province");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "contact_type");

            migrationBuilder.DropTable(
                name: "document_type");

            migrationBuilder.DropTable(
                name: "teacher");

            migrationBuilder.DropTable(
                name: "teacher_education");

            migrationBuilder.DropTable(
                name: "teacher_hiring_type");

            migrationBuilder.DropTable(
                name: "education_type");
        }
    }
}
