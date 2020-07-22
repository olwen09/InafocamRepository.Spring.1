using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
  public  interface IAgreementWithInstitutionsRelatedToCurricularActivities
    {
        IEnumerable<AgreementWithInstitutionsRelatedToCurricularActivities> GetAll { get; }
        public IEnumerable<AgreementWithInstitutionsRelatedToCurricularActivities> GetAllByTracingId(int tracingId);

        public AgreementWithInstitutionsRelatedToCurricularActivities GetById(int id);

        void Save(AgreementWithInstitutionsRelatedToCurricularActivities model);
    }
}
