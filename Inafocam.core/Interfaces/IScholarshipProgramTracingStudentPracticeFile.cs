using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingStudentPracticeFile
    {
        IEnumerable<ScholarshipProgramTracingStudentPracticeFile> GetAll { get; }

        IEnumerable<ScholarshipProgramTracingStudentPracticeFile> GetAllByPracticeId(long practiceId , long practiceTypeId);

        void Save(ScholarshipProgramTracingStudentPracticeFile model);

        void Delete(long studentPracticeFileId);
    }
}
