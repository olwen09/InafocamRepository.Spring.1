using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class InformeIndexViewModel
    {
       public IEnumerable<Report> ReportList { get; set; }

        public int? TracingId { get; set; }
        public bool IsGestionUniversitariaRole { get; set; }

        public int? ScholarshipProgramUniversityId { get; set; }

        public string  UniversityName { get; set; }
        public string ProgramNameScatCodeContractCode { get; set; }
    }
}
