using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ScholarshipProgramTracingAgreementRepository : IScholarshipProgramTracingAgreement
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingAgreementRepository(inafocam_tracingContext context)
        {
            _context = context;
        }
        public IEnumerable<ScholarshipProgramTracingAgreement> GetAll => _context.ScholarshipProgramTracingAgreement
            .Include(x => x.ScholarshipProgramTracing)
            .Include(x => x.ScholarshipProgramUniversityAgreement)
            .Include(x => x.Status);

        public IEnumerable<ScholarshipProgramTracingAgreement> GetAllByScholarshipProgramUniversityId(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(ScholarshipProgramTracingAgreement model)
        {
            var now = DateTime.Now;
            if(model.ScholarshipProgramTracingAgreementId != 0)
            {
                model.UpgradeDate= now;
                _context.ScholarshipProgramTracingAgreement.Update(model);
            }
            else
            {
                model.CreationDate = now;
                model.StatusId = StatusValues.Activo;
                _context.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
