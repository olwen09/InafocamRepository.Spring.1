using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Representantes.Models
{
    public class AgentModel
    {
        public long? AgentId { get; set; }

        [Required(ErrorMessage ="El {0} es requerido")]
        [Display(Name ="Tipo de agente")]
        public long? AgentTypeId { get; set; }
        public long? UserId { get; set; }
        public long? ContactId { get; set; }
        public long? CreationUserId { get; set; }
        public long? UpgradeUserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual ContactModel Contact { get; set; }
        public virtual AgentType AgentType { get; set; }
        public virtual User CreationUser { get; set; }
        public virtual Status Status { get; set; }
        public virtual User UpgradeUser { get; set; }
        public virtual User User { get; set; }
        //public virtual ContactCommunicationModel ContactCommunication { get; set; }
        public virtual ICollection<ScholarshipProgramTracing> ScholarshipProgramTracingCoordinator { get; set; }
        public virtual ICollection<ScholarshipProgramTracing> ScholarshipProgramTracingTechnical { get; set; }
        public virtual ICollection<ScholarshipProgramUniversityAgent> ScholarshipProgramUniversityAgent { get; set; }
        public virtual ICollection<ScholarshipProgramUniversity> ScholarshipProgramUniversityCoordinator { get; set; }
        public virtual ICollection<ScholarshipProgramUniversity> ScholarshipProgramUniversityTechnical { get; set; }
    }
}
