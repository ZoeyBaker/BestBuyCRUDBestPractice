using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BestBuyCRUDBestPractices
{
   public class Program
    {
        static void Main(string[] args)
        {

          #region Configuration

            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");
           #endregion  
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Hello user, here are the current departments:");
            var depos = repo.GetAllDepartments();
            

            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentId} Name: {depo.Name}");
            }

            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();
            if(userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is name of new department");
                userResponse = Console.ReadLine();

                repo.InsertDepartment(userResponse);
                Print(repo.GetAllDepartments());
            }

            Console.WriteLine("Have a great day.");

        }

        private static void Print(IEnumerable<Department> depos)
        {
           foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentId} Name: {depo.Name}");
            }


        }
    }
}
