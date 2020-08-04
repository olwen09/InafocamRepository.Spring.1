using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingStudentPracticeFile
    {
        IEnumerable<ScholarshipProgramTracingStudentPracticeFile> GetAll { get; }

        IEnumerable<ScholarshipProgramTracingStudentPracticeFile> GetAllByPracticeId(long practiceId);

        void Save(ScholarshipProgramTracingStudentPracticeFile model);
    }
}
