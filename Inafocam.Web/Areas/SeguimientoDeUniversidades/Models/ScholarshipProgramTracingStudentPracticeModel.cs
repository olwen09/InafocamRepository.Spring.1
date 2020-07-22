using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ScholarshipProgramTracingStudentPracticeModel
    {
        public long Id { get; set; }
        public long? TracingId { get; set; }
        public int? StudentPracticeTypeId { get; set; }
        public int? StudentsQuantity { get; set; }
        public int? PracticeCenterQuantity { get; set; }
        public int? SupervisorQuantity { get; set; }
        public int? TeacherQuantity { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }


        public virtual StudentPracticeType StudentPracticeType { get; set; }
        public virtual Status Status { get; set; }
        public virtual ScholarshipProgramTracing Tracing { get; set; }
    }
}
