namespace EvidencijaClanova
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datRodj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clanarina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placeno = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dug = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vazi_do = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.texSearch = new System.Windows.Forms.TextBox();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dodajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniIliObrisiTreningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finansijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posaljiPutemMailaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izveziNaDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sifraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promeniSifruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgmDodaj = new System.Windows.Forms.Button();
            this.treninziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ime,
            this.prezime,
            this.brTel,
            this.datRodj,
            this.trening,
            this.clanarina,
            this.placeno,
            this.dug,
            this.Vazi_do});
            this.dataGridView1.Location = new System.Drawing.Point(12, 49);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1145, 499);
            this.dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "Br. članske karte";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // ime
            // 
            this.ime.HeaderText = "Ime";
            this.ime.Name = "ime";
            this.ime.ReadOnly = true;
            this.ime.Width = 125;
            // 
            // prezime
            // 
            this.prezime.HeaderText = "Prezime";
            this.prezime.Name = "prezime";
            this.prezime.ReadOnly = true;
            this.prezime.Width = 125;
            // 
            // brTel
            // 
            this.brTel.HeaderText = "Broj telefona";
            this.brTel.Name = "brTel";
            this.brTel.ReadOnly = true;
            this.brTel.Width = 150;
            // 
            // datRodj
            // 
            this.datRodj.HeaderText = "Datum Rodjenja";
            this.datRodj.Name = "datRodj";
            this.datRodj.ReadOnly = true;
            // 
            // trening
            // 
            this.trening.HeaderText = "Trening";
            this.trening.Name = "trening";
            this.trening.ReadOnly = true;
            // 
            // clanarina
            // 
            this.clanarina.HeaderText = "Članarina";
            this.clanarina.Name = "clanarina";
            this.clanarina.ReadOnly = true;
            // 
            // placeno
            // 
            this.placeno.HeaderText = "Plaćeno/Ne";
            this.placeno.Name = "placeno";
            this.placeno.ReadOnly = true;
            // 
            // dug
            // 
            this.dug.HeaderText = "Dug";
            this.dug.Name = "dug";
            this.dug.ReadOnly = true;
            // 
            // Vazi_do
            // 
            this.Vazi_do.HeaderText = "Članarina važi do";
            this.Vazi_do.Name = "Vazi_do";
            this.Vazi_do.ReadOnly = true;
            // 
            // texSearch
            // 
            this.texSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.texSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texSearch.Location = new System.Drawing.Point(519, 12);
            this.texSearch.Name = "texSearch";
            this.texSearch.Size = new System.Drawing.Size(389, 26);
            this.texSearch.TabIndex = 8;
            this.texSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texSearch_KeyPress);
            // 
            // comboSearch
            // 
            this.comboSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Items.AddRange(new object[] {
            "Broj clanske karte",
            "Ime i prezime"});
            this.comboSearch.Location = new System.Drawing.Point(926, 12);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(191, 26);
            this.comboSearch.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PeachPuff;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treninziToolStripMenuItem,
            this.dodajToolStripMenuItem,
            this.izmeniIliObrisiTreningToolStripMenuItem,
            this.finansijeToolStripMenuItem,
            this.bazaToolStripMenuItem,
            this.aboutUsToolStripMenuItem,
            this.sifraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(516, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dodajToolStripMenuItem
            // 
            this.dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            this.dodajToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.dodajToolStripMenuItem.Text = "Dodaj trening";
            this.dodajToolStripMenuItem.Click += new System.EventHandler(this.dodajToolStripMenuItem_Click);
            // 
            // izmeniIliObrisiTreningToolStripMenuItem
            // 
            this.izmeniIliObrisiTreningToolStripMenuItem.Name = "izmeniIliObrisiTreningToolStripMenuItem";
            this.izmeniIliObrisiTreningToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.izmeniIliObrisiTreningToolStripMenuItem.Text = "Izmeni ili obrisi trening";
            this.izmeniIliObrisiTreningToolStripMenuItem.Click += new System.EventHandler(this.izmeniIliObrisiTreningToolStripMenuItem_Click);
            // 
            // finansijeToolStripMenuItem
            // 
            this.finansijeToolStripMenuItem.Name = "finansijeToolStripMenuItem";
            this.finansijeToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.finansijeToolStripMenuItem.Text = "Finansije";
            this.finansijeToolStripMenuItem.Click += new System.EventHandler(this.finansijeToolStripMenuItem_Click);
            // 
            // bazaToolStripMenuItem
            // 
            this.bazaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.posaljiPutemMailaToolStripMenuItem,
            this.izveziNaDiskToolStripMenuItem});
            this.bazaToolStripMenuItem.Name = "bazaToolStripMenuItem";
            this.bazaToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.bazaToolStripMenuItem.Text = "Baza";
            // 
            // posaljiPutemMailaToolStripMenuItem
            // 
            this.posaljiPutemMailaToolStripMenuItem.Name = "posaljiPutemMailaToolStripMenuItem";
            this.posaljiPutemMailaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.posaljiPutemMailaToolStripMenuItem.Text = "Posalji putem Mail-a";
            this.posaljiPutemMailaToolStripMenuItem.Click += new System.EventHandler(this.posaljiPutemMailaToolStripMenuItem_Click);
            // 
            // izveziNaDiskToolStripMenuItem
            // 
            this.izveziNaDiskToolStripMenuItem.Name = "izveziNaDiskToolStripMenuItem";
            this.izveziNaDiskToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.izveziNaDiskToolStripMenuItem.Text = "Izvezi na disk";
            this.izveziNaDiskToolStripMenuItem.Click += new System.EventHandler(this.izveziNaDiskToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aboutUsToolStripMenuItem.Text = "About us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // sifraToolStripMenuItem
            // 
            this.sifraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.promeniSifruToolStripMenuItem});
            this.sifraToolStripMenuItem.Name = "sifraToolStripMenuItem";
            this.sifraToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.sifraToolStripMenuItem.Text = "Sifra";
            // 
            // promeniSifruToolStripMenuItem
            // 
            this.promeniSifruToolStripMenuItem.Name = "promeniSifruToolStripMenuItem";
            this.promeniSifruToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.promeniSifruToolStripMenuItem.Text = "Promeni sifru";
            this.promeniSifruToolStripMenuItem.Click += new System.EventHandler(this.promeniSifruToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1043, 554);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 94);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.BackgroundImage = global::SQLiteRepository2008.Properties.Resources.searchImage;
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.Location = new System.Drawing.Point(1123, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(46, 43);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackgroundImage = global::SQLiteRepository2008.Properties.Resources.minus;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(226, 578);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 55);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackgroundImage = global::SQLiteRepository2008.Properties.Resources.edit;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(123, 578);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 55);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgmDodaj
            // 
            this.dgmDodaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgmDodaj.BackgroundImage = global::SQLiteRepository2008.Properties.Resources.plus;
            this.dgmDodaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dgmDodaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgmDodaj.Location = new System.Drawing.Point(27, 578);
            this.dgmDodaj.Name = "dgmDodaj";
            this.dgmDodaj.Size = new System.Drawing.Size(60, 55);
            this.dgmDodaj.TabIndex = 1;
            this.dgmDodaj.UseVisualStyleBackColor = true;
            this.dgmDodaj.Click += new System.EventHandler(this.dgmDodaj_Click);
            // 
            // treninziToolStripMenuItem
            // 
            this.treninziToolStripMenuItem.Checked = true;
            this.treninziToolStripMenuItem.CheckOnClick = true;
            this.treninziToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.treninziToolStripMenuItem.Name = "treninziToolStripMenuItem";
            this.treninziToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.treninziToolStripMenuItem.Text = "Treninzi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1169, 645);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboSearch);
            this.Controls.Add(this.texSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgmDodaj);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Početna";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button dgmDodaj;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox texSearch;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dodajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finansijeToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn brTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn datRodj;
        private System.Windows.Forms.DataGridViewTextBoxColumn trening;
        private System.Windows.Forms.DataGridViewTextBoxColumn clanarina;
        private System.Windows.Forms.DataGridViewCheckBoxColumn placeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dug;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vazi_do;
        private System.Windows.Forms.ToolStripMenuItem bazaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posaljiPutemMailaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izveziNaDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sifraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promeniSifruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izmeniIliObrisiTreningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treninziToolStripMenuItem;
    }
}

