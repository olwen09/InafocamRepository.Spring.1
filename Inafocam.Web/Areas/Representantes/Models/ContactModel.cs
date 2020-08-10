using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Representantes.Models
{
    public class ContactModel
    {
        public long? ContactId { get; set; }

        [Required(ErrorMessage ="El {0} es requerido")]
        [Display(Name ="Tipo de documento")]
        public long? DocumentTypeId { get; set; }

        public long? ContactCommunicationId { get; set; }

        [Required]
        public string ContactDocumentNumber { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ContactLastname { get; set; }
        public string ContactGender { get; set; }

        [Required (ErrorMessage ="El {0} es requerido")]
        [Display(Name ="Tipo de contacto")]
        public long? ContactTypeId { get; set; }

        //[Required]
        public string ContactComment { get; set; }

        [Required]
        public DateTime? ContactBornDate { get; set; }

        [Required]
        public string ContactBornPlace { get; set; }
        public long? ContactNationalityId { get; set; }


        [MaxLength(50)]
        [Required]
        public string Nationality { get; set; }
        public long? ContactMaritalStatusId { get; set; }
        public long? ContactJobInformationId { get; set; }
        public long? CreationUserId { get; set; }
        public long? UpgradeUserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual ContactCommunicationModel ContactCommunication { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual User CreationUser { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual Status Status { get; set; }
        public virtual User UpgradeUser { get; set; }
        public virtual ICollection<Company> Company { get; set; }
        public virtual ContactAddressModel ContactAddres { get; set; }
        //public virtual ICollection<ContactAddress> ContactAddress { get; set; }
        //public virtual ContactCommunication ContactCommunicatio { get; set; }
        public virtual ICollection<ContactCommunication> ContactCommunicationList { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
