using System;
using System.Data;
using System.Data.SqlClient;

namespace DBO_opgave
{
    class Program
    {
        static void Main(string[] args)
        {
            //getall();

            // DNumber kan være 1,4,5
            //getallByDNumber(5);


             //DeleteDep(10);


            //updatedname(1, "Headquarters");
             
            
            //CreateDepartment("test50", 50, 123456789);
        }


        private static void getall()
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("getAlleDeparment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }

            // Call Close when done reading.
            reader.Close();
        }

        private static void getallByDNumber(int dnum)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetDepartmentByDNumber ", conn);
            cmd.Parameters.Add("@dnum", SqlDbType.Int).Value = dnum;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }
            Console.WriteLine("check databasen");
            // Call Close when done reading.
            reader.Close();
        }

        private static void DeleteDep(int dnum)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("DleteDempartment ", conn);
            cmd.Parameters.Add("@dnum", SqlDbType.Int).Value = dnum;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("check databasen");
        }
        
        private static void updatedname(int dnum, string DName)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateDepartmentName ", conn);
            cmd.Parameters.Add("@DNumber", SqlDbType.Int).Value = dnum;
            cmd.Parameters.Add("@DName", SqlDbType.NVarChar).Value = DName;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Close();
            Console.WriteLine("check databasen");
        }

        private static void CreateDepartment(string dname, int dnumber, int mgrssn)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=Company;Trusted_Connection=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("CreateDepartment ", conn);
            cmd.Parameters.Add("@DNum", SqlDbType.Int).Value = dnumber;
            cmd.Parameters.Add("@DName", SqlDbType.NVarChar).Value = dname;
            cmd.Parameters.Add("@MgrSSN", SqlDbType.Int).Value = mgrssn;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("check databasen");
        }


    }
}
