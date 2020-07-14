using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
  public  interface IScholarshipProgramTracingCourseFileType
    {
        IEnumerable<ScholarshipProgramTracingCourseFileType> GetAll { get; }
    }
}
