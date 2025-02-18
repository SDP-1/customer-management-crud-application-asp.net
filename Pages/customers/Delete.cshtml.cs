using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Customer_Management_CRUD_Application_ASP.NET_.Pages.customers
{
    public class Delete : PageModel
    {
        

        public void OnGet()
        {
        }

        public void OnPost(int id)
        {
            deleteCustomer(id);
            Response.Redirect("/Customers/Index");
        }

        private void deleteCustomer(int id){
                try{
                string connectionString = "Server=MSI\\SQLEXPRESS; Database=crmdb; Trusted_Connection=True; TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString)){
                    connection.Open();

                    //delete customer from database
                    string sql = "DELETE FROM customers WHERE id = @id";

                    using(SqlCommand command = new SqlCommand(sql,connection)){
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }


            }catch(Exception e){
                Console.WriteLine("Cannot delete Customer : " + e.Message);
            }
        }
    }
}