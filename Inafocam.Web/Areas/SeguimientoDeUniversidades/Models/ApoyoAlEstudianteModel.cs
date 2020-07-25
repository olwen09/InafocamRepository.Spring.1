using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ApoyoAlEstudianteModel
    {


        public string Answer { get; set; }

        public Indicador Indicador { get; set; }

        public Preguntas Preguntas { get; set; }

        public int? ScholarshipProgramUniversityId { get; set; }
        public int? TracingId { get; set; }

        public ScholarshipProgramTracingStudentSupport StudentSupporModel { get; set; }
        public ScholarshipProgramTracingStudentSupport StudentSupporModelEmpty { get; set; }
        public IEnumerable<ScholarshipProgramTracingStudentSupport> StudentSupporModeltList { get; set; }
        public IEnumerable<ScholarshipProgramTracingStudentSupport> StudentSupportList { get; set; }

       public  List<Indicador> IndicadoresList { get; set; }
       public List<Preguntas> PreguntasList { get; set; }
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
