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
    public class UsserRepository : IUsser
    {
        private readonly MySQLConfiguration _connectionString;

        public UsserRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }


        public async Task<bool> DeleteUsser(Usser usser)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM usuario
                        WHERE IdUsuario = @IdUsser";
            var result = await db.ExecuteAsync(sql, new { IdUsser = usser.IdUsser });
            return result > 0;
        }

        public async Task<IEnumerable<Usser>> GetAllUssers()
        {
            var db = dbConnection();
            var sql = @"SELECT IdUsuario, Usuario, Contraseña, Activo, IdEmpleado
                        FROM usuario;";

            return await db.QueryAsync<Usser>(sql, new { });
        }

        public async Task<Usser> GetUsserDetails(int idUsser)
        {
            var db = dbConnection();
            var sql = @"SELECT IdUsuario, Usuario, Contraseña, Activo, IdEmpleado
                        FROM usuario;
                        WHERE IdUsuario = @idUsser";

            return await db.QueryFirstOrDefaultAsync<Usser>(sql, new { idUsser = idUsser });
        }

        public async Task<bool> InsertUsser(Usser usser)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO usuario(Usuario, Contraseña, Activo)
                        VALUES (@)";

            var result = await db.ExecuteAsync(sql, new
            { usser.UsserName, usser.Password, usser.IsActiveUsser });
            return result > 0;
        }

        public async Task<bool> UpdateUsser(Usser usser)
        {
            var db = dbConnection();
            var sql = @"UPDATE costos
                        SET usuario = @UsserName,
                            Contraseña = @Password
                            Activo = IsActiveUsser";

            var result = await db.ExecuteAsync(sql, new
            { usser.UsserName, usser.Password, usser.IsActiveUsser });
            return result > 0;
        }
    }
}
