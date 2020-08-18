using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.ProgramacionDeSeguimiento.Models;
using Inafocam.Web.Areas.SeguimientoDeUniversidades.Models;
using Inafocam.Web.Helpers;
using Inafocam.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration;
using MySql.Data.EntityFrameworkCore.Query.Internal;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Controllers
{

    [Area("SeguimientoDeUniversidades"), ReturnArea("SeguimientoDeUniversidades")]
    [ReturnControllador("Seguimiento De Universidades"), ReturnController("SeguimientoDeUniversida")]
 

    public class SeguimientoDeUniversidaController : Controller
    {
        private readonly IScholarshipProgramTracing _scholarshipProgramTracing;
        private readonly IScholarshipProgramUniversityAgreement _scholarshipProgramUniversityAgreement;
        private readonly IScholarshipProgramTracingAgreementFile _scholarshipProgramTracingAgreementFile;
        private readonly IScholarshipProgramTracingStudentSupport _studentSupport;
        private readonly IScholarshipProgramUniversity _scholarshipProgramUniversity;
        private readonly IScholarshipProgramTracingAgreement _scholarshipProgramTracingAgreement;
        private readonly IAgent _agent;
        private readonly ITracingStudyPlanDevelopment _tracingStudyPlanDevelopment;
        private readonly IContactCommunication _contactCommunication;
        private readonly ITeacher _teacher;
        private readonly IScholarshipProgramTracingCourse _scholarshipProgramTracingCourse;
        private readonly IScholarshipProgramTracingCourseFile _tracingCourseFile;
        private readonly IScholarshipProgramTracingCourseFileType _CourseFileType;
        private readonly IScholarshipProgramTracingQualitySystemFileType _qualitySystemFileType;
        private readonly IScholarshipProgramTracingQualitySystem _qualitySystem;
        private readonly IConfiguration _config;
        private readonly IFile _file;
        private readonly IComponentFileType _componentFileType;
        private readonly IStudentPracticeType _studentPracticeType;
        private readonly IScholarshipProgramTracingStudentPractice _studentPractice;
        private readonly IScholarshipProgramTracingPracticePlanning _practicePlanning;
        private readonly IActionType _actionType;
        private readonly IActivityType _activityType;
        private readonly IScholarshipProgramTracingPractice _tracingPractice;
        private readonly IResultsFromThePreviousPeriod _previousPeriod;
        private readonly IScholarshipProgramTracingAgreementsWithPracticeCenter _agreementsWithPracticeCenter;
        private readonly IAgreementWithInstitutionsRelatedToCurricularActivities _relatedToCurricularActivities;
        private readonly ISubjectMatter _subjectMatter;
        private readonly IScholarshipProgramTracingStudentPracticeFile  _studentPracticeFile;
        private readonly IComment _comment;
        private readonly IReport _Informe;
        private readonly IUniversity _university;


        private readonly UserManager<Usuario> _userManager;

        public SeguimientoDeUniversidaController(IScholarshipProgramTracing scholarshipProgramTracing, IScholarshipProgramTracingStudentSupport studentSupport,
            IScholarshipProgramUniversity scholarshipProgramUniversity, IAgent agent, IContactCommunication contactCommunication,
            IScholarshipProgramUniversityAgreement scholarshipProgramUniversityAgreement, IScholarshipProgramTracingAgreement scholarshipProgramTracingAgreement,
            IScholarshipProgramTracingAgreementFile scholarshipProgramTracingAgreementFile, ITracingStudyPlanDevelopment tracingStudyPlanDevelopment, ITeacher teacher
            , UserManager<Usuario> userManager, IScholarshipProgramTracingCourse scholarshipProgramTracingCourse,
            IScholarshipProgramTracingCourseFile tracingCourseFile, IScholarshipProgramTracingCourseFileType CourseFileType,
            IScholarshipProgramTracingQualitySystemFileType qualitySystemFileType, IScholarshipProgramTracingQualitySystem qualitySystem,
            IConfiguration config, IFile file, IComponentFileType componentFileType, IStudentPracticeType studentPracticeType,
            IScholarshipProgramTracingStudentPractice studentPractice, IScholarshipProgramTracingPracticePlanning practicePlanning,
            IActionType actionType, IActivityType activityType, IScholarshipProgramTracingPractice tracingPractice,
            IResultsFromThePreviousPeriod previousPeriod, IScholarshipProgramTracingAgreementsWithPracticeCenter agreementsWithPracticeCenter, ISubjectMatter subjectMatter,
            IAgreementWithInstitutionsRelatedToCurricularActivities relatedToCurricularActivities,
            IScholarshipProgramTracingStudentPracticeFile studentPracticeFile,IComment comment,
            IUniversity university,IReport informe )
        {
            _scholarshipProgramTracing = scholarshipProgramTracing;
            _studentSupport = studentSupport;
            _userManager = userManager;
            _scholarshipProgramUniversity = scholarshipProgramUniversity;
            _agent = agent;
            _contactCommunication = contactCommunication;
            _scholarshipProgramUniversityAgreement = scholarshipProgramUniversityAgreement;
            _scholarshipProgramTracingAgreement = scholarshipProgramTracingAgreement;
            _scholarshipProgramTracingAgreementFile = scholarshipProgramTracingAgreementFile;
            _tracingStudyPlanDevelopment = tracingStudyPlanDevelopment;
            _teacher = teacher;
            _scholarshipProgramTracingCourse = scholarshipProgramTracingCourse;
            _tracingCourseFile = tracingCourseFile;
            _CourseFileType = CourseFileType;
            _qualitySystemFileType = qualitySystemFileType;
            _qualitySystem = qualitySystem;
            _config = config;
            _file = file;
            _componentFileType = componentFileType;
            _studentPracticeType = studentPracticeType;
            _studentPractice = studentPractice;
            _practicePlanning = practicePlanning;
            _actionType = actionType;
            _activityType = activityType;
            _tracingPractice = tracingPractice;
            _previousPeriod = previousPeriod;
            _agreementsWithPracticeCenter = agreementsWithPracticeCenter;
            _relatedToCurricularActivities = relatedToCurricularActivities;
            _subjectMatter = subjectMatter;
            _studentPracticeFile = studentPracticeFile;
            _comment = comment;
            _university = university;
            _Informe = informe;
        }


        public IActionResult Index()
        {


            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario user = _userManager.FindByIdAsync(userId).Result;

            var universityId = Convert.ToInt32(user.UniversityId);

            if (user.Role == RoleName.GestionUniversitaria || user.Role == RoleName.UsuarioEjecutivoUniversitario)
            {
                var availableTracings = _scholarshipProgramTracing.GetTracingByUserUniversityId(universityId);
                return View(availableTracings);
            }
            else if (user.Role == RoleName.AdministradorInafocam || user.Role == RoleName.UsuarioEjecutivoInafocam)
            {
                var tracings = _scholarshipProgramTracing.ScholarshipProgramTracing;
                return View(tracings);
            }

            return View();

        }


        public IActionResult Informes(int tracingId,int programUniversityId)
        {
            var model = new InformeIndexViewModel();
               model.ReportList = _Informe.GetAllByTracingId(tracingId);
               model.ScholarshipProgramUniversityId = programUniversityId;
               model.TracingId = tracingId;    
                     
            return View(model);
        }

        public IActionResult AgregarInformes(int tracingId, int scholarshipProgramUniversityId)
        {

            var model = new InformeModel();
            model.TracingId = (long)tracingId;
            model.CreatorUserId = GetUserId();
            model.CreatorName = GetUserName();
            model.UniversityName = GetUniversityName(scholarshipProgramUniversityId);
            model.Program = _scholarshipProgramTracing.GetById(tracingId).ScholarshipProgramUniversity.ScholarshipProgram.ScholarshipProgramName;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> GuadrdarInforme(InformeModel model , IFormFile file)
        {
          
                var rutaPdf = _config.GetSection("rutas").GetSection("InformesFiles").Value;

                if (file != null)
                {

                    string ext = Path.GetExtension(file.FileName);
                    var fileName = GetUserId() + "-" + Guid.NewGuid() + ext;
                    if (ext.ToLower() != ".pdf")
                    {
                        return RedirectToAction("AgregarInformes", new {  tracingId = model.TracingId,  scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId});
                    }
                    var fileFullPath = Path.Combine(rutaPdf, fileName);

                    using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileSteam);
                    }

                var fileModel = new Inafocam.core.Modelos.File();

                    fileModel.FileName = file.FileName;
                    fileModel.FilePath = fileName;
                    fileModel.FileFullPath = fileFullPath;

                    var data = CopyPropierties.Convert<InformeModel, Report>(model);
                    data.File = fileModel;

                    try
                    {
                        _Informe.Save(data);
                    }
                    catch (Exception e)
                    {
                    return RedirectToAction("AgregarInformes", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
                    }
                }
                else
                {
                    EnviarMensaje.Enviar(TempData, "red", "El archivo es requerido");

                return RedirectToAction("Informes", new { tracingId = model.TracingId, programUniversityId = model.ScholarshipProgramUniversityId });

            }



            return RedirectToAction("Informes", new { tracingId = model.TracingId,  programUniversityId = model.ScholarshipProgramUniversityId});
        }
        
        [HttpPost]
        public int EliminarInforme(int reportId)
        {
            try
            {

            _Informe.DeleteReport(reportId);

            }
            catch(Exception e)
            {
                return 0;
            }

            return 1;

        }

      
        //public IActionResult ReloadInformesView(int tracingId, int programUniversityId)
        //{
        //    return RedirectToAction("Informes", new { tracingId = tracingId, programUniversityId = programUniversityId });
        //}

        public IActionResult Comentarios(int programUniversityId, int tracingId)
        {

            var model = new  CommentsIndexViewModel();
            model.CommentList = _comment.GetAllByTracingId(tracingId);
            model.UniversityName = GetUniversityName(programUniversityId);
            

            return View(model);
        }

        public IActionResult AgregarComentario(string screenComment, int tracingId, int scholarshipProgramUniversityId, string description, string actionName)
        {

            var model = new ComentariosViewModel();
            model.CreationDate = DateTime.Today;
            model.CreatorName = GetUserName();
            model.CommentScreen = screenComment;
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.Description = description;
            model.CreatorUserId = GetUserId();
            model.ScholarshipProgramTracingId = tracingId;
            model.TracingId = tracingId;
            model.ActionName = actionName;


            return View(model);
        }


        [HttpPost]
        public IActionResult GuardarComentario(ComentariosViewModel model)
        {

            var data = CopyPropierties.Convert<ComentariosViewModel, Comment>(model);


            if (ModelState.IsValid)
            {

                try
                {
                   _comment.Save(data);

                }
                catch(Exception e)
                {
                    return View("AgregarComentario" ,model);

                }

            }

            EnviarMensaje.Enviar(TempData, "green", model.CreatorName + " usted agrego un comentario a " + model.CommentScreen + " puede ir ala lista de comentarios y verificar.");

            return RedirectToAction(model.ActionName, new
            {
                tracingId = model.TracingId,  scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId
            });

         }

        public IActionResult Instrucciones(int tracingId, int programUniversityId)
        {

            var model = new InstruccionesViewModel();

            string[] instrucciones = {
                "Preparar la evidencia",
                "Llenar correctamente la información",
                "Ser honesto al responder"
            };

            var lista = new List<string>();
            var count = 0;
            var instrucion = "";
            foreach (var item in instrucciones)
            {

                count += 1;
                instrucion = count + "." + item;
                lista.Add(instrucion);
            }

            model.InstruccionesList = lista;
            model.ScholarshipProgramTracingId = tracingId;
            model.ScholarshipProgramUniversityId = programUniversityId;

            return View(model);
        }

        public IActionResult InformacionPrincipal(int tracingId)
        {

            var data = _scholarshipProgramTracing.GetById(tracingId);
            var model = CopyPropierties.Convert<ScholarshipProgramTracing, InformacionPrincipalViewModel>(data);
            model.IsGestionUniversitariaRole = GetLogUserRole();


            var coordinators = _agent.GetCoordinators.Select(x => new GetAgents
            {
                AgentId = x.AgentId,
                FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname
            });

            ViewBag.Coordinator = new SelectList(coordinators, "AgentId", "FullName");
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveInformacionPrincipal(InformacionPrincipalViewModel model)
        {
            if ((CheckIfTheProgramIsClose(model.ScholarshipProgramTracingId)  == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "InformacionPrincipal", tracingId = model.ScholarshipProgramTracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }


            var data = CopyPropierties.Convert<InformacionPrincipalViewModel, ScholarshipProgramTracing>(model);

            try
            {
                _scholarshipProgramTracing.Save(data);

            }
            catch (Exception e)
            {
                return RedirectToAction("InformacionPrincipal", new { tracingId = model.ScholarshipProgramTracingId });
            }

            return RedirectToAction("InformacionPrincipal", new { tracingId = model.ScholarshipProgramTracingId });

        }

        public string GetCoordinatorEmail(int id)
        {

            var coordinator = _agent.GetCoordinatorById(id);
            var contactid = Convert.ToInt32(coordinator.ContactId);
            var email = _contactCommunication.GetByContactId(contactid).Communication.CommunicationEmail;
            return email;
        }

        public string GetCoordinatorTelelofo(int id)
        {

            var coordinator = _agent.GetCoordinatorById(id);
            var contactid = Convert.ToInt32(coordinator.ContactId);
            var telefono = _contactCommunication.GetByContactId(contactid).Communication.CommunicationPhoneNumber1;
            return telefono;

        }

        public IActionResult Acuerdos(int scholarshipProgramUniversityId, int tracingId)
        {
            var model = new AcuerdosViewModel();
            model.IsGestionUniversitariaRole = GetLogUserRole();

            model.ScholarshipProgramUniversityAgreementList = _scholarshipProgramUniversityAgreement.GetAllPendingAndActiveByScholarshipProgramUniversityId(scholarshipProgramUniversityId);
            model.ScholarshipProgramTracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAcuerdos(AcuerdosViewModel model, int agremmentId, int universityAgreementId, int tracingId, IFormFile file)
        {
            if ((CheckIfTheProgramIsClose(model.ScholarshipProgramTracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "Acuerdos", tracingId = model.ScholarshipProgramTracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            //Pasando las los valores de los parametros al modelo ScholarshipProgramTracingAgreementModel
            model.ScholarshipProgramTracingAgreementModel.ScholarshipProgramUniversityAgreementId = universityAgreementId;
            model.ScholarshipProgramTracingAgreementModel.ScholarshipProgramTracingAgreementId = universityAgreementId;
            model.ScholarshipProgramTracingAgreementModel.ScholarshipProgramTracingId = tracingId;


            var rutaPdf = _config.GetSection("rutas").GetSection("AcuerdosFiles").Value;
            var scholarshipProgramTracingAgreementModel = new ScholarshipProgramTracingAgreementModel();
            scholarshipProgramTracingAgreementModel = model.ScholarshipProgramTracingAgreementModel;
            var tracingAgreementData = CopyPropierties.Convert<ScholarshipProgramTracingAgreementModel, ScholarshipProgramTracingAgreement>(scholarshipProgramTracingAgreementModel);


            if (file != null)
            {
                string ext = Path.GetExtension(file.FileName);
                var fileName = model.ScholarshipProgramTracingAgreementModel.ScholarshipProgramTracingAgreementId + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                    return RedirectToAction("Acuerdos", new { scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, tracingId = model.ScholarshipProgramTracingId });

                }

                var fileFullPath = Path.Combine(rutaPdf, fileName);

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }

                var fileTypeId = 14;
                var fileModel = new core.Modelos.File
                {
                    FileName = file.FileName,
                    FilePath = fileName,
                    FileFullPath = fileFullPath,
                    FileTypeId = fileTypeId
                };

                var scholarshipProgramTracingAgreementFileModel = new ScholarshipProgramTracingAgreementFileModel
                {
                    ScholarshipProgramTracingAgreementId = agremmentId,
                    AgreementFileDescription = model.ScholarshipProgramTracingAgreementFileModel.AgreementFileDescription,
                    File = fileModel

                };


                var tracingAgreementFileData = CopyPropierties.Convert<ScholarshipProgramTracingAgreementFileModel, ScholarshipProgramTracingAgreementFile>(scholarshipProgramTracingAgreementFileModel);

                try
                {

                    _scholarshipProgramTracingAgreementFile.Save(tracingAgreementFileData);

                }
                catch (Exception e)
                {
                    return RedirectToAction("Acuerdos", new { scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, tracingId = model.ScholarshipProgramTracingId });

                }
            }
            else
            {
                EnviarMensaje.Enviar(TempData, "red", "El documento es requerido");

                return RedirectToAction("Acuerdos", new { scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, tracingId = model.ScholarshipProgramTracingId });
            }
            return RedirectToAction("Acuerdos", new { scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, tracingId = model.ScholarshipProgramTracingId });
        }


        [HttpPost]
        public int EliminarEvidenciaAcuerdos(long evidenciaId)
        {

            try
            {
                _scholarshipProgramTracingAgreementFile.Delete(evidenciaId);
            }
            catch (Exception e)
            {
                return 0;
            }

            return 1;

        }

        public IActionResult DesarrolloDelPlanDeEstudio(int tracingId, int scholarshipProgramUniversityId)
        {

            var model = new DesarrolloDelPlanDeEstudioModel();
            var universityId = _scholarshipProgramTracing.GetUniversityId(tracingId);
            model.IsGestionUniversitariaRole = GetLogUserRole();



            model.UniversityId = universityId;
            model.subjectMatterList = _subjectMatter.GetAllByScholarshipProgramUniversityId(scholarshipProgramUniversityId).ToList();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;

            var teachers = _teacher.GetTeachersByUSerUniversityId(universityId).Select(x => new TeacherIDAndName
            {
                TeacherId = (long)x.TeacherId,
                TeacherFullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname.ToString()
            }).ToList();


            model.TeacherLis = teachers;
            ViewBag.Teacher = new SelectList(teachers, "TeacherId", "TeacherFullName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDesarrolloDelPlanDeEstudio(DesarrolloDelPlanDeEstudioModel model, int tracingId, int scholarshipProgramUniversityId, IFormFile subjectMatterScoreReportFile, IFormFile listadoDeEstudiantes)
        {
            if ((CheckIfTheProgramIsClose(model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "DesarrolloDelPlanDeEstudio", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            var SubjectMatterScoreReportFile = new core.Modelos.File();
            var StudentReportFile = new core.Modelos.File();
            var tracingStudyPlanDevelopment = new TracingStudyPlanDevelopment();
            var fileFullPath = "";
            var lista = new List<IFormFile>();

            lista.Add(subjectMatterScoreReportFile);
            lista.Add(listadoDeEstudiantes);
            
            var studentReportFilerutaPdf = _config.GetSection("rutas").GetSection("DesarrolloDelPlanDeEstudioStudentReportFile").Value;   
            
            var subjectMatterScoreReportFilerutaPdf = _config.GetSection("rutas").GetSection("DesarrolloDelPlanDeEstudioSubjectMatterScoreReportFile").Value;
           
            foreach(var file in lista)
            {
               

                if (file != null)
                {
                    string ext = Path.GetExtension(file.FileName);
                    var fileName = model.TracingStudyPlanDevelopmentModel.Id + "-" + Guid.NewGuid() + ext;
                    if (ext.ToLower() != ".pdf")
                    {

                        return RedirectToAction("DesarrolloDelPlanDeEstudio", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
                    }


                    if(file.Name == "listadoDeEstudiantes")
                    {

                         fileFullPath = Path.Combine(studentReportFilerutaPdf, fileName);

                    }
                    else
                    {
                        fileFullPath = Path.Combine(subjectMatterScoreReportFilerutaPdf, fileName);
                    }

                    using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileSteam);
                    }


                    var fileTypeId = 13;
                    if (file.Name == "subjectMatterScoreReportFile")
                    {
                        SubjectMatterScoreReportFile.FileId = model.TracingStudyPlanDevelopmentModel.SubjectMatterScoreReportFile.FileId;
                        SubjectMatterScoreReportFile.FileName = file.FileName;
                        SubjectMatterScoreReportFile.FilePath = fileName;
                        SubjectMatterScoreReportFile.FileFullPath = fileFullPath;
                        SubjectMatterScoreReportFile.FileTypeId = fileTypeId;

                        model.TracingStudyPlanDevelopmentModel.SubjectMatterScoreReportFile = SubjectMatterScoreReportFile;

                    }
                    else
                    {                       
                        StudentReportFile.FileId = model.TracingStudyPlanDevelopmentModel.StudentReportFile.FileId;
                        StudentReportFile.FileName = file.FileName;
                        StudentReportFile.FilePath = fileName;
                        StudentReportFile.FileFullPath = fileFullPath;
                        StudentReportFile.FileTypeId = fileTypeId;
                        
                        model.TracingStudyPlanDevelopmentModel.StudentReportFile = StudentReportFile;

                    }
                                                       
                }
              
            }

            try
            {

                tracingStudyPlanDevelopment = model.TracingStudyPlanDevelopmentModel;
                _tracingStudyPlanDevelopment.Save(tracingStudyPlanDevelopment);

            }
            catch (Exception e)
            {

                return RedirectToAction("DesarrolloDelPlanDeEstudio", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            return RedirectToAction("DesarrolloDelPlanDeEstudio", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }

        public IActionResult ActividadesCoCurriculares(int tracingId, int scholarshipProgramUniversityId, int courseId)
        {

            var tracings = _scholarshipProgramTracingCourse.GetAllByTracingId(tracingId);

            var model = new ActividadesCoCurricularesModel();

            model.TracingId = tracingId;           
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.CourseId = courseId;
            model.TracingCourseList = _scholarshipProgramTracingCourse.GetAvaliableTracingsById(tracingId);
            model.TracingCourseFileList = _tracingCourseFile.GetAllByCourseIdAndTracingId(tracingId,courseId);
            model.IsGestionUniversitariaRole = GetLogUserRole();

            ViewBag.DocumentTypes = new SelectList(_CourseFileType.GetAll, "Id", "FileTypeName");

            return View(model);
        }

        public IActionResult EditarActividadesCoCurriculares(int actividadId,int tracingId, int scholarshipProgramUniversityId, int courseId)
        {

            var tracings = _scholarshipProgramTracingCourse.GetAllByTracingId(tracingId);

            var data = _scholarshipProgramTracingCourse.GetById(actividadId);

            var model = new ActividadesCoCurricularesModel();


            var parseProperties = CopyPropierties.Convert<ScholarshipProgramTracingCourse, ScholarshipProgramTracingCourseModel>(data);
            model.TracingCourseModel = parseProperties;
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.CourseId = courseId;
            model.TracingCourseList = _scholarshipProgramTracingCourse.GetAvaliableTracingsById(tracingId);
            model.TracingCourseFileList = _tracingCourseFile.GetAllByCourseIdAndTracingId(tracingId, courseId);
            model.IsGestionUniversitariaRole = GetLogUserRole();

            ViewBag.DocumentTypes = new SelectList(_CourseFileType.GetAll, "Id", "FileTypeName");

            return View(model);
        }


        [HttpPost]
        public IActionResult SaveActividadesCoCurriculares(ActividadesCoCurricularesModel model, int tracingId, int scholarshipProgramUniversityId)
        {

            if ((CheckIfTheProgramIsClose(model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "DesarrolloDelPlanDeEstudio", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            var tracingCourseModel = new ScholarshipProgramTracingCourseModel();
            tracingCourseModel = model.TracingCourseModel;
            tracingCourseModel.TracingId = model.TracingId;
            var data = CopyPropierties.Convert<ScholarshipProgramTracingCourseModel, ScholarshipProgramTracingCourse>(tracingCourseModel);

            try
            {
                _scholarshipProgramTracingCourse.Save(data);
            }
            catch(Exception e)
            {
                return RedirectToAction("ActividadesCoCurriculares", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
            }

            return RedirectToAction("ActividadesCoCurriculares", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }

        [HttpPost]
        public async Task<IActionResult> SaveCourseFile(ActividadesCoCurricularesModel model, IFormFile file)
        {
            if ((CheckIfTheProgramIsClose((long)model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "DocumentoParaElSistemaDeCalidad", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

           var rutaPdf = _config.GetSection("rutas").GetSection("DocumentosActividadesCo-Curriculares").Value;
           var fileTypeId = model.TracingCourseFileModel.FileTypeId;
           var CourseId = model.CourseId;
           var tracingCourseFile = _tracingCourseFile.CheckIfTheFileExits(fileTypeId, CourseId);
            var tracingCourseFileModel = new ScholarshipProgramTracingCourseFileModel();
            tracingCourseFileModel.FileTypeId = model.TracingCourseFileModel.FileTypeId;
            tracingCourseFileModel.ScholarshipProgramTracingCourseId = model.CourseId;
            tracingCourseFileModel.TracingId = model.TracingId;


            if (tracingCourseFile != null)
            {
                tracingCourseFileModel = CopyPropierties.Convert<ScholarshipProgramTracingCourseFile, ScholarshipProgramTracingCourseFileModel>(tracingCourseFile);
                
            }

            if (file != null && model.TracingCourseFileModel.FileTypeId != null)
            {

                string ext = Path.GetExtension(file.FileName);
                var fileName = model.TracingCourseFileModel.ScholarshipProgramTracingCourseId + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                    return RedirectToAction("ActividadesCoCurriculares", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, courseId = model.CourseId });

                }
                var fileFullPath = Path.Combine(rutaPdf, fileName);

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }
            
                var fileModel = new core.Modelos.File();

                if (tracingCourseFile != null)
                {
                    fileModel.FileId = (long)tracingCourseFileModel.FileId;

                }
                fileModel.FileName = file.FileName;
                fileModel.FilePath = fileName;
                fileModel.FileFullPath = fileFullPath;
                fileModel.FileTypeId = fileTypeId;


                tracingCourseFileModel.File = fileModel;
                var data = CopyPropierties.Convert<ScholarshipProgramTracingCourseFileModel, ScholarshipProgramTracingCourseFile>(tracingCourseFileModel);

                try
                {
                    if (tracingCourseFile != null)
                    {

                        _file.Save(fileModel);
                    }

                    if (data.CourseFileId == 0)
                    {
                        _tracingCourseFile.Save(data);
                    }

                     
                }
                catch (Exception e)
                {
                    return RedirectToAction("ActividadesCoCurriculares", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, courseId = model.CourseId });

                }
            }
            else
            {
                EnviarMensaje.Enviar(TempData, "red", "El tipo de documento y el documento son requeridos");
                return RedirectToAction("ActividadesCoCurriculares", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, courseId = model.CourseId });
            }


            return RedirectToAction("ActividadesCoCurriculares", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId , courseId = model.CourseId});

        }

        public IActionResult DocumentoParaElSistemaDeCalidad(int tracingId, int scholarshipProgramUniversityId)
        {
            var model = new DocumentoParaElSistemaDeCalidadViewModel();
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.TracingId = tracingId;
            model.QualitySystemList = _qualitySystem.GetAllByTracingId(tracingId);
            model.IsGestionUniversitariaRole = GetLogUserRole();

            ViewBag.QualitySystemFileTye = new SelectList(_qualitySystemFileType.GetAll, "Id", "FileTypeName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDocumentoParaElSistemaDeCalidad(DocumentoParaElSistemaDeCalidadViewModel model, IFormFile file)
        {

            if ((CheckIfTheProgramIsClose((long)model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "DocumentoParaElSistemaDeCalidad", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }
            var rutaPdf = _config.GetSection("rutas").GetSection("DocumentosParaElSistemaDeCalidad").Value;
            var qualitySystem = _qualitySystem.GetAll.FirstOrDefault(x => x.TracingId == model.TracingId && x.FileTypeId == model.QualitySystemModel.FileTypeId);

            model.QualitySystemModel.TracingId = model.TracingId;

            if (qualitySystem != null)
            {
                model.QualitySystemModel.FileId = qualitySystem.FileId;
                model.QualitySystemModel.QualityFileId = qualitySystem.QualityFileId;
                model.QualitySystemModel.CreationDate = qualitySystem.CreationDate;
                model.QualitySystemModel.UpgradeDate = qualitySystem.UpgradeDate;
                model.QualitySystemModel.StatusId = qualitySystem.StatusId;
            }



            if (file != null && model.QualitySystemModel.FileTypeId != null)
            {

                string ext = Path.GetExtension(file.FileName);
                var fileName = model.QualitySystemModel.TracingId + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                    return RedirectToAction("DocumentoParaElSistemaDeCalidad", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }
                var fileFullPath = Path.Combine(rutaPdf, fileName);

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }

                var fileTypeId = 14;
                var fileModel = new core.Modelos.File();

                if (qualitySystem != null)
                {
                    fileModel.FileId = (long)model.QualitySystemModel.FileId;

                }
                fileModel.FileName = file.FileName;
                fileModel.FilePath = fileName;
                fileModel.FileFullPath = fileFullPath;
                fileModel.FileTypeId = fileTypeId;


                var scholarshipProgramTracingQualitySystemModel = new ScholarshipProgramTracingQualitySystemModel();
                scholarshipProgramTracingQualitySystemModel = model.QualitySystemModel;
                scholarshipProgramTracingQualitySystemModel.File = fileModel;
                var data = CopyPropierties.Convert<ScholarshipProgramTracingQualitySystemModel, ScholarshipProgramTracingQualitySystem>(scholarshipProgramTracingQualitySystemModel);

                try
                {
                    if (qualitySystem != null)
                    {

                        _file.Save(fileModel);
                    }
                    _qualitySystem.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("DocumentoParaElSistemaDeCalidad", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }
            }
            else
            {
                EnviarMensaje.Enviar(TempData, "red", "El tipo de documento y el documento son requeridos");
                return RedirectToAction("DocumentoParaElSistemaDeCalidad", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
            }



            return RedirectToAction("DocumentoParaElSistemaDeCalidad", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }

        public IActionResult ApoyoAlStudiante(int tracingId, int scholarshipProgramUniversityId)
        {



            var studentSupport = _studentSupport.GetAllByTracingId(tracingId);




            var model = new ApoyoAlEstudianteModel
            {
                IndicadoresList = GetIndicadores().IndicadoresList,
                StudentSupportList = studentSupport,
                StudentSupporModeltList = studentSupport,
                TracingId = tracingId,
                ScholarshipProgramUniversityId = scholarshipProgramUniversityId
            };
            model.IsGestionUniversitariaRole = GetLogUserRole();


            return View(model);
        }

        [HttpPost]
        public IActionResult SaveApoyoAlStudiante(ApoyoAlEstudianteModel model)
        {
            if ((CheckIfTheProgramIsClose((long)model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "ApoyoAlStudiante", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            var studentSupportModel = new ScholarshipProgramTracingStudentSupport();
            studentSupportModel = model.StudentSupporModel;
            studentSupportModel.IndicatorId = model.Indicador.IndicadorId;
            studentSupportModel.TracingId = (long)model.TracingId;


            try
            {
                _studentSupport.Save(studentSupportModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("ApoyoAlStudiante", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
            }

            return RedirectToAction("ApoyoAlStudiante", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }


    

        public IActionResult EstudiantesEnPractica(int tracingId, int scholarshipProgramUniversityId)
        {

            var model = new EstudiantesEnPracticaViewModel();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;

            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.IsGestionUniversitariaRole = GetLogUserRole();
            model.StudentPracticeList = _studentPractice.GetAllByTracingId(tracingId).OrderBy(x => x.StudentPracticeTypeId).ToList();



            ViewBag.StudentPracticeType = new SelectList(_studentPracticeType.GetAll, "StudentPracticeTypeId", "StudentPracticeTypeTypeName");
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveEstudiantesEnPractica(EstudiantesEnPracticaViewModel model)
        {
            if ((CheckIfTheProgramIsClose((long)model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "EstudiantesEnPractica", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            if(model.StudentPracticeModel.StudentPracticeTypeId  == null)
            {
                EnviarMensaje.Enviar(TempData, "red", "El tipo de Practica es requerido");


                model.StudentPracticeList = _studentPractice.GetAllByTracingId(model.TracingId).OrderBy(x => x.StudentPracticeTypeId).ToList();



                ViewBag.StudentPracticeType = new SelectList(_studentPracticeType.GetAll, "StudentPracticeTypeId", "StudentPracticeTypeTypeName");
                return View("EstudiantesEnPractica",model);
            }

            var studentPracticeModel = new ScholarshipProgramTracingStudentPracticeModel();
            var studentPracticeTypeId = Convert.ToInt32(model.StudentPracticeModel.StudentPracticeTypeId);
            var studentPractice = _studentPractice.GetOneByStudentPracticeTypeId(studentPracticeTypeId);

            studentPracticeModel = model.StudentPracticeModel;
            studentPracticeModel.TracingId = model.TracingId;

            if (studentPractice != null)
            {
                studentPracticeModel.Id = studentPractice.Id;
            }



            //En caso de que ya exixta el id del tipo de practica sera actualizado


            var data = CopyPropierties.Convert<ScholarshipProgramTracingStudentPracticeModel, ScholarshipProgramTracingStudentPractice>(studentPracticeModel);

            try
            {
                _studentPractice.Save(data);
            }
            catch (Exception e)
            {
              model.StudentPracticeList = _studentPractice.GetAllByTracingId(model.TracingId).OrderBy(x => x.StudentPracticeTypeId).ToList();
              ViewBag.StudentPracticeType = new SelectList(_studentPracticeType.GetAll, "StudentPracticeTypeId", "StudentPracticeTypeTypeName");
                return View("EstudiantesEnPractica", model);
            }

            return RedirectToAction("EstudiantesEnPractica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }


        [HttpPost]
        public  async Task<IActionResult> AgregarEstudiantePracticeFile(EstudiantesEnPracticaViewModel model , IFormFile file,int practiceId,int practiceTypeId)
        {


            if ((CheckIfTheProgramIsClose(model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "EstudiantesEnPractica", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }

            var rutaPdf = _config.GetSection("rutas").GetSection("EstudiantesEnPracticaFiles").Value;
            var studentPracticeFileModel = new ScholarshipProgramTracingStudentPracticeFileModel();
            studentPracticeFileModel = model.StudentPracticeFileModel;
            studentPracticeFileModel.StudentPracticeTypeId = practiceTypeId;
            studentPracticeFileModel.ScholarshipProgramTracingStudentPracticeId = practiceId;

            if (file != null)
            {

                string ext = Path.GetExtension(file.FileName);
                var fileName = model.StudentPracticeFileModel.ScholarshipProgramTracingStudentPracticeId + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                    return RedirectToAction("EstudiantesEnPractica", new { tracingId = model.TracingId,
                        scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId
                    });
                }
                var fileFullPath = Path.Combine(rutaPdf, fileName);

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }

                var fileModel = new Inafocam.core.Modelos.File();
                fileModel.FileName = file.FileName;
                fileModel.FilePath = fileName;
                fileModel.FileFullPath = fileFullPath;

                studentPracticeFileModel.File = fileModel;
                

                var data = CopyPropierties.Convert<ScholarshipProgramTracingStudentPracticeFileModel, ScholarshipProgramTracingStudentPracticeFile>(studentPracticeFileModel);

                try
                {
                    _studentPracticeFile.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("EstudiantesEnPractica", new { tracingId = model.TracingId,
                        scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId
                    });
                }
            }
            else
            {
                EnviarMensaje.Enviar(TempData, "red", "El archivo es requerido");

                return RedirectToAction("EstudiantesEnPractica", new {tracingId = model.TracingId,
                    scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId
                });

            }

            return RedirectToAction("EstudiantesEnPractica", new { model.TracingId,
                scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId
            });


        }

        

        [HttpPost]
        public int EliminarEstudiantePracticeFile(int studentPracticeFileId)
        {

            try
            {
                _studentPracticeFile.Delete(studentPracticeFileId);
            }
            catch(Exception e)
            {
                return 0;
            }

            return 1;
        }


        public IActionResult PlanificaciónDeLaPráctica(int tracingId, int scholarshipProgramUniversityId)
        {
            var model = new PlanificaciónDeLaPrácticaViewModel();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.PracticePlanningList = _practicePlanning.GetAllByTracingId(tracingId);
            model.IsGestionUniversitariaRole = GetLogUserRole();

            ViewBag.ActionType = new SelectList(_actionType.GetAll, "ActionTypeId", "ActionTypeName");
            return View(model);
        }

        [HttpPost]
        public IActionResult SavePlanificaciónDeLaPráctica(PlanificaciónDeLaPrácticaViewModel model)
        {

            if ((CheckIfTheProgramIsClose((long)model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "PlanificaciónDeLaPráctica", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            if(model.Started == 0 || model.Started == null && model.Finished == 1)
            {
                EnviarMensaje.Enviar(TempData, "red", "No puede seleccionar la opción finalizo si la opción comenzo no a sido seleccionada ");

                model.PracticePlanningList = _practicePlanning.GetAllByTracingId((long)model.TracingId);
                ViewBag.ActionType = new SelectList(_actionType.GetAll, "ActionTypeId", "ActionTypeName");

                return View("PlanificaciónDeLaPráctica", model);
            }

            if(model.PracticePlanningModel.ActionTypeId == null ||
                model.PracticePlanningModel.ActionTypeId == 0)
            {
                EnviarMensaje.Enviar(TempData, "red", "El tipo de planificación es requerido");


                model.PracticePlanningList = _practicePlanning.GetAllByTracingId((long)model.TracingId);
                ViewBag.ActionType = new SelectList(_actionType.GetAll, "ActionTypeId", "ActionTypeName");

                return View("PlanificaciónDeLaPráctica", model);

            }

            var practicePlanningModel = new ScholarshipProgramTracingPracticePlanningModel();
            practicePlanningModel = model.PracticePlanningModel;
            practicePlanningModel.Started = model.Started;
            practicePlanningModel.Finished = model.Finished;
            practicePlanningModel.TracingId = model.TracingId;


            var actionTypeId = Convert.ToInt32(model.PracticePlanningModel.ActionTypeId);
            var practicePlanningData = _practicePlanning.GetOneByActionType(actionTypeId);

            if (practicePlanningData != null)
            {
                model.PracticePlanningModel.Id = practicePlanningData.Id;
                model.PracticePlanningModel.CreationDate = practicePlanningData.CreationDate;
            }

            var data = CopyPropierties.Convert<ScholarshipProgramTracingPracticePlanningModel, ScholarshipProgramTracingPracticePlanning>(practicePlanningModel);

            try
            {
                _practicePlanning.Save(data);
            }
            catch (Exception e)
            {
                model.PracticePlanningList = _practicePlanning.GetAllByTracingId((long)model.TracingId);
                ViewBag.ActionType = new SelectList(_actionType.GetAll, "ActionTypeId", "ActionTypeName");

                return View("PlanificaciónDeLaPráctica",model);
            }

            return RedirectToAction("PlanificaciónDeLaPráctica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

        }

        public IActionResult SeguimientoALapráctica(int tracingId, int scholarshipProgramUniversityId)
        {
            var model = new SeguimientoALaprácticaViewModel();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.IsGestionUniversitariaRole = GetLogUserRole();
            model.PracticeList = _tracingPractice.GetAllByTracingId(tracingId);

            ViewBag.ActivityType = new SelectList(_activityType.GetAll, "ActivityTypeId", "ActivityTypeName");

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveSeguimientoALapráctica(SeguimientoALaprácticaViewModel model)
        {

            if ((CheckIfTheProgramIsClose((long)model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "SeguimientoALapráctica", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }


            if (ModelState.IsValid)
            {
                var activityTypeId = Convert.ToInt32(model.PracticeModel.ActivityTypeId);
                var getPractice = _tracingPractice.GetOneByActivityTypeId(activityTypeId);
                var practiceModel = new ScholarshipProgramTracingPracticeModel();
                practiceModel = model.PracticeModel;
                practiceModel.TracingId = model.TracingId;
                practiceModel.TracingId = model.TracingId;

                if (getPractice != null)
                {
                    practiceModel.Id = getPractice.Id;
                }


                var data = CopyPropierties.Convert<ScholarshipProgramTracingPracticeModel, ScholarshipProgramTracingPractice>(practiceModel);

                try
                {
                    _tracingPractice.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("SeguimientoALapráctica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
                }
            }
            else
            {
                var erros = ModelState.Select(x => x.Value.Errors).FirstOrDefault(x => x.Count() > 0).First();

                EnviarMensaje.Enviar(TempData, "red", erros.ErrorMessage);
                model.PracticeList = _tracingPractice.GetAllByTracingId((int)model.TracingId);
                ViewBag.ActivityType = new SelectList(_activityType.GetAll, "ActivityTypeId", "ActivityTypeName");
                return View("SeguimientoALapráctica", model);
            }
            



            return RedirectToAction("SeguimientoALapráctica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }


        /// <summary>
        ///Formalización de convenios con los centros de práctica
        /// </summary>
        public IActionResult ConveniosConLosCentrosDePráctica(int tracingId, int scholarshipProgramUniversityId)
        {


            var model = new ConveniosConLosCentrosDePrácticaViewModel();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.AgreementsWithPracticeCenterList = _agreementsWithPracticeCenter.GetAllByTracingId(tracingId);
            var ScholarshipProgramTracingAgreementsWithPracticeCenterModel = new ScholarshipProgramTracingAgreementsWithPracticeCenterModel
            {
                TracingId = tracingId
            };


            model.AgreementsWithPracticeCenterModel = ScholarshipProgramTracingAgreementsWithPracticeCenterModel;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.IsGestionUniversitariaRole = GetLogUserRole();

            return View(model);
        }

        public IActionResult EditarConveniosConLosCentrosDePráctica(int tracingId, int scholarshipProgramUniversityId,int agreementsWithPracticeCenterId)
        {

           var data =  _agreementsWithPracticeCenter.GetById(agreementsWithPracticeCenterId);


            var paresProperties = CopyPropierties.Convert<ScholarshipProgramTracingAgreementsWithPracticeCenter, ScholarshipProgramTracingAgreementsWithPracticeCenterModel>(data);

            var model = new ConveniosConLosCentrosDePrácticaViewModel();
            model.AgreementsWithPracticeCenterModel = paresProperties;
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;


            return View(model);
        }

        [HttpPost]
        public IActionResult SaveConveniosConLosCentrosDePráctica(ConveniosConLosCentrosDePrácticaViewModel model)
        {
            if ((CheckIfTheProgramIsClose((long)model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "ConveniosConLosCentrosDePráctica", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }


            var practiceModel = new ScholarshipProgramTracingAgreementsWithPracticeCenterModel();
            practiceModel.TracingId = model.TracingId;
            practiceModel = model.AgreementsWithPracticeCenterModel;

            var data = CopyPropierties.Convert<ScholarshipProgramTracingAgreementsWithPracticeCenterModel, ScholarshipProgramTracingAgreementsWithPracticeCenter>(practiceModel);

                try
                {
                    _agreementsWithPracticeCenter.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("ConveniosConLosCentrosDePráctica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }


            return RedirectToAction("ConveniosConLosCentrosDePráctica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }

        /// <summary>
        /// 5.- Formalización de convenios con instituciones afines a los programas para actividades co-curriculares
        /// </summary>

        public IActionResult InstitucionesAfinesALosProgramasParaActividades(int tracingId, int scholarshipProgramUniversityId)
        {
            var model = new InstitucionesAfinesALosProgramasParaActividadesViewModel();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.RelatedToCurricularActivitiesList = _relatedToCurricularActivities.GetAllByTracingId(tracingId);
            var ScholarshipProgramTracingAgreementsWithPracticeCenterModel = new AgreementWithInstitutionsRelatedToCurricularActivitiesModel
            {
                TracingId = tracingId
            };


            model.RelatedToCurricularActivitiesModel = ScholarshipProgramTracingAgreementsWithPracticeCenterModel;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.IsGestionUniversitariaRole = GetLogUserRole();

            return View(model);
        }

        public IActionResult EditarInstitucionesAfinesALosProgramasParaActividades(int tracingId, int scholarshipProgramUniversityId,int agreementWithInstitutionsRelatedToCurricularActivitiesId)
        {
          var data =  _relatedToCurricularActivities.GetById(agreementWithInstitutionsRelatedToCurricularActivitiesId);

            var parseProperties = CopyPropierties.Convert<AgreementWithInstitutionsRelatedToCurricularActivities, AgreementWithInstitutionsRelatedToCurricularActivitiesModel>(data);

            var model = new InstitucionesAfinesALosProgramasParaActividadesViewModel();
            model.RelatedToCurricularActivitiesModel = parseProperties;
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveInstitucionesAfinesALosProgramasParaActividades(InstitucionesAfinesALosProgramasParaActividadesViewModel model)
        {
            if ((CheckIfTheProgramIsClose((long)model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "InstitucionesAfinesALosProgramasParaActividades", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            var RelatedToCurricularActivitiesModel = new AgreementWithInstitutionsRelatedToCurricularActivitiesModel();
            RelatedToCurricularActivitiesModel.TracingId = model.TracingId;
            RelatedToCurricularActivitiesModel = model.RelatedToCurricularActivitiesModel;

            var data = CopyPropierties.Convert<AgreementWithInstitutionsRelatedToCurricularActivitiesModel, AgreementWithInstitutionsRelatedToCurricularActivities>(RelatedToCurricularActivitiesModel);

            try
            {
                _relatedToCurricularActivities.Save(data);
            }
            catch (Exception e)
            {
                return RedirectToAction("InstitucionesAfinesALosProgramasParaActividades", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            return RedirectToAction("InstitucionesAfinesALosProgramasParaActividades", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

        }

        public IActionResult ResultadosDelPeriodoAnterior(int tracingId, int scholarshipProgramUniversityId)
        {
            var model = new ResultadosDelPeriodoAnteriorViewModel();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.PreviousPeriodList = _previousPeriod.GetAllByTracingId(tracingId);
            model.IsGestionUniversitariaRole = GetLogUserRole();
            ViewBag.ComponentTypes = new SelectList(_componentFileType.GetAll, "ComponentFileTypeId", "ComponentFileTypeName");

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SaveResultadosDelPeriodoAnterior(ResultadosDelPeriodoAnteriorViewModel model, IFormFile file)
        {
            if ((CheckIfTheProgramIsClose((long)model.TracingId) == StatusValues.Cerrado))
            {

                return RedirectToAction("RedirectToActiontest", new { method = "ResultadosDelPeriodoAnterior", tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

            }

            var rutaPdf = _config.GetSection("rutas").GetSection("DocumentosResultadosDelPeriodoAnterior").Value;


            var previousPeriod = _previousPeriod.GetAll.FirstOrDefault(x =>
            x.TracingId == model.TracingId && x.ComponentFileTypeId == model.PreviousPeriodModel.ComponentFileTypeId);

            model.PreviousPeriodModel.TracingId = model.TracingId;

            if (previousPeriod != null)
            {
                model.PreviousPeriodModel.PreviousPeriodId = previousPeriod.PreviousPeriodId;
                model.PreviousPeriodModel.FileId = previousPeriod.FileId;
                model.PreviousPeriodModel.ComponentFileTypeId = previousPeriod.ComponentFileTypeId;
                model.PreviousPeriodModel.CreationDate = previousPeriod.CreationDate;
                model.PreviousPeriodModel.UpgradeDate = previousPeriod.UpgradeDate;
                model.PreviousPeriodModel.StatusId = previousPeriod.StatusId;
            }

            if (file != null && model.PreviousPeriodModel.ComponentFileTypeId != null)
            {

                string ext = Path.GetExtension(file.FileName);
                var fileName = model.PreviousPeriodModel.PreviousPeriodId + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                    return RedirectToAction("ResultadosDelPeriodoAnterior", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }
                var fileFullPath = Path.Combine(rutaPdf, fileName);

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }

                var fileTypeId = 12;
                var fileModel = new core.Modelos.File();

                if (previousPeriod != null)
                {
                    fileModel.FileId = (long)model.PreviousPeriodModel.FileId;

                }

                fileModel.FileName = file.FileName;
                fileModel.FilePath = fileName;
                fileModel.FileFullPath = fileFullPath;
                fileModel.FileTypeId = fileTypeId;

                var resultsFromThePreviousPeriodModel = new ResultsFromThePreviousPeriodModel();
                resultsFromThePreviousPeriodModel = model.PreviousPeriodModel;
                resultsFromThePreviousPeriodModel.File = fileModel;

                var data = CopyPropierties.Convert<ResultsFromThePreviousPeriodModel, ResultsFromThePreviousPeriod>(resultsFromThePreviousPeriodModel);

                try
                {
                    if (previousPeriod != null)
                    {

                        _file.Save(fileModel);
                    }

                    _previousPeriod.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("ResultadosDelPeriodoAnterior", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }
            }
            else
            {

                EnviarMensaje.Enviar(TempData, "red", "El tipo de componente y el documento son requeridos");
                model.PreviousPeriodList = _previousPeriod.GetAllByTracingId(model.TracingId);
                ViewBag.ComponentTypes = new SelectList(_componentFileType.GetAll, "ComponentFileTypeId", "ComponentFileTypeName");

                return View("ResultadosDelPeriodoAnterior",model);
            }

            return RedirectToAction("ResultadosDelPeriodoAnterior", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }

        public IActionResult RedirectToActiontest(string method, long tracingId, long? scholarshipProgramUniversityId)
        {
            EnviarMensaje.Enviar(TempData, "red", "Este programa de seguimiento se encuentra en estado cerrado contacte a el administrador");

            return RedirectToAction(method, new { tracingId = tracingId, scholarshipProgramUniversityId = scholarshipProgramUniversityId });
        }
      
        public ApoyoAlEstudianteModel GetIndicadores()
        {
            string[] indicadores =
            {
                "Mecanismos para la Identificación de necesidades de apoyo de los alumnos",
                "Estrategias de intervención para el apoyo de los alumnos puestas en marcha",
                "Niveles de satisfacción de los estudiantes con el sistema de apoyo",
                "Resultados de la gestión del sistema de apoyos al estudiante"
            };

            string[] preguntas =
            {
                "¿Cuáles utilizan?",
                "¿Cómo lo hacen? Procedimiento",
                "¿Cuándo se hace? Periodicidad",
                "¿Quién es el responsable?"
            };

            var indicadorList = new List<Indicador>();

            var count = 0;
            foreach (var item in indicadores)
            {
                count++;
                var indicador = new Indicador
                {
                    IndicadorId = count,
                    IndicadorNombre = item
                };

                indicadorList.Add(indicador);
            }

            var model = new ApoyoAlEstudianteModel
            {
                IndicadoresList = indicadorList.ToList()
            };

            return model;
        }

        public ApoyoAlEstudianteModel GetPreguntas()
        {
            string[] preguntas =
           {
                "¿Cuáles utilizan?",
                "¿Cómo lo hacen? Procedimiento",
                "¿Cuándo se hace? Periodicidad",
                "¿Quién es el responsable?"
            };

            var preguntasList = new List<Preguntas>();

            var count = 0;
            foreach (var item in preguntas)
            {
                count++;
                var pregunta = new Preguntas
                {
                    PreguntaId = count,
                    NombrePregunta = item
                };

                preguntasList.Add(pregunta);
            }

            var model = new ApoyoAlEstudianteModel
            {
                PreguntasList = preguntasList.ToList()
            };

            return model;
        }

        public bool GetLogUserRole()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario user = _userManager.FindByIdAsync(userId).Result;

            var role = user.Role == RoleName.GestionUniversitaria ? true : false;

            return role;
        }

        public long? CheckIfTheProgramIsClose(long tracingId)
        {
            var tracing = _scholarshipProgramTracing.GetById(tracingId).StatusId;

            return tracing;
        }

        public string GetUserName()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario user = _userManager.FindByIdAsync(userId).Result;

            var userName = user.Nombre.ToString() + " " + user.Apellido.ToString();
            return userName;
        }

        public string GetUserId()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario user = _userManager.FindByIdAsync(userId).Result;

           
            return user.Id;
        }

        public string GetUniversityName(int id)
        {

            var universityName = "";

          var universityId =  _scholarshipProgramUniversity.GetUniversityIdByScholarshipProgramUniversityId(id);

            if(universityId != null)
            {
                universityName = _university.GetById((int)universityId).UniversityName;
            }


            return universityName;
        }
    }
}
