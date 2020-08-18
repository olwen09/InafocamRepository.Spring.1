using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
    public class FileRepository : IFile
    {
        private readonly inafocam_tracingContext _context;
        public FileRepository(inafocam_tracingContext context)
        {
            _context = context;

        }

        public void Save(File model)
         {
            var now = DateTime.Now;
            if(model.FileId != 0)
            {
                var currentData = _context.File.Find(model.FileId);
                model.UpgradeDate = now;
                model.UpgradeDate = now;

                _context.Entry(currentData).CurrentValues.SetValues(model);
                _context.Entry(currentData).State = EntityState.Modified;
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
