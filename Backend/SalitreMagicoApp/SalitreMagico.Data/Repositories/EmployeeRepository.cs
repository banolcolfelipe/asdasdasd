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
    public class EmployeeRepository : IEmployee
    {

        private readonly MySQLConfiguration _connectionString;

        public EmployeeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        // querys sql
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM empleado
                        WHERE IdEmpleado = @idEmployee";
            var result = await db.ExecuteAsync(sql, new { idEmployee = employee.IdEmployee });
            return result > 0;
        }

        //SELECT IdEmpleado, Nombre, Cedula,Telefono, CorreoElectronico, Estatura, Edad, IdCargo
        //FROM empleados;


        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var db = dbConnection();
            var sql = @"SELECT IdEmpleado, Nombre, Cedula,Telefono, CorreoElectronico, Estatura, Edad, IdCargo
                        FROM empleados;";

            return await db.QueryAsync<Employee>(sql, new { });
        }

        public async Task<Employee> GetDetailsEmployee(int IdentityEmployee)
        {
            var db = dbConnection();
            var sql = @"SELECT IdEmpleado, Nombre, Cedula,Telefono, CorreoElectronico, Estatura, Edad, IdCargo
                        FROM empleados
                        WHERE Cedula = @IdentityEmployee;";

            return await db.QueryFirstOrDefaultAsync<Employee>(sql, new { IdentityEmployee = IdentityEmployee });
        }

        public async Task<bool> InsertEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO empleados( Nombre, Cedula,Telefono, CorreoElectronico, Estatura, Edad)
                        VALUES (@RelationshipContact, @ContactName, @PhoneContact)";

            var result = await db.ExecuteAsync(sql, new
            { employee.NameEmployee, employee.IdentityEmployee, employee.PhoneEmplyee, employee.EmailEmployee, employee.HeightEmployee, employee.AgeEmployee });
            return result > 0;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var db = dbConnection();
            var sql = @"UPDATE empleados
                        SET Nombre = @NameEmploye, 
                        Cedula = @IdentityEmployee,
                        Telefono = @PhoneEmplyee, 
                        CorreoElectronico = @EmailEmployee, 
                        Estatura = @HeightEmployee, 
                        Edad = @AgeEmployee;";

            var result = await db.ExecuteAsync(sql, new
            { employee.NameEmployee, employee.IdentityEmployee, employee.PhoneEmplyee, employee.EmailEmployee, employee.HeightEmployee, employee.AgeEmployee });
            return result > 0;
        }
    }
}
