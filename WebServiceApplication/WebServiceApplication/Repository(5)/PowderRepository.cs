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
    public class PowderRepository
    {
        SqlConnection connection;

        public PowderRepository()
        {
            connection = new SqlConnection(ConnectionHelper.connectionString);
        }


        public List<Powder> getAllPowders()
        {
            List<Powder> powders = new List<Powder>();

            try
            {
                if (connection.State == ConnectionState.Closed)
                {

                    connection.Open();

                }

                SqlCommand command = new SqlCommand("SELECT * FROM [Powder]", connection);

                SqlDataReader result = command.ExecuteReader();

                while (result.Read())
                {
                    powders.Add(PowderFactory.createPowder((Int32)result.GetValue(0), (String)result.GetValue(1), (Int32)result.GetValue(2), (Int32)result.GetValue(3), (String)result.GetValue(4), (String)result.GetValue(5)));

                }
                connection.Close();

            }
            catch (Exception error)
            {
                Debug.Print(error.ToString());
            }

            return powders;
        }

        public String updateStocks(List<Powder> powders, String id)
        {

            try
            {
                if (connection.State == ConnectionState.Closed)
                {

                    connection.Open();


                }

                SqlCommand insert = new SqlCommand("INSERT INTO [Transaction](CustomerID) VALUES(@id) ", connection);

                insert.Parameters.AddWithValue("id", id);
                insert.ExecuteNonQuery();
                
                connection.Close();

                if (connection.State == ConnectionState.Closed)
                {

                    connection.Open();

                }

                SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM [Transaction] ORDER BY ID DESC", connection);

                SqlDataReader result = command.ExecuteReader();
                int transactionID = 0;

                if (result.Read())
                {
                    transactionID = (Int32)result.GetValue(0);
                }
                result.Close();
                for (int i = 0; i < powders.Count; i++)
                {

                    SqlCommand ins = new SqlCommand("INSERT INTO DetailTransaction(TransactionID,PowderID,Quantity) VALUES(@transactionId,@powderId,@quantity) ", connection);

                    ins.Parameters.AddWithValue("transactionId", transactionID);
                    ins.Parameters.AddWithValue("powderId", powders[i].id);
                    ins.Parameters.AddWithValue("quantity", powders[i].stock);
                    ins.ExecuteNonQuery();

                    SqlCommand update = new SqlCommand("UPDATE [Powder] SET Stock=Stock-@stock WHERE ID=@id", connection);

                    update.Parameters.AddWithValue("stock", powders[i].stock);
                    update.Parameters.AddWithValue("id", powders[i].id);
                    int affected = update.ExecuteNonQuery();
                }
                
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
                return "Success checking out!";

            }
            catch (Exception error)
            {
                Debug.Print(error.ToString());
            }

            return "Error checking out!";
        }

        public String deletePowder(Int32 id)
        {

            try
            {
                if (connection.State == ConnectionState.Closed)
                {

                    connection.Open();


                }
                
                SqlCommand delete = new SqlCommand("DELETE FROM [Powder] WHERE ID=@id", connection);
                
                delete.Parameters.AddWithValue("id", id);
                int affected = delete.ExecuteNonQuery();
               

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
                return "Success deleting powder!";

            }
            catch (Exception error)
            {
                Debug.Print(error.ToString());
            }

            return "Error deleting powder!";
        }

    }
}