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

        readonly Bitmap[] tileImages = new Bitmap[]
        {
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\TileEmpty.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\TileCyan.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\TileBlue.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\TileOrange.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\TileYellow.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\TileGreen.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\TilePurple.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\TileRed.png")
        };

        PictureBox[,] pictureBoxGrid = new PictureBox[10, 22];

        public Form()
        {
            InitializeComponent();

            MakePictureBoxGrid();

            /*
             Finding layout...
                - top margin 54
                - side & bottom marign 27
                - pbx size 30
            */
        }

        void MakePictureBoxGrid()
        {
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 22; c++)
                {
                    PictureBox pbx = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 30,
                        Height = 30,
                    };

                    pictureBoxGrid[r, c] = pbx;
                }
            }
        }
    }
}
