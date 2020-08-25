using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class SeguimientoALaprácticaViewModel
    {
        public int? TracingId { get; set; }
        public int? ScholarshipProgramUniversityId { get; set; }

        public bool IsGestionUniversitariaRole { get; set; }
        public bool CanAddComment { get; set; }
        public IEnumerable<ScholarshipProgramTracingPractice> PracticeList { get; set; }
        public ScholarshipProgramTracingPracticeModel PracticeModel { get; set; }
    }
}
