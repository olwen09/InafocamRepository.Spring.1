using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class DesarrolloDelPlanDeEstudioModel
    {
        public TracingStudyPlanDevelopment TracingStudyPlanDevelopmentModel { get; set; }
        public IEnumerable<TracingStudyPlanDevelopment> TracingStudyPlanDevelopmentList { get; set; }
    }
}
