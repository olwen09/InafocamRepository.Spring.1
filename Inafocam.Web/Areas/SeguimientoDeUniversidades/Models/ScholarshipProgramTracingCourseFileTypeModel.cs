using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ScholarshipProgramTracingCourseFileTypeModel
    {
        public long Id { get; set; }
        public string FileTypeName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual ICollection<ScholarshipProgramTracingCourseFile> ScholarshipProgramTracingCourseFile { get; set; }
    }
}
