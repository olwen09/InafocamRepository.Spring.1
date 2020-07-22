using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Modelos
{
   public class ActionType
    {
        public long ActionTypeId { get; set; }
        public string ActionTypeName { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
