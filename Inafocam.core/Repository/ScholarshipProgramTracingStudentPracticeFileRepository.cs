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
    public class ScholarshipProgramTracingStudentPracticeFileRepository : IScholarshipProgramTracingStudentPracticeFile
    {
        private readonly inafocam_tracingContext _context;

        public ScholarshipProgramTracingStudentPracticeFileRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ScholarshipProgramTracingStudentPracticeFile> GetAll =>
            _context.ScholarshipProgramTracingStudentPracticeFile
            .Include(x => x.File)
            .Include(x => x.ScholarshipProgramTracingStudentPractice);

        public void Delete(long studentPracticeFileId)
        {
           var model = _context.ScholarshipProgramTracingStudentPracticeFile.Find(studentPracticeFileId);
            model.StatusId = StatusValues.Eliminado;

            _context.ScholarshipProgramTracingStudentPracticeFile.Update(model);

            _context.SaveChanges();
        }

        public IEnumerable<ScholarshipProgramTracingStudentPracticeFile> GetAllByPracticeId(long practiceId, long practiceTypeId)
        {
            return GetAll.Where(x => x.ScholarshipProgramTracingStudentPracticeId == practiceId && x.StudentPracticeTypeId == practiceTypeId && x.StatusId != StatusValues.Eliminado);
        }

        public void Save(ScholarshipProgramTracingStudentPracticeFile model)
        {
            var now = DateTime.Today;
           if(model.ScholarshipProgramTracingStudentPracticeFileId != 0)
            {
                model.UpgradeDate = now;

                _context.ScholarshipProgramTracingStudentPracticeFile.Update(model);
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
