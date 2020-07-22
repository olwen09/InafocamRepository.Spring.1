using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.ProgramacionDeSeguimiento.Models;
using Inafocam.Web.Areas.SeguimientoDeUniversidades.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Controllers
{

    [Area("SeguimientoDeUniversidades"),ReturnArea("SeguimientoDeUniversidades")]
    [ReturnControllador("Seguimiento De Universidades"),ReturnController("SeguimientoDeUniversida")]
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


        private readonly UserManager<Usuario> _userManager;

        public SeguimientoDeUniversidaController(IScholarshipProgramTracing scholarshipProgramTracing, IScholarshipProgramTracingStudentSupport studentSupport,
            IScholarshipProgramUniversity scholarshipProgramUniversity,IAgent agent,IContactCommunication contactCommunication ,
            IScholarshipProgramUniversityAgreement scholarshipProgramUniversityAgreement, IScholarshipProgramTracingAgreement scholarshipProgramTracingAgreement,
            IScholarshipProgramTracingAgreementFile scholarshipProgramTracingAgreementFile, ITracingStudyPlanDevelopment tracingStudyPlanDevelopment,ITeacher teacher 
            ,UserManager<Usuario> userManager, IScholarshipProgramTracingCourse scholarshipProgramTracingCourse,
            IScholarshipProgramTracingCourseFile tracingCourseFile, IScholarshipProgramTracingCourseFileType CourseFileType,
            IScholarshipProgramTracingQualitySystemFileType qualitySystemFileType, IScholarshipProgramTracingQualitySystem qualitySystem,
            IConfiguration config,IFile file, IComponentFileType componentFileType, IStudentPracticeType studentPracticeType,
            IScholarshipProgramTracingStudentPractice studentPractice, IScholarshipProgramTracingPracticePlanning practicePlanning,
            IActionType actionType, IActivityType activityType,IScholarshipProgramTracingPractice  tracingPractice,
            IResultsFromThePreviousPeriod previousPeriod, IScholarshipProgramTracingAgreementsWithPracticeCenter agreementsWithPracticeCenter,
            IAgreementWithInstitutionsRelatedToCurricularActivities relatedToCurricularActivities)
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
        }


        public IActionResult Index()
        {

            var prueba = _previousPeriod.GetAll.ToList();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario user = _userManager.FindByIdAsync(userId).Result;

            var universityId = Convert.ToInt32(user.UniversityId);

           
            //university availableTracings
            if (user.Role == "GESTIÓN UNIVERSITARIA")
            {
                var availableTracings = _scholarshipProgramTracing.GetfindAvailableTracings(universityId);
                return View(availableTracings);
            }
            else if(user.Role == "ADMINISTRADOR INAFOCAM")
            {
                var tracings = _scholarshipProgramTracing.ScholarshipProgramTracing;
                return View(tracings);
            }

            return View();
            
        }

        public IActionResult Instrucciones(int tracingId,int programUniversityId)
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
          var model =  CopyPropierties.Convert<ScholarshipProgramTracing, InformacionPrincipalViewModel>(data);

        

            var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { 
                AgentId = x.AgentId, 
                FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname 
            });

            ViewBag.Coordinator = new SelectList(coordinators, "AgentId", "FullName");
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveInformacionPrincipal(InformacionPrincipalViewModel model)
        {
            var data = CopyPropierties.Convert<InformacionPrincipalViewModel,ScholarshipProgramTracing>(model);

            try
            {
                _scholarshipProgramTracing.Save(data);

            }catch(Exception e)
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
   
            model.ScholarshipProgramUniversityAgreementList = _scholarshipProgramUniversityAgreement.GetAllByScholarshipProgramUniversityId(scholarshipProgramUniversityId);
            model.ScholarshipProgramTracingId = tracingId;
            model.ScholarshipProgramUniversityId= scholarshipProgramUniversityId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAcuerdos(AcuerdosViewModel model, int agremmentId, int universityAgreementId, int tracingId, IFormFile file)
        {

            //Pasando las los valores de los parametros al modelo ScholarshipProgramTracingAgreementModel
            model.ScholarshipProgramTracingAgreementModel.ScholarshipProgramUniversityAgreementId = universityAgreementId;
            model.ScholarshipProgramTracingAgreementModel.ScholarshipProgramTracingAgreementId = universityAgreementId;
            model.ScholarshipProgramTracingAgreementModel.ScholarshipProgramTracingId = tracingId;


            var rutaPdf = _config.GetSection("rutas").GetSection("AcuerdosFiles").Value;
            var scholarshipProgramTracingAgreementModel = new ScholarshipProgramTracingAgreementModel();
            scholarshipProgramTracingAgreementModel = model.ScholarshipProgramTracingAgreementModel;
            var tracingAgreementData = CopyPropierties.Convert<ScholarshipProgramTracingAgreementModel, ScholarshipProgramTracingAgreement>(scholarshipProgramTracingAgreementModel);

           


            //var file = model.FormFile;

            if (file != null)
            {
                string ext = Path.GetExtension(file.FileName);
                var fileName = model.ScholarshipProgramTracingAgreementModel.ScholarshipProgramTracingAgreementId + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                    return RedirectToAction("Acuerdos", new { scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, tracingId = model.ScholarshipProgramTracingId });

                }

                var fileFullPath = Path.Combine(rutaPdf, fileName);
                //var filePath = "\\app-assets\\documentos\\teacher" + fileName; 

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }

                var fileTypeId = 14;
                var fileModel = new core.Modelos.File {
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
                    _scholarshipProgramTracingAgreement.Save(tracingAgreementData);
                    _scholarshipProgramTracingAgreementFile.Save(tracingAgreementFileData);
                }
                catch(Exception e)
                {
                    return RedirectToAction("Acuerdos", new { scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, tracingId = model.ScholarshipProgramTracingId });

                }
            }
                return RedirectToAction("Acuerdos", new { scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId, tracingId = model.ScholarshipProgramTracingId });
        }
        
       public IActionResult DesarrolloDelPlanDeEstudio(int tracingId,int scholarshipProgramUniversityId)
        {

            var model = new DesarrolloDelPlanDeEstudioModel();
         

            model.TracingStudyPlanDevelopmentList = _tracingStudyPlanDevelopment.GetAllByProgramTracingId(tracingId);
            model.TracingStudyPlanDevelopmentModelList = _tracingStudyPlanDevelopment.GetAllByProgramTracingId(tracingId); ;
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
           

            var teachers = _teacher.GetAll.Select(x => new TeacherIDAndName
            {
                TeacherId = x.TeacherId,
                TeacherFullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname.ToString()
            }).ToList();

            ViewBag.Teacher = new SelectList(teachers, "TeacherId", "TeacherFullName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDesarrolloDelPlanDeEstudio(DesarrolloDelPlanDeEstudioModel model, int tracingId, int scholarshipProgramUniversityId, IFormFile file)
        {
            var rutaPdf = _config.GetSection("rutas").GetSection("DesarrolloDelPlanDeEstudioFiles").Value;
            if (file != null)
            {
                string ext = Path.GetExtension(file.FileName);
                var fileName = model.TracingStudyPlanDevelopmentModel.Id + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                  
                    return RedirectToAction("DesarrolloDelPlanDeEstudio", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
                }

                var fileFullPath = Path.Combine(rutaPdf, fileName);
                //var filePath = "\\app-assets\\documentos\\teacher" + fileName; 

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }

                var fileTypeId = 13;
                var fileModel = new core.Modelos.File
                {
                    FileName = file.FileName,
                    FilePath = fileName,
                    FileFullPath = fileFullPath,
                    FileTypeId = fileTypeId
                };
                var tracingStudyPlanDevelopment = new TracingStudyPlanDevelopment();
                tracingStudyPlanDevelopment = model.TracingStudyPlanDevelopmentModel;
                tracingStudyPlanDevelopment.SubjectMatterScoreReportFile = fileModel;
                
                

                try
                {

              
                _tracingStudyPlanDevelopment.Save(tracingStudyPlanDevelopment);

                }catch(Exception e)
                {

                    return RedirectToAction("DesarrolloDelPlanDeEstudio", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }
            }

          
              
           

            return RedirectToAction("DesarrolloDelPlanDeEstudio", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }

        public IActionResult ActividadesCoCurriculares(int tracingId, int scholarshipProgramUniversityId)
        {

         var tracings = _scholarshipProgramTracingCourse.GetAllByTracingId(tracingId);

            var model = new ActividadesCoCurricularesModel();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.TracingCourseList = _scholarshipProgramTracingCourse.GetAvaliableTracingsById(tracingId);
            model.TracingCourseFileList = _tracingCourseFile.GetAllByTracingId(tracingId);


            ViewBag.DocumentTypes = new SelectList(_CourseFileType.GetAll, "Id", "FileTypeName");
            
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveActividadesCoCurriculares(ActividadesCoCurricularesModel model,int tracingId, int scholarshipProgramUniversityId)
        {
            return RedirectToAction("ActividadesCoCurriculares", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }



        public IActionResult DocumentoParaElSistemaDeCalidad(int tracingId, int scholarshipProgramUniversityId)
        {
            var model = new DocumentoParaElSistemaDeCalidadViewModel();
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.TracingId = tracingId;
            model.QualitySystemList = _qualitySystem.GetAllByTracingId(tracingId);

            ViewBag.QualitySystemFileTye = new SelectList(_qualitySystemFileType.GetAll, "Id", "FileTypeName");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDocumentoParaElSistemaDeCalidad(DocumentoParaElSistemaDeCalidadViewModel model,IFormFile file)
        {

            var rutaPdf = _config.GetSection("rutas").GetSection("DocumentosParaElSistemaDeCalidad").Value;
            var qualitySystem =   _qualitySystem.GetAll.FirstOrDefault(x => x.TracingId == model.TracingId && x.FileTypeId == model.QualitySystemModel.FileTypeId);
            
                model.QualitySystemModel.TracingId = model.TracingId;

            if (qualitySystem != null)
            {
                model.QualitySystemModel.FileId = qualitySystem.FileId;
                model.QualitySystemModel.QualityFileId = qualitySystem.QualityFileId;
                model.QualitySystemModel.CreationDate = qualitySystem.CreationDate;
                model.QualitySystemModel.UpgradeDate = qualitySystem.UpgradeDate;
                model.QualitySystemModel.StatusId = qualitySystem.StatusId;
            }
            
           

            if (file != null)
            {
                //upload files to wwwroot
                //var fileName = Path.GetFileName(file.FileName);         

                //judge if it is pdf file
                string ext = Path.GetExtension(file.FileName);
                var fileName = model.QualitySystemModel.TracingId + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                    return RedirectToAction("DocumentoParaElSistemaDeCalidad", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }
                var fileFullPath = Path.Combine(rutaPdf, fileName);
                //var filePath = "\\app-assets\\documentos\\teacher" + fileName; 

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }
                //your logic to save filePath to database, for example



                var fileTypeId = 14;
                var fileModel = new core.Modelos.File();

                if(qualitySystem != null)
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
                    if(qualitySystem != null)
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



            return RedirectToAction("DocumentoParaElSistemaDeCalidad", new { tracingId =model.TracingId, scholarshipProgramUniversityId =model.ScholarshipProgramUniversityId});
        }

        public IActionResult ApoyoAlStudiante(int tracingId, int scholarshipProgramUniversityId)
        {

            var studentSupport = _studentSupport.GetAllByTracingId(tracingId);




            var model = new ApoyoAlEstudianteModel
            {
                IndicadoresList = GetIndicadores().IndicadoresList,
                PreguntasList = GetPreguntas().PreguntasList,
                StudentSupportList = studentSupport.ToList(),
                TracingId = tracingId,
                ScholarshipProgramUniversityId = scholarshipProgramUniversityId
                
            };
          
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveApoyoAlStudiante(ApoyoAlEstudianteModel model)
        {
            return View();
        }


        public IActionResult EstudiantesEnPractica(int tracingId, int scholarshipProgramUniversityId)
        {

            var model = new EstudiantesEnPracticaViewModel();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.StudentPracticeList = _studentPractice.GetAllByTracingId(tracingId).OrderBy(x=> x.StudentPracticeTypeId);




            ViewBag.StudentPracticeType = new SelectList(_studentPracticeType.GetAll, "StudentPracticeTypeId", "StudentPracticeTypeTypeName");
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveEstudiantesEnPractica(EstudiantesEnPracticaViewModel model)
        {

            var studentPracticeModel = new ScholarshipProgramTracingStudentPracticeModel();
            var studentPracticeTypeId = Convert.ToInt32(model.StudentPracticeModel.StudentPracticeTypeId);
            var studentPractice = _studentPractice.GetOneByStudentPracticeTypeId(studentPracticeTypeId);

            studentPracticeModel = model.StudentPracticeModel;
            studentPracticeModel.TracingId = model.TracingId;

            if(studentPractice != null)
            {
                studentPracticeModel.Id = studentPractice.Id;
            }

            

            //En caso de que ya exixta el id del tipo de practica sera actualizado
           

            var data = CopyPropierties.Convert<ScholarshipProgramTracingStudentPracticeModel,ScholarshipProgramTracingStudentPractice>(studentPracticeModel);

            try
            {
                _studentPractice.Save(data);
            }
            catch (Exception e)
            {
                return RedirectToAction("EstudiantesEnPractica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
            }

            return RedirectToAction("EstudiantesEnPractica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }


        public IActionResult PlanificaciónDeLaPráctica(int tracingId, int scholarshipProgramUniversityId)
        {
            var model = new PlanificaciónDeLaPrácticaViewModel();
            model.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.PracticePlanningList = _practicePlanning.GetAllByTracingId(tracingId);

            ViewBag.ActionType = new SelectList(_actionType.GetAll, "ActionTypeId", "ActionTypeName");
            return View(model);
        }

        [HttpPost]
        public IActionResult SavePlanificaciónDeLaPráctica(PlanificaciónDeLaPrácticaViewModel model)
        {
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
                return RedirectToAction("PlanificaciónDeLaPráctica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
            }

            return RedirectToAction("PlanificaciónDeLaPráctica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

        }

        public IActionResult SeguimientoALapráctica(int tracingId, int scholarshipProgramUniversityId)
        {
            var model = new SeguimientoALaprácticaViewModel();
            model.TracingId = tracingId;
            //model.PracticeModel.TracingId = tracingId;
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.PracticeList = _tracingPractice.GetAllByTracingId(tracingId);

            ViewBag.ActivityType = new SelectList(_activityType.GetAll, "ActivityTypeId", "ActivityTypeName");

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveSeguimientoALapráctica(SeguimientoALaprácticaViewModel model)
        {

            var activityTypeId = Convert.ToInt32(model.PracticeModel.ActivityTypeId);
            var getPractice = _tracingPractice.GetOneByActivityTypeId(activityTypeId);
            var practiceModel = new ScholarshipProgramTracingPracticeModel();
            practiceModel = model.PracticeModel;
            practiceModel.TracingId = model.TracingId;
            practiceModel.TracingId = model.TracingId;

            if(getPractice != null)
            {
                practiceModel.Id = getPractice.Id;
            }


            var data = CopyPropierties.Convert<ScholarshipProgramTracingPracticeModel, ScholarshipProgramTracingPractice>(practiceModel);

            try
            {
                _tracingPractice.Save(data);
            }
            catch(Exception e)
            {
                return RedirectToAction("SeguimientoALapráctica", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
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


            return View(model);
        }

        public IActionResult SaveConveniosConLosCentrosDePráctica(ConveniosConLosCentrosDePrácticaViewModel model)
        {

            var practiceModel = new ScholarshipProgramTracingAgreementsWithPracticeCenterModel();
            practiceModel.TracingId = model.TracingId;
            practiceModel = model.AgreementsWithPracticeCenterModel;

            var data = CopyPropierties.Convert<ScholarshipProgramTracingAgreementsWithPracticeCenterModel, ScholarshipProgramTracingAgreementsWithPracticeCenter>(practiceModel);

            try
            {
                _agreementsWithPracticeCenter.Save(data);
            }
            catch(Exception e)
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


            return View(model);
        }



        [HttpPost]
        public IActionResult SaveInstitucionesAfinesALosProgramasParaActividades(InstitucionesAfinesALosProgramasParaActividadesViewModel model)
        {
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
            ViewBag.ComponentTypes = new SelectList(_componentFileType.GetAll, "ComponentFileTypeId", "ComponentFileTypeName");

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SaveResultadosDelPeriodoAnterior(ResultadosDelPeriodoAnteriorViewModel  model,IFormFile file)
        {
            var rutaPdf = _config.GetSection("rutas").GetSection("DocumentosResultadosDelPeriodoAnterior").Value;


            var previousPeriod = _previousPeriod.GetAll.FirstOrDefault(x =>
            x.TracingId == model.TracingId && x.ComponentFileTypeId == model.PreviousPeriodModel.ComponentFileTypeId);

            model.PreviousPeriodModel.TracingId = model.TracingId;

            if(previousPeriod != null)
            {
                model.PreviousPeriodModel.PreviousPeriodId = previousPeriod.PreviousPeriodId;
                model.PreviousPeriodModel.FileId = previousPeriod.FileId;
                model.PreviousPeriodModel.ComponentFileTypeId = previousPeriod.ComponentFileTypeId;
                model.PreviousPeriodModel.CreationDate = previousPeriod.CreationDate;
                model.PreviousPeriodModel.UpgradeDate = previousPeriod.UpgradeDate;
                model.PreviousPeriodModel.StatusId = previousPeriod.StatusId;
            }

            if (file != null)
            {
                //upload files to wwwroot
                //var fileName = Path.GetFileName(file.FileName);         

                //judge if it is pdf file
                string ext = Path.GetExtension(file.FileName);
                var fileName = model.PreviousPeriodModel.PreviousPeriodId + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                    return RedirectToAction("ResultadosDelPeriodoAnterior", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }
                var fileFullPath = Path.Combine(rutaPdf, fileName);
                //var filePath = "\\app-assets\\documentos\\teacher" + fileName; 

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }
                //your logic to save filePath to database, for example



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
                catch(Exception e)
                {
                    return RedirectToAction("ResultadosDelPeriodoAnterior", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }
            }


            return RedirectToAction("ResultadosDelPeriodoAnterior", new { tracingId = model.TracingId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

        }
        //public IActionResult SeguimientoALaPráctica(int tracingId, int scholarshipProgramUniversityId)
        //{
        //    return View();
        //}
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

            var model= new ApoyoAlEstudianteModel
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
    }
}
