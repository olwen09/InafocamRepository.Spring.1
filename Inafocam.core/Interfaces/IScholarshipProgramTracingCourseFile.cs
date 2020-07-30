using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingCourseFile
    {
        IEnumerable<ScholarshipProgramTracingCourseFile> GetAll { get; }
        public IEnumerable<ScholarshipProgramTracingCourseFile> GetAllByCourseIdAndTracingId(int tracingId, int courseId);

        public ScholarshipProgramTracingCourseFile CheckIfTheFileExits(long? fileTypeId, long? CourseId);
        
        void Save(ScholarshipProgramTracingCourseFile model);
    }
}
