using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.ProgramacionDeSeguimiento.Models
{
    public class GetAgents
    {
        public long? AgentTypeId { get; set; }
        public long? AgentId { get; set; }

        public string FullName { get; set; }

    }

    public class GetScholarShipProgram
    {
        public long? ScholarshipProgramUniversityId { get; set; }
        public string ScholarShipProgramNameScatCodeContractNumber { get; set; }
    }
}