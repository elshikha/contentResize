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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_SeamMINActual = new System.Windows.Forms.Label();
            this.label_SeamMINExpected = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_seampathcorrectness = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(492, 534);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(2, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(492, 521);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(159, 531);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Visible = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCAR
            // 
            this.btnCAR.Location = new System.Drawing.Point(529, 581);
            this.btnCAR.Name = "btnCAR";
            this.btnCAR.Size = new System.Drawing.Size(136, 23);
            this.btnCAR.TabIndex = 3;
            this.btnCAR.Text = "Open image and resize";
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
            this.pictureBox3.Location = new System.Drawing.Point(10, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(401, 512);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
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
            this.btnSave.Location = new System.Drawing.Point(929, 435);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSave2
            // 
            this.btnSave2.Location = new System.Drawing.Point(554, 474);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(75, 23);
            this.btnSave2.TabIndex = 9;
            this.btnSave2.Text = "Save Image";
            this.btnSave2.UseVisualStyleBackColor = true;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 569);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Actual Output";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 569);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Expected Output";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 590);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Seam MIN Value";
            // 
            // label_SeamMINActual
            // 
            this.label_SeamMINActual.AutoSize = true;
            this.label_SeamMINActual.Location = new System.Drawing.Point(134, 590);
            this.label_SeamMINActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SeamMINActual.Name = "label_SeamMINActual";
            this.label_SeamMINActual.Size = new System.Drawing.Size(16, 13);
            this.label_SeamMINActual.TabIndex = 17;
            this.label_SeamMINActual.Text = "-1";
            // 
            // label_SeamMINExpected
            // 
            this.label_SeamMINExpected.AutoSize = true;
            this.label_SeamMINExpected.Location = new System.Drawing.Point(206, 590);
            this.label_SeamMINExpected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SeamMINExpected.Name = "label_SeamMINExpected";
            this.label_SeamMINExpected.Size = new System.Drawing.Size(16, 13);
            this.label_SeamMINExpected.TabIndex = 18;
            this.label_SeamMINExpected.Text = "-1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 615);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Path Correctness";
            // 
            // label_seampathcorrectness
            // 
            this.label_seampathcorrectness.AutoSize = true;
            this.label_seampathcorrectness.Location = new System.Drawing.Point(107, 615);
            this.label_seampathcorrectness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_seampathcorrectness.Name = "label_seampathcorrectness";
            this.label_seampathcorrectness.Size = new System.Drawing.Size(16, 13);
            this.label_seampathcorrectness.TabIndex = 20;
            this.label_seampathcorrectness.Text = "...";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 453);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(407, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 453);
            this.panel2.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(828, 20);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 453);
            this.panel3.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_seampathcorrectness);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_SeamMINExpected);
            this.Controls.Add(this.label_SeamMINActual);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemoveCols);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumOfSeams);
            this.Controls.Add(this.btnCAR);
            this.Controls.Add(this.btnOpen);
            this.Name = "Form1";
            this.Text = "Content Aware Resizing...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_SeamMINActual;
        private System.Windows.Forms.Label label_SeamMINExpected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_seampathcorrectness;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

