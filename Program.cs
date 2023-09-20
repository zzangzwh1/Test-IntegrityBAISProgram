﻿using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
namespace Test_IntegrityBAISProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetProgramExcuteReader();
        }
        public static void GetProgramExcuteReader()
        {
            Console.WriteLine("GetProgramExcuteReader");
            SqlConnection conn = new();
            conn.ConnectionString = @"Persist Security Info=false; Integrated Security = True; Database=NaitTemp; Server=(localDB)\mssqlLocalDb;";
            conn.Open();

            SqlCommand command = new()
            {
                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgramData"
            };
            SqlDataReader reader;

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine($"Columns");
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i));
                }
                Console.WriteLine($"Values ");
                Console.WriteLine("---------");
                while (reader.Read())
                {
                    Console.Write($"{reader[0].ToString()} {reader[1].ToString()}");
                    Console.WriteLine();
                }
            }

            reader.Close();
            conn.Close();

        }
        public static void AddProgramExcuteNoneQueryExample()
        {

            /*   SqlConnection myDatasource; // declaration
               myDatasource = new(); // instantiation
               myDatasource.ConnectionString = "Persist Security Info=false; Integrated Security = True; Database=NaitTemp; Server=(localDB)\\mssqlLocalDb;";*/
            string connectionString = @"Persist Security Info=false; Integrated Security = True; Database=NaitTemp; Server=(localDB)\mssqlLocalDb;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Addprogram";

            SqlParameter parameter;

            parameter = new()
            {
                ParameterName = "@programCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "BAIST5"
            };
            command.Parameters.Add(parameter);

            parameter = new()
            {
                ParameterName = "@description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Bachelor of Applied information System Techonology5"
            };

            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();


            conn.Close();

        }

        public static void AddExcuteNoneQueryEx()
        {
            string connectionString = @"Persist Security Info=false; Integrity Security= True; Database=NaitTemp; Server=(localDB)\mssqlLocalDb;";
            string insertProcedure = @"Exec Addprogram @value1 @value2";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(insertProcedure, conn);


            conn.Close();

        }
    }
}