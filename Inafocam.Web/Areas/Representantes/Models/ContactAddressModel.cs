using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Representantes.Models
{
    public class ContactAddressModel
    {
        public long? ContactAddressId { get; set; }
        public long? ContactId { get; set; }
        public long? AddressId { get; set; }
        public string ContactAddressComment { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual AddressModel Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Status Status { get; set; }
    }
}
