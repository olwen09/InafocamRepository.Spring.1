using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Andamios.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Inafocam.core.Modelos;
using Inafocam.Web.Models;

namespace Andamios.Web.Controllers {
    [Authorize]
    //[Area("Home"), ReturnArea("Home")]
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Usuario> _userManager;


        public HomeController (ILogger<HomeController> logger, UserManager<Usuario> userManager) {
            _logger = logger;
            _userManager = userManager;
        }

        [Layout ("_layout")]

        [AllowAnonymous]
        public async Task<IActionResult> Index () 
        {

            //var claims = User.Claims.Select(c =>
            //   new
            //   {
            //       c.Type,
            //       c.Value
            //   }).ToList();

            //var claims = User.Claims.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario user = _userManager.FindByIdAsync(userId).Result;



          





            if (user == null)
            {
                return View("StartPage");
            }

            return RedirectToAction("Home", new { });

            //return View("Home",user);
        }

        public IActionResult Lock () {
            return View ();
        }

        [Layout ("_layout")]
        public IActionResult Home () 
        {
            //var claims = User.Claims.Select(c =>
            // new
            // {
            //     c.Type,
            //     c.Value
            // }).ToList();

            


             var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Usuario user = _userManager.FindByIdAsync(userId).Result;

            if (user.Role == RoleName.UsuarioEjecutivoUniversitario || 
                user.Role == RoleName.UsuarioEjecutivoInafocam || user.Role == RoleName.GestionUniversitaria)
            {
                return RedirectToAction("Index", "SeguimientoDeUniversida", new { Area = "SeguimientoDeUniversidades" });
            }
            else if (user.Role == RoleName.AdministradorInafocam)
            {
                return View();
            }

        
            return View ();
        }
        [AllowAnonymous]
        public IActionResult StartPage () {

            return View ();
        }

        public IActionResult Instrucciones () {
            return View ();
        }

        public IActionResult Soporte () {
            return View ();
        }

        [AllowAnonymous]
        public void ClearTempData () {
            TempData.Clear ();
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //public void GetParametros(string culture, string returnUrl)
        //{
        //    SetLanguage(culture, returnUrl);
        //}

        public IActionResult SetLanguage(string returnUrl)
        {

          return LocalRedirect(returnUrl);
            //return View(nameof(Index));

        }

    }
}