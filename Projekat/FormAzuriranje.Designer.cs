
namespace Projekat
{
    partial class FormAzuriranje
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
            this.cmbRez = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBrSale = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSlobMesta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDatum = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUkupno = new System.Windows.Forms.TextBox();
            this.btnAzuriraj = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbIDProj = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRez
            // 
            this.cmbRez.FormattingEnabled = true;
            this.cmbRez.Location = new System.Drawing.Point(182, 62);
            this.cmbRez.Name = "cmbRez";
            this.cmbRez.Size = new System.Drawing.Size(176, 24);
            this.cmbRez.TabIndex = 0;
            this.cmbRez.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID rezervacije";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID projekcije";
            // 
            // txtFilm
            // 
            this.txtFilm.Location = new System.Drawing.Point(182, 147);
            this.txtFilm.Name = "txtFilm";
            this.txtFilm.ReadOnly = true;
            this.txtFilm.Size = new System.Drawing.Size(176, 22);
            this.txtFilm.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Naziv filma";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Broj sale";
            // 
            // txtBrSale
            // 
            this.txtBrSale.Location = new System.Drawing.Point(182, 188);
            this.txtBrSale.Name = "txtBrSale";
            this.txtBrSale.ReadOnly = true;
            this.txtBrSale.Size = new System.Drawing.Size(176, 22);
            this.txtBrSale.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Broj slobodnih mesta";
            // 
            // txtSlobMesta
            // 
            this.txtSlobMesta.Location = new System.Drawing.Point(182, 232);
            this.txtSlobMesta.Name = "txtSlobMesta";
            this.txtSlobMesta.ReadOnly = true;
            this.txtSlobMesta.Size = new System.Drawing.Size(176, 22);
            this.txtSlobMesta.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Datum projekcije";
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(182, 274);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.ReadOnly = true;
            this.txtDatum.Size = new System.Drawing.Size(176, 22);
            this.txtDatum.TabIndex = 10;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(182, 319);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(176, 22);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Broj mesta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ukupna cena";
            // 
            // txtUkupno
            // 
            this.txtUkupno.Location = new System.Drawing.Point(182, 362);
            this.txtUkupno.Name = "txtUkupno";
            this.txtUkupno.ReadOnly = true;
            this.txtUkupno.Size = new System.Drawing.Size(176, 22);
            this.txtUkupno.TabIndex = 14;
            // 
            // btnAzuriraj
            // 
            this.btnAzuriraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAzuriraj.Location = new System.Drawing.Point(53, 409);
            this.btnAzuriraj.Name = "btnAzuriraj";
            this.btnAzuriraj.Size = new System.Drawing.Size(305, 59);
            this.btnAzuriraj.TabIndex = 17;
            this.btnAzuriraj.Text = "Ažuriraj";
            this.btnAzuriraj.UseVisualStyleBackColor = true;
            this.btnAzuriraj.Click += new System.EventHandler(this.btnAzuriraj_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(93, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(265, 29);
            this.label9.TabIndex = 18;
            this.label9.Text = "Ažuriranje rezervacije";
            // 
            // cmbIDProj
            // 
            this.cmbIDProj.FormattingEnabled = true;
            this.cmbIDProj.Location = new System.Drawing.Point(182, 97);
            this.cmbIDProj.Name = "cmbIDProj";
            this.cmbIDProj.Size = new System.Drawing.Size(176, 24);
            this.cmbIDProj.TabIndex = 19;
            this.cmbIDProj.SelectedIndexChanged += new System.EventHandler(this.cmbIDProj_SelectedIndexChanged);
            // 
            // FormAzuriranje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 496);
            this.Controls.Add(this.cmbIDProj);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAzuriraj);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUkupno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSlobMesta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBrSale);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRez);
            this.Name = "FormAzuriranje";
            this.Text = "FormAzuriranje";
            this.Load += new System.EventHandler(this.FormAzuriranje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRez;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBrSale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSlobMesta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDatum;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUkupno;
        private System.Windows.Forms.Button btnAzuriraj;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbIDProj;
    }
}