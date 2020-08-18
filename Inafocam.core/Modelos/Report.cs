using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inafocam.core.Modelos
{
   public class Report
    {
        public int ReportId { get; set; }

        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpgradeDate { get; set; }

        public string CreatorUserId { get; set; }

        public long TracingId { get; set; }

        public long FileId { get; set; }

        public long StatusId { get; set; }

        [ForeignKey("CreatorUserId")]
        public virtual Usuario Usuario { get; set; }
        
        [ForeignKey("FileId")]
        public virtual File File { get; set; }

        [ForeignKey("TracingId")]
        public virtual ScholarshipProgramTracing ScholarshipProgramTracing { get; set; }


        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

    }
}
