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
using Inafocam.Web.Areas.Usuarios.Models;
using Inafocam.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inafocam.Web.Areas.Usuarios.Controllers
{
    [Area("Usuarios"),ReturnArea("Usuarios")]
    [ReturnControllador("Usuarios"),ReturnController("Usuario")]
    [Authorize]
    public class UsuarioController : Controller
    {

        private readonly IUser _user;
        private readonly IUsuario _usuario;
        private readonly IUserRole _userRole;
        private readonly IRole _role;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioController(IUser user, IUserRole userRole, SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, IUsuario usuario,IRole role)
        {
            _user = user;
            _usuario = usuario;
            _userRole = userRole;
            _role = role;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            var data = _usuario.Usuarios;

            return View(data);
        }

        [ReturnVista("Login")]
        [AllowAnonymous]
        //[Authorize(Policy = Constante.UsuarioCanRead)]
        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult PerfilUsuario()
        {
            return View();
        }   public IActionResult PerfilUsuarioAdmin(int id)
        {

            var data = _user.GetByID(id);

            var model = CopyPropierties.Convert<User, UserModel>(data);

            ViewBag.UserRole = new SelectList(_userRole.GetAll, "UserRoleId", "UserRoleName");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        //[Authorize(Policy = Constante.UsuarioCanRead)]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {

            if (!ModelState.IsValid) return View(model);
            /////
            var usuario = _usuario.Usuarios.FirstOrDefault(x => x.UserName == model.UserName);
            //Where(n => n.UserName == model.UserName).Single();
            if (usuario != null)
            {
                var estado = _usuario.Usuarios.Where(n => n.UserName == model.UserName).Select(x => x.Estado).AsQueryable().Single();

                if (estado == true)
                {

                    var result = await _signInManager.PasswordSignInAsync(model.UserName,
                 model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {




                        // _logger.LogInformation("User logged in.");

                        return RedirectToAction("Home", "Home", new { area = "" });




                    }

                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("./LoginWith2fa", new
                        {
                            ReturnUrl = returnUrl,
                            RememberMe = model.RememberMe
                        });
                    }

                    if (result.IsLockedOut)
                    {
                        // _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        //TempData.Enviar("error", "green", "olwen");
                        TempData.Enviar("Datos incorrectos", "error", "La Contraseña o el usuario no coinciden");
                        //EnviarMensaje.Enviar(TempData, "red", 13);
                        return View(model);
                    }
                }

                else
                {
                    TempData.Enviar("Usuario Inactivo", "error", "Contacte al administrador del sistema");

                    return View(model);
                }


                //}
            }

            else
            {
                //var value = _localizer["Este usuario no existe"]. == null ? "Este usuario no existe" : "This user does not exist";
                TempData.Enviar("Este usuario no existe", "error", "Verifique el nombre del usuario o contacte al administrador");

                return View(model);
            }


           return View(model);


        }


        [ReturnVista("Nuevo")]
        [AllowAnonymous]
        //[Authorize(Policy = Constante.UsuarioCanRead)]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = Constante.UsuariorCanCreate)]
        public async Task<IActionResult> Registro(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                MensajesViewModel mensaje = new MensajesViewModel();

                var user = CopyPropierties.Convert<RegisterViewModel, Usuario>(model);
                var email = _usuario.Usuarios.FirstOrDefault(x => x.Email.Equals(model.Email));
                user.EmailConfirmed = true;

                //ViewData["Prueba"] =  _localizer["Este email ya existe, intenten con otro"];




                try
                {

                    if (model.Password.Length < 6)
                    {
                        mensaje.Titulo = "La Contraseña debe contener al menos 6 digitos";
                    }

                    else if (email != null)
                    {

                        mensaje.Titulo = "Este email ya existe, intenten con otro";
                        //ViewData["Prueba"] = _localizer["Clientes"];
                    }
                    else
                    {

                        var result = await _userManager.CreateAsync(user, model.Password);


                        if (result.Succeeded)
                        {
                            if (!string.IsNullOrEmpty(user.Role))
                            {
                                result = await _userManager.AddToRoleAsync(user, user.Role);
                            }

                            mensaje.Titulo = "Usuario Creado";

                            mensaje.Texto = "El usuario se creó satisfactoriamente";

                            mensaje.Tipo = "success";

                            TempData.Put("mensaje", mensaje);

                            return RedirectToAction("Login", "Usuario");
                        }

                        mensaje.Titulo = "Hubo un problema";

                        if (result.Errors.First().Code == "DuplicateUserName")
                        {
                            mensaje.Texto = "El nombre de usuario ya exite, intenten con otro";

                        }

                    }

                    mensaje.Tipo = "error";
                    ViewBag.mensaje = mensaje;

                    return View(model);

                }
                catch (System.Exception e)
                {
                    var error = e;
                    return View(model);
                }

            }

            return View(model);
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [AllowAnonymous]
        [ReturnVista("Cambiar Estado"), ReturnViewAtttribute("CambiarEstado")]
        public async Task<EditarUsuarioModel> CambiarEstado(string id)
        {
            //code = "12346AASS";

            EditarUsuarioModel editar = new EditarUsuarioModel();

            Usuario user = await _userManager.FindByIdAsync(id);

            var value = CopyPropierties.Convert<Usuario, EditarUsuarioModel>(user);


            return value;
        }

        [HttpGet, AllowAnonymous]
        //[Authorize(Policy = Constante.UsuarioCanRead)]
        public IActionResult CambiarEstadoModal(string userId)
        {

            var cambiarestado = CambiarEstado(userId).Result;
            //var dataJSon = JsonConvert.SerializeObject(resetPassword);


            return ViewComponent("CambiarEstadoComponent", new { cambiarestado = cambiarestado });

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = Constante.UsuarioCanUpdate)]
        public async Task<IActionResult> CambiarEstado(EditarUsuarioModel model)
        {


            if (TryValidateModel(model))
            {

                var usuarioCreado = _usuario.GetUsuarioById(model.Id);

                PropertiesParser<EditarUsuarioModel, Usuario>
                    .CopyPropertiesTo<EditarUsuarioModel, Usuario>(model, usuarioCreado);

                await _userManager.UpdateAsync(usuarioCreado);

                var roles = await _userManager.GetRolesAsync(usuarioCreado);
                if (!string.IsNullOrEmpty(model.Role))
                {
                    if (!roles.Contains(model.Role))
                        await _userManager.AddToRoleAsync(usuarioCreado, model.Role);
                }

                EnviarMensaje.Enviar(TempData, "green", 3);


                return View("Index", _usuario.Usuarios);

            }



            return View("Index", _usuario.Usuarios);

        }


        [AllowAnonymous]
        [ReturnVista("Reiniciar Contraseña"), ReturnViewAtttribute("ResetPassword")]
        //[Authorize(Policy = Constante.UsuarioCanRead)]
        public async Task<ResetPasswordViewModel> ResetPassword(string id)
        {
            //code = "12346AASS";
            ResetPasswordViewModel rsvm = new ResetPasswordViewModel();

            Usuario user = await _userManager.FindByIdAsync(id);


            if (user == null)
            {
                return rsvm;
            }

            rsvm.Id = user.Id;
            rsvm.UserName = user.UserName;
            rsvm.Code = await _userManager.GeneratePasswordResetTokenAsync(user);
            rsvm.Url = "Index";

            return rsvm;
        }

        [HttpGet, AllowAnonymous]
        //[Authorize(Policy = Constante.UsuarioCanRead)]
        public IActionResult ResetPasswordModal(string userId)
        {

            var resetPassword = ResetPassword(userId).Result;
            //var dataJSon = JsonConvert.SerializeObject(resetPassword);


            return ViewComponent("ResetPasswordComponent", new { rpvm = resetPassword });

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = Constante.UsuarioCanUpdate)]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {



            var usuario = _usuario.GetUsuarioById(model.Id);
            var roles = _role.Roles.ToList();

            var perfilmodel = new PerfilUsuario
            {

                EditarUsuarioModel = CopyPropierties.Convert<Usuario, EditarUsuarioModel>(usuario),
                ResetPasswordViewModel = model
            };


            //if (model == null) return View(model);
            MensajesViewModel mensaj = new MensajesViewModel();
            var user = await _userManager.FindByNameAsync(model.UserName);





            if (model.Url == "PerfilUsuarioAdmin")
            {
                if (model.Password == null || model.ConfirmPassword == null)
                {

                    EnviarMensaje.Enviar(TempData, "red", 12);
                    ViewBag.Role = new SelectList(roles, "Name", "Name");
                    return View("PerfilUsuarioAdmin", perfilmodel);

                }

                else if (model.Password != model.ConfirmPassword)
                {
                    EnviarMensaje.Enviar(TempData, "red", 13);
                    ViewBag.Role = new SelectList(roles, "Name", "Name");
                    return View("PerfilUsuarioAdmin", perfilmodel);
                }
                else
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

                    if (result.Succeeded)
                    {




                        //ViewBag.Role = new SelectList(roles, "Name", "Name");
                        EnviarMensaje.Enviar(TempData, "green", 12);
                        return RedirectToAction("PerfilUsuarioAdmin", "Usuario", new { id = model.Id });

                    }
                }
            }

            else
            {
                if (model.Password == null || model.ConfirmPassword == null)
                {

                    EnviarMensaje.Enviar(TempData, "red", 12);
                    //ViewBag.Role = new SelectList(roles, "Name", "Name");
                    return View("Index", _usuario.Usuarios);

                }
                else if (model.Password.Length < 6)
                {
                    EnviarMensaje.Enviar(TempData, "red", "La contraseña debe ser de por lo menos 6 caracteres de longitud");
                    return View("Index", _usuario.Usuarios);
                }

                else if (model.Password != model.ConfirmPassword)
                {
                    EnviarMensaje.Enviar(TempData, "red", 13);
                    return View("Index", _usuario.Usuarios);
                }
                //else if (model.Password.Length < 6 && model.con)
                else
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

                    if (result.Succeeded)
                    {




                        EnviarMensaje.Enviar(TempData, "green", 12);


                        return View("Index", _usuario.Usuarios);

                    }
                }

            }




            if (user == null)
            {
                // Don't reveal that the user does not exist
                return View("login");
            }

            //model.ResetPasswordViewModel.Code = UserManager.GeneratePasswordResetToken(user.Id);
            //model.Code = await _userManager.GeneratePasswordResetTokenAsync(user);

            ViewBag.Role = new SelectList(roles, "Name", "Name");

            return View("PerfilUsuarioAdmin", perfilmodel);
        }

    }
}
