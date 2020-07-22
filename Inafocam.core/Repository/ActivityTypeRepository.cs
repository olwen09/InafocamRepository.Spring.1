using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ActivityTypeRepository : IActivityType
    {
        private readonly inafocam_tracingContext _context;


        public ActivityTypeRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ActivityType> GetAll => _context.ActivityType
            .Include(x => x.Status);
            
    }
}
