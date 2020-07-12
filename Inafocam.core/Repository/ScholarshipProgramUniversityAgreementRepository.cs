using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramUniversityAgreementRepository : IScholarshipProgramUniversityAgreement
    {

        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramUniversityAgreementRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramUniversityAgreement> GetAll => _context.ScholarshipProgramUniversityAgreement
            .Include(x => x.AgreementType)
            .Include(x => x.ScholarshipProgramUniversity)
            .Include(x => x.Status)
            .Include(x => x.ScholarshipProgramTracingAgreement)
            .Include(x => x.CreationUser)
            .Include(x => x.UpgradeUser);

        public IEnumerable<ScholarshipProgramUniversityAgreement> GetAllByScholarshipProgramUniversityId(int id)
        {
            return GetAll.Where(x => x.ScholarshipProgramUniversityId == id).ToList();
        }

        public void Save(ScholarshipProgramUniversityAgreement model)
        {
            var now = DateTime.Now;
            if(model.ScholarshipProgramUniversityAgreementId != 0)
            {
                model.UpgradeDate = now;
                _context.ScholarshipProgramUniversityAgreement.Update(model);
            }
            else
            {
                model.CreationDate = now;
                _context.Add(model);
            }
            _context.SaveChanges();

        }
    }
}
