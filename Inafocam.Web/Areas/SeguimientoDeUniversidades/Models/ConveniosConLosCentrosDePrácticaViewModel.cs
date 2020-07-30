using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ConveniosConLosCentrosDePrácticaViewModel
    {
        public int? TracingId { get; set; }
        public int? ScholarshipProgramUniversityId { get; set; }

        public bool IsGestionUniversitariaRole { get; set; }


        public IEnumerable<ScholarshipProgramTracingAgreementsWithPracticeCenter> AgreementsWithPracticeCenterList { get; set; }
        public ScholarshipProgramTracingAgreementsWithPracticeCenterModel AgreementsWithPracticeCenterModel { get; set; }
    }
}
