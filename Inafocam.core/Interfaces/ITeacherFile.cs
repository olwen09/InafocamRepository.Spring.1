using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface ITeacherFile
    {
        IEnumerable<TeacherFile> GetAll { get; }

        TeacherFile GetById(int id);


        IEnumerable<TeacherFile> GetByTeacherId(int id);

        void Save(TeacherFile model);

       void Delete(long teacherFileId);
    }
}
