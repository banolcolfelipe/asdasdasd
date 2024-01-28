using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface IFunctions
    {
        Task<IEnumerable<Functions>> GetAllFunctions();
        Task<Functions> GetDetailsFunction(int IdFunctions);
        Task<bool> InsertFunction(Functions functions);
        Task<bool> UpdateFunction(Functions functions);
    }
}