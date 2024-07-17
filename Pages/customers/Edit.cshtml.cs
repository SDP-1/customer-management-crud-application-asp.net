using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Customer_Management_CRUD_Application_ASP.NET_.Pages.customers
{
    public class Edit : PageModel
    {

        [BindProperty]
        public int Id { get; set; }
        [BindProperty, Required(ErrorMessage = "The First Name is required")]
        public string FirstName { get; set; } = "";
        [BindProperty, Required(ErrorMessage = "The Last Name is required")]
        public string LastName { get; set; } = "";
        [BindProperty, Required, EmailAddress]
        public string Email { get; set; } = "";
        [BindProperty, Phone]
        public string? Phone { get; set; } = "";
        [BindProperty]
        public string? Address { get; set; } = "";
        [BindProperty, Required]
        public string Company { get; set; } = "";
        [BindProperty]
        public string? Notes { get; set; } = "";

        public string ErrorMessage { get; private set; }
        public void OnGet(int id)
        {
            try
            {

                string connectionString = "Server=MSI\\SQLEXPRESS; Database=crmdb; Trusted_Connection=True; TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM customers WHERE id = @id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Id = reader.GetInt32(0);
                                FirstName = reader.GetString(1);
                                LastName = reader.GetString(2);
                                Email = reader.GetString(3);
                                Phone = reader.GetString(4);
                                Address = reader.GetString(5);
                                Company = reader.GetString(6);
                                Notes = reader.GetString(7);
                            }
                            else
                            {
                                Response.Redirect("/Customer/Index");
                            }
                        }

                    }
                }

            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            if (Phone == null) Phone = "";
            if (Address == null) Address = "";
            if (Notes == null) Notes = "";

            
            try
            {
                string connectionString = "Server=MSI\\SQLEXPRESS; Database=crmdb; Trusted_Connection=True; TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE customers SET firstName=@firstName, LastName=@LastName, email=@email, phone=@phone, address=@address, company=@company, notes=@notes WHERE id = @id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@email", Email);
                        command.Parameters.AddWithValue("@phone", Phone);
                        command.Parameters.AddWithValue("@address", Address);
                        command.Parameters.AddWithValue("@company", Company);
                        command.Parameters.AddWithValue("@notes", Notes);
                        command.Parameters.AddWithValue("@id", Id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return ;
            }

           Response.Redirect("/Customers/Index");
        }
    }
}