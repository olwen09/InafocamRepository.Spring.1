using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ResultsFromThePreviousPeriodModel
    {
        public long PreviousPeriodId { get; set; }

        [Required]
        public int? Quantity { get; set; }
        [Required]
        public string Observations { get; set; }
        [Required]
        public string FileDescription { get; set; }
        public long? TracingId { get; set; }
        [Required (ErrorMessage = "El tipo de componente es requerido")]
        public long? ComponentFileTypeId { get; set; }
        public long? StatusId { get; set; }
        public long? FileId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public virtual File File { get; set; }
        public ComponentFileType ComponentFileType { get; set; }
        public virtual Status Status { get; set; }
        public virtual ScholarshipProgramTracing Tracing { get; set; }
    }
}
