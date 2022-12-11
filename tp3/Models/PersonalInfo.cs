using System.Data.SQLite;
using System.Diagnostics;

namespace tp3.Models
{
    public class PersonalInfo
    {
        public List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();
            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=C:\\Users\\LENOVO\\Downloads\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            sQLiteConnection.Open();
            using (sQLiteConnection)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", sQLiteConnection);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        Person p = new Person(
                            id,
                            first_name,
                            last_name,
                            email,
                            image,
                            country
                            );
                        list.Add(p);
                    }
                }
            }
            return list;
        }
        public Person getPerson(int id)
        {
            PersonalInfo personalInfo = new PersonalInfo();
            List<Person> list = personalInfo.GetAllPerson();
            Person person =list.Find(delegate(Person p) { return p.id == id; });
            return person;
        }
    }
}
