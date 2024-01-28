using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Model
{
    public class TicketStation
    {
        public int IdStation { get; set; }
        public Boolean ActiveStation { get; set; }
        public int OcupationStation { get; set; }
        public int IdEmployee { get; set;}
}
}
