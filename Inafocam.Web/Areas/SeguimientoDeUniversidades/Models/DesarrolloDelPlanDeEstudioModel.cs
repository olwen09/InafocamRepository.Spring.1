using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class DesarrolloDelPlanDeEstudioModel
    {
        public int TracingId { get; set; }
        public int ScholarshipProgramUniversityId { get; set; }
        public bool IsGestionUniversitariaRole { get; set; }

        public long? UniversityId { get; set; }
        public TracingStudyPlanDevelopment TracingStudyPlanDevelopmentModel { get; set; }
        public SubjectMatter SubjectMatterModel { get; set; }
        public IEnumerable<SubjectMatter> subjectMatterList { get; set; }
        public IEnumerable<TracingStudyPlanDevelopment> TracingStudyPlanDevelopmentModelList { get; set; }
        public IEnumerable<TracingStudyPlanDevelopment> TracingStudyPlanDevelopmentList { get; set; }

    }

    public class TeacherIDAndName
    {
        public long  TeacherId { get; set; }

        public string  TeacherFullName { get; set; }
}

}
