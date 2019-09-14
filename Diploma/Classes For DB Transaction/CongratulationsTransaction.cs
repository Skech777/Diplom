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
    public class CongratulationTransaction : SimpleBDObject
    {
        private readonly Font Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
        public CongratulationTransaction(int x, int y, int height, int width, Form1 _mainForm) : base(x, y, height, width, _mainForm) { }



        public override void Select(List<Congratulations> List, CongratulationTransaction @object, int indexOfSelect)
        {
            int Y = @object.Y;
            try
            {
                Label SQLLabel;
                List = List.FindAll(p => p.GetThematicId() == indexOfSelect);

                foreach (var i in List)
                {
                    SQLLabel = new Label
                    {
                        AutoSize = true,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Location = new Point(@object.X, Y),
                        Font = @object.Font,
                        Text = i.GetText()+"\n\n"+ i.GetAuthor(),                        
                        Tag = i
                    };
                    MainForm.Controls.Add(SQLLabel);
                    Y += SQLLabel.Size.Height+20;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
