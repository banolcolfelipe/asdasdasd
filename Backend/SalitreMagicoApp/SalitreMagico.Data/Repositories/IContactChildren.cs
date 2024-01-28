using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface IContactChildren
    {
        Task<IEnumerable<ContactChildren>> GetAllContacts();

        Task<ContactChildren> GetDetailsContact(int ContactId);
        Task<bool> InsertContact(ContactChildren contactChildren);
        Task<bool> UpdateContact(ContactChildren contactChildren);
        Task<bool> DeleteContact(ContactChildren contactChildren);
    }
}
