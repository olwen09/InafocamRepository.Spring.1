using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Materias.Models
{
    public class SubjectMatterModel
    {
    
        public long SubjectMatterId { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Codigo")]
        public string SubjectMatterCode { get; set; }
        [Required(ErrorMessage = "El {0} es requerido")]
        public string SubjectMatterName { get; set; }
        [Required]
        public string period { get; set; }
        [Required]
        public long? Creditos { get; set; }
        public long? CreationUserId { get; set; }
        public long? UpgradeUserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }
        public long? ScholarshipProgramUniversityId { get; set; }
        public long? TracingStudyPlanDevelopmentId { get; set; }


        public virtual User CreationUser { get; set; }
        public virtual Status Status { get; set; }
        public virtual User UpgradeUser { get; set; }

       
        public virtual ScholarshipProgramUniversity ScholarshipProgramUniversity { get; set; }

      
        public virtual TracingStudyPlanDevelopment TracingStudyPlanDevelopment { get; set; }

        public virtual ICollection<ScholarshipProgramUniversitySubjectMatter> ScholarshipProgramUniversitySubjectMatter { get; set; }
    }
}
