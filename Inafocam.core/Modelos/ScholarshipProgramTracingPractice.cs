using System;
using System.Collections.Generic;

namespace Inafocam.core.Modelos
{
    public partial class ScholarshipProgramTracingPractice
    {
        public long Id { get; set; }
        public long? TracingId { get; set; }
        public long? ActivityTypeId { get; set; }
        public string Coordinator { get; set; }
        public string Superviser { get; set; }
        public string Teacher { get; set; }
        public string Periodicity { get; set; }
        public string CreationDate { get; set; }
        public string UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual ActivityType ActivityType { get; set; }
        public virtual Status Status { get; set; }
        public virtual ScholarshipProgramTracing Tracing { get; set; }
    }
}
