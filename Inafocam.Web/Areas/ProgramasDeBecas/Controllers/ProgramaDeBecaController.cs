using System;
using System.Linq;
using Andamios.Web.Helpers;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.Web.Areas.ProgramasDeBecas.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inafocam.Web.Areas.ProgramasDeBeca.Controllers
{

    [Area("ProgramasDeBecas"), ReturnArea("ProgramasDeBecas")]
    [ReturnControllador("Programa De Becas"), ReturnController("ProgramaDeBeca")]
    [Authorize]
    public class ProgramaDeBecaController : Controller
    {
        private readonly IScholarshipProgram _scholarshipProgram;
        private readonly IScholarshipLevel _scholarshipLevel;
        private readonly IStatus _status;
        private readonly IUniversity _university;
        private readonly IScholarshipProgramUniversity _scholarshipProgramUniversity;

        public ProgramaDeBecaController(IScholarshipProgram scholarshipProgram, 
            IScholarshipLevel scholarshipLevel,
            IStatus status,
            IUniversity university,
              IScholarshipProgramUniversity scholarshipProgramUniversity)
        {
            _scholarshipProgram = scholarshipProgram;
            _scholarshipLevel = scholarshipLevel;
            _status = status;
            _university = university;
            _scholarshipProgramUniversity = scholarshipProgramUniversity;
          
        }

        [ReturnVista("Lista"), ReturnViewAtttribute("Index")]
        public IActionResult Index()
        {
            var ScholarshipProgramList = _scholarshipProgram.GetAll.ToList();
            return View(ScholarshipProgramList);
        }
        
        public IActionResult Crear(ScholarshipProgramModel model)
        {
            ViewBag.Nivel = new SelectList(_scholarshipLevel.ScholarshipsLevel, "ScholarshipLevelId", "ScholarshipLevelName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");



            return View(model);
        }

        public IActionResult Editar(int id)
        {
         var ProgramaDeBeca =   _scholarshipProgram.GetById(id);


            var scholarshipProgramModel = new ScholarshipProgramModel
            {
                ScholarshipProgramId = ProgramaDeBeca.ScholarshipProgramId,
                ScholarshipProgramName = ProgramaDeBeca.ScholarshipProgramName,
                ScholarshipLevelId = ProgramaDeBeca.ScholarshipLevelId,
                CreationDate = ProgramaDeBeca.CreationDate,
                UpgradeDate = ProgramaDeBeca.UpgradeDate,
                StatusId = ProgramaDeBeca.StatusId,
                ScholarshipLevel = ProgramaDeBeca.ScholarshipLevel,
                Status = ProgramaDeBeca.Status,
                ScholarshipProgramUniversityList = ProgramaDeBeca.ScholarshipProgramUniversity,
            };

            ViewBag.Nivel = new SelectList(_scholarshipLevel.ScholarshipsLevel, "ScholarshipLevelId", "ScholarshipLevelName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");

            return View("Crear", scholarshipProgramModel);
        }

        [HttpPost]
        public IActionResult GuardarPrograma(ScholarshipProgramModel model,string prueba)
        {

            var scholarshipProgramModel = new ScholarshipProgram
            {
                ScholarshipProgramId = model.ScholarshipProgramId,
                ScholarshipProgramName = model.ScholarshipProgramName,
                ScholarshipLevelId = model.ScholarshipLevelId,
                CreationDate = model.CreationDate,
                UpgradeDate = model.UpgradeDate,
                StatusId = model.StatusId,
                ScholarshipLevel = model.ScholarshipLevel,
                Status = model.Status,
            };




            try
            {

                _scholarshipProgram.GuardarScholarshipProgram(scholarshipProgramModel);

            }

            catch (Exception e)
            {
                ViewBag.Nivel = new SelectList(_scholarshipLevel.ScholarshipsLevel, "ScholarshipLevelId", "ScholarshipLevelName");
                ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
                ViewBag.University = new SelectList(_university.Universities, "UniversityId", "UniversityName");
                return View("Crear", model);
            }

         
            return View("Index", _scholarshipProgram.GetAll.ToList());
        }

        [HttpPost]
        public IActionResult AgregarConvocatoria(ScholarshipProgramModel model)
        {

            if (ModelState.IsValid)
            {
                var data = new ScholarshipProgramUniversity
                {

                    ScholarshipProgramId = model.ScholarshipProgramId,
                    ScatProgramCode = model.ScholarshipProgramUniversity.ScatProgramCode,
                    ContractNumber = model.ScholarshipProgramUniversity.ContractNumber,
                    UniversityId = model.ScholarshipProgramUniversity.UniversityId,
                    AnnouncementStartDate = model.ScholarshipProgramUniversity.AnnouncementStartDate,
                    AnnouncementEndDate = model.ScholarshipProgramUniversity.AnnouncementEndDate,
                    StartDate = model.ScholarshipProgramUniversity.StartDate,
                    EndDate = model.ScholarshipProgramUniversity.EndDate
                };



                try
                {
                    _scholarshipProgramUniversity.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("Editar", new { id = model.ScholarshipProgramId });
                }
            }

           

            return RedirectToAction("Editar", new { id = model.ScholarshipProgramId });
        }
    }
}
