using System.Linq;
using System.Threading.Tasks;
using Inafocam.core.Modelos;
using Inafocam.core.Interfaces;
using Inafocam.core.Utilidades;
using Andamios.Web.Areas.Usuarios.Models;
using Andamios.Web.Helpers;
using Andamios.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Inafocam.Web.Helpers;
using System.Security.Claims;
using Inafocam.Web.Areas.Usuarios.Models;

namespace Inafocam.Web.Areas.Identity.Controllers
{
    [Area("Identity"), ReturnArea("Account")]
    [ReturnControllador("Perfil de Usuario"), ReturnController("Account")]

    public class AccountController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly IUsuario _usuario;
        private readonly IRole _role;
        private IConfiguration _config;


        public AccountController(SignInManager<Usuario> signInManager, IUsuario usuario, UserManager<Usuario> userManager, IRole role, IConfiguration config)
        {
            _role = role;
            _userManager = userManager;
            _signInManager = signInManager;
            _usuario = usuario;
            _config = config;
         
        }

        public IActionResult Index()
        {
            return View();
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}

        //public IActionResult AccessDenied()
        //{
        //    TempData.Enviar("Acceso denegado!", "error", "no tiene permitido acceder a este lugar");
        //    return RedirectToAction("Login", "Usuario", new { area = "Usuarios", mensaje = "Acceso denegado!" });
        //}

        [ReturnVista("Login")]
        [AllowAnonymous]
        //[Authorize(Policy = Constante.UsuarioCanRead)]
        public IActionResult Login()
        {

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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



                        //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                        //Usuario user = _userManager.FindByIdAsync(userId).Result;
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
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = Constante.UsuariorCanCreate)]
        public async Task<IActionResult> Register(RegisterViewModel model)
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

                            return RedirectToAction("Login", "Account");
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

        //public async Task<IActionResult> LogOut()
        //{
        //    await _signInManager.SignOutAsync();

        //    return RedirectToAction("Index", "Home", new { area = "" });
        //}


        [AllowAnonymous]
        //[ReturnVista("Perfil Usuario"), ReturnViewAtttribute("ResetPassword")]
        [ReturnVista("Perfil Usuario"), ReturnViewAtttribute("PerfilUsuario")]
        public async Task<IActionResult> PerfilUsuario(string id)
        {
            Usuario user = _usuario.GetUsuarioById(id);

            MensajesViewModel mensaje = new MensajesViewModel();
            var userId = _userManager.GetUserId(User);



            if (string.IsNullOrEmpty(id))
            {

                return View("Login");
            }

            // 1. traer el usuairo

            //Usuario user = _usuario.GetUsuarioById(id);

            if (user == null)
            {
                //EnviarMensaje.Enviar(TempData, "orange", "Debe de seleccionar una categoría válida!");
                return View("Login");

            }

            // 2. Crear el modelo de resset password

            ResetPasswordViewModel rpvm = new ResetPasswordViewModel
            {
                UserName = user.UserName,
                Code = await _userManager.GeneratePasswordResetTokenAsync(user)
            };

            // 3. crear el modelo de la vista

            var editarUsuarioModel = new EditarUsuarioModel();
            editarUsuarioModel.ImageUrl = "wwwroot/app-assets/images/usuario";

            var model = new PerfilUsuario
            {

                EditarUsuarioModel = CopyPropierties.Convert<Usuario, EditarUsuarioModel>(user),
                ResetPasswordViewModel = rpvm
            };

            var roles = _role.Roles.ToList();

            ViewBag.Role = new SelectList(roles, "Name", "Name");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = Constante.UsuarioCanUpdate)]
        public async Task<IActionResult> Editar(PerfilUsuario model, IFormFile imagen)
        {
            var size = 3145728;
            var rutaImg = _config.GetSection("rutas").GetSection("usuario").Value;
            string ext = imagen != null ? Path.GetExtension(imagen.FileName) : "";

            // Validar imagen
            var resp = ValidacionDocumento.Validar(imagen, size, ext, string.IsNullOrEmpty(model.EditarUsuarioModel.Imagen));

            if (resp > 1)
            {
                //ViewBag.tipo = new SelectList(_tipo.Tipos, "TipoProductoId", "Nombre", model.TipoProductoId);

                EnviarMensaje.Enviar(TempData, "red", resp);

                return View("PerfilUsuario", model);
            }


            if (TryValidateModel(model.EditarUsuarioModel))
            {

                var usuarioCreado = _usuario.GetUsuarioById(model.EditarUsuarioModel.Id);

                PropertiesParser<EditarUsuarioModel, Usuario>
                    .CopyPropertiesTo<EditarUsuarioModel, Usuario>(model.EditarUsuarioModel, usuarioCreado);

                var name = usuarioCreado.Id + "-" + Guid.NewGuid() + ext;

                if (imagen != null)
                {

                    usuarioCreado.Imagen = name;

                }

                var result = await _userManager.UpdateAsync(usuarioCreado);

                var roles = await _userManager.GetRolesAsync(usuarioCreado);
                if (!string.IsNullOrEmpty(model.EditarUsuarioModel.Role))
                {
                    if (!roles.Contains(model.EditarUsuarioModel.Role))
                        await _userManager.AddToRoleAsync(usuarioCreado, model.EditarUsuarioModel.Role);
                }

                if (usuarioCreado.Imagen != null)
                {

                    if (result.Succeeded)
                    {
                        await ValidacionDocumento.GuardarDocumentoAsync(imagen, rutaImg, name);
                    }

                    EnviarMensaje.Enviar(TempData, "green", 3);



                    return RedirectToAction("Home", "Home", new { area = "" });

                }
                else
                {
                    if (result.Succeeded)
                    {
                        await ValidacionDocumento.GuardarDocumentoAsync(imagen, rutaImg, name);
                    }

                    EnviarMensaje.Enviar(TempData, "green", 3);



                    return RedirectToAction("Home", "Home", new { area = "" });
                }





            }


            return View("PerfilUsuario", model);

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
            rsvm.area = "Identity";
            rsvm.controller = "Account";


            return rsvm;
        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = Constante.UsuarioCanUpdate)]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {



            var usuario = _usuario.GetUsuarioById(model.Id);
            var perfilmodel = new PerfilUsuario
            {

                EditarUsuarioModel = CopyPropierties.Convert<Usuario, EditarUsuarioModel>(usuario),
                ResetPasswordViewModel = model
            };


            //if (model == null) return View(model);
            MensajesViewModel mensaj = new MensajesViewModel();
            var user = await _userManager.FindByNameAsync(model.UserName);


            if (model.Url == "Index")
            {

                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

                if (result.Succeeded)
                {



                    EnviarMensaje.Enviar(TempData, "green", 12);

                    //return RedirectToAction("PerfilUsuario", new RouteValueDictionary(new { Controller = "Usuario", Action = "PerfilUsuario", Id = "eeed77ad - 8815 - 4d7a - b5d5 - fa6a1393b6e2" }));
                    return View("Index", _usuario.Usuarios);

                }
            }

            if (model.Password == null || model.ConfirmPassword == null)
            {

                EnviarMensaje.Enviar(TempData, "red", 12);
                return View("PerfilUsuario", perfilmodel);

            }

            else if (model.Password != model.ConfirmPassword)
            {
                EnviarMensaje.Enviar(TempData, "red", 13);
                return View("PerfilUsuario", perfilmodel);
            }
            else
            {
                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

                if (result.Succeeded)
                {




                    EnviarMensaje.Enviar(TempData, "green", 12);

                    return RedirectToAction("PerfilUsuario", "Account", new { id = model.Id });

                    //RedirectToAction("PerfilUsuario", "Usuario", model.Id);


                }
            }


            if (user == null)
            {
                // Don't reveal that the user does not exist
                return View("login");
            }




            return View("PerfilUsuario", perfilmodel);
        }

        public IActionResult AccessDenied()
        {
            TempData.AccesoDenegado("Acceso denegado", "No tiene permisos para entrar a esta área", "red");

            return RedirectToAction("Home", "Home", new { area = "" });
        }

    }
}
