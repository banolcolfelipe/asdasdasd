using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface IUsser
    {
        Task<IEnumerable<Usser>> GetAllUssers();

        Task<Usser> GetUsserDetails(int idUsser);
        Task<bool> InsertUsser(Usser usser);
        Task<bool> UpdateUsser(Usser usser);
        Task<bool> DeleteUsser(Usser usser);
    }
}
