using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.ComponentsComentariosComponent
{
    public class ComentariosComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("ComentariosDataTable");
        }
    }

}
