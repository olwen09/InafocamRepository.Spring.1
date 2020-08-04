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
        IEnumerable<ScholarshipProgramUniversityAgreement> GetAllPendingAndActiveByScholarshipProgramUniversityId(int id);

        void CambiarEstado(long agremmentId,string estado);
        ScholarshipProgramUniversityAgreement GetById(int agremmentId);

        void Save(ScholarshipProgramUniversityAgreement model);
    }
}
