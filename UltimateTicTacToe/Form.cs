using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateTicTacToe
{
    /*
        pbx size = (44; 44)
        mellanrum mellan rutor = 51px
        tillägg mellan 3x3 = 3px
    */

    public partial class Form : System.Windows.Forms.Form
    {
        int targetSize = 51;
        int targetPosX;
        int targetPosY;

        public Form()
        {
            InitializeComponent();
        }

        private void pbxPlayingBoard_MouseClick(object sender, MouseEventArgs e)
        {
            CalculateSquare(e.X, e.Y);
        }

        void CalculateSquare(int mouseX, int mouseY)
        {
            int posInGridX = mouseX / targetSize;
            int posInGridY = mouseY / targetSize;

            targetPosX = FindStartPosX(posInGridX);
            targetPosY = FindStartPosY(posInGridY);
        }

        int FindStartPosX(int posX)
        {
            int targetPosX;

            if (posX >= 0 && posX <= 2)
            {
                targetPosX = (posX * 51) + 6;
            }
            else if (posX >= 3 && posX <= 5)
            {
                targetPosX = (posX * 51) + 9;
            }
            else
            {
                targetPosX = (posX * 51) + 12;
            }

            return targetPosX;
        }

        int FindStartPosY(int posY)
        {
            int targetPosY;

            if (posY >= 0 && posY <= 2)
            {
                targetPosY = (posY * 51) + 6;
            }
            else if (posY >= 3 && posY <= 5)
            {
                targetPosY = (posY * 51) + 9;
            }
            else
            {
                targetPosY = (posY * 51) + 12;
            }

            return targetPosY;
        }  
    }
}
