using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using Diploma.Classes;

namespace Diploma.Classes_For_DB_Transaction
{
    public class SimpleBDObject
    {
		//MainForm
		public Form MainForm;	

        // Location
        public int X { get; private set; }
        public int Y { get; private set; }
        
        //Size
        public int Height { get; private set; }
        public int Width { get; private set; }

        public static EventHandler Click;

        public SimpleBDObject() { }
        public SimpleBDObject(int x, int y, int height, int width, Form1 _mainForm)
        {
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
            this.MainForm = _mainForm;
            Console.WriteLine("X="+ this.X + "; Y="+ this.Y +"; Height="+ this.Height+"; Width="+ this.Width);
        }

        public virtual void Select(List<Congratulations> List, CongratulationTransaction @object, int indexOfSelect)
        {
            Console.WriteLine("Performing base class selecting all info from Events by loading form");
        }
        public virtual void Select(List<Thematics> List, ThematicTransaction @object, int indexOfSelect)
        {
            Console.WriteLine("Performing base class selecting all with index");
        }      

        public virtual void Select(List<Events> List, EventTransaction @object)
        {
            Console.WriteLine("Performing base class selecting all info from Events by loading form");
        }        

        public virtual void Find(string symbols)
        {
            Console.WriteLine("Performing base class finding by symbols");
        }

        public void Clear()
        {
            for (int i = 0; i < MainForm.Controls.Count; i++)
            {
                if (MainForm.Controls[i] is Button)
                {
                    (MainForm.Controls[i] as Button).Dispose();
                    i--;
                }
            }
        }
        
    }
}
