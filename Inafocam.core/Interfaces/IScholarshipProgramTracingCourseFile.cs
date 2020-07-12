using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingCourseFile
    {
        IEnumerable<ScholarshipProgramTracingCourseFile> GetAll { get; }

        void Save(ScholarshipProgramTracingCourseFile model);
    }
}
