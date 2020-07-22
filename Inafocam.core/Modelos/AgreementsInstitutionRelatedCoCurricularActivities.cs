using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inafocam.core.Modelos
{
   public class AgreementsInstitutionRelatedCoCurricularActivities
    {
        [Key]
        public int AgreementsInstitutionRelatedCoCurricularActivitiesId { get; set; }

        public string Institution { get; set; }
        public string ActivityDescription { get; set; }

        public DateTime? Date { get; set; }

        public string Duration { get; set; }

        public int? NumberOfParticipatingStudents { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }

        public int? TracingId { get; set; }

        public int? StatusId { get; set; }

        public virtual Status Status { get; set; }

        public virtual ScholarshipProgramTracing Tracing { get; set; }
    }
}
