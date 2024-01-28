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
    public class TicketStationRepository : ITicketStation
    {
        private readonly MySQLConfiguration _connectionString;

        public TicketStationRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<TicketStation>> GetAllStations()
        {
            var db = dbConnection();
            var sql = @"SELECT IdEstacion, Activo, Cantidad, IdEmpleado
                        FROM estaciontickets;";

            return await db.QueryAsync<TicketStation>(sql, new { });
        }

        public async Task<bool> UpdateStation(TicketStation ticketStation)
        {
            var db = dbConnection();
            var sql = @"UPDATE cliente
                        SET Activo = @Name, 
                            Cantidad = @IdentityNumber";

            var result = await db.ExecuteAsync(sql, new
            { ticketStation.ActiveStation, ticketStation.OcupationStation });
            return result > 0;
        }
    }
}
