using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface ITicket
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<bool> UpdateTicket(Ticket ticket);
    }
}
