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
    public class StatusAttractionRepository : IStatusAttraction
    {
        private readonly MySQLConfiguration _connectionString;

        public StatusAttractionRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<StatusAttraction>> GetAllStatusAttractions()
        {
            var db = dbConnection();
            var sql = @"SELECT IdEstado, Estado
                        FROM estadoatraccion;";

            return await db.QueryAsync<StatusAttraction>(sql, new { });
        }

        public async Task<bool> UpdateStatusAttraction(StatusAttraction statusAttraction)
        {
            var db = dbConnection();
            var sql = @"UPDATE estadoatraccion
                        SET estadoatraccion = @Status";

            var result = await db.ExecuteAsync(sql, new
            { statusAttraction.IdStatusAttraction, statusAttraction.Status });
            return result > 0;
        }
    }
}
