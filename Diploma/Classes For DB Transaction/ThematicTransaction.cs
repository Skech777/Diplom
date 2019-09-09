using Diploma.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma.Classes_For_DB_Transaction
{
    public class ThematicTransaction : SimpleBDObject
    {
        private readonly Font Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
        public ThematicTransaction(int x, int y, int height, int width, Form1 _mainForm) : base(x, y, height, width, _mainForm) { }



        public override void Select(List<Thematics> List, ThematicTransaction @object, int indexOfSelect)
        {
            int Y = @object.Y;
            try
            {
                Button SQLButton;
                List = List.FindAll(p => p.GetEventId() == indexOfSelect);
                foreach (var i in List)
                {
                    SQLButton = new Button
                    {
                        Size = new Size(@object.Width, @object.Height),
                        Location = new Point(@object.X, Y),
                        Font = @object.Font,
                        Text = i.GetDescription(),
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
