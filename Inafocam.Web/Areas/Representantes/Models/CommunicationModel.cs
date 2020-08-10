using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Representantes.Models
{
    public class CommunicationModel
    {
        public long? CommunicationId { get; set; }

        [Required]
        public string CommunicationPhoneNumber1 { get; set; }
      
        [Required]
        public string CommunicationPhoneNumber2 { get; set; }

        [Required]
        public string CommunicationEmail { get; set; }
        
  
        public string CommunicationWebsite { get; set; }

        public long? CreationUserId { get; set; }
        public long? UpgradeUserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

   
        public virtual Status Status { get; set; }

    }
}
