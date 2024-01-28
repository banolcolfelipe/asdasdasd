using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface IClient
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetDetailsClient(int IdentityNumber);
        Task<bool> InsertClient(Client client);
        Task<bool> UpdateClient(Client client);

    }
}
