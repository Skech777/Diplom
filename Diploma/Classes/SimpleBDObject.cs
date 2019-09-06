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

namespace Diploma.Classes
{
    public class SimpleBDObject
    {
        // Location
        public int X { get; private set; }
        public int Y { get; private set; }
        
        //Size
        public int Height { get; private set; }
        public int Width { get; private set; }

        public SimpleBDObject(int x, int y, int height, int width)
        {
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
            Console.WriteLine("X="+ this.X + "; Y="+ this.Y +"; Height="+ this.Height+"; Width="+ this.Width);
        }
        /*
        public virtual void Select(int index)
        {
            Console.WriteLine("Performing base class selecting all");
        }
        public virtual void Select<T>(List<T> List)
        {
            
            try
            {
                Button SQLButton;
                int y = 50;
                foreach (var i in List)
                {
                    SQLButton = new Button
                    {
                        Size = new Size(330, 60),
                        Location = new Point(40, y),
                        Text = i.GetText() + "\n" + i.GetAuthor()
                    };
                    Controls.Add(SQLButton);
                    y += 95;
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
        */
    }
}
