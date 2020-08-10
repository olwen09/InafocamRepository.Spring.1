using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Humanizer;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.ProgramacionDeSeguimiento.Models;
using Inafocam.Web.Helpers;
using Inafocam.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inafocam.Web.Areas.ProgramacionDeSeguimiento.Controllers
{
    [Area("ProgramacionDeSeguimiento") , ReturnArea("ProgramacionDeSeguimiento")]
    [ReturnControllador("Programación De Seguimientos"),ReturnController("ProgramacionDeSeguimiento")]
    [Authorize(Roles = RoleName.AdministradorInafocam)]

    public class ProgramacionDeSeguimientoController : Controller
    {
        private readonly IScholarshipProgramTracing _scholarshipProgramTracing;
        private readonly IUniversity _university;
        private readonly IScholarshipProgramUniversity _scholarshipProgramUniversity;
        private readonly IScholarshipProgram _scholarshipProgram;
        private readonly IAgent  _agent;
        private readonly IAgentType  _agentType;
        private readonly IStatus _status;
        private readonly ISubjectMatter _subjectMatter;
        private readonly ITracingStudyPlanDevelopment _tracingStudyPlanDevelopment;
        private readonly ITeacher _teacher;
        private readonly IScholarshipProgramUniversitySubjectMatter _scholarshipProgramUniversitySubjectMatter;

        public ProgramacionDeSeguimientoController(IScholarshipProgramTracing scholarshipProgramTracing,
            IUniversity university,ITracingStudyPlanDevelopment tracingStudyPlanDevelopment,
            IScholarshipProgramUniversity scholarshipProgramUniversity,IAgent agent, IScholarshipProgram scholarshipProgram,
            IAgentType agentType, IStatus status,ISubjectMatter subjectMatter,ITeacher teacher,
            IScholarshipProgramUniversitySubjectMatter scholarshipProgramUniversitySubjectMatter)
        {
            _scholarshipProgramTracing = scholarshipProgramTracing;
            _university = university;
            _scholarshipProgramUniversity = scholarshipProgramUniversity;
            _agent = agent;
            _scholarshipProgram = scholarshipProgram;
            _agentType = agentType;
            _status = status;
            _subjectMatter = subjectMatter;
            _teacher = teacher;
            _tracingStudyPlanDevelopment = tracingStudyPlanDevelopment;
            _scholarshipProgramUniversitySubjectMatter = scholarshipProgramUniversitySubjectMatter;
        }
    

        public IActionResult Index()
        {
            var scholarshipProgramTracing = _scholarshipProgramTracing.ScholarshipProgramTracing;
            var now = DateTime.Today;
            //var prueba = now.ToShortDateString();
            var secondDate = new DateTime(2019,05,27);
            var firstDate = DateTime.Today;
            var prueba = secondDate - firstDate;
            //System.TimeSpan diff = secondDate.Subtract(firstDate);

            return View(scholarshipProgramTracing);
        }
        
        public IActionResult Crear()
        {
            var model = new ScholarshipProgramTracingModel();

            var technicals = _agent.GetTechnicals.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var scholarshipProgram = _scholarshipProgramUniversity.ScholarshipProgramUniversity
               .Select(x => new GetScholarShipProgram
               {
                   ScholarshipProgramUniversityId = x.ScholarshipProgramUniversityId,
                   ScholarShipProgramNameScatCodeContractNumber = x.ScholarshipProgram.ScholarshipProgramName.ToString() + " " + x.ScatProgramCode.ToString()
                   + ", " + x.ContractNumber.ToString()
               });


       
            ViewBag.ScholarshipProgram = new SelectList(scholarshipProgram, "ScholarshipProgramUniversityId", "ScholarShipProgramNameScatCodeContractNumber");
            ViewBag.Coordinator = new SelectList(coordinators, "AgentTypeId","FullName");
            ViewBag.Technical = new SelectList(technicals, "AgentTypeId", "FullName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");

            return View(model);
        }

        public IActionResult Editar(int id)
        {
            var scholarshipProgramTracing = _scholarshipProgramTracing.GetById(id);

           

            var scholarshipProgramTracingModel = CopyPropierties.Convert<ScholarshipProgramTracing, ScholarshipProgramTracingModel>(scholarshipProgramTracing);
            var technicals = _agent.GetTechnicals.Select(x => new GetAgents { AgentId = x.AgentId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { AgentId = x.AgentId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var scholarshipProgram = _scholarshipProgramUniversity.ScholarshipProgramUniversity
                .Select(x => new GetScholarShipProgram
                {
                    ScholarshipProgramUniversityId = x.ScholarshipProgramUniversityId,
                    ScholarShipProgramNameScatCodeContractNumber = x.ScholarshipProgram.ScholarshipProgramName.ToString() + ", " + x.ScatProgramCode.ToString()
                   + ", " + x.ContractNumber.ToString()
                });

            scholarshipProgramTracingModel.SelectedProgram = scholarshipProgramTracingModel.ScholarshipProgramUniversity.ScholarshipProgram.ScholarshipProgramName.ToString() + ", " +
                scholarshipProgramTracingModel.ScholarshipProgramUniversity.ScatProgramCode.ToString() + ", " +
                scholarshipProgramTracingModel.ScholarshipProgramUniversity.ContractNumber.ToString();


            ViewBag.ScholarshipProgram = new SelectList(scholarshipProgram, "ScholarshipProgramUniversityId", "ScholarShipProgramNameScatCodeContractNumber");
            ViewBag.Coordinator = new SelectList(coordinators, "AgentId", "FullName");
            ViewBag.Technical = new SelectList(technicals, "AgentId", "FullName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");

            return View("Crear", scholarshipProgramTracingModel);
        }

        public IActionResult GuardarScholarshipProgramTracing(ScholarshipProgramTracingModel model)
        {
            var data = CopyPropierties.Convert< ScholarshipProgramTracingModel, ScholarshipProgramTracing>(model);
            var scholarshipProgramTracing = _scholarshipProgramTracing.ScholarshipProgramTracing;


            if (ModelState.IsValid)
            {
                try
                {
                    _scholarshipProgramTracing.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Editar", new { id = model.ScholarshipProgramTracingId });
                }

                return View("Index", scholarshipProgramTracing);
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors).FirstOrDefault(x => x.Count > 0).First();



                EnviarMensaje.Enviar(TempData, "red", errors.ErrorMessage);



                if(model.ScholarshipProgramTracingId != null)
                {
                    return RedirectToAction("Editar", new { id = model.ScholarshipProgramTracingId });
                }

                var technicals = _agent.GetTechnicals.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
                var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
                var scholarshipProgram = _scholarshipProgramUniversity.ScholarshipProgramUniversity
                   .Select(x => new GetScholarShipProgram
                   {
                       ScholarshipProgramUniversityId = x.ScholarshipProgramUniversityId,
                       ScholarShipProgramNameScatCodeContractNumber = x.ScholarshipProgram.ScholarshipProgramName + " " + x.ScatProgramCode
                   + ", " + x.ContractNumber
                   });



                ViewBag.ScholarshipProgram = new SelectList(scholarshipProgram, "ScholarshipProgramUniversityId", "ScholarShipProgramName");
                ViewBag.Coordinator = new SelectList(coordinators, "AgentTypeId", "FullName");
                ViewBag.Technical = new SelectList(technicals, "AgentTypeId", "FullName");
                ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
                ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");

                return View("Crear");

            }





            return View("Index",scholarshipProgramTracing);
        }


        [AllowAnonymous]
        public IActionResult GetScholarshipProgramUniversity(int id, object ScholarshipProgramUniversitySeleccionado = null)
        {
            //List<Municipio> municipios = new List<Municipio>();
            //// ------------- Obteniendo la data de la base de datos ---------------------//
            //municipios = _provincia.GetMunicipiosByProvincias(id).ToList();
            //municipios.Insert(0, new Municipio{MunicipioId = 0, ProvinciaId = 0, MunicipioNombre = "Selección"});

            return ViewComponent("GetScholarshipProgramUniversityComponent", new { id = id });

            //return Json(new SelectList(municipios, "MunicipioId", "MunicipioNombre", municipioSeleccionado));

        }

        //public IActionResult ProgramaDeBecasMateriaUniversitaria(int scholarshipProgramUniversityId,int tracingId,int universityId)
        //{
        //    var model = new ProgramaDeBecasMateriaUniversitariaViewModel();
        //    var subjectMatterList = _subjectMatter.GetAllByUniversityId(universityId).Select(x => new SubjectMatterProp {
        //        SubjectMatterId = x.SubjectMatterId, SubjectMatterCode = x.SubjectMatterCode.ToString() + ", " + x.SubjectMatterName.ToString() 
        //    });
        //    var teachers = _teacher.GetAll.Select(x => new TeacherInfo
        //    {
        //        TeacherId = (long)x.TeacherId,
        //        TeacherFullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname.ToString()
        //    });

        //    model.TracingStudyPlanDevelopmentList = _tracingStudyPlanDevelopment.GetAllByProgramTracingId(tracingId);
        //    model.TracingId = tracingId;
        //    model.ProgramUniversityId = scholarshipProgramUniversityId;

        //    ViewBag.Teachers = new SelectList(teachers, "TeacherId", "TeacherFullName");
        //    ViewBag.SubjectMatter = new SelectList(subjectMatterList, "SubjectMatterId", "SubjectMatterCode");
        //    return View(model);
        //}

        //public IActionResult SaveProgramaDeBecasMateriaUniversitaria(ProgramaDeBecasMateriaUniversitariaViewModel model)
        //{
        //    var tracingStudyPlanDevelopment = new TracingStudyPlanDevelopmentModel();
        //    tracingStudyPlanDevelopment.SubjectMatterId = model.TracingStudyPlanDevelopmentModel.SubjectMatterId;
        //    tracingStudyPlanDevelopment.ScholarshipProgramTracingId = model.TracingId;
        //    tracingStudyPlanDevelopment.TeacherId = model.TracingStudyPlanDevelopmentModel.TeacherId;
        //    tracingStudyPlanDevelopment.Creditos = model.TracingStudyPlanDevelopmentModel.Creditos;

        //    var data = CopyPropierties.Convert<TracingStudyPlanDevelopmentModel, TracingStudyPlanDevelopment>(tracingStudyPlanDevelopment);

        //    var scholarshipProgramUniversitySubjectMatter = new ScholarshipProgramUniversitySubjectMatter();
        //    scholarshipProgramUniversitySubjectMatter.ScholarshipProgramUniversityId = model.ProgramUniversityId;
        //    scholarshipProgramUniversitySubjectMatter.SubjectMatterId = model.TracingStudyPlanDevelopmentModel.SubjectMatterId;
        //    scholarshipProgramUniversitySubjectMatter.TeacherId = model.TracingStudyPlanDevelopmentModel.TeacherId;
        //    scholarshipProgramUniversitySubjectMatter.SubjectMatterCredits = model.SubjectMatterCredits;


        //    try
        //    {
        //        _tracingStudyPlanDevelopment.Save(data);
        //        _scholarshipProgramUniversitySubjectMatter.Save(scholarshipProgramUniversitySubjectMatter);
        //    }
        //    catch(Exception e)
        //    {
        //        return RedirectToAction("ProgramaDeBecasMateriaUniversitaria", new { scholarshipProgramUniversityId = model.ProgramUniversityId, tracingId = model.TracingId });
        //    }

        //    return RedirectToAction("ProgramaDeBecasMateriaUniversitaria", new { scholarshipProgramUniversityId = model.ProgramUniversityId, tracingId = model.TracingId });

        //}


    }
}
