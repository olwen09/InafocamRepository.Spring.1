using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramTracingAgreementsWithPracticeCenter
    {
        IEnumerable<ScholarshipProgramTracingAgreementsWithPracticeCenter> GetAll { get; }
        public IEnumerable<ScholarshipProgramTracingAgreementsWithPracticeCenter> GetAllByTracingId(int tracingId);

        public ScholarshipProgramTracingAgreementsWithPracticeCenter GetById(int id);

        void Save(ScholarshipProgramTracingAgreementsWithPracticeCenter model);
    }
}
