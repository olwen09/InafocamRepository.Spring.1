using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ApoyoAlEstudianteModel
    {
        public int? ScholarshipProgramUniversityId { get; set; }
        public int? TracingId { get; set; }

        public IEnumerable<ScholarshipProgramTracingStudentSupport> StudentSupportList { get; set; }

       public  IEnumerable<Indicador> IndicadoresList { get; set; }
       public IEnumerable<Preguntas> PreguntasList { get; set; }
    }

    public class Indicador
    {
        public int IndicadorId { get; set; }
        public string IndicadorNombre { get; set; }
    }

    public class Preguntas
    {
        public int PreguntaId { get; set; }

        public string NombrePregunta { get; set; }
    }
}
