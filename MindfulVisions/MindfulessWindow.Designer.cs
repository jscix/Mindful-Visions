namespace MindfulVisions
{
    partial class MindfulessWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MindfulessWindow));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.Quote = new System.Windows.Forms.Label();
            this.Tip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(464, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Quote
            // 
            this.Quote.BackColor = System.Drawing.Color.Black;
            this.Quote.Dock = System.Windows.Forms.DockStyle.Top;
            this.Quote.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quote.ForeColor = System.Drawing.Color.White;
            this.Quote.Location = new System.Drawing.Point(0, 0);
            this.Quote.Name = "Quote";
            this.Quote.Size = new System.Drawing.Size(502, 46);
            this.Quote.TabIndex = 1;
            this.Quote.Text = "\"All that we are is the result of what we have thought: it is founded on our thou" +
                "ghts, it is made up of our thoughts.\"\r\n-- Siddhārtha Gautama Buddha";
            this.Quote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tip
            // 
            this.Tip.BackColor = System.Drawing.Color.Black;
            this.Tip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Tip.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tip.ForeColor = System.Drawing.Color.White;
            this.Tip.Location = new System.Drawing.Point(0, 348);
            this.Tip.Name = "Tip";
            this.Tip.Size = new System.Drawing.Size(502, 54);
            this.Tip.TabIndex = 2;
            this.Tip.Text = "tips";
            this.Tip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tip.Click += new System.EventHandler(this.Tip_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(502, 402);
            this.ControlBox = false;
            this.Controls.Add(this.Tip);
            this.Controls.Add(this.Quote);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Quote;
        private System.Windows.Forms.Label Tip;
    }
}