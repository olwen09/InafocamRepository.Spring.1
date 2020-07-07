using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class TeacherFileRepository : ITeacherFile
    {
        public inafocam_tracingContext _context;

        public TeacherFileRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<TeacherFile> GetAll => _context.TeacherFile
            .Include(x => x.File)
            .Include(x => x.Status)
            .Include(x => x.Teacher)
            .Include(x => x.TeacherFileType)
            .Include(x => x.TeacherResearch);

        

        public TeacherFile GetById(int id)
        {
             return  GetAll.FirstOrDefault(x => x.TeacherFileId == id);
        }

      public IEnumerable<TeacherFile> GetByTeacherId(int id)
        {
            return GetAll.Where(x => x.TeacherId == id).ToList();
        }

        public void Save(TeacherFile model)
        {
            var now = DateTime.Now;

            if(model.TeacherFileId != 0)
            {
                model.UpgradeDate = now;
                _context.TeacherFile.Update(model);
            }
            else
            {
                model.StatusId = 1;
                model.CreationDate = now;
                _context.Add(model);
            }

            _context.SaveChanges();
        }
    }
}
