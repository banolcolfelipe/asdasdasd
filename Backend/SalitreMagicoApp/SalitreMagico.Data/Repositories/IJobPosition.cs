using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public interface IJobPosition
    {
        Task<IEnumerable<JobPosition>> GetAllJobs();
        Task<JobPosition> GetDetailsJob(int IdJob);
        Task<bool> InsertJob(JobPosition jobPosition);
        Task<bool> UpdateJob(JobPosition jobPosition);
    }
}
