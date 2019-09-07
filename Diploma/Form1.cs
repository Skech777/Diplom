using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Diploma.Classes;
using System.Collections.Generic;

namespace Diploma
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            AutoScroll = true;
            InitializeComponent();
        }

        //class obj { }
        //public List<obj> sList = new List<obj>();

        private async void Form1_Load(object sender, EventArgs e)
        {

            //Creating some initial data 
            SqlDataReader sqlReader = null;
            Events Event = new Events();
            Thematics theme = new Thematics();
            Congratulations congratulation = new Congratulations();
            SimpleBDObject EventBD = new SimpleBDObject(40,50,60,330, this);
            //Fill ListofEvents
            List<Events> ListofEvents = Event.Fill();

            //Fill ListOfThematics
            List<Thematics> ListofThematics = theme.Fill();

            //Fill ListOfCongratulations
            List<Congratulations> ListOfCongratulations = congratulation.Fill();

            //First eelect when form has alreadde loaded
            EventBD.Select(ListofEvents, EventBD);
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SQLConnectionInfo.SqlConnection != null && SQLConnectionInfo.SqlConnection.State != ConnectionState.Closed)
            {
                SQLConnectionInfo.SqlConnection.Close();
            }
            

        }

        private void ВыходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SQLConnectionInfo.SqlConnection != null && SQLConnectionInfo.SqlConnection.State != ConnectionState.Closed)
            {
                SQLConnectionInfo.SqlConnection.Close();
            }
            this.Close();
        }
    }
}
