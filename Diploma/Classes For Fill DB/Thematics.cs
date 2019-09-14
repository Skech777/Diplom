using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Classes
{
    public  class Thematics
    {
        public int Id;
        public string Description;
        public int EventId;

        public Thematics() { }
        public Thematics(int Id, string Description, int EventId)
        {
            this.Id = Id;
            this.Description = Description;
            this.EventId = EventId;
        }

        public int GetId() => Id;
        public string GetDescription() => Description;
        public int GetEventId() => EventId;


        public List<Thematics> Fill()
        {
            SQLConnectionInfo.SqlConnection.Open();
            SQLConnectionInfo.SqlCommand = new SqlCommand("SELECT * FROM [Thematics]", SQLConnectionInfo.SqlConnection);
            SqlDataReader sqlReader = null;
            List<Thematics> ListofThematics = new List<Thematics>();
            sqlReader = SQLConnectionInfo.SqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                string ThematicId = sqlReader["ThematicId"].ToString();
                string Description = sqlReader["Description"].ToString();
                string EventId = sqlReader["EventId"].ToString();
                Thematics ThematicsTemplate = new Thematics(Convert.ToInt32(ThematicId), Description, Convert.ToInt32(EventId));
                ListofThematics.Add(ThematicsTemplate);
            }
            SQLConnectionInfo.SqlConnection.Close();
            return ListofThematics;
        }
    }
}
