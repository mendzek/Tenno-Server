using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tenno_Server.Models
{
    public class Warframes : DbContext
    {
        public DbSet<Warframe> Warframes_units { get; set; }
        public static int warframe_number;
        public string textNumOfWarframes = $"There is all {warframe_number} warframes. You can learn anything about them here.";
        public object warframe_id;
        public object warframe_name;
        public object warframe_HP;
        public object warframe_Mana;
        public List<Warframe> warframesList = new();

        string connectionString = "Data Source=TennoServer.db";

        public void SqlShowAllWarframes()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM Warframes";
                object numOfRows=0;
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            numOfRows = reader.GetValue(0);
                        }
                    }
                }
                
                

                foreach (var x in Enumerable.Range(1, Convert.ToInt32(numOfRows)))
                {
                    Warframe warframeTemp = new Warframe();
                    command.CommandText = $"SELECT id, name, health, mana FROM Warframes WHERE id={x}";
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                warframeTemp.id = Convert.ToInt32(reader.GetValue(0));
                                warframeTemp.name = reader.GetValue(1).ToString();
                                warframeTemp.health = Convert.ToInt32(reader.GetValue(2));
                                warframeTemp.mana = Convert.ToInt32(reader.GetValue(3));
                            }
                        }
                    }
                    warframesList.Add(warframeTemp);
                }
            }
        }

        public class Warframe
        {
            public int? id;
            public string? name;
            public int? health;
            public int? mana;

            public Warframe(){} 
            public Warframe(int id, string name, int HP, int Mana)
            {
                this.id = id;
                this.name = name;
                this.health = HP;
                this.mana = Mana;
            }
        }
    }

}
