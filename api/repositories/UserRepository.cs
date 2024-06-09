using api.Interfaces;
using api.Models;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace api.repositories
{
    public class UserRepository : iRepository<User>
    {
         public User GetByID(int id){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT userID, fname, lname, phone, email, password, deleted FROM Users WHERE userID = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            foreach (DataRow row in dataTable.Rows)
            {
                User user = new User
                {
                    userID = row["userID"].ToString(),
                    fname = row["fname"].ToString(),
                    lname = row["lname"].ToString(),
                    fname = row["roleID"].ToString(),
                    phone = row["phone"].ToString(),
                    email = row["email"].ToString(),
                    password = row["password"].ToString(),
                    deleted = Convert.ToInt32(row["deleted"]),
                }
            }
            return user;
         }
        public List<User> GetAll(){

            List<User> users = new List<User>();

            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT userID, fname, lname, phone, email, password, deleted FROM Users";

            using var cmd = new MySqlCommand(stm, con);

            using var reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            foreach (DataRow row in dataTable.Rows)
            {
                User user = new User
                {
                    userID = row["userID"].ToString(),
                    fname = row["fname"].ToString(),
                    lname = row["lname"].ToString(),
                    fname = row["roleID"].ToString(),
                    phone = row["phone"].ToString(),
                    email = row["email"].ToString(),
                    password = row["password"].ToString(),
                    deleted = Convert.ToInt32(row["deleted"]),
                }
                users.Add(user);
            }
            return users;
        }

         void Add(User item){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO Users(userID, fname, lname, phone, email, password, deleted) VALUES(@userID, @fname, @lname, @phone, @email, @password, @deleted)";

            using var cmd = new MySqlCommand(stm,con);

            cmd.Parameters.AddWithValue("@userID", item.userID);
            cmd.Parameters.AddWithValue("@fname", item.fname);
            cmd.Parameters.AddWithValue("@lname", item.lname);
            cmd.Parameters.AddWithValue("@phone", item.phone);
            cmd.Parameters.AddWithValue("@email", item.email);
            cmd.Parameters.AddWithValue("@password", item.fname);
            cmd.Parameters.AddWithValue("@password", item.deleted)

            cmd.Prepare();

            cmd.ExecuteNonQuery();
         }

         void Update(User item){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"UPDATE Users SET fname = @fname, lname = @lname, phone = @phone, email = @email, password = @password deleted = @deleted WHERE userID = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@fname", item.fname);
            cmd.Parameters.AddWithValue("@lname", item.lname);
            cmd.Parameters.AddWithValue("@phone", item.phone);
            cmd.Parameters.AddWithValue("@email", item.email);
            cmd.Parameters.AddWithValue("@password", item.password);
            cmd.Parameters.AddWithValue("@password", item.deleted)
            cmd.Parameters.AddWithValue("@id", item.userID);

            cmd.ExecuteNonQuery();
         }

         void Delete(int id){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE Users SET deleted = 1 WHERE userID = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
         }
    }
}