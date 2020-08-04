using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ScholarshipProgramTracingPracticePlanningModel
    {
        public long Id { get; set; }
        public long? TracingId { get; set; }

        [Required (ErrorMessage = "El tipo de planificación es requerido")]
        public long? ActionTypeId { get; set; }
        public short? Started { get; set; }
        public short? Finished { get; set; }

        [Required]
        public string Comment { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ActionType ActionType { get; set; }
        public virtual ScholarshipProgramTracing Tracing { get; set; }
    }
}
