using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ComponentFileTypeRepository : IComponentFileType
    {
        private readonly inafocam_tracingContext _context;

        public ComponentFileTypeRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ComponentFileType> GetAll => _context.ComponentFileTypes
            .Include(x => x.Status);

        public void Save(ComponentFileType model)
        {

            var now = DateTime.Now;
            if(model.ComponentFileTypeId != 0)
            {
                model.UpgradeDate = now;
                _context.ComponentFileTypes.Update(model);
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
