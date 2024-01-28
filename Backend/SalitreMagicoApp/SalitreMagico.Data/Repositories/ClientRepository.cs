using SalitreMagico.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlX.XDevAPI.Common;

namespace SalitreMagico.Data.Repositories
{
    public class ClientRepository : IClient
    {

        private readonly MySQLConfiguration _connectionString;

        public ClientRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var db = dbConnection();
            var sql = @"SELECT IdCliente , Nombre, Cedula, Telefono, CorreoElectronico, Estatura, Edad, FechaIngreso
                        FROM cliente;";

            return await db.QueryAsync<Client>(sql, new { });
        }

        public async Task<Client> GetDetailsClient(int IdentityNumber)
        {
            var db = dbConnection();
            var sql = @"SELECT IdCliente , Nombre, Cedula, Telefono, CorreoElectronico, Estatura, Edad, FechaIngreso
                        FROM cliente
                        WHERE Cedula = @IdentityNumber;";

            return await db.QueryFirstOrDefaultAsync<Client>(sql, new { IdentityNumber = IdentityNumber});
        }

        public async Task<bool> InsertClient(Client client)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO cliente(Nombre, Cedula, Telefono, CorreoElectronico, Estatura, Edad, FechaIngreso)
                        VALUES (@Name, @IdentityNumber, @PhoneNumber, @Email, @Heightclient, @ClienteAge, @EntryDate)";

            var result = await db.ExecuteAsync(sql, new 
                        { client.Name, client.IdentityNumber, client.PhoneNumber, client.Email, client.Heightclient, client.ClienteAge, client.EntryDate });
            return result > 0;
        }

        public async Task<bool> UpdateClient(Client client)
        {
            var db = dbConnection();
            var sql = @"UPDATE cliente
                        SET Nombre = @Name, 
                            Cedula = @IdentityNumber, 
                            Telefono = @PhoneNumber, 
                            CorreoElectronico = @Email, 
                            Estatura = @Heightclient, 
                            Edad = @ClienteAge, 
                            FechaIngreso = @EntryDate";

            var result = await db.ExecuteAsync(sql, new
            { client.Name, client.IdentityNumber, client.PhoneNumber, client.Email, client.Heightclient, client.ClienteAge, client.EntryDate });
            return result > 0;
        }
    }
}
