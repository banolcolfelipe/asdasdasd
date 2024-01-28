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
    public class AttractionRepository : IActtraction
    {
        private readonly MySQLConfiguration _connectionString;

        public AttractionRepository (MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Attractions>> GetAllAttractions()
        {
            var db = dbConnection();
            var sql = @"SELECT IdAtracciones, Nombre, Activo, IdEstado
                        FROM atracciones";

            return db.QueryAsync<Attractions>(sql, new { });
        }

        public async Task<bool> InsertAttraction(Attractions attractions)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO atracciones( Nombre, Activo)
                        VALUES (@AttractionName, @IsActiveAttraction )";

            var result = await db.ExecuteAsync(sql, new
            { attractions.AttractionName, attractions.IsActiveAttraction });
            return result > 0;
        }

        public async Task<bool> UpdateAttractions(Attractions attractions)
        {
            var db = dbConnection();
            var sql = @"UPDATE atracciones
                        SET Nombre = @AttractionName, 
                            Activo = @IsActiveAttractio";

            var result = await db.ExecuteAsync(sql, new
            { attractions.AttractionName, attractions.IsActiveAttraction });
            return result > 0;
        }
    }
}
