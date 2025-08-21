namespace ClientREST_form
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.buttonRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(101, 34);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 28);
            this.textBoxID.TabIndex = 0;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(101, 88);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(335, 28);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(59, 36);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(27, 22);
            this.labelID.TabIndex = 2;
            this.labelID.Text = "ID";
            this.labelID.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(41, 91);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(45, 22);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title";
            this.labelTitle.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(21, 144);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(65, 22);
            this.labelUserID.TabIndex = 5;
            this.labelUserID.Text = "UserID";
            this.labelUserID.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(101, 144);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(335, 28);
            this.textBoxUserID.TabIndex = 4;
            this.textBoxUserID.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(160, 217);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(188, 35);
            this.buttonRead.TabIndex = 6;
            this.buttonRead.Text = "READ";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 299);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.labelUserID);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxID);
            this.Name = "Form1";
            this.Text = "Sample Client REST";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Button buttonRead;
    }
}

