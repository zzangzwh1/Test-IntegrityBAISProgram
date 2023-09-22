using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
//using static System.Net.Mime.MediaTypeNames;

namespace Test_IntegrityBAISProgram
{
    internal class Program
    {    //1. register project fir SQLSERVER
        static void Main(string[] args)
        {
            DataService.GetProgramData();

            //  DataService.AddDataIntoProgram("Baist3", "This is Baist3 Test");
            //  DataService.GetOneProgram("Baist3");

            //  DataService.ChangeDescriptionInProgram("TEST2", "2nd time  Test2 Data Changed");

            // Console.ReadLine();
        }



    }
}