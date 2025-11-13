using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class HracVHrac : Form
    {

        public HracVHrac()
        {

            InitializeComponent();


            this.Text = "Přetahovaná";
            this.ClientSize = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;


            controlPanel = new Panel()
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = Color.FromArgb(230, 230, 230)
            };


            btnExit = new Button()
            {
                Text = "Konec",
                Width = 160,
                Height = 40,
                Location = new Point(20, 170)
            };
            btnExit.Click += BtnExit_Click;

            lblTurn = new Label()
            {
                Text = "Na tahu: Hráč 1",
                Width = 160,
                Height = 30,
                Location = new Point(20, 230),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };


            controlPanel.Controls.Add(btnExit);
            controlPanel.Controls.Add(lblTurn);


            gameBoard = new PictureBox()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            gameBoard.Paint += GameBoard_Paint;
            gameBoard.MouseClick += GameBoard_MouseClick;

            this.Controls.Add(gameBoard);
            this.Controls.Add(controlPanel);
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
        }

        private void GameBoard_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"Kliknuto na: X={e.X}, Y={e.Y}");
        }

        private void DrawGrid(Graphics g)
        {

            // Počet sloupců
            int cols = 10;
            // Počet řádků
            int rows = 8;
            // Velikost každého čtverečku
            int cellSize = 50;
            // barva a tloušťka.
            Pen gridPen = new Pen(Color.LightGray, 1);

            // Odsazení
            int odsazeni = 20;


            // SLOUPCE
            // Smyčka projde tolikrát, kolik chceme sloupců + jednu čáru navíc pro uzavření mřížky.
            for (int i = 0; i <= cols; i++)
            {
                // x
                int x = i * cellSize + odsazeni;
                // y - konec
                int y2 = rows * cellSize + odsazeni;

                // nakresleni
                g.DrawLine(gridPen, x, odsazeni, x, y2);
            }

            // ŘÁDKY
            // Smyčka projde tolikrát, kolik chceme řádků + jednu čáru navíc.
            for (int j = 0; j <= rows; j++)
            {
                // y
                int y = j * cellSize + odsazeni;
                // x - konec
                int x2 = cols * cellSize + odsazeni;

                // nakresleni
                g.DrawLine(gridPen, odsazeni, y, x2, y);
            }

            Brush gateBrush = new SolidBrush(Color.LightBlue);//brana modry (vlevo) a
            g.FillRectangle(gateBrush, 10, (rows / 2 - 1) * cellSize + 20, 10, cellSize * 2);
            gateBrush = new SolidBrush(Color.Firebrick);//brana cerveny (vpravo)
            g.FillRectangle(gateBrush, cols * cellSize + 20, (rows / 2 - 1) * cellSize + 20, 10, cellSize * 2);
        }


        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void HracVHrac_Load(object sender, EventArgs e)
        {

        }
    }
}