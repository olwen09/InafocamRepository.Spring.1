using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ComentariosViewModel
    {
       

        public long CommentId { get; set; }

        public string Comments { get; set; }


        public string ActionName { get; set; }

        public string CreatorName { get; set; }
        public string Description { get; set; }

        public string NormalizedDescription { get; set; }

        public string CommentScreen { get; set; }

        public long StatusId { get; set; }



        public string CreatorUserId { get; set; }

        public long? ScholarshipProgramTracingId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpgradeDate { get; set; }

        public int? ScholarshipProgramUniversityId { get; set; }
        public long TracingId { get; set; }
        public bool IsGestionUniversitariaRole { get; set; }

        public virtual ScholarshipProgramTracing ScholarshipProgramTracing { get; set; }



        public virtual Usuario Usuario { get; set; }

        public virtual Status Status { get; set; }

    }
}
