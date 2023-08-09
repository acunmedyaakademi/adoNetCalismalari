using System.Data.SqlClient;

namespace adonetİlkCalisma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=True; TrustServerCertificate=Yes");
            SqlCommand cmd = new SqlCommand("SELECT CompanyName FROM Customers",conn);

            //updateEmployee(9, "AbdulMecid", conn);
            //printAllEmployees(conn);
        }

        static void updateEmployee(int  employeeId,string firstName, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Employees SET FirstName='"+firstName+"'WHERE EmployeeID="+employeeId,conn);
            conn.Open();
            //cmd.ExecuteNonQuery();
            int affectRow = cmd.ExecuteNonQuery();
            if (affectRow > 0)
            {
                Console.WriteLine($"{employeeId} ID'li kayıt {firstName} olarak güncellenmiştir.");

            }
            else
            {
                Console.WriteLine("kayıt güncellenemedi");
            }
            conn.Close();
        }

        static void printAllEmployees(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT EmployeeID,FirstName,LastName FROM Employees",conn);

            conn.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["EmployeeID"] +"\t" + dr["FirstName"] +"\t" + dr["LastName"]);
            }
            conn.Close();
        }

    }
}