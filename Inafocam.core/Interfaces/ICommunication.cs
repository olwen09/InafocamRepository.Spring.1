using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public  interface ICommunication
    {
        IQueryable<Communication> GetAll { get; }

        Communication GetById(int id);
    }
}
