using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Diploma.Classes;

namespace Diploma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            AutoScroll = true;
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            SQLConnectionInfo.SqlConnection.Open();
            SQLConnectionInfo.SqlCommand = new SqlCommand("SELECT * FROM [Events]", SQLConnectionInfo.SqlConnection);

            SqlDataReader sqlReader = null;
            try
            {
                Button SQLButton;
                int y = 50;
                sqlReader = await SQLConnectionInfo.SqlCommand.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    SQLButton = new Button
                    {
                        Size = new Size(330, 60),
                        Location = new Point(40, y),
                        Text = sqlReader["Name"].ToString()
                    };
                    Controls.Add(SQLButton);
                    y += 95;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SQLConnectionInfo.SqlConnection != null && SQLConnectionInfo.SqlConnection.State != ConnectionState.Closed)
            {
                SQLConnectionInfo.SqlConnection.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SQLConnectionInfo.SqlConnection != null && SQLConnectionInfo.SqlConnection.State != ConnectionState.Closed)
            {
                SQLConnectionInfo.SqlConnection.Close();
            }
        }

    }
}
