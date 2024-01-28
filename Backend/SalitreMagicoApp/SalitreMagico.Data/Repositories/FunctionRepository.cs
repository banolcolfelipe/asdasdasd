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
    public class FunctionRepository : IFunctions
    {

        private readonly MySQLConfiguration _connectionString;

        public FunctionRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        // Querys SQL

        public async Task<IEnumerable<Functions>> GetAllFunctions()
        {
            var db = dbConnection();
            var sql = @"SELECT IdFuncion, NombreFuncion, Descripcion
                        FROM funciones;";

            return await db.QueryAsync<Functions>(sql, new { });
        }

        public async Task<Functions> GetDetailsFunction(int IdFunctions)
        {
            var db = dbConnection();
            var sql = @"SELECT IdFuncion, NombreFuncion, Descripcion
                        FROM funciones
                        WHERE IdFuncion = @IdFunctions";

            return await db.QueryFirstOrDefaultAsync<Functions>(sql, new { IdFunctions = IdFunctions });
        }

        public async Task<bool> InsertFunction(Functions functions)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO funciones( NombreFuncion, Descripcion)
                        VALUES ( @NameFunctions, @DescriptionFunctions)";

            var result = await db.ExecuteAsync(sql, new
            { functions.IdFunctions, functions.NameFunctions, functions.DescriptionFunctions });
            return result > 0;
        }

        public async Task<bool> UpdateFunction(Functions functions)
        {
            var db = dbConnection();
            var sql = @"UPDATE funciones
                        SET NombreFuncion = @NameFunctions, 
                            Descripcion = @DescriptionFunctions";
                            

            var result = await db.ExecuteAsync(sql, new
            { functions.IdFunctions, functions.NameFunctions, functions.DescriptionFunctions });
            return result > 0;
        }
    }
}
