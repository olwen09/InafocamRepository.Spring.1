using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Repository
{
    public class ActionTypeRepository : IActionType
    {
        private readonly inafocam_tracingContext _context;

        public ActionTypeRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<ActionType> GetAll => _context.ActionType
            .Include(x => x.Status);
    }
}
