namespace LogoConnectTest
{
    partial class MainForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btReadNq1 = new System.Windows.Forms.Button();
            this.btSetNi1True = new System.Windows.Forms.Button();
            this.btSetNi1False = new System.Windows.Forms.Button();
            this.btSetNAi1Inc = new System.Windows.Forms.Button();
            this.btSetNAi1Dec = new System.Windows.Forms.Button();
            this.btReadNAq1 = new System.Windows.Forms.Button();
            this.BT_DIS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(9, 132);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(388, 222);
            this.textBox1.TabIndex = 0;
            // 
            // btReadNq1
            // 
            this.btReadNq1.Location = new System.Drawing.Point(26, 63);
            this.btReadNq1.Margin = new System.Windows.Forms.Padding(2);
            this.btReadNq1.Name = "btReadNq1";
            this.btReadNq1.Size = new System.Drawing.Size(156, 23);
            this.btReadNq1.TabIndex = 1;
            this.btReadNq1.Text = "Read NQ1";
            this.btReadNq1.UseVisualStyleBackColor = true;
            this.btReadNq1.Click += new System.EventHandler(this.btReadNq1_Click);
            // 
            // btSetNi1True
            // 
            this.btSetNi1True.Location = new System.Drawing.Point(26, 90);
            this.btSetNi1True.Margin = new System.Windows.Forms.Padding(2);
            this.btSetNi1True.Name = "btSetNi1True";
            this.btSetNi1True.Size = new System.Drawing.Size(76, 25);
            this.btSetNi1True.TabIndex = 2;
            this.btSetNi1True.Text = "Set NI1 True";
            this.btSetNi1True.UseVisualStyleBackColor = true;
            this.btSetNi1True.Click += new System.EventHandler(this.btSetNi1True_Click);
            // 
            // btSetNi1False
            // 
            this.btSetNi1False.Location = new System.Drawing.Point(106, 90);
            this.btSetNi1False.Margin = new System.Windows.Forms.Padding(2);
            this.btSetNi1False.Name = "btSetNi1False";
            this.btSetNi1False.Size = new System.Drawing.Size(76, 25);
            this.btSetNi1False.TabIndex = 3;
            this.btSetNi1False.Text = "Set NI1 False";
            this.btSetNi1False.UseVisualStyleBackColor = true;
            this.btSetNi1False.Click += new System.EventHandler(this.btSetNi1False_Click);
            // 
            // btSetNAi1Inc
            // 
            this.btSetNAi1Inc.Location = new System.Drawing.Point(308, 90);
            this.btSetNAi1Inc.Margin = new System.Windows.Forms.Padding(2);
            this.btSetNAi1Inc.Name = "btSetNAi1Inc";
            this.btSetNAi1Inc.Size = new System.Drawing.Size(76, 25);
            this.btSetNAi1Inc.TabIndex = 6;
            this.btSetNAi1Inc.Text = "Inc NAI1";
            this.btSetNAi1Inc.UseVisualStyleBackColor = true;
            this.btSetNAi1Inc.Click += new System.EventHandler(this.btSetNAi1Inc_Click);
            // 
            // btSetNAi1Dec
            // 
            this.btSetNAi1Dec.Location = new System.Drawing.Point(228, 90);
            this.btSetNAi1Dec.Margin = new System.Windows.Forms.Padding(2);
            this.btSetNAi1Dec.Name = "btSetNAi1Dec";
            this.btSetNAi1Dec.Size = new System.Drawing.Size(76, 25);
            this.btSetNAi1Dec.TabIndex = 5;
            this.btSetNAi1Dec.Text = "Dec NAI1";
            this.btSetNAi1Dec.UseVisualStyleBackColor = true;
            this.btSetNAi1Dec.Click += new System.EventHandler(this.btSetNAi1Dec_Click);
            // 
            // btReadNAq1
            // 
            this.btReadNAq1.Location = new System.Drawing.Point(228, 63);
            this.btReadNAq1.Margin = new System.Windows.Forms.Padding(2);
            this.btReadNAq1.Name = "btReadNAq1";
            this.btReadNAq1.Size = new System.Drawing.Size(156, 23);
            this.btReadNAq1.TabIndex = 4;
            this.btReadNAq1.Text = "Read NAQ1";
            this.btReadNAq1.UseVisualStyleBackColor = true;
            this.btReadNAq1.Click += new System.EventHandler(this.btReadNAq1_Click);
            // 
            // BT_DIS
            // 
            this.BT_DIS.Location = new System.Drawing.Point(27, 35);
            this.BT_DIS.Name = "BT_DIS";
            this.BT_DIS.Size = new System.Drawing.Size(75, 23);
            this.BT_DIS.TabIndex = 7;
            this.BT_DIS.Text = "Disconnect";
            this.BT_DIS.UseVisualStyleBackColor = true;
            this.BT_DIS.Click += new System.EventHandler(this.BT_DIS_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 363);
            this.Controls.Add(this.BT_DIS);
            this.Controls.Add(this.btSetNAi1Inc);
            this.Controls.Add(this.btSetNAi1Dec);
            this.Controls.Add(this.btReadNAq1);
            this.Controls.Add(this.btSetNi1False);
            this.Controls.Add(this.btSetNi1True);
            this.Controls.Add(this.btReadNq1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btReadNq1;
        private System.Windows.Forms.Button btSetNi1True;
        private System.Windows.Forms.Button btSetNi1False;
        private System.Windows.Forms.Button btSetNAi1Inc;
        private System.Windows.Forms.Button btSetNAi1Dec;
        private System.Windows.Forms.Button btReadNAq1;
        private System.Windows.Forms.Button BT_DIS;
    }
}

