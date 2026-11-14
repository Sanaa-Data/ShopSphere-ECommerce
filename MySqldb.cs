using MySql.Data.MySqlClient;
using System.Data;

namespace Ray_Sanaa_Final_Project
{
    internal class MySqldb
    {
     
        string connectionString;

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
 
        public string Email { get; set; }

        public MySqldb(string username, string name, string email, string password, string phone,string address,string country )
        {
          
          Email=email;
          Name = name;
          Username = username;
          Password= password;
          PhoneNumber = phone;
          Address = address;
          Country = country;
        }
        public MySqldb(string dbName)
        {
            connectionString =
        $"server=localhost;user id=root;password=;port=3306;database={dbName}";

        }

        public int ExecuteQuery(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection connection =
                   new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command =
                       new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();

                    return Convert.ToInt32(command.LastInsertedId);
                }
            }
        }
        public DataTable GetData(string sql, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public  DataTable TotalCustomers()
        {
          string sql = "SELECT COUNT(*)  AS Customers FROM customers";
          return GetData(sql);
        }
        public DataTable TotalProducts()
        {
            string sql = "SELECT COUNT(*)  AS Products FROM product";
            return GetData(sql);
        }
        public DataTable TotalOrders()
        {
            string sql = "SELECT COUNT(*)  AS Orders FROM orders  WHERE Status != 'Cancelled'";
            return GetData(sql);
        }
        public DataTable TotalRevenue() 
        {
            string sql = "SELECT IFNULL(SUM(TotalAmount),0) AS Revenue FROM orders  WHERE Status != 'Cancelled'";
            return GetData(sql);
        }
    }
}
