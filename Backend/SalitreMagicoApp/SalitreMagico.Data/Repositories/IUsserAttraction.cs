using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface IUsserAttraction
    {
        Task<IEnumerable<UsserAttraction>> GetAllUsserAttraction();
        Task<bool> InsertUsserAttraction(UsserAttraction usserAttraction);
        Task<bool> UpdateUsserAttraction(UsserAttraction usserAttraction);
    }
}
