using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Andamios.Web.Models;
using Inafocam.core.Modelos;
//using Andamios.Web.Resources;
using DinkToPdf;
using DinkToPdf.Contracts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Inafocam.core.Interfaces;
using Inafocam.core.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Inafocam.Web.Models;

namespace Andamios.Web
{
    public class Startup
    {
        private string[] permisos = new[] { "Create", "Read", "Update", "Admin" };
        private const string esCulture = "es";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<inafocam_tracingContext>(options =>
               options.UseMySQL(
                   Configuration.GetConnectionString("InafocamContext")));

            services.AddIdentity<Usuario, Role>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<inafocam_tracingContext>()
                .AddDefaultTokenProviders();




            services.AddAuthorization(op =>
            {
                op.AddPolicy(PolicyName.AdminUser, policy => policy.RequireRole(RoleName.AdministradorInafocam));
                op.AddPolicy(PolicyName.UsuarioEjecutivo, policy => policy.RequireRole(RoleName.UsuarioEjecutivoInafocam));

                op.AddPolicy(PolicyName.GestionUniversitaria, policy => policy.RequireRole(RoleName.GestionUniversitaria));
            });


            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            services.AddRazorPages();

            services.AddMvc().AddFluentValidation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.LoginPath = "/Usuarios/Usuario/Login";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                    options.Cookie.Expiration = TimeSpan.FromHours(1);
                });

            //////
            services.ConfigureApplicationCookie(options =>
            {


                options.LoginPath = "/Usuarios/Usuario/Login";
                options.AccessDeniedPath = "/identity/Account/AccessDenied";
                //options.SlidingExpiration = true;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;


                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });




            services.AddMvc();
 

            // conexiones de para las inyecciones de dependencias

            #region DI Connections

            //app
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IScholarshipProgram, ScholarshipProgramRepository>();
            services.AddScoped<IScholarshipLevel, ScholarshipLevelRepository>();
            services.AddScoped<IStatus, StatusRepositoty>();
            services.AddScoped<IUniversity, UniversityRepository>();
            services.AddScoped<IScholarshipProgramUniversity, ScholarshipProgramUniversityRepository>();
            services.AddScoped<IScholarshipProgramTracing, ScholarshipProgramTracingRepository>();
            services.AddScoped<IAddressType, AddressTypeRepository>();
            services.AddScoped<ICountry, CountryRepository>();
            services.AddScoped<IProvince, ProvinceRepository>();
            services.AddScoped<ICity, CityRepository>();
            services.AddScoped<IAgent, AgentRepository>();
            services.AddScoped<IAgreementType, AgreementTypeRepository>();
            services.AddScoped<IAgentType, AgentTypeRepository>();
            services.AddScoped<ITeacher, TeacherRepository>();
            services.AddScoped<IContactType, ContactTypeRepository>();
            services.AddScoped<IDocumentType, DocumentTypeRepository>();
            services.AddScoped<IEducationType, EducationTypeRepository>();
            services.AddScoped<ITeacherEducation, TeacherEducationRepository>();
            services.AddScoped<ITeacherFileType, TeacherFileTypeRepository> ();
            services.AddScoped<IMatirialStatus, MatirialStatusRepository> ();
            services.AddScoped<INationality, NationalityRepository> ();
            services.AddScoped<ISubjectMatter, SubjectMatterRepository> ();
            services.AddScoped<IUser, UserRepository> ();
            services.AddScoped<IUserRole, UserRoleRepository> ();
            services.AddScoped<IContact, ContactRepository> ();
            services.AddScoped<IScholarshipProgramUniversityAgreement, ScholarshipProgramUniversityAgreementRepository> ();
            services.AddScoped<ITeacherHiringType, TeacherHiringTypeRepository> ();
            services.AddScoped<ITeacherFile, TeacherFileRepository> ();
            services.AddScoped<IContactAddress, ContactAddressRepository>();
            services.AddScoped<IContactCommunication, ContactCommunicationRepository>();
            services.AddScoped<IUsuario, UsuarioRepository>();
            services.AddScoped<IRole, RoleRepository>();
            services.AddScoped<IScholarshipProgramTracingCourse, ScholarshipProgramTracingCourseRepository>();
            services.AddScoped<IScholarshipProgramTracingStudentSupport, ScholarshipProgramTracingStudentSupportRepository>();
            services.AddScoped<IScholarshipProgramTracingAgreement, ScholarshipProgramTracingAgreementRepository>();
            services.AddScoped<IScholarshipProgramTracingCourseFile, ScholarshipProgramTracingCourseFileRepository>();
            services.AddScoped<IScholarshipProgramTracingAgreementFile, ScholarshipProgramTracingAgreementFileRepository>();
            services.AddScoped<ITracingStudyPlanDevelopment, TracingStudyPlanDevelopmentRepository>();
            services.AddScoped<IScholarshipProgramTracingCourse, ScholarshipProgramTracingCourseRepository>();
            services.AddScoped<IScholarshipProgramTracingCourseFileType, ScholarshipProgramTracingCourseFileTypeRepository>();
            services.AddScoped<IScholarshipProgramTracingQualitySystemFileType, ScholarshipProgramTracingQualitySystemFileTypeRepository>();
            services.AddScoped<IScholarshipProgramTracingQualitySystem, ScholarshipProgramTracingQualitySystemRepository>();
            services.AddScoped<IFile, FileRepository>();
            services.AddScoped<IScholarshipProgramUniversitySubjectMatter, ScholarshipProgramUniversitySubjectMatterRepository>();
            services.AddScoped<IComponentFileType, ComponentFileTypeRepository>();
            services.AddScoped<IStudentPracticeType, StudentPracticeTypeRepository>();
            services.AddScoped<IScholarshipProgramTracingStudentPractice, ScholarshipProgramTracingStudentPracticeRepository>();
            services.AddScoped<IActionType, ActionTypeRepository>();
            services.AddScoped<IScholarshipProgramTracingPracticePlanning, ScholarshipProgramTracingPracticePlanningRepository>();
            services.AddScoped<IScholarshipProgramTracingPractice, ScholarshipProgramTracingPracticeRepository>();
            services.AddScoped<IActivityType, ActivityTypeRepository>();
            services.AddScoped<IResultsFromThePreviousPeriod, ResultsFromThePreviousPeriodRepository>();
            services.AddScoped<IScholarshipProgramTracingAgreementsWithPracticeCenter, ScholarshipProgramTracingAgreementsWithPracticeCenterRepository>();
            services.AddScoped<IAgreementWithInstitutionsRelatedToCurricularActivities, AgreementWithInstitutionsRelatedToCurricularActivitiesRepository>(); services.AddScoped<IScholarshipProgramTracingStudentPracticeFile, ScholarshipProgramTracingStudentPracticeFileRepository>();
            services.AddScoped<IComment, CommentRepository>();
            services.AddScoped<IReport, ReportRepository>();


            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}",
                    defaults: new { action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


        }
    }
}