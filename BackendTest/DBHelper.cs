﻿using System;
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

        public static bool ObtainLock(int orderId)
        {
            using (var con = new SqlConnection())
            {
                SqlCommand commandObj = new SqlCommand(CONNSTR, con);

                con.Open();
                return true;
            }

            return false;
        }


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


        public static void MarkOrderAsProcessed(int orderId)
        {
            try
            {
                using (var con = new SqlConnection(CONNSTR))
                {
                    SqlCommand commandObj = new SqlCommand("MarkOrderAsProcessed", con);
                    commandObj.CommandType = CommandType.StoredProcedure;
                    commandObj.Parameters.Add( new SqlParameter("@orderid", orderId) );
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