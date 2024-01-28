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
    public class VisitStatusRepository : IVisitsStatus
    {

        private readonly MySQLConfiguration _connectionString;

        public VisitStatusRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        // SQL QUERYs
        public async Task<IEnumerable<VisitsStatus>> GetAllVisitsStatus()
        {
            var db = dbConnection();
            var sql = @"SELECT IdVisitaCliente,  NumeroVisitas, IdCliente
                        FROM numerovisitascliente;";

            return await db.QueryAsync<VisitsStatus>(sql, new { });
        }

        public async Task<bool> InsertStatusVisit(VisitsStatus visitsStatus)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO numerovisitascliente (NumeroVisitas)
                        VALUES (@numberOfVisits)";

            var result = await db.ExecuteAsync(sql, new
            { visitsStatus.numberOfVisits });
            return result > 0;
        }

        public async Task<bool> UpdateStatusVisit(VisitsStatus visitsStatus)
        {
            var db = dbConnection();
            var sql = @"UPDATE numerovisitascliente
                        SET NumeroVisitas = @numberOfVisits";

            var result = await db.ExecuteAsync(sql, new
            { visitsStatus.numberOfVisits });
            return result > 0;
        }
    }
}
