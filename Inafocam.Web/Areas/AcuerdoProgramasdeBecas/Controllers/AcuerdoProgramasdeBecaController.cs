using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.AcuerdoProgramasdeBecas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inafocam.Web.Areas.AcuerdoProgramasdeBecas.Controllers
{
    [Area("AcuerdoProgramasdeBecas"),ReturnArea("AcuerdoProgramasdeBecas")]
    [ReturnControllador("Acuerdo Programas de Becas"),ReturnController("AcuerdoProgramasdeBeca")]
    [Authorize]
    public class AcuerdoProgramasdeBecaController : Controller
    {
        private readonly IScholarshipProgramUniversity _scholarshipProgramUniversity;
        private readonly IScholarshipProgramUniversityAgreement _scholarshipProgramUniversityAgreement;
        private readonly IAgreementType _agreementType;
        private readonly IStatus _status;
        //private readonly IScholarshipProgramUniversity _scholarshipProgramUniversity;

        public AcuerdoProgramasdeBecaController(IScholarshipProgramUniversity scholarshipProgramUniversity,
            IAgreementType agreementType, IStatus status, IScholarshipProgramUniversityAgreement scholarshipProgramUniversityAgreement)
        {
            _scholarshipProgramUniversity = scholarshipProgramUniversity;
            _agreementType = agreementType;
            _status = status;
            _scholarshipProgramUniversityAgreement = scholarshipProgramUniversityAgreement;
        }

        public IActionResult Index()
        {

            var model = _scholarshipProgramUniversity.ScholarshipProgramUniversity.ToList();


           

            return View(model);
        } 
        
        public IActionResult Crear()
        {

            //var prueba = _agreementType.GetAll.ToList();
            ViewBag.AgreementTypes = new SelectList(_agreementType.GetAll, "AgreementTypeId", "AgreementTypeName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            return View();
        }


        public IActionResult Editar(int id)
        {
            var data = _scholarshipProgramUniversity.GetById(id);

            var acuerdoProgramasdeBecaModel = CopyPropierties.Convert<ScholarshipProgramUniversity, AcuerdoProgramasdeBecaModel>(data);
           var agreementList = _scholarshipProgramUniversityAgreement.GetAll.Where(x => x.ScholarshipProgramUniversityId == data.ScholarshipProgramUniversityId).ToList();
            acuerdoProgramasdeBecaModel.ScholarshipProgramUniversityAgreement = agreementList;
            //acuerdoProgramasdeBecaModel.Agreement.ScholarshipProgramUniversityId = data.ScholarshipProgramUniversityId;

            ViewBag.AgreementTypes = new SelectList(_agreementType.GetAll, "AgreementTypeId", "AgreementTypeName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");

            return View("Crear",acuerdoProgramasdeBecaModel);
        }

        public IActionResult Guardar(AcuerdoProgramasdeBecaModel model)
        {


            var scholarshipProgramUniversity = _scholarshipProgramUniversity.ScholarshipProgramUniversity.ToList();
            try
            {
                var data = CopyPropierties.Convert<AcuerdoProgramasdeBecaModel, ScholarshipProgramUniversity>(model);
                _scholarshipProgramUniversity.Save(data);
            }

            catch(Exception e)
            {
               

                return View("Index",scholarshipProgramUniversity);
            }

          

            return View("Index", scholarshipProgramUniversity);
        }


        public IActionResult AgregarAcuerdo(AcuerdoProgramasdeBecaModel model)
        {
            var scholarshipProgramUniversityAgreement = new ScholarshipProgramUniversityAgreement
            {
                ScholarshipProgramUniversityAgreementId = model.Agreement.ScholarshipProgramUniversityAgreementId,
                ScholarshipProgramUniversityId = model.ScholarshipProgramUniversityId,
                ScholarshipProgramUniversityAgreement1 = model.Agreement.ScholarshipProgramUniversityAgreement1,
                AgreementTypeId = model.Agreement.AgreementTypeId,
                CreationUserId = 1,
                StatusId = 1
            };

            try
            {
                _scholarshipProgramUniversityAgreement.Save(scholarshipProgramUniversityAgreement);
            }
            catch(Exception e)
            {
                return RedirectToAction("Editar", new { id = model.ScholarshipProgramUniversityId });
            }

            return RedirectToAction("Editar", new { id = model.ScholarshipProgramUniversityId });

        }
    }
}
