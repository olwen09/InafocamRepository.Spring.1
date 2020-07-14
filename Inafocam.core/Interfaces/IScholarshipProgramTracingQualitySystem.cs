using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingQualitySystem
    {
        IEnumerable<ScholarshipProgramTracingQualitySystem> GetAll { get; }
        public IEnumerable<ScholarshipProgramTracingQualitySystem> GetAllByTracingId(int tracingId);

        void Save(ScholarshipProgramTracingQualitySystem model);
    }
}
