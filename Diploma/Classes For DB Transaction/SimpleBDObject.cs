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

        public virtual void Find(string symbols, List<Events> listOfEvents, ThematicTransaction @theme, List<Thematics> listOfThematics)
        {
            int Y = @theme.Y;
            try
            {
                Button SQLButton;

                listOfThematics = listOfThematics.FindAll(x => x.GetDescription() == symbols);
                foreach (var i in listOfThematics)
                {
                    List<Events> Event = listOfEvents.FindAll(p=> p.GetId() == i.GetEventId());
                    string eventId = default;
                    foreach (var item in Event)
                    {
                        eventId = item.GetName();
                    }
                    SQLButton = new Button
                    {
                        Size = new Size(@theme.Width, @theme.Height),
                        Location = new Point(@theme.X, Y),
                        Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204),
                        Text = i.GetDescription() + "\n"+ eventId,
                        Tag = i
                    };
                    theme.MainForm.Controls.Add(SQLButton);
                    Y += 95;
                    SQLButton.Click += Click;
                }

                listOfEvents = listOfEvents.FindAll(p => p.GetName() == symbols);
                foreach (var i in listOfEvents)
                {
                    SQLButton = new Button
                    {
                        Size = new Size(@theme.Width, @theme.Height),
                        Location = new Point(@theme.X, Y),
                        Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 204),
                        Text = i.GetName(),
                        Tag = i
                    };
                    theme.MainForm.Controls.Add(SQLButton);
                    Y += 95;
                    SQLButton.Click += Click;
                }
                
                if (listOfEvents.Count() == 0 && listOfThematics.Count() == 0)
                {
                    Label SQLLabel;
                    SQLLabel = new Label
                    {
                        Size = new Size(@theme.Width, @theme.Height),
                        Location = new Point(@theme.X, Y),
                        Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 204),
                        Text = "На ваш запрос не нашлось результата"
                    };
                    theme.MainForm.Controls.Add(SQLLabel);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            for (int i = 0; i < MainForm.Controls.Count; i++)
            {
                if (MainForm.Controls[i] is Label)
                {
                    (MainForm.Controls[i] as Label).Dispose();
                    i--;
                }
            }
        }
        
    }
}
