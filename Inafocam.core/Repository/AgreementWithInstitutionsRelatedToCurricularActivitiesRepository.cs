using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class AgreementWithInstitutionsRelatedToCurricularActivitiesRepository : IAgreementWithInstitutionsRelatedToCurricularActivities
    {
        private readonly inafocam_tracingContext _context;

        public AgreementWithInstitutionsRelatedToCurricularActivitiesRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<AgreementWithInstitutionsRelatedToCurricularActivities> GetAll => _context.AgreementWithInstitutionsRelatedToCurricularActivities
            .Include(x => x.Tracing)
            .Include(x => x.Status);

        public IEnumerable<AgreementWithInstitutionsRelatedToCurricularActivities> GetAllByTracingId(int tracingId)
        {
            return GetAll.Where(x => x.TracingId == tracingId);
        }

        public AgreementWithInstitutionsRelatedToCurricularActivities GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.AgreementWithInstitutionsRelatedToCurricularActivitiesId == id);
        }

        public void Save(AgreementWithInstitutionsRelatedToCurricularActivities model)
        {
            var now = DateTime.Now;
            

            if (model.AgreementWithInstitutionsRelatedToCurricularActivitiesId != 0)
            {
                model.UpgradeDate = now;

                _context.AgreementWithInstitutionsRelatedToCurricularActivities.Update(model);
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

