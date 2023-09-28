﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UltimateTicTacToe
{
    /*
     - Gör en klasser 
        - en för varje liten ruta (81st)
           - pbx, bool träff (är rutan använd), index för varje box i flp (1-9 per flp)
        - en för varje 3x3 (är hela ifyld, isf vem vann), index för varje flp (1-9)
        - en för hela planen (vilken är den nästa 3x3, vem van totalt)
    */

    public partial class Form : System.Windows.Forms.Form
    {
        Square square;
        Small3x3 small3x3;

        List<Square> squareList = new List<Square>();
        List<Small3x3> small3x3List = new List<Small3x3>();

        bool circleTurn;

        public Form()
        {
            InitializeComponent();

            MakePlayingBoard();
            circleTurn = WhoStarts();
        }

        void MakePlayingBoard()
        {
            int i = 1;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    small3x3 = new Small3x3(FlpPosX(x, y), FlpPosY(x, y));
                    small3x3.TabIndex = i;
                    this.Controls.Add(small3x3.FlowLayoutPanel);
                    small3x3List.Add(small3x3);
                    i++;
                }
            }

            foreach (var flp in this.Controls.OfType<FlowLayoutPanel>())
            {
                for (int j = 0; j < 9; j++)
                {
                    square = new Square();
                    square.TabIndex = j + 1;
                    square.PictureBox.Click += PictureBoxClick;
                    flp.Controls.Add(square.PictureBox);
                    squareList.Add(square);
                }
            }
        }

        void PictureBoxClick(object sender, EventArgs e)
        {
            (sender as Square).TabIndex
            // behöver något för att hitta vilken pbx som klickats
            foreach (FlowLayoutPanel flp in this.Controls.OfType<FlowLayoutPanel>())
            {
                if (flp.Contains((PictureBox)sender))
                {
                    foreach (var square in squareList)
                    {
                        if (((PictureBox)sender) == square.PictureBox)
                        {
                            if (circleTurn)
                            {
                                square.Image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Circle.png");
                                circleTurn = false;
                            }
                            else
                            {
                                square.Image = new Bitmap(@"C:\Repos\baby-joda\UltimateTicTacToe\Images\Cross.png");
                                circleTurn = true;
                            }
                            Console.WriteLine(flp.TabIndex + ", " + square.TabIndex + " " + square.Image);
                            square.Enabled = false;
                            square.PictureBox.Invalidate();
                        }
                    }
                }
            }
        }

        int FlpPosX(int x, int y)
        {
            int xPos;
            int size = 150;

            if ((x == 0 && y == 0) || (x == 0 && y == 1) || (x == 0 && y == 2))
            {
                xPos = (x * size) + (5 * (x + 1));
            }
            else
            {
                xPos = (x * size) + (2 * (x + 1) + 3);
            }
            return xPos;
        }

        int FlpPosY(int x, int y)
        {
            int yPos;
            int size = 150;

            if ((x == 0 && y == 0) || (x == 1 && y == 0) || (x == 2 && y == 0))
            {
                yPos = (y * size) + (5 * (y + 1));
            }
            else
            {
                yPos = (y * size) + (2 * (y + 1) + 3);
            }
            return yPos;
        }

        bool WhoStarts()
        {
            Random random = new Random();

            if (random.Next(0, 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
