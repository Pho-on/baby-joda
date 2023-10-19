using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{

    public partial class Form : System.Windows.Forms.Form
    {

        static readonly Bitmap[] tileImages = new Bitmap[]
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

        static Bitmap SetOpacityImage(Bitmap image)
        {
            Bitmap originalImage = new Bitmap(image);
            Bitmap opacityImage = new Bitmap(image.Width, image.Height);

            int alpha = 50;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color original = originalImage.GetPixel(x, y);
                    Color opacity = Color.FromArgb(alpha, original.R, original.G, original.B);
                    opacityImage.SetPixel(x, y, opacity);
                }
            }

            return opacityImage;
        }

        readonly Bitmap[] tileOpacityImages = new Bitmap[]
        {
            new Bitmap(SetOpacityImage(tileImages[0])),
            new Bitmap(SetOpacityImage(tileImages[1])),
            new Bitmap(SetOpacityImage(tileImages[2])),
            new Bitmap(SetOpacityImage(tileImages[3])),
            new Bitmap(SetOpacityImage(tileImages[4])),
            new Bitmap(SetOpacityImage(tileImages[5])),
            new Bitmap(SetOpacityImage(tileImages[6])),
            new Bitmap(SetOpacityImage(tileImages[7]))
        };


        readonly Bitmap[] blockImages = new Bitmap[]
        {
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\Block-Empty.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\Block-I.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\Block-J.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\Block-L.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\Block-O.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\Block-S.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\Block-T.png"),
            new Bitmap(@"C:\Repos\baby-joda\Tetris\Images\Block-Z.png")
        };

        PictureBox[,] pictureBoxGrid;

        GameState gameState= new GameState();

        int maxDelay = 1000;
        int minDelay = 75;
        int delayDecrease = 25;

        public Form()
        {
            InitializeComponent();
            pictureBoxGrid = SetupPictureBoxGrid(gameState.GameGrid);
            Draw(gameState);
            GameLoop();
        }

        PictureBox[,] SetupPictureBoxGrid(GameGrid grid)
        {
            PictureBox[,] pictureBoxGrid = new PictureBox[grid.Rows, grid.Columns];
            int pbxSize = 30;

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    PictureBox pbx = new PictureBox
                    {
                        BackColor = Color.Black,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = pbxSize,
                        Height = pbxSize,
                        Location = new Point(pbxSize * c + 27, pbxSize * r - 27),
                    };

                    Controls.Add(pbx);
                    pictureBoxGrid[r, c] = pbx;
                }
            }

            return pictureBoxGrid;
        }

        void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    pictureBoxGrid[r, c].Image = tileImages[id];
                }
            }
        }

        void DrawBlock(Block block)
        {
            foreach (Position pos in block.TilePositions())
            {
                pictureBoxGrid[pos.Row, pos.Column].Image = tileImages[block.Id];
            }
        }

        void DrawNextBlock(BlockQueue blockQueue)
        {
            Block next = blockQueue.NextBlock;
            pictureBox1.Image = blockImages[next.Id];
        }

        void DrawGhostBlock(Block block)
        {
            int dropDistance = gameState.BlockDropDistance();

            foreach (Position pos in block.TilePositions())
            {
                pictureBoxGrid[pos.Row + dropDistance, pos.Column].Image = tileOpacityImages[block.Id];
            }
        }

        void Draw(GameState gameState) 
        {
            DrawGrid(gameState.GameGrid);
            DrawGhostBlock(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);
            lblScore.Text = (gameState.Score).ToString();
        }

        async Task GameLoop()
        {
            Draw(gameState);

            while (!gameState.GameOver)
            {
                int delay = Math.Max(minDelay, maxDelay - (gameState.Score * delayDecrease));
                await Task.Delay(delay);
                gameState.MoveBlockDown();
                Draw(gameState);
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.A:
                    gameState.MoveBlockLeft(); 
                    break;
                case Keys.D:
                    gameState.MoveBlockRight(); 
                    break;
                case Keys.S:
                    gameState.MoveBlockDown();
                    break;
                case Keys.R:
                    gameState.RotateBlock();
                    break;
                case Keys.Space:
                    gameState.DropBlock();
                    break;
                default:
                    return;
            }

            Draw(gameState);
        }
    }
}
