﻿using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
   public class ScholarshipProgramUniversityRepository : IScholarshipProgramUniversity
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramUniversityRepository(inafocam_tracingContext context)
        {
            _context = context;
        }
        public IQueryable<ScholarshipProgramUniversity> ScholarshipProgramUniversity => _context.ScholarshipProgramUniversity
            .Include(x => x.Coordinator)
            .Include(x => x.ScholarshipLevel)
            .Include(x => x.ScholarshipProgram)
            .Include(x => x.Status)
            .Include(x => x.Technical)
            .Include(x => x.Technical.AgentType)
            .Include(x => x.University)
            .Include(x => x.ScholarshipProgramTracing)
            .Include(x => x.ScholarshipProgramUniversityAgent)
            .Include(x => x.ScholarshipProgramUniversityAgreement)
            //.Include(x => x.ScholarshipProgramUniversityAgreement.Select(x=> x.AgreementType))
            .Include(x => x.ScholarshipProgramUniversitySubjectMatter);

       

        public ScholarshipProgramUniversity GetById(int id)
        {
            return ScholarshipProgramUniversity.FirstOrDefault(x=> x.ScholarshipProgramUniversityId == id);
        }

        public IQueryable<ScholarshipProgramUniversity> GetProgramUniversityByUniversityId(int universityId)
        {
            return ScholarshipProgramUniversity.Where(x => x.UniversityId == universityId);
        }

        public ScholarshipProgramUniversity GetUniversityByScholarshipProgramUniversity(int id)
        {
            return ScholarshipProgramUniversity.FirstOrDefault(x=> x.ScholarshipProgramUniversityId == id);
        }

        public long? GetUniversityIdByScholarshipProgramUniversityId(long? ScholarshipProgramUniversityId)
        {
            return ScholarshipProgramUniversity.FirstOrDefault(x => x.ScholarshipProgramUniversityId == ScholarshipProgramUniversityId).UniversityId;
        }

        public void Save(ScholarshipProgramUniversity model)
        {
            var now = DateTime.Now;

            if(model.ScholarshipProgramUniversityId != 0)
            {
                model.UpgradeDate = now;
                _context.ScholarshipProgramUniversity.Update(model);
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
