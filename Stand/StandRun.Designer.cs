namespace VirtualStand
{
    partial class StandRun
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
            this.bStart = new System.Windows.Forms.Button();
            this.pbStand = new System.Windows.Forms.PictureBox();
            this.tbError = new System.Windows.Forms.RichTextBox();
            this.canMoved = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStand)).BeginInit();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 12);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(209, 23);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Искать стенд и подключиться";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // pbStand
            // 
            this.pbStand.Location = new System.Drawing.Point(12, 41);
            this.pbStand.Name = "pbStand";
            this.pbStand.Size = new System.Drawing.Size(978, 451);
            this.pbStand.TabIndex = 1;
            this.pbStand.TabStop = false;
            this.pbStand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbStand_MouseClick);
            this.pbStand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbStand_MouseDown);
            this.pbStand.MouseLeave += new System.EventHandler(this.pbStand_MouseLeave);
            this.pbStand.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbStand_MouseMove);
            this.pbStand.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbStand_MouseUp);
            // 
            // tbError
            // 
            this.tbError.Location = new System.Drawing.Point(12, 498);
            this.tbError.Name = "tbError";
            this.tbError.Size = new System.Drawing.Size(449, 55);
            this.tbError.TabIndex = 2;
            this.tbError.Text = "";
            // 
            // canMoved
            // 
            this.canMoved.AutoSize = true;
            this.canMoved.Location = new System.Drawing.Point(821, 18);
            this.canMoved.Name = "canMoved";
            this.canMoved.Size = new System.Drawing.Size(169, 17);
            this.canMoved.TabIndex = 3;
            this.canMoved.Text = "Перетаскивание элементов";
            this.canMoved.UseVisualStyleBackColor = true;
            // 
            // StandRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 565);
            this.Controls.Add(this.canMoved);
            this.Controls.Add(this.tbError);
            this.Controls.Add(this.pbStand);
            this.Controls.Add(this.bStart);
            this.Name = "StandRun";
            this.Text = "StandRun";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.StandRun_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbStand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.PictureBox pbStand;
        private System.Windows.Forms.RichTextBox tbError;
        private System.Windows.Forms.CheckBox canMoved;
    }
}