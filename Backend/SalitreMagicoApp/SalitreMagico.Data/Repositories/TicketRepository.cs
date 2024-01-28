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
    public class TicketRepository : ITicket
    {
        private readonly MySQLConfiguration _connectionString;

        public TicketRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            var db = dbConnection();
            var sql = @"SELECT IdTicket, Activo, IdCosto, IdCliente, IdEstacion
                        FROM ticket;";

            return await db.QueryAsync<Ticket>(sql, new { });
        }

        public async Task<bool> UpdateTicket(Ticket ticket)
        {
            var db = dbConnection();
            var sql = @"UPDATE ticket
                        SET Activo = @IsActiveTicket";

            var result = await db.ExecuteAsync(sql, new
            { ticket.IsActiveTicket });
            return result > 0;
        }
    }
}
