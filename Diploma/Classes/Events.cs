using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Classes
{
    class Events
    {
        private int Id;
        private string Name;

        public Events() { }
        public Events(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public int GetId() => Id;
        public string GetName() => Name;

        public List<Events> Fill()
        {
            List<Events> ListofEvents = new List<Events>();
            SQLConnectionInfo.SqlConnection.Open();
            SQLConnectionInfo.SqlCommand = new SqlCommand("SELECT * FROM [Events]", SQLConnectionInfo.SqlConnection);
            SqlDataReader sqlReader = null;

            sqlReader =  SQLConnectionInfo.SqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                string EventId = sqlReader["EventId"].ToString();
                string Name = sqlReader["Name"].ToString();
                Events EventTemplate = new Events(Convert.ToInt32(EventId), Name);
                ListofEvents.Add(EventTemplate);
            }
            SQLConnectionInfo.SqlConnection.Close();
            return ListofEvents;
        }
    }
}
