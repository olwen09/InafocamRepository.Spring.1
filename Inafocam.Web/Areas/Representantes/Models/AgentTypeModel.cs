using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Representantes.Models
{
    public class AgentTypeModel
    {
        public long AgentTypeId { get; set; }

        [Required]
        public string AgentTypeName { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Agent> Agent { get; set; }
    }
}
