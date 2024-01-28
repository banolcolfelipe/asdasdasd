using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Model
{
    public class Attractions
    {
        public int AttractionId { get; set ;}
        public string AttractionName { get; set;}
        public Boolean IsActiveAttraction { get; set; }
        public int IdStatus { get; set; }
    }
}
