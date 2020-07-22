using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Modelos
{
  public  class ActivityType
    {
        public long ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
