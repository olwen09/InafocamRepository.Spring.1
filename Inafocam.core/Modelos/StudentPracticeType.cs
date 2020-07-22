using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Modelos
{
   public class StudentPracticeType
    {
        public int StudentPracticeTypeId { get; set; }
        public string StudentPracticeTypeTypeName { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
