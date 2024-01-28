using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetDetailsEmployee(int IdentityEmployee);
        Task<bool> InsertEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(Employee employee);
    }
}
