using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class InformeModel
    {
        public int ReportId { get; set; }


        public string UniversityName { get; set; }

        public string CreatorName { get; set; }

        public int ScholarshipProgramUniversityId { get; set; }

        public string Program { get; set; }


        [Required]
        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpgradeDate { get; set; }

        public string CreatorUserId { get; set; }

        public long TracingId { get; set; }

        public long FileId { get; set; }

        public virtual Usuario Usuario { get; set; }

       
        public virtual File File { get; set; }

       
        public virtual ScholarshipProgramTracing ScholarshipProgramTracing { get; set; }
    }
}
