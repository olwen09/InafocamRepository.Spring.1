using Inafocam.core.Modelos;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.ConvocatoriaDeBecas.Models
{
    public class ScholarshipProgramUniversityModel
    {
        public long? ScholarshipProgramUniversityId { get; set; }

        [Required (ErrorMessage ="El {0} es requerido")]
        [Display(Name ="Nivel escolar")]
        public long? ScholarshipLevelId { get; set; }

        [Required (ErrorMessage = "El {0} es requerido")]
        [Display(Name ="Programa de beca ")]
        public long? ScholarshipProgramId { get; set; }

        [Required(ErrorMessage ="La Universidad es requerida")]
        public long? UniversityId { get; set; }
        public long? ScatProgramId { get; set; }

        [Required]
        public string ScatProgramCode { get; set; }

        public int? ActiveStudents { get; set; }

        [Required]
        public string ContractNumber { get; set; }

        [Required (ErrorMessage ="El {0} es requerido")]
        [Display(Name = "Coordinador")]
        public long? CoordinatorId { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Técnico")]
        public long? TechnicalId { get; set; }

        [Required]
        public DateTime? AnnouncementStartDate { get; set; }

        [Required]
        public DateTime? AnnouncementEndDate { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual Agent Coordinator { get; set; }
        public virtual ScholarshipLevel ScholarshipLevel { get; set; }
        public virtual ScholarshipProgram ScholarshipProgram { get; set; }
        public virtual Status Status { get; set; }
        public virtual Agent Technical { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<ScholarshipProgramTracing> ScholarshipProgramTracing { get; set; }
        public virtual ICollection<ScholarshipProgramUniversityAgent> ScholarshipProgramUniversityAgent { get; set; }
        public virtual ICollection<ScholarshipProgramUniversityAgreement> ScholarshipProgramUniversityAgreement { get; set; }
        public virtual IEnumerable<TracingStudyPlanDevelopment> TracingStudyPlanDevelopmentList { get; set; }
        public virtual ICollection<ScholarshipProgramUniversitySubjectMatter> ScholarshipProgramUniversitySubjectMatter { get; set; }
    }
}
