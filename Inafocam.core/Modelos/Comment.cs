using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inafocam.core.Modelos
{
   public class Comment
    {

        public long CommentId { get; set; }

        public string Comments { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(150)]
        public string CommentScreen { get; set; }

        [MaxLength(50)]
        public string CreatorUserId { get; set; }

        public long? ScholarshipProgramTracingId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpgradeDate { get; set; }


        [ForeignKey("ScholarshipProgramTracingId")]
        public virtual ScholarshipProgramTracing ScholarshipProgramTracing { get; set; }


        [ForeignKey("CreatorUserId")]
        public virtual Usuario Usuario { get; set; }


    }
}
