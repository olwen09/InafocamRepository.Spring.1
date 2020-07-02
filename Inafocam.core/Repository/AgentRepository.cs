using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class AgentRepository : IAgent
    {
        private readonly inafocam_tracingContext _context;

        public AgentRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IQueryable<Agent> Agents => _context.Agent
            .Include(x => x.Contact)
            //.Include(x => x.Contact.ContactAddres) 
            .Include(x => x.Contact.ContactAddres)
            .Include(x => x.Contact.ContactAddres.Address)
            .Include(x => x.Contact.DocumentType)
            .Include(x => x.Contact.ContactType)
            .Include(x => x.AgentType)
            .Include(x => x.Status);
        //.Include(x => x.User);
        //.Include(x => x.CreationUser)
        //.Include(x => x.UpgradeUser);
        //.Include(x => x.Contact.ContactCommunication);
        //.Include(x => x.ScholarshipProgramTracingCoordinator)
        //.Include(x => x.ScholarshipProgramTracingTechnical)
        //.Include(x => x.ScholarshipProgramUniversityAgent)
        //.Include(x => x.ScholarshipProgramUniversityCoordinator)
        //.Include(x => x.ScholarshipProgramUniversityTechnical);
        //.Include(x => x.Contact.ContactCommunicatio);

        public IQueryable<Agent> GetCoordinators => Agents.Where(x => x.AgentId == 1);

        public IQueryable<Agent> GetTechnicals => Agents.Where(x => x.AgentId == 2);

        public Agent GetById(int id)
        {
            return Agents.FirstOrDefault(x => x.AgentId == id);
        }

        public void Save(Agent model)
        {
            var now = DateTime.Now;
            model.UserId  = 1;
            if(model.AgentId != 0)
            {
                model.UpgradeDate = now;
                _context.Agent.Update(model);
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
