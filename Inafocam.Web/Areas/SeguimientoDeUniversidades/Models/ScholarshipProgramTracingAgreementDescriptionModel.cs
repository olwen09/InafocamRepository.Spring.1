using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class ScholarshipProgramTracingAgreementDescriptionModel
    {
        public long ScholarshipProgramTracingAgreementDescriptionId { get; set; }

        public long? ScholarshipProgramTracingId { get; set; }
        public long? ScholarshipProgramUniversityAgreementId { get; set; }
        public string ScholarshipProgramTracingAgreementDescription1 { get; set; }
        public string ScholarshipProgramTracingAgreementDescription2 { get; set; }
        public string ScholarshipProgramTracingAgreementDescription3 { get; set; }

        [MaxLength(60)]
        public string CommentedUserId { get; set; }

        [MaxLength(60)]
        public string CreationUserId { get; set; }

        [MaxLength(60)]
        public string UpgradeUserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual Usuario CommentedUser { get; set; }
        public virtual Usuario CreationUser { get; set; }
        public virtual ScholarshipProgramTracing ScholarshipProgramTracing { get; set; }
        public virtual ScholarshipProgramUniversityAgreement ScholarshipProgramUniversityAgreement { get; set; }
        public virtual Status Status { get; set; }
        public virtual Usuario UpgradeUser { get; set; }
    }
}
