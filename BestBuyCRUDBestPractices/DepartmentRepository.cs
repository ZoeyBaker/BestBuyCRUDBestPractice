using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;

namespace BestBuyCRUDBestPractices
{
    class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connectionString;

        public DepartmentRepository(IDbConnection connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connectionString.Query<Department>("SELECT * FROM Departments;");
        }
    }
}
