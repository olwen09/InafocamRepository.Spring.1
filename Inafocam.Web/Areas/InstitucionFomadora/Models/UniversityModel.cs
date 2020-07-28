using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.InstitucionFomadora.Models
{
    public class UniversityModel
    {
        public long? UniversityId { get; set; }

        [Required(ErrorMessage ="El {0} es requerido")]
        [Display(Name ="nombre de la universidad")]
        public string UniversityName { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name ="nombre de la universidad")]
        public string UniversityAcronym { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Campus de la universidad")]
        public string UniversityCampus { get; set; }
        public long? AddressId { get; set; }
        public long? CommunicationId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Estado")]
        public long? StatusId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Communication Communication { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<ScholarshipProgramTracing> ScholarshipProgramTracing { get; set; }
        public virtual ICollection<ScholarshipProgramUniversity> ScholarshipProgramUniversity { get; set; }
        public virtual ICollection<UserUniversity> UserUniversity { get; set; }

    }
}
