using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace Diploma.Classes
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

        public SimpleBDObject(int x, int y, int height, int width, Form1 _mainForm)
        {
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
            this.MainForm = _mainForm;
            Console.WriteLine("X="+ this.X + "; Y="+ this.Y +"; Height="+ this.Height+"; Width="+ this.Width);
        }
        

        public virtual void Select(int index)
        {
            Console.WriteLine("Performing base class selecting all with index");
        }

        public virtual void Select(List<Events> List, SimpleBDObject @object)
        {
            
            try
            {
                Button SQLButton;
                foreach (var i in List)
                {
                    SQLButton = new Button
                    {
                        Size = new Size(@object.Width, @object.Height),
                        Location = new Point(@object.X, @object.Y),
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular,
                        System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                        Text = i.GetName() 
                    };
                    MainForm.Controls.Add(SQLButton);
                    Y += 95;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public virtual void Find(string symbols)
        {
            Console.WriteLine("Performing base class finding by symbols");
        }

        public virtual void Clear()
        {
            Console.WriteLine("Performing base class clearing display");
        }
        
    }
}
