using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    // Obycejna trida pro ulozeni jedne cary
    public class Cara
    {
        public int startX;
        public int startY;
        public int konecX;
        public int konecY;
        public Color barva;

        public Cara(int x1, int y1, int x2, int y2, Color b)
        {
            startX = x1; startY = y1;
            konecX = x2; konecY = y2;
            barva = b;
        }
    }

    public partial class HracVHrac : Form
    {
        // --- STAV HRY ---
        private int micX;
        private int micY;
        private int cisloHrace;
        private bool jeKonecHry;
        private List<Cara> seznamVsechCar;

        // --- NASTAVENI VELIKOSTI ---
        private int velikostCtverecku = 50;
        private int okraj = 50; // Posuneme to jeste vic od kraje plochy

        // --- OVLADACI PRVKY ---
        private PictureBox kresliciPlocha;
        private Label textKdoHraje;
        private Button tlacitkoRestart;
        private Panel levyPanel;

        public HracVHrac()
        {
            // Nastaveni hlavniho okna - udelame ho siroke
            this.Text = "Jednoduchy Fotbalek";
            this.ClientSize = new Size(1000, 650); // Pevna velikost okna
            this.StartPosition = FormStartPosition.CenterScreen; // Vycentrovat na monitoru

            VytvoritGrafiku(); // Vytvori tlacitka a plochu
            RestartovatHru();  // Spusti hru
        }

        private void VytvoritGrafiku()
        {
            // 1. LEVY PANEL (NATVRDO POZICE)
            levyPanel = new Panel();
            levyPanel.Location = new Point(0, 0); // Zacina vlevo nahore
            levyPanel.Size = new Size(200, 650);  // Sirka 200, vyska pres cele okno
            levyPanel.BackColor = Color.LightGray;
            this.Controls.Add(levyPanel);

            // 2. KRESLICI PLOCHA (VEDLE PANELU)
            kresliciPlocha = new PictureBox();
            kresliciPlocha.Location = new Point(200, 0); // Zacina az za panelem (na 200px)
            kresliciPlocha.Size = new Size(800, 650);    // Zbytek sirky
            kresliciPlocha.BackColor = Color.White;

            kresliciPlocha.Paint += KresleniPlochy;      // Napojeni kresleni
            kresliciPlocha.MouseClick += KliknutiNaPlochu; // Napojeni klikani
            this.Controls.Add(kresliciPlocha);

            // 3. PRVKY V PANELU
            textKdoHraje = new Label();
            textKdoHraje.Location = new Point(20, 30);
            textKdoHraje.Text = "Hraje: ...";
            textKdoHraje.Font = new Font("Arial", 14, FontStyle.Bold);
            textKdoHraje.AutoSize = true;
            levyPanel.Controls.Add(textKdoHraje);

            tlacitkoRestart = new Button();
            tlacitkoRestart.Text = "Nová hra";
            tlacitkoRestart.Location = new Point(20, 80);
            tlacitkoRestart.Size = new Size(150, 40);
            tlacitkoRestart.Click += (s, e) => RestartovatHru();
            levyPanel.Controls.Add(tlacitkoRestart);
        }

        private void RestartovatHru()
        {
            micX = 5; // Stred sirky (0-10)
            micY = 4; // Stred vysky (0-8)
            cisloHrace = 1;
            jeKonecHry = false;

            seznamVsechCar = new List<Cara>();

            textKdoHraje.Text = "Hraje: Modrý";
            textKdoHraje.ForeColor = Color.Blue;

            kresliciPlocha.Invalidate();
        }

        // --- KRESLENI ---
        private void KresleniPlochy(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Vyhlazovani hran (nepovinne, ale vypada to lip)
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. Mrizka
            Pen seda = new Pen(Color.LightGray);
            for (int i = 0; i <= 10; i++) // Svisle
            {
                int x = okraj + (i * velikostCtverecku);
                g.DrawLine(seda, x, okraj, x, okraj + (8 * velikostCtverecku));
            }
            for (int j = 0; j <= 8; j++) // Vodorovne
            {
                int y = okraj + (j * velikostCtverecku);
                g.DrawLine(seda, okraj, y, okraj + (10 * velikostCtverecku), y);
            }

            // 2. Branky
            Pen modra = new Pen(Color.Blue, 4);
            Pen cervena = new Pen(Color.Red, 4);
            int yStred = okraj + (4 * velikostCtverecku);

            // Leva
            g.DrawLine(modra, okraj, yStred - 50, okraj - 20, yStred - 50);
            g.DrawLine(modra, okraj - 20, yStred - 50, okraj - 20, yStred + 50);
            g.DrawLine(modra, okraj - 20, yStred + 50, okraj, yStred + 50);

            // Prava
            int xKonec = okraj + (10 * velikostCtverecku);
            g.DrawLine(cervena, xKonec, yStred - 50, xKonec + 20, yStred - 50);
            g.DrawLine(cervena, xKonec + 20, yStred - 50, xKonec + 20, yStred + 50);
            g.DrawLine(cervena, xKonec + 20, yStred + 50, xKonec, yStred + 50);

            // 3. Historie car
            foreach (Cara c in seznamVsechCar)
            {
                int px1 = okraj + (c.startX * velikostCtverecku);
                int py1 = okraj + (c.startY * velikostCtverecku);
                int px2 = okraj + (c.konecX * velikostCtverecku);
                int py2 = okraj + (c.konecY * velikostCtverecku);

                Pen pero = new Pen(c.barva, 2);
                g.DrawLine(pero, px1, py1, px2, py2);
            }

            // 4. Mic
            int mx = okraj + (micX * velikostCtverecku);
            int my = okraj + (micY * velikostCtverecku);
            g.FillEllipse(Brushes.Black, mx - 6, my - 6, 12, 12);

            // Krouzek kolem mice podle toho kdo hraje
            Color barvaMice = (cisloHrace == 1) ? Color.Blue : Color.Red;
            if (!jeKonecHry)
            {
                Pen p = new Pen(barvaMice, 2);
                g.DrawEllipse(p, mx - 8, my - 8, 16, 16);
            }
        }

        // --- KLIKANI ---
        private void KliknutiNaPlochu(object sender, MouseEventArgs e)
        {
            if (jeKonecHry) return;

            // Zjistime souradnice mysi a prevedeme na policka
            // Pricteme polovinu bunky (25), aby to bralo nejblizsi bod
            int klikX = (e.X - okraj + 25) / velikostCtverecku;
            int klikY = (e.Y - okraj + 25) / velikostCtverecku;

            // Jsme uvnitr hriste?
            if (klikX < 0 || klikX > 10 || klikY < 0 || klikY > 8) return;

            if (JeTahSpravny(klikX, klikY))
            {
                Color barva = (cisloHrace == 1) ? Color.Blue : Color.Red;
                seznamVsechCar.Add(new Cara(micX, micY, klikX, klikY, barva));

                micX = klikX;
                micY = klikY;

                // Kontrola golu (jen jednoduche vysvetleni)
                if (micX == 0 && (micY == 3 || micY == 4 || micY == 5))
                {
                    MessageBox.Show("GÓL! Červený vyhrál!");
                    jeKonecHry = true;
                }
                else if (micX == 10 && (micY == 3 || micY == 4 || micY == 5))
                {
                    MessageBox.Show("GÓL! Modrý vyhrál!");
                    jeKonecHry = true;
                }
                else
                {
                    // Zmena hrace
                    cisloHrace = (cisloHrace == 1) ? 2 : 1;
                    if (cisloHrace == 1)
                    {
                        textKdoHraje.Text = "Hraje: Modrý";
                        textKdoHraje.ForeColor = Color.Blue;
                    }
                    else
                    {
                        textKdoHraje.Text = "Hraje: Červený";
                        textKdoHraje.ForeColor = Color.Red;
                    }
                }

                kresliciPlocha.Invalidate();
            }
        }

        private bool JeTahSpravny(int cilX, int cilY)
        {
            if (micX == cilX && micY == cilY) return false; // Stejne misto

            if (Math.Abs(micX - cilX) > 1) return false; // Moc daleko X
            if (Math.Abs(micY - cilY) > 1) return false; // Moc daleko Y

            // Kontrola jestli cara existuje
            foreach (Cara c in seznamVsechCar)
            {
                bool tam = (c.startX == micX && c.startY == micY && c.konecX == cilX && c.konecY == cilY);
                bool zpet = (c.startX == cilX && c.startY == cilY && c.konecX == micX && c.konecY == micY);
                if (tam || zpet) return false;
            }
            return true;
        }

        // Jen aby designer nebrecel
        private void HracVHrac_Load(object sender, EventArgs e) { }
    }
}