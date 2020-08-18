using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class InstruccionesViewModel
    {
        public string Instrucciones { get; set; }


        public int ScholarshipProgramTracingId { get; set; }

        public int ScholarshipProgramUniversityId { get; set; }

        public List<string> InstruccionesList { get; set; } 
    }

    public class EstructuraDelPlan {

        public  int TotalAsignaturas{ get; set; }
        public  int TotalCreditos { get; set; }
        public  int TotalHoras{ get; set; }
        public  int TotalHorasPracticas { get; set; }
        public  int NumeroDeBecadosActivos{ get; set; }
        public  int Femenino { get; set; }
        public  int Masculino { get; set; }

    }
}
