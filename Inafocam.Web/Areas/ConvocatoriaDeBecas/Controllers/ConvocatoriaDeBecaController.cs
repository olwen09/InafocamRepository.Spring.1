using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inafocam.Web.Areas.ConvocatoriaDeBecas.Models;
using Microsoft.AspNetCore.Authorization;
using Inafocam.Web.Areas.ProgramacionDeSeguimiento.Models;
using Inafocam.Web.Helpers;

namespace Inafocam.Web.Areas.ConvocatoriaDeBecas.Controllers
{
   
    [Area("ConvocatoriaDeBecas"), ReturnArea("ConvocatoriaDeBecas")]
    [ReturnControllador("Convocatoria De Becas"), ReturnController("ConvocatoriaDeBeca")]
    [Authorize]
    public class ConvocatoriaDeBecaController : Controller
    {
        private readonly IScholarshipProgramUniversity _scholarshipProgramUniversity;
        private readonly IUniversity _university;
        private readonly IScholarshipLevel _scholarshipLevel;
        private readonly IScholarshipProgram _scholarshipProgram;
        private readonly IStatus _status; 
        private readonly IAgent _agent;
        private readonly ITracingStudyPlanDevelopment _tracingStudyPlanDevelopment;

        public ConvocatoriaDeBecaController(IScholarshipProgramUniversity scholarshipProgramUniversity,
            IUniversity university, IScholarshipLevel scholarshipLevel, IScholarshipProgram scholarshipProgram, IStatus status,
             IAgent agent, ITracingStudyPlanDevelopment tracingStudyPlanDevelopment)
        {
            _scholarshipProgramUniversity = scholarshipProgramUniversity;
            _university = university;
            _scholarshipLevel = scholarshipLevel;
            _scholarshipProgram = scholarshipProgram;
            _status = status;
            _agent = agent;
            _tracingStudyPlanDevelopment = tracingStudyPlanDevelopment;
           
        }

        public IActionResult Index()
        {
            var scholarshipProgramUniversity = _scholarshipProgramUniversity.ScholarshipProgramUniversity.ToList();

            return View(scholarshipProgramUniversity);
        }

        public IActionResult Editar(int id)
        {
            var scholarshipProgramUniversity = _scholarshipProgramUniversity.GetById(id);
            //scholarshipProgramUniversity.ScholarshipProgramUniversitySubjectMatter = _tracingStudyPlanDevelopment.GetAllByProgramTracingId(id).ToList();
            var scholarshipProgramUniversityModel = CopyPropierties.Convert<ScholarshipProgramUniversity, ScholarshipProgramUniversityModel>(scholarshipProgramUniversity);
           scholarshipProgramUniversityModel.TracingStudyPlanDevelopmentList = _tracingStudyPlanDevelopment.GetAllByProgramTracingId(id);
            var technicals = _agent.GetTechnicals.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });


            ViewBag.Coordinator = new SelectList(coordinators, "AgentTypeId", "FullName");
            ViewBag.Technical = new SelectList(technicals, "AgentTypeId", "FullName");
            ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");
            ViewBag.Nivel = new SelectList(_scholarshipLevel.ScholarshipsLevel, "ScholarshipLevelId", "ScholarshipLevelName");
            ViewBag.scholarshipProgram = new SelectList(_scholarshipProgram.GetAll, "ScholarshipProgramId", "ScholarshipProgramName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            return View("Crear", scholarshipProgramUniversityModel);
        }

        public IActionResult Crear(ScholarshipProgramUniversityModel model)
        {


            var technicals = _agent.GetTechnicals.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });

            ViewBag.Coordinator = new SelectList(coordinators, "AgentTypeId", "FullName");
            ViewBag.Technical = new SelectList(technicals, "AgentTypeId", "FullName");
            ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");
            ViewBag.Nivel = new SelectList(_scholarshipLevel.ScholarshipsLevel, "ScholarshipLevelId", "ScholarshipLevelName");
            ViewBag.scholarshipProgram = new SelectList(_scholarshipProgram.GetAll, "ScholarshipProgramId", "ScholarshipProgramName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");

            return View();
        }

        [HttpPost]
        public IActionResult GuardarConvocatoriaDeBeca(ScholarshipProgramUniversityModel model)
        {
            var data = CopyPropierties.Convert<ScholarshipProgramUniversityModel, ScholarshipProgramUniversity>(model);
            var scholarshipProgramUniversity = _scholarshipProgramUniversity.ScholarshipProgramUniversity.ToList();

            if (ModelState.IsValid)
            {
                try
                {
                    _scholarshipProgramUniversity.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Editar", new { id = model.ScholarshipProgramUniversityId });
                }
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors).FirstOrDefault(x => x.Count > 0).First();

                EnviarMensaje.Enviar(TempData, "red", errors.ErrorMessage);

                if(model.ScholarshipProgramUniversityId != 0)
                {
                return RedirectToAction("Editar", new { id = model.ScholarshipProgramUniversityId });

                }

                var technicals = _agent.GetTechnicals.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
                var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });

                ViewBag.Coordinator = new SelectList(coordinators, "AgentTypeId", "FullName");
                ViewBag.Technical = new SelectList(technicals, "AgentTypeId", "FullName");
                ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");
                ViewBag.Nivel = new SelectList(_scholarshipLevel.ScholarshipsLevel, "ScholarshipLevelId", "ScholarshipLevelName");
                ViewBag.scholarshipProgram = new SelectList(_scholarshipProgram.GetAll, "ScholarshipProgramId", "ScholarshipProgramName");
                ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");

                return View("Crear");
            }
           



            return View("Index",scholarshipProgramUniversity);
        }

        public IActionResult ProgramaDeBecasMateriaUniversitaria()
        {
            return View();
        }
    }
}
