using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Representantes.Models
{
    public class ContactCommunicationModel
    {
        public long? ContactCommunicationId { get; set; }
        public long? ContactId { get; set; }
        public long? CommunicationId { get; set; }

        [Required]
        public string ContactCommunicationComment { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual CommunicationModel Communication { get; set; }
        public virtual ContactModel Contact { get; set; }
        public virtual Status Status { get; set; }
    }
}
