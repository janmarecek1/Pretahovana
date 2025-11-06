namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>

        /// </summary>
        private void InitializeComponent()
        {
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.lblTurn = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.gameBoard = new System.Windows.Forms.PictureBox();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMode
            // 
            this.cmbMode.Items.AddRange(new object[] {
            "Hráč vs Hráč",
            "Hráč vs Počítač"});
            this.cmbMode.Location = new System.Drawing.Point(0, 0);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(121, 21);
            this.cmbMode.TabIndex = 5;
            // 
            // lblTurn
            // 
            this.lblTurn.Location = new System.Drawing.Point(0, 0);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(100, 23);
            this.lblTurn.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(0, 0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(0, 0);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 0;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.btnNewGame);
            this.controlPanel.Controls.Add(this.btnSave);
            this.controlPanel.Controls.Add(this.btnLoad);
            this.controlPanel.Controls.Add(this.btnExit);
            this.controlPanel.Controls.Add(this.lblTurn);
            this.controlPanel.Controls.Add(this.cmbMode);
            this.controlPanel.Location = new System.Drawing.Point(1019, 376);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(831, 97);
            this.controlPanel.TabIndex = 1;
            // 
            // gameBoard
            // 
            this.gameBoard.Location = new System.Drawing.Point(1055, 444);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(125, 40);
            this.gameBoard.TabIndex = 0;
            this.gameBoard.TabStop = false;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.controlPanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Přetahovaná";
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.PictureBox gameBoard;
    }
}

