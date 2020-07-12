using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
  public  interface IScholarshipProgramTracingStudentSupport
    {
         IEnumerable<ScholarshipProgramTracingStudentSupport> GetAll { get; }


        ScholarshipProgramTracingStudentSupport GetById(int id);
        IEnumerable<ScholarshipProgramTracingStudentSupport> GetAllByTracingId(int id);

        void Save(ScholarshipProgramTracingStudentSupport model);
    }
}
