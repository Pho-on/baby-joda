using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{

    public partial class Form : System.Windows.Forms.Form
    {

        public Form()
        {
            InitializeComponent();

            /*
             Finding layout...
                - top margin 54
                - side & bottom marign 27
                - pbx size 30
            */

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    PictureBox pbx = new PictureBox
                    {
                        Image = new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\TileEmpty.png"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Black,
                        Width = 30,
                        Height = 30,
                    };

                    pbx.Location = new Point((30 * i) + 27, (30 * j));
                    this.Controls.Add(pbx);
                }
            }
        }
    }
}
