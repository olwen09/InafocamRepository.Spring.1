using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.Web.Areas.Usuarios.Models;
using Andamios.Web.Helpers;
using Andamios.Web.Models;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.Materias.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inafocam.Web.Areas.Materias.Controllers
{
    [Area("Materias"),ReturnArea("Materias")]
    [ReturnControllador("Materias"),ReturnController("Materia")]
    [Authorize]
    public class MateriaController : Controller
    {

        private readonly ISubjectMatter _subjectMatter;
        private readonly IStatus _status;

        public MateriaController(ISubjectMatter subjectMatter,IStatus status)
        {
            _subjectMatter = subjectMatter;
            _status = status;
        }

        public IActionResult Index()
        {

            var data = _subjectMatter.GetAll;

            return View(data);
        }

        public IActionResult Crear(SubjectMatterModel model)
        {
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            return View(model);
        }

        public IActionResult Editar(int id)
        {

            var data = _subjectMatter.GetById(id);

            var model = CopyPropierties.Convert<SubjectMatter, SubjectMatterModel>(data);

            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            return View("Crear", model);
        }

        public IActionResult Guardar(SubjectMatterModel model)
        {

            try
            {
                var data = CopyPropierties.Convert<SubjectMatterModel, SubjectMatter>(model);

                _subjectMatter.Save(data);
            }
            catch(Exception e)
            {

                return View("Index", _subjectMatter.GetAll);
            }

            return View("Index", _subjectMatter.GetAll);
        }

    

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Policy = Constante.UsuariorCanCreate)]
        //public async Task<IActionResult> Registro(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        MensajesViewModel mensaje = new MensajesViewModel();

        //        var user = CopyPropierties.Convert<RegisterViewModel, Usuario>(model);
        //        var email = _usuario.Usuarios.FirstOrDefault(x => x.Email.Equals(model.Email));
        //        user.EmailConfirmed = true;

        //        //ViewData["Prueba"] =  _localizer["Este email ya existe, intenten con otro"];




        //        try
        //        {

        //            if (model.Password.Length < 6)
        //            {
        //                mensaje.Titulo = "La Contraseña debe contener al menos 6 digitos";
        //            }

        //            else if (email != null)
        //            {

        //                mensaje.Titulo = "Este email ya existe, intenten con otro";
        //                //ViewData["Prueba"] = _localizer["Clientes"];
        //            }
        //            else
        //            {

        //                var result = await _userManager.CreateAsync(user, model.Password);


        //                if (result.Succeeded)
        //                {
        //                    if (!string.IsNullOrEmpty(user.Role))
        //                    {
        //                        result = await _userManager.AddToRoleAsync(user, user.Role);
        //                    }

        //                    mensaje.Titulo = "Usuario Creado";

        //                    mensaje.Texto = "El usuario se creó satisfactoriamente";

        //                    mensaje.Tipo = "success";

        //                    TempData.Put("mensaje", mensaje);

        //                    return RedirectToAction("Login", "Usuario");
        //                }

        //                mensaje.Titulo = "Hubo un problema";

        //                if (result.Errors.First().Code == "DuplicateUserName")
        //                {
        //                    mensaje.Texto = "El nombre de usuario ya exite, intenten con otro";

        //                }

        //            }

        //            mensaje.Tipo = "error";
        //            ViewBag.mensaje = mensaje;

        //            return View(model);

        //        }
        //        catch (System.Exception e)
        //        {
        //            var error = e;
        //            return View(model);
        //        }

        //    }

        //    return View(model);
        //}
    }
}
