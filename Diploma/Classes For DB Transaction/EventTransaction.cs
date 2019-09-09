using Diploma.Classes;
using Diploma.Classes_For_DB_Transaction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma.Classes_For_DB_Transaction
{
    public class EventTransaction : SimpleBDObject
    {
        // Font 
        private readonly Font Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
        public EventTransaction(int x, int y, int height, int width, Form1 _mainForm) : base(x, y, height, width, _mainForm) { }

        
        public override void Select(List<Events> List, EventTransaction @object)
        {
            int Y = @object.Y;
            try
            {
                Button SQLButton;
                foreach (var i in List)
                {
                    SQLButton = new Button
                    {
                        Size = new Size(@object.Width, @object.Height),
                        Location = new Point(@object.X, Y),
                        Font = @object.Font,
                        Text = i.GetName(),
                        Tag = i
                    };
                    MainForm.Controls.Add(SQLButton);
                    Y += 95;
                    SQLButton.Click += Click;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
