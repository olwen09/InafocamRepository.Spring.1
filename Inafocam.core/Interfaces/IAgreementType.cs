﻿using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IAgreementType
    {
        IQueryable<AgreementType> GetAll { get; }

       
    }
}
