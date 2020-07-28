using Andamios.Web.Areas.Usuarios.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Usuarios.Components.CambiarEstadoComponent
{
    public class CambiarEstadoComponent : ViewComponent
    {

      

        public IViewComponentResult Invoke(EditarUsuarioModel cambiarestado)
        {
            if (cambiarestado == null)
            {
                return View("CambiarEstado");
            }


            return View("CambiarEstado", cambiarestado);
        }
    }
}
