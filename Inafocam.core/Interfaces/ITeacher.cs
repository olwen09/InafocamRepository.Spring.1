using Inafocam.core.Modelos;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface ITeacher
    {
        IQueryable<Teacher> GetAll { get; }
        public IQueryable<Teacher> GetTeachersByUSerUniversityId(long? userUniversityId);

        Teacher GetById(int id);
        
        int GetContactId(int id);



        void Save(Teacher model);
    }
}
