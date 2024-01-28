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
    public class ContactChildrenRepository : IContactChildren
    {

        private readonly MySQLConfiguration _connectionString;

        public ContactChildrenRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



        public async Task<bool> DeleteContact(ContactChildren contactChildren)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM contactomenoredad
                        WHERE IdContacto = @ContactId";
            var result = await db.ExecuteAsync(sql, new { ContactId = contactChildren.ContactId });
            return result > 0;
        }

        public async Task<IEnumerable<ContactChildren>> GetAllContacts()
        {
            var db = dbConnection();
            var sql = @"SELECT IdContacto, Parentesco, Nombre, Telefono, IdCliente
                        FROM contactomenoredad;";

            return await db.QueryAsync<ContactChildren>(sql, new { });
        }


        public async Task<ContactChildren> GetDetailsContact(int ContactId)
        {
            var db = dbConnection();
            var sql = @"SELECT IdContacto, Parentesco, Nombre, Telefono
                        FROM contactomenoredad
                        WHERE IdContacto = @ContactId;";

            return await db.QueryFirstOrDefaultAsync<ContactChildren>(sql, new { ContactId = ContactId });
        }

        public async Task<bool> InsertContact(ContactChildren contactChildren)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO cliente(Parentesco, Nombre, Telefono)
                        VALUES (@RelationshipContact, @ContactName, @PhoneContact)";

            var result = await db.ExecuteAsync(sql, new
            { contactChildren.RelationshipContact, contactChildren.ContactName, contactChildren.PhoneContact });
            return result > 0;
        }

        public async Task<bool> UpdateContact(ContactChildren contactChildren)
        {
            var db = dbConnection();
            var sql = @"UPDATE contactomenoredad
                        SET Parentesco= @RelationshipContact, 
                            Nombre = @ContactName,
                            Telefono =  @PhoneContact";

            var result = await db.ExecuteAsync(sql, new
            { contactChildren.RelationshipContact, contactChildren.ContactName, contactChildren.PhoneContact });
            return result > 0;
        }
    }
}
