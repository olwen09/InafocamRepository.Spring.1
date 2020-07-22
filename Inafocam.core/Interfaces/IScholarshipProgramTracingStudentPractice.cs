using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingStudentPractice
    {
        IEnumerable<ScholarshipProgramTracingStudentPractice> GetAll { get; }
        IEnumerable<ScholarshipProgramTracingStudentPractice> GetAllByTracingId(long tracingId);

        public ScholarshipProgramTracingStudentPractice GetOneByStudentPracticeTypeId(long id);


        void Save(ScholarshipProgramTracingStudentPractice model);
    }
}
