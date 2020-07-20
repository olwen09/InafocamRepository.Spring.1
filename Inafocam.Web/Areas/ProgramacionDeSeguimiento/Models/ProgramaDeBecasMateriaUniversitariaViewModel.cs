using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.ProgramacionDeSeguimiento.Models
{
    public class ProgramaDeBecasMateriaUniversitariaViewModel
    {

        public int TracingId { get; set; }
        public int ProgramUniversityId { get; set; }
        public int SubjectMatterCredits{ get; set; }
        public TracingStudyPlanDevelopmentModel TracingStudyPlanDevelopmentModel { get; set; }
        public ScholarshipProgramUniversitySubjectMatterModel ScholarshipProgramUniversitySubjectMatterModel { get; set; }
        public IEnumerable<TracingStudyPlanDevelopment> TracingStudyPlanDevelopmentList { get; set; }
    }

    public class SubjectMatterProp
    {
        public long SubjectMatterId { get; set; }
        public string SubjectMatterName { get; set; }
        public string SubjectMatterCode { get; set; }
    }

    public class TeacherInfo
    {
        public long TeacherId { get; set; }
        public string TeacherFullName { get; set; }
    }
}
