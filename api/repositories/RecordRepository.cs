using api.Interfaces;
using api.Models;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace api.repositories
{
    public class RecordRepository : iRepository<Record>
    {
         public Record GetByID(int id){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT recordID, classrank, timemin, timesec, timems, cpudiff, buildID, userID, deleted FROM records WHERE recordID = @id";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            foreach (DataRow row in dataTable.Rows)
            {
                Record record = new Record
                {
                    recordID = row["recordID"].ToString(),
                    classrank = row["make"].ToString(),
                    timemin = convert.ToInt32(row["timemin"]),
                    timesec = convert.ToInt32(row["timesec"]),
                    timems = convert.ToInt32(row["timems"]),
                    cpudiff = row["cpudiff"].ToString(),
                    buildID = row["buildID"].ToString(),
                    userID = row["userID"].ToString(),
                    deleted = Convert.ToInt32(row["deleted"]),
                }
            }
            return record;
         } 

         public List<Record> GetAll(){
            List<Record> records = new List<Record>();

            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT recordID, classrank, timemin, timesec, timems, cpudiff, buildID, userID, deleted FROM records";

            using var cmd = new MySqlCommand(stm, con);

            using var reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            foreach (DataRow row in dataTable.Rows)
            {
                Record record = new Record
                {
                    recordID = row["recordID"].ToString(),
                    classrank = row["make"].ToString(),
                    timemin = convert.ToInt32(row["timemin"]),
                    timesec = convert.ToInt32(row["timesec"]),
                    timems = convert.ToInt32(row["timems"]),
                    cpudiff = row["cpudiff"].ToString(),
                    buildID = row["buildID"].ToString(),
                    userID = row["userID"].ToString(),
                    deleted = Convert.ToInt32(row["deleted"]),
                }
                records.Add(record);
            }
            return records;
         }

         public void Add(Record item){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO records(recordID, classrank, timemin, timesec, timems, cpudiff, buildID, userID, deleted) VALUES(@recordID, @classrank, @timemin, @timesec, @timems, @cpudiff, @buildID, @userID, @deleted)";

            using var cmd = new MySqlCommand(stm,con);

            cmd.Parameters.AddWithValue("@recordID", item.recordID);
            cmd.Parameters.AddWithValue("@classrank", item.classrank);
            cmd.Parameters.AddWithValue("@timemin", item.timemin);
            cmd.Parameters.AddWithValue("@timesec", item.timesec);
            cmd.Parameters.AddWithValue("@timems", item.timems);
            cmd.Parameters.AddWithValue("@cpudiff", item.cpudiff);
            cmd.Parameters.AddWithValue("@buildID", item.buildID);
            cmd.Parameters.AddWithValue("@userID", item.userID);
            cmd.Parameters.AddWithValue("deleted", deleted);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
         }

         public void Update(Record item){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"UPDATE records SET classrank = @classrank, timemin = @timemin, timesec = @timesec, timems = @timems, cpudiff = @cpudiff, buildID = @buildID WHERE recordID = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@classrank", item.classrank);
            cmd.Parameters.AddWithValue("@timemin", item.timemin);
            cmd.Parameters.AddWithValue("@timesec", item.timesec);
            cmd.Parameters.AddWithValue("@timems", item.timems);
            cmd.Parameters.AddWithValue("@cpudiff", item.cpudiff);
            cmd.Parameters.AddWithValue("@buildID", item.buildID);
            cmd.Parameters.AddWithValue("@id", item.recordID);

            cmd.ExecuteNonQuery();
         }

         public void Delete(int id){
            string cs = Connection.conString;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE records SET deleted = 1 WHERE recordID = @id";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
         }
    }
}