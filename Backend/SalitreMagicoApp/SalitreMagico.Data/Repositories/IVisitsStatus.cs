using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface IVisitsStatus
    {
        Task<IEnumerable<VisitsStatus>> GetAllVisitsStatus();
        Task<bool> InsertStatusVisit(VisitsStatus visitsStatus);
        Task<bool> UpdateStatusVisit(VisitsStatus visitsStatus);
    }
}
