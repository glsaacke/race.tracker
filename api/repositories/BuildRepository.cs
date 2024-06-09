using api.Interfaces;
using api.Models;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace api.repositories
{
    public class buildRepository : iRepository<build>
    {
         public Build GetByID(int id){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT buildID, make, model, rank, speedST, handlingST, accelerationST, launchST, brakingST, offroadST, userID, deleted FROM builds WHERE buildID = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            foreach (DataRow row in dataTable.Rows)
            {
                Build build = new Build
                {
                    buildID = row["buildID"].ToString(),
                    make = row["make"].ToString(),
                    model = row["model"].ToString(),
                    rank = row["rank"].ToString(),
                    speedST = convert.ToDouble(row["speedST"]),
                    handlingST = convert.ToDouble(row["handlingST"]),
                    accelerationST = convert.ToDouble(row["accelerationST"]),
                    launchST = convert.ToDouble(row["launchST"]),
                    brakingST = convert.ToDouble(row["brakingST"]),
                    offroadST = convert.ToDouble(row["offroadST"]),
                    userID = row["userID"].ToString(),
                    deleted = Convert.ToInt32(row["deleted"]),
                }
            } 
            return build;
         }

         public List<Build> GetAll(){
            List<Build> builds = new List<Build>();

            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT buildID, make, model, rank, speedST, handlingST, accelerationST, launchST, brakingST, offroadST, userID, deleted FROM builds";

            using var cmd = new MySqlCommand(stm, con);

            using var reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            foreach (DataRow row in dataTable.Rows)
            {
                Build build = new Build
                {
                    buildID = row["buildID"].ToString(),
                    make = row["make"].ToString(),
                    model = row["model"].ToString(),
                    rank = row["rank"].ToString(),
                    speedST = convert.ToDouble(row["speedST"]),
                    handlingST = convert.ToDouble(row["handlingST"]),
                    accelerationST = convert.ToDouble(row["accelerationST"]),
                    launchST = convert.ToDouble(row["launchST"]),
                    brakingST = convert.ToDouble(row["brakingST"]),
                    offroadST = convert.ToDouble(row["offroadST"]),
                    userID = row["userID"].ToString(),
                    deleted = Convert.ToInt32(row["deleted"]),
                }
                builds.Add(build);
            }
            return builds;
         }

         public void Add(Build item){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO builds(buildID, make, model, rank, speedST, handlingST, accelerationST, launchST, brakingST, offroadST, userID, deleted) VALUES(@buildID, @make, @model, @rank, @speedST, @handlingST, @accelerationST, @launchST, @brakingST, @offroadST, @userID, @deleted)";

            using var cmd = new MySqlCommand(stm,con);

            cmd.Parameters.AddWithValue("@buildID", item.buildID);
            cmd.Parameters.AddWithValue("@make", item.make);
            cmd.Parameters.AddWithValue("@model", item.model);
            cmd.Parameters.AddWithValue("@rank", item.rank);
            cmd.Parameters.AddWithValue("@speedST", item.speedST);
            cmd.Parameters.AddWithValue("@handlingST", item.handlingST);
            cmd.Parameters.AddWithValue("@accelerationST", item.accelerationST);
            cmd.Parameters.AddWithValue("@launchST", item.launchST);
            cmd.Parameters.AddWithValue("@brakingST", item.brakingST);
            cmd.Parameters.AddWithValue("@offroadST", item.offroadST);
            cmd.Parameters.AddWithValue("@userID", item.userID);
            cmd.Parameters.AddWithValue("deleted", deleted);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
         }

         public void Update(Build item){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"UPDATE builds SET make = @make, model = @model, rank = @rank, speedST = @speedST, handlingST = @handlingST, accelerationST = @accelerationST, launchST = @launchST, brakingST = @brakingST, offroadST = @offroadST WHERE buildID = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@make", item.make);
            cmd.Parameters.AddWithValue("@model", item.model);
            cmd.Parameters.AddWithValue("@rank", item.rank);
            cmd.Parameters.AddWithValue("@speedST", item.speedST);
            cmd.Parameters.AddWithValue("@handlingST", item.handlingST);
            cmd.Parameters.AddWithValue("@accelerationST", item.accelerationST);
            cmd.Parameters.AddWithValue("@launchST", item.launchST);
            cmd.Parameters.AddWithValue("@brakingST", item.brakingST);
            cmd.Parameters.AddWithValue("@offroadST", item.offroadST);
            cmd.Parameters.AddWithValue("@id", item.buildID);

            cmd.ExecuteNonQuery();
         }

         public void Delete(int id){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE builds SET deleted = 1 WHERE buildID = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
         }
    }
}