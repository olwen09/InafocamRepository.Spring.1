using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class CommentModel
    {
        public long CommentId { get; set; }

        public string Comments { get; set; }


        public string UniversityName { get; set; }

        public string Description { get; set; }

     
        public string CommentScreen { get; set; }

       
        public string CreatorUserId { get; set; }

        public long? ScholarshipProgramTracingId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpgradeDate { get; set; }


 
        public virtual ScholarshipProgramTracing ScholarshipProgramTracing { get; set; }


       
        public virtual Usuario Usuario { get; set; }
    }
}
