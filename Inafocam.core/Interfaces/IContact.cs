using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IContact
    {
        IQueryable<Contact> GetAll { get; }

        Contact GetById(int id);

        void Save(Contact model);
    }
}
