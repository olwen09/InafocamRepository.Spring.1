using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class EstudiantesEnPracticaViewModel
    {
        public long TracingId { get; set; }
        public int? ScholarshipProgramUniversityId { get; set; }
        public bool IsGestionUniversitariaRole { get; set; }


        public IEnumerable<ScholarshipProgramTracingStudentPractice> StudentPracticeList { get; set; }
        public ScholarshipProgramTracingStudentPracticeFileModel StudentPracticeFileModel { get; set; }
        public ScholarshipProgramTracingStudentPracticeModel StudentPracticeModel { get; set; }
    }
}
