using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UltimateTicTacToe
{
    /*
     - Gör en klasser 
        - en för varje liten ruta (81st)
           - pbx, bool träff (är rutan använd), bool isCircle (cross eller cirkle)
        - en för varje 3x3 (är hela ifyld, isf vem vann)
        - en för hela planen (vilken är den nästa 3x3, vem van totalt)
    */

    public partial class Form : System.Windows.Forms.Form
    {

        bool circleTurn = true;

        public Form()
        {
            InitializeComponent();

            EventHandlerPictureboxes(); 
        }

        void EventHandlerPictureboxes()
        {
            foreach (var picturebox in this.Controls.OfType<PictureBox>())
            {
                picturebox.BackColor = Color.White;
                picturebox.Click += PictureBoxClick;
            }
        }

        void PictureBoxClick(object sender, EventArgs e)
        {
            Bitmap circle = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Circle.png");
            Bitmap cross = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Cross.png");

            var pictureBoxName = ((PictureBox)sender).Name;
            PictureBox selected = (PictureBox)this.Controls[pictureBoxName];
            selected.SizeMode = PictureBoxSizeMode.StretchImage;

            if (circleTurn)
            {
                selected.Image = circle;
                circleTurn = false;
            }
            else
            {
                selected.Image = cross;
                circleTurn = true;
            }

            selected.Enabled = false;
        }
    }
}
