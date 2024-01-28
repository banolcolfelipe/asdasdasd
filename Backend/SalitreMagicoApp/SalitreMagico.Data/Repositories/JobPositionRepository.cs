using Dapper;
using MySql.Data.MySqlClient;
using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public class JobPositionRepository : IJobPosition
    {
        private readonly MySQLConfiguration _connectionString;

        public JobPositionRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<JobPosition>> GetAllJobs()
        {
            var db = dbConnection();
            var sql = @"SELECT IdCargo, NombreCargo, IdFunciones
                        FROM cargo;";

            return await db.QueryAsync<JobPosition>(sql, new { });
        }

        public async Task<JobPosition> GetDetailsJob(int IdJob)
        {
            var db = dbConnection();
            var sql = @"SELECT IdCargo, NombreCargo, IdFunciones
                        FROM cargo;
                        WHERE IdCargo = @IdJob;";

            return await db.QueryFirstOrDefaultAsync<JobPosition>(sql, new { IdJob = IdJob });
        }

        public async Task<bool> InsertJob(JobPosition jobPosition)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO cargo( IdCargo, NombreCargo, IdFunciones )
                        VALUES (@IdJob, @JobName, @IdFunction)";

            var result = await db.ExecuteAsync(sql, new
            { jobPosition.IdJob, jobPosition.JobName, jobPosition.IdFunction });
            return result > 0;
        }

        public async Task<bool> UpdateJob(JobPosition jobPosition)
        {
            var db = dbConnection();
            var sql = @"UPDATE cargo
                        NombreCargo = @JobName";

            var result = await db.ExecuteAsync(sql, new
            { jobPosition.IdJob, jobPosition.JobName, jobPosition.IdFunction });
            return result > 0; ;
        }
    }
}
