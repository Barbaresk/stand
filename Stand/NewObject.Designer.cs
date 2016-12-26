namespace VirtualStand
{
    partial class NewObject
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
            this.bAddElement = new System.Windows.Forms.Button();
            this.pObject = new System.Windows.Forms.Panel();
            this.bBackground = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBackground = new System.Windows.Forms.TextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.ElementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIn = new System.Windows.Forms.DataGridView();
            this.ElementIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Input = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOut = new System.Windows.Forms.DataGridView();
            this.ElementOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbIn = new System.Windows.Forms.CheckBox();
            this.cbOut = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bCheck = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lErrors = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lWarnings = new System.Windows.Forms.Label();
            this.bAddObject = new System.Windows.Forms.Button();
            this.cbLink = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bAddElement
            // 
            this.bAddElement.BackColor = System.Drawing.Color.Gainsboro;
            this.bAddElement.Location = new System.Drawing.Point(12, 12);
            this.bAddElement.Name = "bAddElement";
            this.bAddElement.Size = new System.Drawing.Size(127, 30);
            this.bAddElement.TabIndex = 0;
            this.bAddElement.Text = "Добавить элемент";
            this.bAddElement.UseVisualStyleBackColor = false;
            this.bAddElement.Click += new System.EventHandler(this.bAddElement_Click);
            // 
            // pObject
            // 
            this.pObject.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pObject.Location = new System.Drawing.Point(354, 60);
            this.pObject.Name = "pObject";
            this.pObject.Size = new System.Drawing.Size(851, 601);
            this.pObject.TabIndex = 2;
            this.pObject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pObject_MouseDown);
            this.pObject.MouseLeave += new System.EventHandler(this.pObject_MouseLeave);
            this.pObject.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pObject_MouseMove);
            this.pObject.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pObject_MouseUp);
            // 
            // bBackground
            // 
            this.bBackground.BackColor = System.Drawing.Color.Gainsboro;
            this.bBackground.Location = new System.Drawing.Point(278, 12);
            this.bBackground.Name = "bBackground";
            this.bBackground.Size = new System.Drawing.Size(127, 30);
            this.bBackground.TabIndex = 3;
            this.bBackground.Text = "Загрузить фон";
            this.bBackground.UseVisualStyleBackColor = false;
            this.bBackground.Click += new System.EventHandler(this.bBackground_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя фона:";
            // 
            // tbBackground
            // 
            this.tbBackground.BackColor = System.Drawing.Color.Gainsboro;
            this.tbBackground.Location = new System.Drawing.Point(475, 18);
            this.tbBackground.Name = "tbBackground";
            this.tbBackground.Size = new System.Drawing.Size(100, 20);
            this.tbBackground.TabIndex = 5;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementType,
            this.ElementName});
            this.dgvItems.Location = new System.Drawing.Point(12, 60);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(336, 150);
            this.dgvItems.TabIndex = 6;
            this.dgvItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItems_CellBeginEdit);
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEndEdit);
            this.dgvItems.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvItems_RowsRemoved);
            this.dgvItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItems_KeyDown);
            // 
            // ElementType
            // 
            this.ElementType.HeaderText = "Элемент";
            this.ElementType.Name = "ElementType";
            this.ElementType.ReadOnly = true;
            this.ElementType.Width = 135;
            // 
            // ElementName
            // 
            this.ElementName.HeaderText = "Имя";
            this.ElementName.Name = "ElementName";
            this.ElementName.Width = 135;
            // 
            // dgvIn
            // 
            this.dgvIn.AllowUserToAddRows = false;
            this.dgvIn.AllowUserToDeleteRows = false;
            this.dgvIn.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementIn,
            this.Input,
            this.NewIn});
            this.dgvIn.Location = new System.Drawing.Point(12, 228);
            this.dgvIn.Name = "dgvIn";
            this.dgvIn.Size = new System.Drawing.Size(336, 208);
            this.dgvIn.TabIndex = 7;
            this.dgvIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvIn_KeyDown);
            // 
            // ElementIn
            // 
            this.ElementIn.HeaderText = "Имя элемента";
            this.ElementIn.Name = "ElementIn";
            this.ElementIn.ReadOnly = true;
            this.ElementIn.Width = 110;
            // 
            // Input
            // 
            this.Input.HeaderText = "Вход";
            this.Input.Name = "Input";
            this.Input.ReadOnly = true;
            this.Input.Width = 60;
            // 
            // NewIn
            // 
            this.NewIn.HeaderText = "Новый вход";
            this.NewIn.Name = "NewIn";
            // 
            // dgvOut
            // 
            this.dgvOut.AllowUserToAddRows = false;
            this.dgvOut.AllowUserToDeleteRows = false;
            this.dgvOut.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementOut,
            this.Output,
            this.NewOut});
            this.dgvOut.Location = new System.Drawing.Point(12, 453);
            this.dgvOut.Name = "dgvOut";
            this.dgvOut.Size = new System.Drawing.Size(336, 208);
            this.dgvOut.TabIndex = 8;
            this.dgvOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOut_KeyDown);
            // 
            // ElementOut
            // 
            this.ElementOut.HeaderText = "Имя элемента";
            this.ElementOut.Name = "ElementOut";
            this.ElementOut.ReadOnly = true;
            this.ElementOut.Width = 110;
            // 
            // Output
            // 
            this.Output.HeaderText = "Выход";
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Width = 60;
            // 
            // NewOut
            // 
            this.NewOut.HeaderText = "Новый выход";
            this.NewOut.Name = "NewOut";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Имена элементов и объектов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Объединение входов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Объединение выходов";
            // 
            // cbIn
            // 
            this.cbIn.AutoSize = true;
            this.cbIn.Location = new System.Drawing.Point(185, 211);
            this.cbIn.Name = "cbIn";
            this.cbIn.Size = new System.Drawing.Size(160, 17);
            this.cbIn.TabIndex = 15;
            this.cbIn.Text = "Не менять автоматически";
            this.cbIn.UseVisualStyleBackColor = true;
            // 
            // cbOut
            // 
            this.cbOut.AutoSize = true;
            this.cbOut.Location = new System.Drawing.Point(185, 436);
            this.cbOut.Name = "cbOut";
            this.cbOut.Size = new System.Drawing.Size(160, 17);
            this.cbOut.TabIndex = 16;
            this.cbOut.Text = "Не менять автоматически";
            this.cbOut.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Название элемента:";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.Gainsboro;
            this.tbName.Location = new System.Drawing.Point(714, 18);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 18;
            // 
            // bSave
            // 
            this.bSave.BackColor = System.Drawing.Color.Gainsboro;
            this.bSave.Location = new System.Drawing.Point(820, 12);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(127, 30);
            this.bSave.TabIndex = 19;
            this.bSave.Text = "Сохранить";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCheck
            // 
            this.bCheck.BackColor = System.Drawing.Color.Gainsboro;
            this.bCheck.Location = new System.Drawing.Point(953, 12);
            this.bCheck.Name = "bCheck";
            this.bCheck.Size = new System.Drawing.Size(127, 30);
            this.bCheck.TabIndex = 20;
            this.bCheck.Text = "Проверить";
            this.bCheck.UseVisualStyleBackColor = false;
            this.bCheck.Click += new System.EventHandler(this.bCheck_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lErrors);
            this.panel1.Location = new System.Drawing.Point(12, 667);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 82);
            this.panel1.TabIndex = 21;
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
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.lWarnings);
            this.panel2.Location = new System.Drawing.Point(617, 667);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 82);
            this.panel2.TabIndex = 22;
            // 
            // lWarnings
            // 
            this.lWarnings.AutoSize = true;
            this.lWarnings.ForeColor = System.Drawing.Color.Gold;
            this.lWarnings.Location = new System.Drawing.Point(3, 0);
            this.lWarnings.Name = "lWarnings";
            this.lWarnings.Size = new System.Drawing.Size(159, 13);
            this.lWarnings.TabIndex = 0;
            this.lWarnings.Text = "Предупреждения отсутствуют";
            // 
            // bAddObject
            // 
            this.bAddObject.BackColor = System.Drawing.Color.Gainsboro;
            this.bAddObject.Location = new System.Drawing.Point(145, 12);
            this.bAddObject.Name = "bAddObject";
            this.bAddObject.Size = new System.Drawing.Size(127, 30);
            this.bAddObject.TabIndex = 1;
            this.bAddObject.Text = "Добавить объект";
            this.bAddObject.UseVisualStyleBackColor = false;
            this.bAddObject.Click += new System.EventHandler(this.bAddObject_Click);
            // 
            // cbLink
            // 
            this.cbLink.AutoSize = true;
            this.cbLink.Checked = true;
            this.cbLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLink.Location = new System.Drawing.Point(1086, 20);
            this.cbLink.Name = "cbLink";
            this.cbLink.Size = new System.Drawing.Size(76, 17);
            this.cbLink.TabIndex = 23;
            this.cbLink.Text = "Привязка";
            this.cbLink.UseVisualStyleBackColor = true;
            this.cbLink.CheckedChanged += new System.EventHandler(this.cbLink_CheckedChanged);
            // 
            // NewObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1212, 761);
            this.Controls.Add(this.cbLink);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bCheck);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbOut);
            this.Controls.Add(this.cbIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvOut);
            this.Controls.Add(this.dgvIn);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.tbBackground);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bBackground);
            this.Controls.Add(this.pObject);
            this.Controls.Add(this.bAddObject);
            this.Controls.Add(this.bAddElement);
            this.Name = "NewObject";
            this.Text = "Создание нового объекта";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewObject_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAddElement;
        private System.Windows.Forms.Panel pObject;
        private System.Windows.Forms.Button bBackground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBackground;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridView dgvIn;
        private System.Windows.Forms.DataGridView dgvOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbIn;
        private System.Windows.Forms.CheckBox cbOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Input;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Output;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lErrors;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lWarnings;
        private System.Windows.Forms.Button bAddObject;
        private System.Windows.Forms.CheckBox cbLink;
    }
}