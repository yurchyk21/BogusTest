using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trans
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public User(int Id, string FullName, string Role)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Role = Role;
        }
    }
    public class Mdl
    {
        public static List<User> users = new List<User>();
        public static void ReadOrderData(string connectionString)
        {
            string queryString = "SELECT dbo.Users.Id, dbo.Users.FirstName + ' ' + dbo.Users.Name + ' ' + dbo.Users.LastName AS Name, dbo.Roles.Name AS Role FROM dbo.Roles INNER JOIN dbo.Users ON dbo.Roles.Id = dbo.Users.RoleId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IDataRecord curRow = (IDataRecord)reader;
                    users.Add(new User(int.Parse(curRow[0].ToString()), curRow[1].ToString(), curRow[2].ToString()));
                }
                reader.Close();
            }
        }
        public static void InsertOrderData()
        {

        }
    }
}
