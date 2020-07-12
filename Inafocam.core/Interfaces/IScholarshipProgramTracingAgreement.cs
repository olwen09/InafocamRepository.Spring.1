using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingAgreement
    {
        IEnumerable<ScholarshipProgramTracingAgreement> GetAll { get;}

        IEnumerable<ScholarshipProgramTracingAgreement> GetAllByScholarshipProgramUniversityId(int id);

        void Save(ScholarshipProgramTracingAgreement model);
    }
}
