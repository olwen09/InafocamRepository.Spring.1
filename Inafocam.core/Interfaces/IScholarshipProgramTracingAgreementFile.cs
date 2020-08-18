using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public  interface IScholarshipProgramTracingAgreementFile
    {
        IEnumerable<ScholarshipProgramTracingAgreementFile> GetAll { get; }
       public IEnumerable<ScholarshipProgramTracingAgreementFile> GetAllByscholarshipPogramTracingAgreementId(int id);

        void Save(ScholarshipProgramTracingAgreementFile model);

        void Delete(long evidenceId);
    }
}
