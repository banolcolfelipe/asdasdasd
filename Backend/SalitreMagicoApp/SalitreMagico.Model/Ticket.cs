using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Model
{
    public class Ticket
    {
        public int IdTicket { get; set; }
        public Boolean IsActiveTicket { get; set; }
        public int IdCost { get; set; }
        public int IdClient { get; set; }
        public int IdStation { get; set; }
    }
}
