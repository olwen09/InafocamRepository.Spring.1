using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Materias.Models
{
    public class IndexViewModel
    {

        public long? scholarshipProgramUniversityId { get; set; }
        public IEnumerable<SubjectMatter> SubjectMatterList { get; set; }
    }
}
