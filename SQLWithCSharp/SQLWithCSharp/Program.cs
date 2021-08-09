using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customers>();
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                using (var updateCustomerCommand = new SqlCommand("UpdateCustomer", connection))
                {
                    updateCustomerCommand.CommandType = CommandType.StoredProcedure;

                    updateCustomerCommand.Parameters.AddWithValue("ID", "ANATR");
                    updateCustomerCommand.Parameters.AddWithValue("NewName", "Eric Smith");
                    int affected = updateCustomerCommand.ExecuteNonQuery();
                }

                //connection.Open();
                //Console.WriteLine(connection.State);

                //string sqlUpdateString = $"UPDATE CUSTOMERS SET CITY = 'Barcelona' WHERE CustomerID = 'BEARD'";
                //using (var command3 = new SqlCommand(sqlUpdateString, connection))
                //{
                //    int affected = command3.ExecuteNonQuery();
                //}

                //string sqlDeleteString = $"DELETE FROM CUSTOMRES WHERE CustomerID = 'BEARD'";
                //using (var command4 = new SqlCommand(sqlDeleteString, connection))
                //{
                //    int affected = command4.ExecuteNonQuery();
                //}
                //connection.Close();

                //var newCustomer = new Customers()
                //{
                //    CustomerID = "BEARD",
                //    ContactName = "Martin Beard", 
                //    City = "London", 
                //    CompanyName ="Sparta Global",
                //};

                //string sqlString = $"INSERT INTO Customers(CustomerID, ContactName, CompanyName, City) VALUES('{newCustomer.CustomerID}','{newCustomer.ContactName}','{newCustomer.CompanyName}','{newCustomer.City}')";

                //using (var command2 = new SqlCommand(sqlString, connection))
                //{
                //    int affected = command2.ExecuteNonQuery();
                //}
                //connection.Close();


                //using (var command = new SqlCommand("SELECT * FROM Customers", connection))
                //{
                //    SqlDataReader sqlDataReader = command.ExecuteReader();
                //    while (sqlDataReader.Read())
                //    {
                //        var CustomerID = sqlDataReader["CustomerID"].ToString();
                //        var contactName = sqlDataReader["ContactName"].ToString();
                //        var companyName = sqlDataReader["CompanyName"].ToString();
                //        var contactTitle = sqlDataReader["ContactTitle"].ToString();
                //        var city = sqlDataReader["City"].ToString();

                //        var customer = new Customers() { ContactName = contactName, ContactTitle = contactTitle, CustomerID = CustomerID, City = city, CompanyName = companyName };

                //        customers.Add(customer);
                //    }
                //    foreach (var c in customers)
                //    {
                //        Console.WriteLine($"Customer {c.GetFullName()} has ID {c.CustomerID}");
                //    }
                //    sqlDataReader.Close();
                //}
            }
        }
        public class Customers
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string City { get; set; }
            public string GetFullName()
            {
                return $"{ContactTitle} - {ContactName}";
            }
        }
    }
}
