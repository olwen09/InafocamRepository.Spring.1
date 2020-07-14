using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.ProgramacionDeSeguimiento.Models;
using Inafocam.Web.Areas.SeguimientoDeUniversidades.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public int GlobalTracingId;
        private int GlobalScholarshipProgramUniversityId;
     
        private readonly UserManager<Usuario> _userManager;

        public SeguimientoDeUniversidaController(IScholarshipProgramTracing scholarshipProgramTracing, IScholarshipProgramTracingStudentSupport studentSupport,
            IScholarshipProgramUniversity scholarshipProgramUniversity,IAgent agent,IContactCommunication contactCommunication ,
            IScholarshipProgramUniversityAgreement scholarshipProgramUniversityAgreement, IScholarshipProgramTracingAgreement scholarshipProgramTracingAgreement,
            IScholarshipProgramTracingAgreementFile scholarshipProgramTracingAgreementFile, ITracingStudyPlanDevelopment tracingStudyPlanDevelopment,ITeacher teacher 
            ,UserManager<Usuario> userManager, IScholarshipProgramTracingCourse scholarshipProgramTracingCourse,
            IScholarshipProgramTracingCourseFile tracingCourseFile, IScholarshipProgramTracingCourseFileType CourseFileType,
            IScholarshipProgramTracingQualitySystemFileType qualitySystemFileType, IScholarshipProgramTracingQualitySystem qualitySystem)
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
        }


        public IActionResult Index()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario user = _userManager.FindByIdAsync(userId).Result;

            var universityId = Convert.ToInt32(user.UniversityId);

            var availableTracings = _scholarshipProgramTracing.GetfindAvailableTracings(universityId);

            return View(availableTracings);
        }

        public IActionResult Instrucciones(int id,int programUniversityId)
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
            model.ScholarshipProgramTracingId = id;
            model.ScholarshipProgramUniversityId = programUniversityId;

            return View(model);
        }

        public IActionResult InformacionPrincipal(int tracingId)
        {
          
          var data = _scholarshipProgramTracing.GetById(tracingId);
          var model =  CopyPropierties.Convert<ScholarshipProgramTracing, InformacionPrincipalViewModel>(data);

            GlobalTracingId = tracingId;

            var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { 
                AgentTypeId = x.AgentTypeId, 
                FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname 
            });

            ViewBag.Coordinator = new SelectList(coordinators, "AgentTypeId", "FullName");
            return View(model);
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
            var prueba = GlobalTracingId;
            model.ScholarshipProgramUniversityAgreementList = _scholarshipProgramUniversityAgreement.GetAllByScholarshipProgramUniversityId(scholarshipProgramUniversityId);
            model.ScholarshipProgramTracingId = tracingId;
            model.ScholarshipProgramUniversityId= scholarshipProgramUniversityId;
            return View(model);
        }

        public IActionResult DesarrolloDelPlanDeEstudio(int tracingId,int scholarshipProgramUniversityId)
        {

            var model = new DesarrolloDelPlanDeEstudioModel();
           var prueba =  GlobalTracingId;

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
        
        public IActionResult DocumentoParaElSistemaDeCalidad(int tracingId, int scholarshipProgramUniversityId)
        {
            var model = new DocumentoParaElSistemaDeCalidadViewModel();
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.TracingId = tracingId;
            model.QualitySystemList = _qualitySystem.GetAllByTracingId(tracingId);

            ViewBag.QualitySystemFileTye = new SelectList(_qualitySystemFileType.GetAll, "Id", "FileTypeName");

            return View(model);
        }

        public IActionResult ApoyoAlStudiante(int tracingId, int scholarshipProgramUniversityId)
        {

            var studentSupport = _studentSupport.GetAllByTracingId(tracingId);




            var model = new ApoyoAlEstudianteModel
            {
                IndicadoresList = GetIndicadores().IndicadoresList,
                PreguntasList = GetPreguntas().PreguntasList,
                StudentSupportList = studentSupport,
                TracingId = tracingId,
                ScholarshipProgramUniversityId = scholarshipProgramUniversityId
                
            };
          
            return View(model);
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
