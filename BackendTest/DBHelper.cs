using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Threading;

namespace BackendTest
{
    static class DBHelper
    {

        const string CONNSTR = "data source = localhost; initial catalog = Test; integrated security = true;";

        /// <summary>
        /// Get order for processing
        /// </summary>
        /// <returns></returns>
        public static int GetOrder()
        {
            try
            {
                using (var con = new SqlConnection(CONNSTR))
                {
                    SqlCommand commandObj = new SqlCommand("GetOrderForProcessing", con);
                    con.Open();
                    return (int)commandObj.ExecuteScalar();
                }
            }
            catch(System.Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }

            return -1;
        }


        public static void MarkOrderAsProcessed(int orderId, string serviceName)
        {
            try
            {
                using (var con = new SqlConnection(CONNSTR))
                {
                    SqlCommand commandObj = new SqlCommand("MarkOrderAsProcessed", con);
                    commandObj.CommandType = CommandType.StoredProcedure;
                    commandObj.Parameters.Add( new SqlParameter("@orderid", orderId) );
                    commandObj.Parameters.Add(new SqlParameter("@service", serviceName));
                    con.Open();
                    commandObj.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }

           
        }

    }
}
