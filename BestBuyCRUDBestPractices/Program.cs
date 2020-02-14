using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BestBuyCRUDBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            var connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);

            var departments = repo.GetAllDepartments();

            //var repo = new DepartmentRepository(connString);
            //var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"Department Name: {dept.Name, -20} Department Id: {dept.ID}");
            }
        }
    }
}
