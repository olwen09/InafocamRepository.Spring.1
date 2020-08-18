using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Andamios.Web.Models
{
    public class SearchbarModel
    {

        public string Pantalla { get; set; }       
        public string Categoria { get; set; }
        public int ResultCount { get; set; }
        public string Total { get; set; }
  
    }
}
