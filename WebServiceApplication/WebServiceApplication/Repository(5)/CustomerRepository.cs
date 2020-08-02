using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebServiceApplication.Factory_6_;
using WebServiceApplication.Helper;
using WebServiceApplication.Model_7_;

namespace WebServiceApplication.Repository_5_
{
    public class CustomerRepository
    {
        SqlConnection connection;

        public CustomerRepository()
        {
            connection = new SqlConnection(ConnectionHelper.connectionString);
        }

        public Customer getCustomer(String username, String password)
        {
            Customer customer = null;

            try
            {
                if(connection.State == ConnectionState.Closed)
                {

                    connection.Open();
                    
                }
                SqlCommand command = new SqlCommand("SELECT * FROM [Customer] WHERE username=@username AND password=@password", connection);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);

                SqlDataReader result = command.ExecuteReader();

                if (result.Read())
                {
                    customer = CustomerFactory.createCustomer(
                        (Int32)result.GetValue(0), (String)result["Name"],
                        (String)result.GetValue(2), (String)result["Password"]);
                }
                connection.Close();
            }
            catch (Exception error)
            {
                Debug.Print(error.ToString());
            }

            return customer;
        }

        public String addCustomer(String name, String username, String password)
        {
            
            try
            {
                if (connection.State == ConnectionState.Closed)
                {

                    connection.Open();

                   
                }

                SqlCommand insert = new SqlCommand("INSERT INTO [Customer](name,username,password) VALUES (@name , @username, @password)", connection);

                insert.Parameters.AddWithValue("name", name);
                insert.Parameters.AddWithValue("username", username);
                insert.Parameters.AddWithValue("password", password);
                int affected = insert.ExecuteNonQuery();
                //if(affected > 0)
                //{
                //    SqlCommand command = new SqlCommand("SELECT TOP 1 FROM [Customer] ORDER BY ID DESCENDING", connection);

                //    SqlDataReader result = command.ExecuteReader();

                //    if (result.Read())
                //    {
                //        customer = CustomerFactory.createCustomer(
                //            (Int32)result.GetValue(0), (String)result["Name"],
                //            (String)result.GetValue(2), (String)result["Password"]);
                //    }
                //}

                connection.Close();
                return "Success adding customer!";

            }
            catch (Exception error)
            {
                Debug.Print(error.ToString());
            }

            return "Error registering!";
        }

    }
}