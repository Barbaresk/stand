namespace VirtualStand
{
    partial class NewElement
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.bBackground = new System.Windows.Forms.Button();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.dgvOut = new System.Windows.Forms.DataGridView();
            this.NameOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RadixOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIn = new System.Windows.Forms.DataGridView();
            this.NameIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RadixIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAddIn = new System.Windows.Forms.Button();
            this.pLines = new System.Windows.Forms.Panel();
            this.pButtons = new System.Windows.Forms.Panel();
            this.pMain = new System.Windows.Forms.Panel();
            this.pOut = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bCheck = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lErrors = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lWarnings = new System.Windows.Forms.Label();
            this.tbBackground = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
            this.pMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название элемента";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.LightCyan;
            this.tbName.Location = new System.Drawing.Point(9, 28);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(174, 20);
            this.tbName.TabIndex = 1;
            // 
            // bBackground
            // 
            this.bBackground.BackColor = System.Drawing.Color.PowderBlue;
            this.bBackground.Location = new System.Drawing.Point(457, 258);
            this.bBackground.Name = "bBackground";
            this.bBackground.Size = new System.Drawing.Size(101, 39);
            this.bBackground.TabIndex = 7;
            this.bBackground.Text = "Загрузить фон";
            this.bBackground.UseVisualStyleBackColor = false;
            this.bBackground.Click += new System.EventHandler(this.bBackground_Click);
            // 
            // pbBackground
            // 
            this.pbBackground.BackColor = System.Drawing.Color.LightCyan;
            this.pbBackground.Location = new System.Drawing.Point(727, 2);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(565, 295);
            this.pbBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBackground.TabIndex = 8;
            this.pbBackground.TabStop = false;
            this.pbBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbBackground_MouseDown);
            this.pbBackground.MouseLeave += new System.EventHandler(this.pbBackground_MouseLeave);
            this.pbBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbBackground_MouseMove);
            this.pbBackground.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbBackground_MouseUp);
            // 
            // dgvOut
            // 
            this.dgvOut.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameOut,
            this.RadixOut});
            this.dgvOut.Location = new System.Drawing.Point(189, 5);
            this.dgvOut.Name = "dgvOut";
            this.dgvOut.Size = new System.Drawing.Size(224, 150);
            this.dgvOut.TabIndex = 10;
            this.dgvOut.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOut_CellValueChanged);
            this.dgvOut.ColumnRemoved += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvOut_ColumnRemoved);
            // 
            // NameOut
            // 
            this.NameOut.HeaderText = "Имя выхода";
            this.NameOut.Name = "NameOut";
            this.NameOut.Width = 80;
            // 
            // RadixOut
            // 
            this.RadixOut.HeaderText = "Разрядность";
            this.RadixOut.Name = "RadixOut";
            this.RadixOut.Width = 80;
            // 
            // dgvIn
            // 
            this.dgvIn.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameIn,
            this.RadixIn,
            this.DefaultIn});
            this.dgvIn.Location = new System.Drawing.Point(419, 5);
            this.dgvIn.Name = "dgvIn";
            this.dgvIn.Size = new System.Drawing.Size(302, 150);
            this.dgvIn.TabIndex = 11;
            this.dgvIn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIn_CellValueChanged);
            this.dgvIn.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvIn_UserAddedRow);
            // 
            // NameIn
            // 
            this.NameIn.DataPropertyName = "nn";
            this.NameIn.HeaderText = "Имя входа";
            this.NameIn.Name = "NameIn";
            this.NameIn.Width = 80;
            // 
            // RadixIn
            // 
            this.RadixIn.HeaderText = "Разрядность";
            this.RadixIn.Name = "RadixIn";
            this.RadixIn.Width = 80;
            // 
            // DefaultIn
            // 
            this.DefaultIn.HeaderText = "Стандартное значение";
            this.DefaultIn.Name = "DefaultIn";
            this.DefaultIn.Width = 80;
            // 
            // bAddIn
            // 
            this.bAddIn.BackColor = System.Drawing.Color.PowderBlue;
            this.bAddIn.Location = new System.Drawing.Point(9, 258);
            this.bAddIn.Name = "bAddIn";
            this.bAddIn.Size = new System.Drawing.Size(174, 39);
            this.bAddIn.TabIndex = 13;
            this.bAddIn.Text = "Добавить изображение для входов";
            this.bAddIn.UseVisualStyleBackColor = false;
            this.bAddIn.Click += new System.EventHandler(this.bAddIn_Click);
            // 
            // pLines
            // 
            this.pLines.AutoSize = true;
            this.pLines.BackColor = System.Drawing.Color.LightCyan;
            this.pLines.Location = new System.Drawing.Point(100, 3);
            this.pLines.Name = "pLines";
            this.pLines.Size = new System.Drawing.Size(854, 233);
            this.pLines.TabIndex = 14;
            // 
            // pButtons
            // 
            this.pButtons.AutoSize = true;
            this.pButtons.BackColor = System.Drawing.Color.LightCyan;
            this.pButtons.Location = new System.Drawing.Point(3, 3);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(91, 233);
            this.pButtons.TabIndex = 15;
            // 
            // pMain
            // 
            this.pMain.AutoScroll = true;
            this.pMain.BackColor = System.Drawing.Color.LightCyan;
            this.pMain.Controls.Add(this.pLines);
            this.pMain.Controls.Add(this.pButtons);
            this.pMain.Location = new System.Drawing.Point(9, 303);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(973, 236);
            this.pMain.TabIndex = 17;
            // 
            // pOut
            // 
            this.pOut.AutoScroll = true;
            this.pOut.BackColor = System.Drawing.Color.LightCyan;
            this.pOut.Location = new System.Drawing.Point(12, 161);
            this.pOut.Name = "pOut";
            this.pOut.Size = new System.Drawing.Size(709, 91);
            this.pOut.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Устройства для выводов";
            // 
            // bCheck
            // 
            this.bCheck.BackColor = System.Drawing.Color.PowderBlue;
            this.bCheck.Location = new System.Drawing.Point(9, 83);
            this.bCheck.Name = "bCheck";
            this.bCheck.Size = new System.Drawing.Size(174, 23);
            this.bCheck.TabIndex = 20;
            this.bCheck.Text = "Проверить";
            this.bCheck.UseVisualStyleBackColor = false;
            this.bCheck.Click += new System.EventHandler(this.bCheck_Click);
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.PowderBlue;
            this.bSave.Location = new System.Drawing.Point(9, 112);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(174, 23);
            this.bSave.TabIndex = 21;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.LightCyan;
            this.panel2.Controls.Add(this.lErrors);
            this.panel2.Location = new System.Drawing.Point(9, 545);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 86);
            this.panel2.TabIndex = 22;
            // 
            // lErrors
            // 
            this.lErrors.AutoSize = true;
            this.lErrors.ForeColor = System.Drawing.Color.Red;
            this.lErrors.Location = new System.Drawing.Point(3, 0);
            this.lErrors.Name = "lErrors";
            this.lErrors.Size = new System.Drawing.Size(112, 13);
            this.lErrors.TabIndex = 0;
            this.lErrors.Text = "Ошибки отсутствуют";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCyan;
            this.panel3.Controls.Add(this.lWarnings);
            this.panel3.Location = new System.Drawing.Point(491, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 86);
            this.panel3.TabIndex = 23;
            // 
            // lWarnings
            // 
            this.lWarnings.AutoSize = true;
            this.lWarnings.ForeColor = System.Drawing.Color.DarkOrange;
            this.lWarnings.Location = new System.Drawing.Point(3, 0);
            this.lWarnings.Name = "lWarnings";
            this.lWarnings.Size = new System.Drawing.Size(159, 13);
            this.lWarnings.TabIndex = 0;
            this.lWarnings.Text = "Предупреждения отсутствуют";
            // 
            // tbBackground
            // 
            this.tbBackground.BackColor = System.Drawing.Color.LightCyan;
            this.tbBackground.Location = new System.Drawing.Point(628, 268);
            this.tbBackground.Name = "tbBackground";
            this.tbBackground.Size = new System.Drawing.Size(93, 20);
            this.tbBackground.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Имя фона:";
            // 
            // NewElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1426, 653);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBackground);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pOut);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.bAddIn);
            this.Controls.Add(this.dgvIn);
            this.Controls.Add(this.dgvOut);
            this.Controls.Add(this.pbBackground);
            this.Controls.Add(this.bBackground);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Name = "NewElement";
            this.Text = "  Создание нового элемента";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewElement_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button bBackground;
        private System.Windows.Forms.PictureBox pbBackground;
        private System.Windows.Forms.DataGridView dgvOut;
        private System.Windows.Forms.DataGridView dgvIn;
        private System.Windows.Forms.Button bAddIn;
        private System.Windows.Forms.Panel pLines;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bCheck;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lErrors;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lWarnings;
        private System.Windows.Forms.TextBox tbBackground;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RadixIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn RadixOut;
    }
}