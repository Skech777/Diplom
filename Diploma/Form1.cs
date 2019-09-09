using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Diploma.Classes;
using System.Collections.Generic;
using Diploma.Classes_For_DB_Transaction;

namespace Diploma
{
    public partial class Form1 : Form
    {
        //Creating some initial data 
        SqlDataReader sqlReader = null;
        Events Event = new Events();
        Thematics Theme = new Thematics();
        Congratulations Congratulation = new Congratulations();

        EventTransaction EventBD;
        ThematicTransaction ThemeBD;
        CongratulationTransaction CongratulationBD;

        List<Events> ListofEvents;
        List<Thematics> ListofThematics;
        List<Congratulations> ListOfCongratulations;

        int indexOfEvent;
        int indexOfTheme;
        public Form1()
        {
            AutoScroll = true;
            InitializeComponent();

            EventTransaction.Click = SQLButton_Click;
        }

        private void SQLButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var myObj = button.Tag;
            if (button.Tag.GetType() == new Events().GetType())
            {
                ThemeBD.Clear();
                var eventObject = (Events)myObj;
                indexOfEvent = eventObject.GetId();
                ThemeBD.Select(ListofThematics, ThemeBD, indexOfEvent);

            }
            else if (button.Tag.GetType() == new Thematics().GetType())
            {
                CongratulationBD.Clear();
                var eventObject = (Thematics)myObj;
                indexOfTheme = eventObject.GetId();
                CongratulationBD.Select(ListOfCongratulations, CongratulationBD, indexOfTheme);
            }
            else if (button.Tag.GetType() == new Congratulations().GetType())
            {
                var eventObject = (Congratulations)myObj;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EventBD = new EventTransaction(40, 50, 60, 330, this);
            ThemeBD = new ThematicTransaction(40, 50, 60, 330, this);
            CongratulationBD = new CongratulationTransaction(40, 50, 60, 330, this);
            //Fill ListofEvents
            ListofEvents = Event.Fill();
            //Fill ListOfThematics
            ListofThematics = Theme.Fill();
            //Fill ListOfCongratulations
            ListOfCongratulations = Congratulation.Fill();
            //First select when form has alreadde loaded
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


        private void Label1_Click(object sender, EventArgs e)
        {
            if (indexOfTheme != 0)
            {
                ThemeBD.Clear();
                ThemeBD.Select(ListofThematics, ThemeBD, indexOfEvent);

            }
            else if (indexOfEvent != 0)
            {
                ThemeBD.Clear();
                EventBD.Select(ListofEvents, EventBD);
            }
        }
    }
}
