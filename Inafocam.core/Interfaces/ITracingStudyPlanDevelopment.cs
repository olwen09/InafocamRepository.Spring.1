using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
  public  interface ITracingStudyPlanDevelopment
    {
        IEnumerable<TracingStudyPlanDevelopment> GetAll { get; }


        public TracingStudyPlanDevelopment GetById(int id);
        public IEnumerable<TracingStudyPlanDevelopment> GetAllByProgramTracingId(int id);
        public IEnumerable<TracingStudyPlanDevelopment> GetAllByscholarshipProgramUniversityId(int id);

        public long? GetUniversityId(int id);
        void Save(TracingStudyPlanDevelopment model);
        
    }
}
