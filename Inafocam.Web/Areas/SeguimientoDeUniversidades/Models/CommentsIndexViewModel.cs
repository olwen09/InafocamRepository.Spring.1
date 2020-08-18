using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inafocam.Web.Areas.SeguimientoDeUniversidades.Models
{
    public class CommentsIndexViewModel
    {

      public IEnumerable<Comment> CommentList { get; set; }

        public string UniversityName { get; set; }
    }
}
