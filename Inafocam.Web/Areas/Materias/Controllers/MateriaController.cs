using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Andamios.Web.Areas.Usuarios.Models;
using Andamios.Web.Helpers;
using Andamios.Web.Models;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.Materias.Models;
using Inafocam.Web.Helpers;
using Inafocam.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inafocam.Web.Areas.Materias.Controllers
{
    [Area("Materias"),ReturnArea("Materias")]
    //[ReturnControllador("Materias"),ReturnController("Materia")]
    [Authorize(Roles = RoleName.AdministradorInafocam)]

    public class MateriaController : Controller
    {

        private readonly ISubjectMatter _subjectMatter;
        private readonly IStatus _status;
        private readonly ITeacher _teacher;
        private readonly IScholarshipProgramUniversity _scholarshipProgramUniversity;

        public MateriaController(ISubjectMatter subjectMatter,IStatus status,ITeacher teacher,
           IScholarshipProgramUniversity scholarshipProgramUniversity)
        {
            _subjectMatter = subjectMatter;
            _status = status;
            _teacher = teacher;
            _scholarshipProgramUniversity = scholarshipProgramUniversity;
        }

        public IActionResult Index(int scholarshipProgramUniversityId)
        {

            var data = _subjectMatter.GetAllByScholarshipProgramUniversityId(scholarshipProgramUniversityId);

            var model = new IndexViewModel();
            model.SubjectMatterList = _subjectMatter.GetAllByScholarshipProgramUniversityId(scholarshipProgramUniversityId);
            model.scholarshipProgramUniversityId = scholarshipProgramUniversityId;


            return View(model);
        }

        public IActionResult Crear(int scholarshipProgramUniversityId)
        {
            var universityId = _scholarshipProgramUniversity.GetUniversityIdByScholarshipProgramUniversityId(scholarshipProgramUniversityId);
            var model = new SubjectMatterModel();
            model.ScholarshipProgramUniversityId = scholarshipProgramUniversityId;
            model.UniversityId = universityId; 

            var teachers = _teacher.GetTeachersByUSerUniversityId(universityId);

            ViewBag.Teachers = new SelectList(TeachersByUniverityIdList(universityId), "TeacherId", "TeacherFullName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            return View(model);
        }

        public IActionResult Editar(int id, int scholarshipProgramUniversityId)
        {

            var data = _subjectMatter.GetById(id);

            var model = CopyPropierties.Convert<SubjectMatter, SubjectMatterModel>(data);
            if(model.TracingStudyPlanDevelopment.TeacherId == null)
            {
                model.TracingStudyPlanDevelopment.TeacherId = 0;
            }

            var univerityTeacherSelected = _teacher.GetById((int)model.TracingStudyPlanDevelopment.TeacherId);

            model.UniversityTeacherSelectedName = univerityTeacherSelected?.Contact?.ContactName?.ToString() + "" + univerityTeacherSelected?.Contact?.ContactLastname?.ToString();

            var universityId = _scholarshipProgramUniversity.GetUniversityIdByScholarshipProgramUniversityId(scholarshipProgramUniversityId);

            var teachers = _teacher.GetTeachersByUSerUniversityId(universityId);

            ViewBag.Teachers = new SelectList(TeachersByUniverityIdList(universityId), "TeacherId", "TeacherFullName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            return View("Crear", model);
        }

        [HttpPost]
        public IActionResult Guardar(SubjectMatterModel model)
        {
            var universityId = _scholarshipProgramUniversity.GetUniversityIdByScholarshipProgramUniversityId(model.ScholarshipProgramUniversityId);
            MensajesViewModel mensaje = new MensajesViewModel();
            var data = CopyPropierties.Convert<SubjectMatterModel, SubjectMatter>(model);

            if (CheckIfSubjectMatterCodeExits(data))
            {
                EnviarMensaje.Enviar(TempData, "red", "Este programa ya contiene un registro de una materia con este código");

                //if (model.SubjectMatterId != 0)
                //{
                //    ViewBag.Teachers = new SelectList(TeachersByUniverityIdList(universityId), "TeacherId", "TeacherFullName");
                //    return RedirectToAction("Editar", new { id = model.SubjectMatterId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
                //}


                ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
                ViewBag.Teachers = new SelectList(TeachersByUniverityIdList(universityId), "TeacherId", "TeacherFullName");
                return View("Crear",model);
            }

            if (ModelState.IsValid)
            {

                try
                {

                    _subjectMatter.Save(data);
                }
                catch (Exception e)
                {


                    if (model.SubjectMatterId != 0)
                    {
                        ViewBag.Teachers = new SelectList(TeachersByUniverityIdList(universityId), "TeacherId", "TeacherFullName");
                        return RedirectToAction("Editar", new { id = model.SubjectMatterId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
                    }
                    else
                    {
                        ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
                        ViewBag.Teachers = new SelectList(TeachersByUniverityIdList(universityId), "TeacherId", "TeacherFullName");
                        return View("Crear");
                    }
                }
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors).FirstOrDefault(x => x.Count > 0).First();



                EnviarMensaje.Enviar(TempData, "red", errors.ErrorMessage);

                if (model.SubjectMatterId != 0)
                {
                    ViewBag.Teachers = new SelectList(TeachersByUniverityIdList(universityId), "TeacherId", "TeacherFullName");
                    return RedirectToAction("Editar", new { id = model.SubjectMatterId, scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });

                }
                ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
                ViewBag.Teachers = new SelectList(TeachersByUniverityIdList(universityId), "TeacherId", "TeacherFullName");
                return View("Crear");
            }


            return RedirectToAction("Index", new { scholarshipProgramUniversityId = model.ScholarshipProgramUniversityId });
        }


        public IEnumerable<SeguimientoDeUniversidades.Models.TeacherIDAndName> TeachersByUniverityIdList(long? universityId)
        {
            var teachers = new List<SeguimientoDeUniversidades.Models.TeacherIDAndName>();
            try
            {
           
             teachers = _teacher.GetTeachersByUSerUniversityId(universityId)
                .Select(x => new SeguimientoDeUniversidades.Models.TeacherIDAndName
                 {
                     TeacherId = (long)x.TeacherId,
                     TeacherFullName = x.Contact.ContactName.ToString() + " " + x.Contact.ContactLastname.ToString()
                 }).ToList();
            }catch(Exception e)
            {
                Console.WriteLine("");
            }

            return teachers;
        }


        public bool CheckIfSubjectMatterCodeExits(SubjectMatter data)
        {
            var check = _subjectMatter.CheckIfSubjectMatterCodeExits(data);

            return check;
        }
    }
}
