using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.AcuerdoProgramasdeBecas.Models;
using Inafocam.Web.Helpers;
using Inafocam.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inafocam.Web.Areas.AcuerdoProgramasdeBecas.Controllers
{
    [Area("AcuerdoProgramasdeBecas"),ReturnArea("AcuerdoProgramasdeBecas")]
    [ReturnControllador("Acuerdos de Programas Formativos"),ReturnController("AcuerdoProgramasdeBeca")]
    [Authorize(Roles = RoleName.AdministradorInafocam)]

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



        public IActionResult CambiarEstado(string estado, long agreementId,int scholarshipProgramUniversityId) 
        {

            try
            {
                _scholarshipProgramUniversityAgreement.CambiarEstado(agreementId, estado);
            }
            catch (Exception e)
            {
                return RedirectToAction("Editar", new { id = scholarshipProgramUniversityId });
            }

            return RedirectToAction("Editar", new { id = scholarshipProgramUniversityId });

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


        [HttpPost]
        public IActionResult AgregarAcuerdo(AcuerdoProgramasdeBecaModel model)
        {


           
            if(model.AgreementId == 0 ||string.IsNullOrWhiteSpace(model.ScholarshipProgramUniversityAgreement1))
            {
                EnviarMensaje.Enviar(TempData, "red", "Ambos campos son requeridos");

                return RedirectToAction("Editar", new { id = model.ScholarshipProgramUniversityId });
            }


            if (ModelState.IsValid)
            {
                var scholarshipProgramUniversityAgreement = new ScholarshipProgramUniversityAgreement
                {
                    ScholarshipProgramUniversityAgreementId = model.Agreement.ScholarshipProgramUniversityAgreementId,
                    ScholarshipProgramUniversityId = model.ScholarshipProgramUniversityId,
                    ScholarshipProgramUniversityAgreement1 = model.ScholarshipProgramUniversityAgreement1,
                    AgreementTypeId = model.AgreementId,                    
                    StatusId = 1
                };

                if (model.Agreement.AgreementTypeId != 0)
                {

                }
                try
                {
                    _scholarshipProgramUniversityAgreement.Save(scholarshipProgramUniversityAgreement);
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

                return RedirectToAction("Editar", new { id = model.ScholarshipProgramUniversityId });

            }


            return RedirectToAction("Editar", new { id = model.ScholarshipProgramUniversityId });

        }

        public IActionResult EditarAcuerdos(int acuerdoId, int scholarshipProgramUniversityId)
        {
            var data = _scholarshipProgramUniversityAgreement.GetById(acuerdoId);

            var model = CopyPropierties.Convert<ScholarshipProgramUniversityAgreement, EditarAcuerdoViewModel>(data);

            ViewBag.AgreementTypes = new SelectList(_agreementType.GetAll, "AgreementTypeId", "AgreementTypeName");
            return View(model);
        }

        [HttpPost]
        public IActionResult EditarAcuerdos(EditarAcuerdoViewModel model, int acuerdoId, int scholarshipProgramUniversityId)
        {

            if (ModelState.IsValid)
            {
                var data = CopyPropierties.Convert<EditarAcuerdoViewModel, ScholarshipProgramUniversityAgreement>(model);

                try
                {
                    _scholarshipProgramUniversityAgreement.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("EditarAcuerdos", new { acuerdoId = model.ScholarshipProgramUniversityAgreementId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
                }
            }
            else
            {

                var errors = ModelState.Select(x => x.Value.Errors).FirstOrDefault(x => x.Count() > 0).First();

                EnviarMensaje.Enviar(TempData, "red", errors.ErrorMessage);

                return RedirectToAction("EditarAcuerdos", new { acuerdoId = model.ScholarshipProgramUniversityAgreementId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
            }

          

            return RedirectToAction("Editar", new { id = model.ScholarshipProgramUniversityId });

        }

    }
}
