using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ApoyoAlEstudianteModel
    {

        public long Id { get; set; }
        public long TracingId { get; set; }
        public long? IndicatorId { get; set; }
        public long? QuestionId { get; set; }
        public string Answer { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ScholarshipProgramTracing Tracing { get; set; }

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
