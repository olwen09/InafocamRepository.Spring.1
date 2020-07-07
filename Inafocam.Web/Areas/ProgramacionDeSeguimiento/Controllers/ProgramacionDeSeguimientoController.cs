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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inafocam.Web.Areas.ProgramacionDeSeguimiento.Controllers
{
    [Area("ProgramacionDeSeguimiento") , ReturnArea("ProgramacionDeSeguimiento")]
    [ReturnControllador("Programacion De Seguimientos"),ReturnController("ProgramacionDeSeguimiento")]
    public class ProgramacionDeSeguimientoController : Controller
    {
        private readonly IScholarshipProgramTracing _scholarshipProgramTracing;
        private readonly IUniversity _university;
        private readonly IScholarshipProgramUniversity _scholarshipProgramUniversity;
        private readonly IScholarshipProgram _scholarshipProgram;
        private readonly IAgent  _agent;
        private readonly IAgentType  _agentType;
        private readonly IStatus _status;

        public ProgramacionDeSeguimientoController(IScholarshipProgramTracing scholarshipProgramTracing,
            IUniversity university,
            IScholarshipProgramUniversity scholarshipProgramUniversity,
            IAgent agent,
            IScholarshipProgram scholarshipProgram,
            IAgentType agentType
            , IStatus status)
        {
            _scholarshipProgramTracing = scholarshipProgramTracing;
            _university = university;
            _scholarshipProgramUniversity = scholarshipProgramUniversity;
            _agent = agent;
            _scholarshipProgram = scholarshipProgram;
            _agentType = agentType;
            _status = status;
        }
    

        public IActionResult Index()
        {
            var scholarshipProgramTracing = _scholarshipProgramTracing.ScholarshipProgramTracing;



            return View(scholarshipProgramTracing);
        }
        
        public IActionResult Crear()
        {

            var technicals = _agent.GetTechnicals.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var scholarshipProgram = _scholarshipProgramUniversity.ScholarshipProgramUniversity
               .Select(x => new GetScholarShipProgram { ScholarshipProgramUniversityId = x.ScholarshipProgramUniversityId, ScholarShipProgramName = x.ScholarshipProgram.ScholarshipProgramName });


       
            ViewBag.ScholarshipProgram = new SelectList(scholarshipProgram, "ScholarshipProgramUniversityId", "ScholarShipProgramName");
            ViewBag.Coordinator = new SelectList(coordinators, "AgentTypeId","FullName");
            ViewBag.Technical = new SelectList(technicals, "AgentTypeId", "FullName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");

            return View();
        }

        public IActionResult Editar(int id)
        {
            var scholarshipProgramTracing = _scholarshipProgramTracing.GetById(id);

           

            var scholarshipProgramTracingModel = CopyPropierties.Convert<ScholarshipProgramTracing, ScholarshipProgramTracingModel>(scholarshipProgramTracing);
            var technicals = _agent.GetTechnicals.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var coordinators = _agent.GetCoordinators.Select(x => new GetAgents { AgentTypeId = x.AgentTypeId, FullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname });
            var scholarshipProgram = _scholarshipProgramUniversity.ScholarshipProgramUniversity
               .Select(x => new GetScholarShipProgram { ScholarshipProgramUniversityId = x.ScholarshipProgramUniversityId, ScholarShipProgramName = x.ScholarshipProgram.ScholarshipProgramName });



            ViewBag.ScholarshipProgram = new SelectList(scholarshipProgram, "ScholarshipProgramUniversityId", "ScholarShipProgramName");
            ViewBag.Coordinator = new SelectList(coordinators, "AgentTypeId", "FullName");
            ViewBag.Technical = new SelectList(technicals, "AgentTypeId", "FullName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");

            return View("Crear", scholarshipProgramTracingModel);
        }

        public IActionResult GuardarScholarshipProgramTracing(ScholarshipProgramTracingModel model)
        {
            var data = CopyPropierties.Convert< ScholarshipProgramTracingModel, ScholarshipProgramTracing>(model);
            var scholarshipProgramTracing = _scholarshipProgramTracing.ScholarshipProgramTracing;

            try
            {
                _scholarshipProgramTracing.Save(data);
            }
            catch(Exception e)
            {
                return RedirectToAction("Editar", new { id = model.ScholarshipProgramTracingId });
            }

            



            return View("Index",scholarshipProgramTracing);
        }
    }
}
