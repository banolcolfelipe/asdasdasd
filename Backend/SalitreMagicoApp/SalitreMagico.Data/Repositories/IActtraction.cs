using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface IActtraction
    {
        Task<IEnumerable<Attractions>> GetAllAttractions();
        Task<bool> InsertAttraction(Attractions attractions);
        Task<bool> UpdateAttractions(Attractions attractions);
    }
}
