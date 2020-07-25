using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Profesores.Models
{
    public class TeacherModel
    {
        public long? TeacherId { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Document { get; set; }



        public long? ContactId { get; set; }


        public long? HigherTeacherEducationId { get; set; }



        [Required (ErrorMessage = "El tipo de contratación es requerido")]
        public long? TeacherHiringTypeId { get; set; }


        [Required]
        public string TeacherCategory { get; set; }

        [Required]
        public DateTime? TeacherJobStartDate { get; set; }
   
        [Required (ErrorMessage = "El campo,es  profesor de alta calificación?, es requerido")]
        public short? TeacherIsPac { get; set; }

        [Required(ErrorMessage = "El campo,tiene funciones administrativas?, es requerido")]
        public short? TeacherHasAdminFunctions { get; set; }

        [Required(ErrorMessage = "El campo,labora en otras instituciones de educación superior?, es requerido")]
        public short? TeacherWorkForOtherInstitutions { get; set; }
    
        public short? TeacherMatchHigherTitle { get; set; }
        [Required]
        public int? TeacherResearchProcess { get; set; }
        [Required]
        public int? TeacherResearchPublished { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual TeacherEducation HigherTeacherEducation { get; set; }
        public virtual Status Status { get; set; }
        public virtual TeacherHiringType TeacherHiringType { get; set; }
        public virtual ICollection<ScholarshipProgramUniversitySubjectMatter> ScholarshipProgramUniversitySubjectMatterPredictedTeacher { get; set; }
        public virtual ICollection<ScholarshipProgramUniversitySubjectMatter> ScholarshipProgramUniversitySubjectMatterTeacher { get; set; }
        public virtual ICollection<TeacherEducation> TeacherEducation { get; set; }
        public virtual ICollection<TeacherFile> TeacherFile { get; set; }
        public virtual ICollection<TeacherResearch> TeacherResearch { get; set; }
        public virtual ICollection<TracingStudyPlanDevelopment> TracingStudyPlanDevelopmentAssignedTeacher { get; set; }
        public virtual ICollection<TracingStudyPlanDevelopment> TracingStudyPlanDevelopmentTeacher { get; set; }
    }
}
