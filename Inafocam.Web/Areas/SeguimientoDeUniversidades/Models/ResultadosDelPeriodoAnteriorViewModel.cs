using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ResultadosDelPeriodoAnteriorViewModel
    {
        public int? ScholarshipProgramUniversityId { get; set; }
        public int? TracingId { get; set; }

        public IEnumerable<ResultsFromThePreviousPeriod> PreviousPeriodList { get; set; }
        public ResultsFromThePreviousPeriodModel PreviousPeriodModel { get; set; }
    }
}
