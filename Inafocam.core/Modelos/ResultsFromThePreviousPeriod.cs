using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inafocam.core.Modelos
{
   public class ResultsFromThePreviousPeriod
    {
        [Key]
        public long PreviousPeriodId { get; set; }
        public int? Quantity { get; set; }
        public string Observations { get; set; }
        public string FileDescription { get; set; }
        public long? TracingId { get; set; }
        public  long? ComponentFileTypeId { get; set; }
        public long? StatusId { get; set; }
        public long? FileId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public virtual File File { get; set; }
        public virtual ComponentFileType ComponentFileType { get; set; }
        public virtual Status Status { get; set; }
        public virtual ScholarshipProgramTracing Tracing { get; set; }
    }
}
