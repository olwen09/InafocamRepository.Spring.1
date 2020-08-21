using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class IndexViewModel
    {
        public bool IsGestionUniversitariaRole { get; set; }

       public IEnumerable<ScholarshipProgramTracing> AveliableScholarshipProgramTracingList { get; set; }
    }
}
