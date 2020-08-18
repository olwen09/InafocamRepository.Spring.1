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
    public class TracingStudyPlanDevelopmentRepository : ITracingStudyPlanDevelopment
    {
        private readonly inafocam_tracingContext _context;

        public TracingStudyPlanDevelopmentRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<TracingStudyPlanDevelopment> GetAll => _context.TracingStudyPlanDevelopment
            .Include(x => x.Teacher)
            .Include(x => x.Teacher.Contact)
            .Include(x => x.AssignedTeacher)
            .Include(x => x.AssignedTeacher.Contact)
            .Include(x => x.ScholarshipProgramTracing)
            .Include(x => x.Status)
            .Include(x => x.AssignedTeacher)
            .Include(x => x.SubjectMatterScoreReportFile)
            .Include(x => x.StudentReportFile);

        public IEnumerable<TracingStudyPlanDevelopment> GetAllByProgramTracingId(int id)
        {
            return GetAll.Where(x => x.ScholarshipProgramTracingId == id);
        }

        public IEnumerable<TracingStudyPlanDevelopment> GetAllByscholarshipProgramUniversityId(int id)
        {
            return GetAll.Where(x => x.ScholarshipProgramTracingId == id);
        }

        public TracingStudyPlanDevelopment GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.Id == id);
        }

        public long? GetUniversityId(int id)
        {
            return GetById(id).ScholarshipProgramTracing.UniversityId;
        }

        public void Save(TracingStudyPlanDevelopment model)
        {
            var now = DateTime.Now;

            if(model.Id != 0)
            {
                model.UpgradeDate = now;
                _context.TracingStudyPlanDevelopment.Update(model);
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
