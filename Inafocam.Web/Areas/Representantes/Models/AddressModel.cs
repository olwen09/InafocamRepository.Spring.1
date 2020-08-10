using Inafocam.core.Modelos;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Representantes.Models
{
    public class AddressModel
    {
        public long? AddressId { get; set; }
        public long? AddressTypeId { get; set; }

        [Required (ErrorMessage = "El {0} es requerido")]
        [Display (Name="Pais")]
        public long? CountryId { get; set; }
        public long? ProvinceId { get; set; }
        public long? CityId { get; set; }

        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required]
        public string HomeNumber { get; set; }
        public long? CreationUserId { get; set; }
        public long? UpgradeUserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual City City { get; set; }
        public virtual User CreationUser { get; set; }
        public virtual Province Province { get; set; }
        public virtual Status Status { get; set; }
        public virtual User UpgradeUser { get; set; }
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<ContactAddress> ContactAddress { get; set; }
        public virtual ICollection<Office> Office { get; set; }
        public virtual ICollection<University> University { get; set; }
    }
}
