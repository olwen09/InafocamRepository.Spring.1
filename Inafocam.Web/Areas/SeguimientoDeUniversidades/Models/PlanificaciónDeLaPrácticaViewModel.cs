using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class PlanificaciónDeLaPrácticaViewModel
    {
        public int? TracingId { get; set; }
        public int? ScholarshipProgramUniversityId { get; set; }
        public bool IsGestionUniversitariaRole { get; set; }

        public short? Started { get; set; }
        public short? Finished { get; set; }

        public IEnumerable<ScholarshipProgramTracingPracticePlanning> PracticePlanningList{ get; set; }
        public ScholarshipProgramTracingPracticePlanningModel PracticePlanningModel { get; set; }

    }
}
