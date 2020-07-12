using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IScholarshipProgramUniversityAgreement
    {
        IEnumerable<ScholarshipProgramUniversityAgreement> GetAll { get; }

        IEnumerable<ScholarshipProgramUniversityAgreement> GetAllByScholarshipProgramUniversityId(int id);

        void Save(ScholarshipProgramUniversityAgreement model);
    }
}
