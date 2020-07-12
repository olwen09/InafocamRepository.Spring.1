using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Models
{
    public class UserUniversityModel
    {
        public long UserUniversityId { get; set; }
        public string UsuarioId { get; set; }
        public long? UniversityId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? UserCreationId { get; set; }
        public long? UserUpgradeId { get; set; }
        public long? StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual University University { get; set; }
    }
}
