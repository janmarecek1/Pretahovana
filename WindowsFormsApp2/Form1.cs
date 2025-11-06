using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public Form1()
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


            btnNewGame = new Button()
            {
                Text = "Nová hra",
                Width = 160,
                Height = 40,
                Location = new Point(20, 20)
            };
            btnNewGame.Click += BtnNewGame_Click;


            btnSave = new Button()
            {
                Text = "Uložit",
                Width = 160,
                Height = 40,
                Location = new Point(20, 70)
            };
            btnSave.Click += BtnSave_Click;


            btnLoad = new Button()
            {
                Text = "Načíst",
                Width = 160,
                Height = 40,
                Location = new Point(20, 120)
            };
            btnLoad.Click += BtnLoad_Click;


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

            cmbMode = new ComboBox()
            {
                Width = 160,
                Height = 30,
                Location = new Point(20, 270),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbMode.Items.AddRange(new string[] { "Hráč vs Hráč", "Hráč vs Počítač" });
            cmbMode.SelectedIndex = 0;

            controlPanel.Controls.Add(btnNewGame);
            controlPanel.Controls.Add(btnSave);
            controlPanel.Controls.Add(btnLoad);
            controlPanel.Controls.Add(btnExit);
            controlPanel.Controls.Add(lblTurn);
            controlPanel.Controls.Add(cmbMode);

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


        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nová hra byla spuštěna!");

            gameBoard.Invalidate();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hra byla uložena (zatím neimplementováno).");
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hra byla načtena (zatím neimplementováno).");
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
            int cols = 10;
            int rows = 8;
            int cellSize = 50;
            Pen gridPen = new Pen(Color.LightGray, 1);

            for (int i = 0; i <= cols; i++)
                g.DrawLine(gridPen, i * cellSize + 20, 20, i * cellSize + 20, rows * cellSize + 20);
          

            for (int j = 0; j <= rows; j++)
                g.DrawLine(gridPen, 20, j * cellSize + 20, cols * cellSize + 20, j * cellSize + 20);

            Brush gateBrush = new SolidBrush(Color.LightBlue);
            g.FillRectangle(gateBrush, 10, (rows / 2 - 1) * cellSize + 20, 10, cellSize * 2);
            gateBrush = new SolidBrush(Color.Firebrick);
            g.FillRectangle(gateBrush, cols * cellSize + 20, (rows / 2 - 1) * cellSize + 20, 10, cellSize * 2);
        }


        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}