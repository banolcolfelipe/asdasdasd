using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface ICostTicket
    {
        Task<IEnumerable<CostTicket>> GetAllCostsTicket();
        Task<bool> UpdateCostTicket(CostTicket costTicket);
    }
}
