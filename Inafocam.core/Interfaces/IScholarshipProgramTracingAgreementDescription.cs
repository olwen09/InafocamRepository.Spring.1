using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
    public interface IScholarshipProgramTracingAgreementDescription
    {
        IEnumerable<ScholarshipProgramTracingAgreementDescription> GetAll { get; }

        IEnumerable<ScholarshipProgramTracingAgreementDescription> GetAllByScholarshipProgramUniversityId(int id);

        void Save(ScholarshipProgramTracingAgreementDescription model);
    }
}
