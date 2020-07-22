using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingPractice
    {
        IEnumerable<ScholarshipProgramTracingPractice> GetAll { get; }

        public IEnumerable<ScholarshipProgramTracingPractice> GetAllByTracingId(int traingId);

        public ScholarshipProgramTracingPractice GetOneByActivityTypeId(int activityTypeId);
        void Save(ScholarshipProgramTracingPractice model);
    }
}
