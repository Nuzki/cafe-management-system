namespace Game
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.energy3 = new System.Windows.Forms.PictureBox();
            this.energy2 = new System.Windows.Forms.PictureBox();
            this.energy1 = new System.Windows.Forms.PictureBox();
            this.ground = new System.Windows.Forms.PictureBox();
            this.mountain_top = new System.Windows.Forms.PictureBox();
            this.mountain_bottom = new System.Windows.Forms.PictureBox();
            this.ufo = new System.Windows.Forms.PictureBox();
            this.score_lbl = new System.Windows.Forms.Label();
            this.game_time = new System.Windows.Forms.Timer(this.components);
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.exEnergy = new System.Windows.Forms.PictureBox();
            this.sky = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.energy3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.energy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.energy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mountain_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mountain_bottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.energy3);
            this.panel1.Controls.Add(this.energy2);
            this.panel1.Controls.Add(this.energy1);
            this.panel1.Location = new System.Drawing.Point(12, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(137, 41);
            this.panel1.TabIndex = 4;
            // 
            // energy3
            // 
            this.energy3.Image = global::Game.Properties.Resources.Untitled_design__5_;
            this.energy3.Location = new System.Drawing.Point(93, 3);
            this.energy3.Name = "energy3";
            this.energy3.Size = new System.Drawing.Size(39, 35);
            this.energy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.energy3.TabIndex = 0;
            this.energy3.TabStop = false;
            // 
            // energy2
            // 
            this.energy2.Image = global::Game.Properties.Resources.Untitled_design__5_;
            this.energy2.Location = new System.Drawing.Point(48, 3);
            this.energy2.Name = "energy2";
            this.energy2.Size = new System.Drawing.Size(39, 35);
            this.energy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.energy2.TabIndex = 0;
            this.energy2.TabStop = false;
            // 
            // energy1
            // 
            this.energy1.Image = global::Game.Properties.Resources.Untitled_design__5_;
            this.energy1.Location = new System.Drawing.Point(3, 3);
            this.energy1.Name = "energy1";
            this.energy1.Size = new System.Drawing.Size(39, 35);
            this.energy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.energy1.TabIndex = 0;
            this.energy1.TabStop = false;
            // 
            // ground
            // 
            this.ground.Image = global::Game.Properties.Resources._9818800_47290;
            this.ground.Location = new System.Drawing.Point(-1, 348);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(656, 61);
            this.ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ground.TabIndex = 3;
            this.ground.TabStop = false;
            // 
            // mountain_top
            // 
            this.mountain_top.BackColor = System.Drawing.Color.Transparent;
            this.mountain_top.Image = global::Game.Properties.Resources._2;
            this.mountain_top.Location = new System.Drawing.Point(209, -14);
            this.mountain_top.Name = "mountain_top";
            this.mountain_top.Size = new System.Drawing.Size(123, 110);
            this.mountain_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mountain_top.TabIndex = 2;
            this.mountain_top.TabStop = false;
            // 
            // mountain_bottom
            // 
            this.mountain_bottom.BackColor = System.Drawing.Color.Transparent;
            this.mountain_bottom.Image = global::Game.Properties.Resources._1;
            this.mountain_bottom.Location = new System.Drawing.Point(424, 277);
            this.mountain_bottom.Name = "mountain_bottom";
            this.mountain_bottom.Size = new System.Drawing.Size(121, 106);
            this.mountain_bottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mountain_bottom.TabIndex = 1;
            this.mountain_bottom.TabStop = false;
            // 
            // ufo
            // 
            this.ufo.BackColor = System.Drawing.Color.Transparent;
            this.ufo.Image = global::Game.Properties.Resources.ufo__1_;
            this.ufo.Location = new System.Drawing.Point(12, 57);
            this.ufo.Name = "ufo";
            this.ufo.Size = new System.Drawing.Size(74, 68);
            this.ufo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ufo.TabIndex = 0;
            this.ufo.TabStop = false;
            // 
            // score_lbl
            // 
            this.score_lbl.BackColor = System.Drawing.Color.DimGray;
            this.score_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.score_lbl.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_lbl.ForeColor = System.Drawing.Color.Chartreuse;
            this.score_lbl.Location = new System.Drawing.Point(518, 357);
            this.score_lbl.Name = "score_lbl";
            this.score_lbl.Size = new System.Drawing.Size(125, 41);
            this.score_lbl.TabIndex = 5;
            this.score_lbl.Text = "Score:";
            this.score_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // game_time
            // 
            this.game_time.Enabled = true;
            this.game_time.Interval = 20;
            this.game_time.Tick += new System.EventHandler(this.gameTimeTickEvent);
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameOverLabel.Font = new System.Drawing.Font("Consolas", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Lime;
            this.gameOverLabel.Location = new System.Drawing.Point(33, 124);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(584, 152);
            this.gameOverLabel.TabIndex = 6;
            this.gameOverLabel.Text = "label1";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameOverLabel.Visible = false;
            // 
            // exEnergy
            // 
            this.exEnergy.BackColor = System.Drawing.Color.Transparent;
            this.exEnergy.Image = global::Game.Properties.Resources.Untitled_design__5_;
            this.exEnergy.Location = new System.Drawing.Point(393, 144);
            this.exEnergy.Name = "exEnergy";
            this.exEnergy.Size = new System.Drawing.Size(39, 35);
            this.exEnergy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exEnergy.TabIndex = 0;
            this.exEnergy.TabStop = false;
            // 
            // sky
            // 
            this.sky.Image = global::Game.Properties.Resources.Untitled_design__4_1;
            this.sky.Location = new System.Drawing.Point(-14, -14);
            this.sky.Name = "sky";
            this.sky.Size = new System.Drawing.Size(669, 33);
            this.sky.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sky.TabIndex = 8;
            this.sky.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Game.Properties.Resources.pause_button;
            this.pictureBox1.Location = new System.Drawing.Point(602, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PauseMenu);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BackgroundImage = global::Game.Properties.Resources._5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(655, 405);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sky);
            this.Controls.Add(this.exEnergy);
            this.Controls.Add(this.ufo);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.score_lbl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.mountain_top);
            this.Controls.Add(this.mountain_bottom);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spaceline";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUpEvent);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.energy3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.energy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.energy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mountain_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mountain_bottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ufo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ufo;
        private System.Windows.Forms.PictureBox mountain_bottom;
        private System.Windows.Forms.PictureBox mountain_top;
        private System.Windows.Forms.PictureBox ground;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox energy1;
        private System.Windows.Forms.PictureBox energy3;
        private System.Windows.Forms.PictureBox energy2;
        private System.Windows.Forms.Label score_lbl;
        private System.Windows.Forms.Timer game_time;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.PictureBox exEnergy;
        private System.Windows.Forms.PictureBox sky;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

