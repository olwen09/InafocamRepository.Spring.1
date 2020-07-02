﻿using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
  public interface IUniversity
    {
        IQueryable<University> Universities { get; }

        University GetById(int id);

        void  Save(University data);
    }
}
