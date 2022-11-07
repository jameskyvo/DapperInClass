using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace DapperInClass
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var depRepo = new DapperDepartmentRepository(conn);
            var prodRepo = new DapperProductRepository(conn);

            Console.WriteLine("Type a new Department name");
            var newDepartment = Console.ReadLine();

            depRepo.InsertDepartment(newDepartment);

            var departments = depRepo.GetAllDepartments();

            foreach(var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }

            Console.WriteLine("Type a new Product name.");
            var prodName = Console.ReadLine();
            Console.WriteLine("Type a new Product price.");
            var price = double.Parse(Console.ReadLine());
            Console.WriteLine("What would you like the products ID to be?");
            var categoryID = int.Parse(Console.ReadLine());

            prodRepo.CreateProduct(prodName, price, categoryID);
            
            var products = prodRepo.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductID} {prod.Name}");
            }
            Console.ReadLine();
        }
    }
}
