using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Components.SeguimientosAsignadosComponent
{
    public class SeguimientosAsignadosComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("SeguimientosAsignadosDataTable");
        }
    }
}
