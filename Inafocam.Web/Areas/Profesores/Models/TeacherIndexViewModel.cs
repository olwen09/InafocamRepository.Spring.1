using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.Profesores.Models
{
    public class TeacherIndexViewModel
    {

        public int? UserUniversityId { get; set; }

        public IEnumerable<Teacher> TeacherList { get; set; }
    }
}
