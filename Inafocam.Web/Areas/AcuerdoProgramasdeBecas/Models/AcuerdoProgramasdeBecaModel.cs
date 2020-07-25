using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.AcuerdoProgramasdeBecas.Models
{
    public class AcuerdoProgramasdeBecaModel
    {
        public long ScholarshipProgramUniversityId { get; set; }
        public long? ScholarshipLevelId { get; set; }
        public long? ScholarshipProgramId { get; set; }
        public long? UniversityId { get; set; }


        [Required(ErrorMessage ="El {0} es requerido")]
        [Display(Name ="Tipo de acuerdo")]
        public int AgreementId { get; set; }


        [Required]
        public string ScholarshipProgramUniversityAgreement1 { get; set; }
        public long? ScatProgramId { get; set; }
        public string ScatProgramCode { get; set; }
        public int? ActiveStudents { get; set; }
        public string ContractNumber { get; set; }
        public long? CoordinatorId { get; set; }
        public long? TechnicalId { get; set; }
        [Display(Name = "Fecha de Inicio")]
        public DateTime? AnnouncementStartDate { get; set; }
        [Display(Name = "Fecha de Inicio")]
        public DateTime? AnnouncementEndDate { get; set; }
        [Display(Name = "Fecha de Inicio")]
        public DateTime? StartDate { get; set; }

        [Display(Name ="Fecha de Termino")]
        public DateTime? EndDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }

        public long? StatusId { get; set; }

        public virtual Agent Coordinator { get; set; }
        public virtual ScholarshipLevel ScholarshipLevel { get; set; }
        public virtual ScholarshipProgram ScholarshipProgram { get; set; }
        public virtual Status Status { get; set; }
        public virtual Agent Technical { get; set; }
        public virtual ScholarshipProgramUniversityAgreement Agreement { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<ScholarshipProgramTracing> ScholarshipProgramTracing { get; set; }
        public virtual ICollection<ScholarshipProgramUniversityAgent> ScholarshipProgramUniversityAgent { get; set; }
        public virtual ICollection<ScholarshipProgramUniversityAgreement> ScholarshipProgramUniversityAgreement { get; set; }
        public virtual ICollection<ScholarshipProgramUniversitySubjectMatter> ScholarshipProgramUniversitySubjectMatter { get; set; }
    }
}
