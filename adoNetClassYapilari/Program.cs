using adoNetClassYapilari.Models;
using System.Data.SqlClient;
using System.Numerics;

namespace adoNetClassYapilari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = DB.conn();

            //callCatetories(conn);
            callCustomers(conn);

        }
        static void callCatetories(SqlConnection conn)
        {

            SqlCommand cmd = new SqlCommand("SELECT CategoryID,CategoryName,Description FROM Categories", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<category> categoryList = new List<category>();


            while (dr.Read())
            {
                category category = new category();
                category.categoryID = (int)dr["CategoryID"];
                category.categoryName = (string)dr["CategoryName"];
                category.Description = (string)dr["Description"];
                categoryList.Add(category);
            }
            conn.Close();
            foreach (category category1 in categoryList)
            {
                Console.WriteLine(category1.categoryID + " " + category1.categoryName);
            }
        }
        static void callCustomers(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT CustomerID,CompanyName,City,Country,Phone FROM Customers", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            List<Customers>customerList=new List<Customers>();
            while (dr.Read())
            {
                Customers customers = new Customers();
                customers.CustomerID = (string)dr["CustomerID"];
                customers.CompanyName = (string)dr["CompanyName"];
                customers.City = (string)dr["City"];
                customers.Country = (string)dr["Country"];
                customers.phone = (string)dr["Phone"];
                customerList.Add(customers);
            }
            conn.Close();
            //foreach (Customers data in customerList)
            //{
            //    Console.WriteLine(data.CustomerID + " " + data.Country + " " + data.City+" "+data.phone);
            //}
            
            var sortedCustomerList = customerList.OrderBy(c => c.Country).ThenBy(c => c.City).ToList();

            foreach (Customers data in sortedCustomerList)
            {
                Console.WriteLine($"{data.Country} \t {data.City} \t \t {data.CustomerID} \t {data.CompanyName} \t {data.phone} ");
            }

        }
    }
}