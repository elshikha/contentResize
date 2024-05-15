namespace ContentAwareResize
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCAR = new System.Windows.Forms.Button();
            this.txtNumOfSeams = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnRemoveCols = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.btnSave3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(396, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(269, 360);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 531);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCAR
            // 
            this.btnCAR.Location = new System.Drawing.Point(590, 581);
            this.btnCAR.Name = "btnCAR";
            this.btnCAR.Size = new System.Drawing.Size(75, 23);
            this.btnCAR.TabIndex = 3;
            this.btnCAR.Text = "CAR";
            this.btnCAR.UseVisualStyleBackColor = true;
            this.btnCAR.Click += new System.EventHandler(this.btnCAR_Click);
            // 
            // txtNumOfSeams
            // 
            this.txtNumOfSeams.Location = new System.Drawing.Point(828, 583);
            this.txtNumOfSeams.Name = "txtNumOfSeams";
            this.txtNumOfSeams.Size = new System.Drawing.Size(44, 20);
            this.txtNumOfSeams.TabIndex = 4;
            this.txtNumOfSeams.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(676, 585);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Seams to Remove";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(553, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(512, 512);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // btnRemoveCols
            // 
            this.btnRemoveCols.Location = new System.Drawing.Point(590, 610);
            this.btnRemoveCols.Name = "btnRemoveCols";
            this.btnRemoveCols.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCols.TabIndex = 7;
            this.btnRemoveCols.Text = "Remove Cols";
            this.btnRemoveCols.UseVisualStyleBackColor = true;
            this.btnRemoveCols.Click += new System.EventHandler(this.btnRemoveCols_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(590, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.Location = new System.Drawing.Point(315, 531);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(75, 23);
            this.btnSave2.TabIndex = 9;
            this.btnSave2.Text = "Save Image";
            this.btnSave2.UseVisualStyleBackColor = true;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // btnSave3
            // 
            this.btnSave3.Location = new System.Drawing.Point(12, 560);
            this.btnSave3.Name = "btnSave3";
            this.btnSave3.Size = new System.Drawing.Size(75, 23);
            this.btnSave3.TabIndex = 10;
            this.btnSave3.Text = "Save Image";
            this.btnSave3.UseVisualStyleBackColor = true;
            this.btnSave3.Click += new System.EventHandler(this.btnSave3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 646);
            this.Controls.Add(this.btnSave3);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemoveCols);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumOfSeams);
            this.Controls.Add(this.btnCAR);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Form1";
            this.Text = "Content Aware Resizing...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCAR;
        private System.Windows.Forms.TextBox txtNumOfSeams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnRemoveCols;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.Button btnSave3;
    }
}

