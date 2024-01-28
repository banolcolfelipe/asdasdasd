using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using SalitreMagico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalitreMagico.Data.Repositories
{
    public class UsserAttractionRepository : IUsserAttraction
    {
        private readonly MySQLConfiguration _connectionString;

        public UsserAttractionRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<UsserAttraction>> GetAllUsserAttraction()
        {
            var db = dbConnection();
            var sql = @"SELECT IdUsuarioAtraccion, IdCliente, IdAtracciones, FechaHoraUso
                        FROM usuarioatraccion;";

            return await db.QueryAsync<UsserAttraction>(sql, new { });
        }

        public async Task<bool> InsertUsserAttraction(UsserAttraction usserAttraction)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO usuarioatraccion(FechaHoraUso)
                        VALUES (@DateUsserAttraction)";

            var result = await db.ExecuteAsync(sql, new
            { usserAttraction.DateUsserAttraction });
            return result > 0;
        }

        public async Task<bool> UpdateUsserAttraction(UsserAttraction usserAttraction)
        {
            var db = dbConnection();
            var sql = @"UPDATE usuarioatraccion
                        SET FechaHoraUso = @DateUsserAttraction";

            var result = await db.ExecuteAsync(sql, new
            { usserAttraction.DateUsserAttraction });
            return result > 0;
        }
    }
}
