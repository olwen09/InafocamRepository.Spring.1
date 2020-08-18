using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Components.ConsultarComentariosViewComponent
{
    public class ConsultarComentariosViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("ConsultarComentariosPantallaResolt");
        }
    }
}
