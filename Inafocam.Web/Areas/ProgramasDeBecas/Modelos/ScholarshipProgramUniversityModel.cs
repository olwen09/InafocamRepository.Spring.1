using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.ProgramasDeBecas.Modelos
{
    public class ScholarshipProgramUniversityModel
    {
        public long ScholarshipProgramUniversityId { get; set; }
        public long? ScholarshipLevelId { get; set; }
        public long? ScholarshipProgramId { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [Display(Name ="Universidad")]
        public long? UniversityId { get; set; }
        public long? ScatProgramId { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "código Scat")]
        public string ScatProgramCode { get; set; }
        public int? ActiveStudents { get; set; }
        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "número de contrato")]
        public string ContractNumber { get; set; }
        public long? CoordinatorId { get; set; }
        public long? TechnicalId { get; set; }

        [Required (ErrorMessage ="La {0} es requerida")]
        [Display(Name = "Fecha de inicio del anuncio")]
        public DateTime? AnnouncementStartDate { get; set; }
        [Required(ErrorMessage = "La {0} es requerida")]
        [Display(Name = "Fecha de finalizacióndel anuncio")]
        public DateTime? AnnouncementEndDate { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [Display(Name = "Fecha de inicio")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [Display(Name = "Fecha de finalización")]
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
        public virtual ICollection<ScholarshipProgramUniversitySubjectMatter> ScholarshipProgramUniversitySubjectMatter { get; set; }
    }
}
