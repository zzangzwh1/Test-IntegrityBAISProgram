using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Net.Quic;

namespace Test_IntegrityBAISProgram
{
    public class DataService
    {
        public static void GetProgramData()
        {
            string connectionString = @"Persist Security Info=false; Integrated Security=true; Database=NaitTest; Server= (localdb)\Local; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetProgramData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        if (reader.HasRows)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader.GetName(i));
                                Console.Write("  ");

                            }
                            Console.WriteLine("");
                            while (reader.Read())
                            {
                                Console.Write($"{reader[0]} {reader[1]}");
                                Console.WriteLine();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        reader.Close();
                        connection.Close();
                    }
                }

            }

        }
        public static void AddDataIntoProgram(string programCode, string description)
        {
            string connectionString = @"Persist Security Info=false; Integrated Security=True; Database=NaitTest; Server=(localdb)\Local; ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("AddProgram", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //if you want to put sqldbtyp.nvarchar
                    /* command.Parameters.Add("@programCode", SqlDbType.NVarChar).Value = programCode;
                     command.Parameters.Add("@description", SqlDbType.NVarChar).Value = description;*/

                    // since i am interting data through parameter 
                    // and parameter is already string type so no necessary putting sqldbtype.nvarchar
                    command.Parameters.AddWithValue("@programCode", programCode);
                    command.Parameters.AddWithValue("@description", description);

                    command.ExecuteNonQuery();

                    conn.Close();


                }
            }
        }
        public static void GetOneProgram(string programCode)
        {
            string connectionString = @"Persist Security Info=false; Integrated Security=true; database=NaitTest; Server=(localdb)\Local; ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetOnedata", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@programCode", programCode);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            for(int i=0; i<reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i)} ");
                               
                                
                            }
                            Console.WriteLine();
                            Console.WriteLine($"---------------------------");
                            while (reader.Read())
                            {
                                Console.Write($"{reader[0]} {reader[1]}");
                                Console.WriteLine();
                            }
                        }
                        reader.Close();
                        conn.Close();
                    }
                }
            }
        }
    }
}
