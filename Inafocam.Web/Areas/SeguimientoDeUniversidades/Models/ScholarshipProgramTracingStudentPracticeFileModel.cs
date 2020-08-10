using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ScholarshipProgramTracingStudentPracticeFileModel
    {
        public long ScholarshipProgramTracingStudentPracticeFileId { get; set; }

        public long? ScholarshipProgramTracingStudentPracticeId { get; set; }
        public long? StudentPracticeTypeId { get; set; }
        public string FileDescription { get; set; }
        public long? FileId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual ScholarshipProgramTracingStudentPractice ScholarshipProgramTracingStudentPractice { get; set; }
        public virtual File File { get; set; }
        public virtual Status Status { get; set; }
    }
}
