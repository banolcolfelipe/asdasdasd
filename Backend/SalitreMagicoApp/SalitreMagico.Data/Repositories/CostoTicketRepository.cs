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
    public class CostoTicketRepository : ICostTicket
    {
        private readonly MySQLConfiguration _connectionString;

        public CostoTicketRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<CostTicket>> GetAllCostsTicket()
        {
            var db = dbConnection();
            var sql = @"SELECT IdCosto, Costo, TipoCosto
                        FROM costos;";

            return await db.QueryAsync<CostTicket>(sql, new { });
        }

        public async Task<bool> UpdateCostTicket(CostTicket costTicket)
        {
            var db = dbConnection();
            var sql = @"UPDATE costos
                        SET Costo = @Cost,
                            TipoCosto = @CostType";

            var result = await db.ExecuteAsync(sql, new
            { costTicket.IdCost, costTicket.Cost, costTicket.CostType });
            return result > 0;
    }
    }
}
