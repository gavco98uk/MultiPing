namespace multiPing
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
        	this.button1 = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.IPpart1 = new System.Windows.Forms.NumericUpDown();
        	this.IPpart2 = new System.Windows.Forms.NumericUpDown();
        	this.IPpart3 = new System.Windows.Forms.NumericUpDown();
        	this.lblStatus = new System.Windows.Forms.Label();
        	this.timer1 = new System.Windows.Forms.Timer(this.components);
        	this.timeoutTimer = new System.Windows.Forms.Timer(this.components);
        	((System.ComponentModel.ISupportInitialize)(this.IPpart1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.IPpart2)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.IPpart3)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.BackColor = System.Drawing.Color.White;
        	this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.button1.Location = new System.Drawing.Point(231, 411);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(75, 20);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "Start Ping!";
        	this.button1.UseVisualStyleBackColor = false;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.ForeColor = System.Drawing.Color.Black;
        	this.label1.Location = new System.Drawing.Point(11, 413);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(55, 13);
        	this.label1.TabIndex = 2;
        	this.label1.Text = "IP Range:";
        	// 
        	// IPpart1
        	// 
        	this.IPpart1.Location = new System.Drawing.Point(72, 411);
        	this.IPpart1.Maximum = new decimal(new int[] {
        	        	        	255,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.IPpart1.Name = "IPpart1";
        	this.IPpart1.Size = new System.Drawing.Size(47, 20);
        	this.IPpart1.TabIndex = 3;
        	this.IPpart1.Value = new decimal(new int[] {
        	        	        	192,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.IPpart1.Click += new System.EventHandler(this.IPpart_SelectText);
        	this.IPpart1.Enter += new System.EventHandler(this.IPpart_SelectText);
        	// 
        	// IPpart2
        	// 
        	this.IPpart2.Location = new System.Drawing.Point(125, 411);
        	this.IPpart2.Maximum = new decimal(new int[] {
        	        	        	255,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.IPpart2.Name = "IPpart2";
        	this.IPpart2.Size = new System.Drawing.Size(47, 20);
        	this.IPpart2.TabIndex = 4;
        	this.IPpart2.Value = new decimal(new int[] {
        	        	        	168,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.IPpart2.Click += new System.EventHandler(this.IPpart_SelectText);
        	this.IPpart2.Enter += new System.EventHandler(this.IPpart_SelectText);
        	// 
        	// IPpart3
        	// 
        	this.IPpart3.Location = new System.Drawing.Point(178, 411);
        	this.IPpart3.Maximum = new decimal(new int[] {
        	        	        	255,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.IPpart3.Name = "IPpart3";
        	this.IPpart3.Size = new System.Drawing.Size(47, 20);
        	this.IPpart3.TabIndex = 5;
        	this.IPpart3.Click += new System.EventHandler(this.IPpart_SelectText);
        	this.IPpart3.Enter += new System.EventHandler(this.IPpart_SelectText);
        	// 
        	// lblStatus
        	// 
        	this.lblStatus.AutoSize = true;
        	this.lblStatus.ForeColor = System.Drawing.Color.Black;
        	this.lblStatus.Location = new System.Drawing.Point(325, 413);
        	this.lblStatus.Name = "lblStatus";
        	this.lblStatus.Size = new System.Drawing.Size(0, 13);
        	this.lblStatus.TabIndex = 6;
        	// 
        	// timer1
        	// 
        	this.timer1.Interval = 1000;
        	this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
        	// 
        	// timeoutTimer
        	// 
        	this.timeoutTimer.Interval = 5000;
        	this.timeoutTimer.Tick += new System.EventHandler(this.TimeoutTimerTick);
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.DarkGray;
        	this.ClientSize = new System.Drawing.Size(620, 441);
        	this.Controls.Add(this.lblStatus);
        	this.Controls.Add(this.IPpart3);
        	this.Controls.Add(this.IPpart2);
        	this.Controls.Add(this.IPpart1);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.button1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.MaximizeBox = false;
        	this.Name = "Form1";
        	this.Text = "MultiPing - By Gavin Coates";
        	((System.ComponentModel.ISupportInitialize)(this.IPpart1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.IPpart2)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.IPpart3)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Timer timeoutTimer;
        private System.Windows.Forms.Timer timer1;

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown IPpart1;
        private System.Windows.Forms.NumericUpDown IPpart2;
        private System.Windows.Forms.NumericUpDown IPpart3;
        private System.Windows.Forms.Label lblStatus;
    }
}

