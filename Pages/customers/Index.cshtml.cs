using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;


namespace Customer_Management_CRUD_Application_ASP.NET_.Pages.customers
{
    public class Index : PageModel
    {
        public List<CustomerInfo> CustomerList { get; set; } = [];

        public void OnGet()
        {
            try
            {
                string connectionString = "Server=MSI\\SQLEXPRESS; Database=crmdb; Trusted_Connection=True; TrustServerCertificate=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM customers ORDER BY id DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerInfo customerInfo = new CustomerInfo
                                {
                                    Id = reader.GetInt32(0),
                                    Firstname = reader.GetString(1),
                                    Lastname = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Phone = reader.GetString(4),
                                    Address = reader.GetString(5),
                                    Company = reader.GetString(6),
                                    Notes = reader.GetString(7),
                                    CreatedAt = reader.GetDateTime(8).ToString("MM/dd/yyyy")
                                };

                                CustomerList.Add(customerInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("We have an error: ", e.Message);
            }
        }
    }

    public class CustomerInfo
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public string Company { get; set; } = "";
        public string Notes { get; set; } = "";
        public string CreatedAt { get; set; } = "";
    }
}