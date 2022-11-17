namespace DemoInloggning
{
    partial class Inlggoning
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inlggoning));
            this.txtlössenord = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnloggaut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.savfDatan = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtlössenord
            // 
            this.txtlössenord.CausesValidation = false;
            this.txtlössenord.Location = new System.Drawing.Point(741, 369);
            this.txtlössenord.MaxLength = 4;
            this.txtlössenord.Name = "txtlössenord";
            this.txtlössenord.PasswordChar = '*';
            this.txtlössenord.Size = new System.Drawing.Size(107, 22);
            this.txtlössenord.TabIndex = 1;
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(588, 432);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(115, 45);
            this.btnlogin.TabIndex = 2;
            this.btnlogin.Text = "Logga in";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnloggaut
            // 
            this.btnloggaut.Location = new System.Drawing.Point(872, 432);
            this.btnloggaut.Name = "btnloggaut";
            this.btnloggaut.Size = new System.Drawing.Size(119, 45);
            this.btnloggaut.TabIndex = 3;
            this.btnloggaut.Text = "Logga ut";
            this.btnloggaut.UseVisualStyleBackColor = true;
            this.btnloggaut.Click += new System.EventHandler(this.btnloggaut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(741, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lössenord:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(622, 249);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Inlggoning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1542, 918);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnloggaut);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtlössenord);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inlggoning";
            this.Text = "Inloggning";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtlössenord;
        private Button btnlogin;
        private Button btnloggaut;
        private Label label2;
        private SaveFileDialog savfDatan;
        private PictureBox pictureBox1;
    }
}