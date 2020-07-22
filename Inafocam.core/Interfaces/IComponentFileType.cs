using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
  public  interface IComponentFileType
    {
        IEnumerable<ComponentFileType> GetAll { get; }

        void Save(ComponentFileType model);

    }
}
