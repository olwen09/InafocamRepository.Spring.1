using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Profesores.Models
{
    public class TeacherIndexViewModel
    {

        public int? UniversityId { get; set; }
        public string UniversityName { get; set; }

        public IEnumerable<Teacher> TeacherList { get; set; }
    }
}
