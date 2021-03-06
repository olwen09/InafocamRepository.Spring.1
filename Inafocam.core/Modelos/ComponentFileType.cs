﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Modelos
{
    public partial class ComponentFileType
    {
        public int ComponentFileTypeId { get; set; }
        public string ComponentFileTypeName { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpgradeDate { get; set; }
        public long? StatusId { get; set; }
        public virtual Status Status { get; set; }

    }
}
