using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Profesores.Models
{
    public class ContactAddressModel
    {
        public long ContactAddressId { get; set; }
        public long? ContactId { get; set; }
        public long? AddressId { get; set; }
        public long? TeacherId { get; set; }
        [Required]
        public string ContactAddressComment { get; set; }
        public string TeacherFullName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public IEnumerable<ContactAddress> ContactAddressList { get; set; }
        public virtual AddressModel Address { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Status Status { get; set; }
    }
}
