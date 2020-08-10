using Inafocam.core.Interfaces;
using Inafocam.Web.Areas.ProgramacionDeSeguimiento.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.ProgramacionDeSeguimiento.Components.ScholarshipProgramUniversityComponent
{
    public class GetScholarshipProgramUniversityComponent :ViewComponent
    {
        private readonly IScholarshipProgramUniversity _scholarshipProgramUniversity;
        private readonly IUniversity _university;

        public GetScholarshipProgramUniversityComponent(IScholarshipProgramUniversity scholarshipProgramUniversity,
            IUniversity university)
        {
            _scholarshipProgramUniversity = scholarshipProgramUniversity;
            _university = university;
        }

        public IViewComponentResult Invoke(int id)
        {
            var ProgramUniversity = _scholarshipProgramUniversity.GetProgramUniversityByUniversityId(id)
               .Select(x => new GetScholarShipProgram
               {
                   ScholarshipProgramUniversityId = x.ScholarshipProgramUniversityId,
                   ScholarShipProgramNameScatCodeContractNumber = x.ScholarshipProgram.ScholarshipProgramName.ToString() + ", " + x.ScatProgramCode.ToString()
                   + ", " + x.ContractNumber.ToString()
               });

            return View("ProgramUniversity", ProgramUniversity);
        }

        public IViewComponentResult ProgramUniversity(int id)
        {
            var ProgramUniversity = _scholarshipProgramUniversity.GetProgramUniversityByUniversityId(id)
                 .Select(x => new GetScholarShipProgram { ScholarshipProgramUniversityId = x.ScholarshipProgramUniversityId, ScholarShipProgramNameScatCodeContractNumber = x.ScholarshipProgram.ScholarshipProgramName + " "+ x.ScatProgramCode 
                     +", " + x.ContractNumber }); 

            return View("ProgramUniversity", ProgramUniversity);
        }
    }
}
