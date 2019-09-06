using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Classes
{
    class Congratulations
    {
        private int Id;
        private string Text;
        private string Author;
        private int ThematicId;

        public Congratulations() { }
        public Congratulations(int Id, string Text, string Author, int ThematicId)
        {
            this.Id = Id;
            this.Text = Text;
            this.Author = Author;
            this.ThematicId = ThematicId;
        }

        public int GetId() => Id;
        public string GetText() => Text;
        public string GetAuthor() => Author;
        public int GetThematicId() => ThematicId;

        public List<Congratulations> Fill()
        {
            List<Congratulations> ListofCongratulations = new List<Congratulations>();

            SQLConnectionInfo.SqlConnection.Open();
            SQLConnectionInfo.SqlCommand = new SqlCommand("SELECT * FROM [Congratulations]", SQLConnectionInfo.SqlConnection);
            SqlDataReader sqlReader = null;

            sqlReader = SQLConnectionInfo.SqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                string CongratulationId = sqlReader["CongratulationId"].ToString();
                string Text = sqlReader["Text"].ToString();
                string Author = sqlReader["Author"].ToString();
                string ThematicId = sqlReader["ThematicId"].ToString();

                Congratulations CongratulationsTemplate = new Congratulations(Convert.ToInt32(CongratulationId), Text, Author, Convert.ToInt32(ThematicId));
                ListofCongratulations.Add(CongratulationsTemplate);
            }
            SQLConnectionInfo.SqlConnection.Close();
            return ListofCongratulations;
        }
    }
}
