using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
  public  interface ITeacherEducation
    {
        IQueryable<TeacherEducation> GetAll { get; }

        public IEnumerable<TeacherEducation> GetAllByTeacherId(int teacherId);

        TeacherEducation GetById(int id);

        void Save(TeacherEducation model);
        
    }
}
