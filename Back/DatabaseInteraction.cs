
using MySql.Data.MySqlClient;
using System.Data;

namespace ScooterSharing.Back
{
    internal class DatabaseInteraction
    {
        MySqlConnection Conn;
        MySqlCommand Cmd;
        MySqlDataAdapter Adapter;
        string Command;
        readonly string ConnStr = "Server = 95.183.12.18; Port = 3306; Database = samokat; user = samokat";
        public void DeleteData(string Tag, int ID)
        {
            string command = $"DELETE FROM {Tag} WHERE Номер = '{ID}'";
            using (Conn = new MySqlConnection(ConnStr))
            {
                Cmd = new MySqlCommand(command, Conn);
                Conn.Open();
                int rowsAffected = Cmd.ExecuteNonQuery();
            }
        }
        public void DoCommand(string command)
        {
            using (Conn = new(ConnStr))
            {
                Conn.Open();
                using (Cmd = new(command, Conn))
                {
                    Cmd.ExecuteNonQuery();
                }
                Conn.Close();
            }
        }
        public DataTable GetData(string command)
        {
            DataTable DataTable = new DataTable();
            Command = command;
            using (Conn = new MySqlConnection($"{ConnStr}"))
            {
                Conn.Open();
                using (Cmd = new MySqlCommand($"{command}", Conn))
                {
                    Adapter = new MySqlDataAdapter(Cmd);
                    Adapter.Fill(DataTable);
                }
                Conn.Close();
                return DataTable;
            }
        }
    }
}
