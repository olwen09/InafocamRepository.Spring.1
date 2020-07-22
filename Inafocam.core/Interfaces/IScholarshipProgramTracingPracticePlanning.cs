using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingPracticePlanning
    {
        IEnumerable<ScholarshipProgramTracingPracticePlanning> GetAll { get; }
        IEnumerable<ScholarshipProgramTracingPracticePlanning> GetAllByTracingId(long tracingId);

        public ScholarshipProgramTracingPracticePlanning GetOneByActionType(long actionTypeId);

        void Save(ScholarshipProgramTracingPracticePlanning model);


    }
}
