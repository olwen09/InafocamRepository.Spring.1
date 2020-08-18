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
    public class TeacherEducationRepository : ITeacherEducation
    {
        private readonly inafocam_tracingContext _context;

        public TeacherEducationRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<TeacherEducation> GetAll => _context.TeacherEducation
            .Include(x => x.EducationType)
            .Include(x => x.Status)
            .Include(x => x.TeacherNavigation)
            .Include(x => x.Teacher)
            .Include(x => x.TracingStudyPlanDevelopment);

        public IEnumerable<TeacherEducation> GetAllByTeacherId(int teacherId)
        {
            return GetAll.Where(x => x.TeacherId == teacherId).ToList();
        }

        public TeacherEducation GetById(int id)
        {
            return GetAll.FirstOrDefault(x => x.TeacherEducationId == id);
        }

        public void Save(TeacherEducation model)
        {
            var now = DateTime.Now;
            if(model.TeacherEducationId != 0)
            {
                model.UpgradeDate = now;
                _context.TeacherEducation.Update(model);
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
