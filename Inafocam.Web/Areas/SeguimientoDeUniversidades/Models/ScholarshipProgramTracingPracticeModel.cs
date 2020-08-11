using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ScholarshipProgramTracingPracticeModel
    {
        public long Id { get; set; }
        public long? TracingId { get; set; }

        [Required (ErrorMessage ="El tipo de Actividad es requerido")]
        public long? ActivityTypeId { get; set; }

        [Required]
        public string Coordinator { get; set; }

        [Required]
        public string Superviser { get; set; }

        [Required]
        public string Teacher { get; set; }

        [Required]

        public string Periodicity { get; set; }
        public string CreationDate { get; set; }
        public string UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual ActivityType ActivityType { get; set; }
        public virtual Status Status { get; set; }
        public virtual ScholarshipProgramTracing Tracing { get; set; }
    }
}
