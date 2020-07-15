using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Seguimientos.Models
{
    public class ProgramaDeBecasMateriaUniversitariaModelView
    {
        public long ScholarshipProgramUniversitySubjectMatterId { get; set; }
        public long ScholarshipProgramUniversityId { get; set; }
        public long? SubjectMatterId { get; set; }
        public long? TeacherId { get; set; }
        public long? PredictedTeacherId { get; set; }
        public int? SubjectMatterCredits { get; set; }
        public long? CreationUserId { get; set; }
        public long? UpgradeUserId { get; set; }
        public long? StatusId { get; set; }

        public virtual Teacher PredictedTeacher { get; set; }
        public virtual ScholarshipProgramUniversity ScholarshipProgramUniversity { get; set; }
        public virtual Status Status { get; set; }
        public virtual SubjectMatter SubjectMatter { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
