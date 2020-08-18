﻿using System;
using Inafocam.core.Modelos;
using Inafocam.core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inafocam.core.Help;

namespace Inafocam.core.Repository
{
   public class ScholarshipProgramRepository : IScholarshipProgram
    {
        private readonly inafocam_tracingContext _context;
        public ScholarshipProgramRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<ScholarshipProgram> GetAll => _context.ScholarshipProgram
            .Include(x => x.ScholarshipLevel)
            .Include(x => x.Status)
        //.Include(x => x.ScholarshipProgramUniversity)
        .Include(x => x.ScholarshipProgramUniversity);

        public ScholarshipProgram GetById(int? id)
        {
            return _context.ScholarshipProgram
            .Include(x => x.ScholarshipLevel)
            .Include(x => x.ScholarshipProgramUniversity)
            .Include(x => x.Status)
            .FirstOrDefault(x=> x.ScholarshipProgramId == id);
        
        }

        public void GuardarScholarshipProgram(ScholarshipProgram model)
        {
            var now = DateTime.Now;

            if(model.ScholarshipProgramId != 0)
            {
                model.UpgradeDate = now;
                _context.ScholarshipProgram.Update(model);
            }
            else
            {
                model.CreationDate = now;
                model.StatusId = StatusValues.Activo;
                _context.Add(model);
            }

            //_context.Add(model);

            _context.SaveChanges();
        }
    }
}
