namespace VirtualStand
{
    partial class Request
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbStand = new System.Windows.Forms.TextBox();
            this.bConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите название стенда";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbStand
            // 
            this.tbStand.Location = new System.Drawing.Point(12, 25);
            this.tbStand.Name = "tbStand";
            this.tbStand.Size = new System.Drawing.Size(260, 20);
            this.tbStand.TabIndex = 1;
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(103, 51);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(75, 23);
            this.bConfirm.TabIndex = 2;
            this.bConfirm.Text = "Ок";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // Request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 77);
            this.Controls.Add(this.bConfirm);
            this.Controls.Add(this.tbStand);
            this.Controls.Add(this.label1);
            this.Name = "Request";
            this.Text = "Имя стенда";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStand;
        private System.Windows.Forms.Button bConfirm;
    }
}