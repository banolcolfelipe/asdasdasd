using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface ITicketStation
    {
        Task<IEnumerable<TicketStation>> GetAllStations();
        Task<bool> UpdateStation(TicketStation ticketStation);
    }
}
