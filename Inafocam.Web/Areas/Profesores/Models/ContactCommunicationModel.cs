using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Profesores.Models
{
    public class ContactCommunicationModel
    {
        public long ContactCommunicationId { get; set; }
        public long? ContactId { get; set; }
        public long? TeacherId { get; set; }

        public string TeacherFullName { get; set; }

        public long? CommunicationId { get; set; }

        [Required]
        public string ContactCommunicationComment { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public IEnumerable<ContactCommunication> CommunicationList { get; set; }
        public virtual Communication Communication { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Status Status { get; set; }
    }
}
