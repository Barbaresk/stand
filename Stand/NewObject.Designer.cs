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
            this.bAddObject = new System.Windows.Forms.Button();
            this.pObject = new System.Windows.Forms.Panel();
            this.bBackground = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBackground = new System.Windows.Forms.TextBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.dgvIn = new System.Windows.Forms.DataGridView();
            this.dgvOut = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NewOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Input = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            this.SuspendLayout();
            // 
            // bAddElement
            // 
            this.bAddElement.Location = new System.Drawing.Point(12, 12);
            this.bAddElement.Name = "bAddElement";
            this.bAddElement.Size = new System.Drawing.Size(127, 30);
            this.bAddElement.TabIndex = 0;
            this.bAddElement.Text = "Добавить элемент";
            this.bAddElement.UseVisualStyleBackColor = true;
            this.bAddElement.Click += new System.EventHandler(this.bAddElement_Click);
            // 
            // bAddObject
            // 
            this.bAddObject.Location = new System.Drawing.Point(145, 12);
            this.bAddObject.Name = "bAddObject";
            this.bAddObject.Size = new System.Drawing.Size(127, 30);
            this.bAddObject.TabIndex = 1;
            this.bAddObject.Text = "Добавить объект";
            this.bAddObject.UseVisualStyleBackColor = true;
            // 
            // pObject
            // 
            this.pObject.Location = new System.Drawing.Point(321, 60);
            this.pObject.Name = "pObject";
            this.pObject.Size = new System.Drawing.Size(583, 462);
            this.pObject.TabIndex = 2;
            this.pObject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pObject_MouseDown);
            this.pObject.MouseLeave += new System.EventHandler(this.pObject_MouseLeave);
            this.pObject.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pObject_MouseMove);
            this.pObject.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pObject_MouseUp);
            // 
            // bBackground
            // 
            this.bBackground.Location = new System.Drawing.Point(278, 12);
            this.bBackground.Name = "bBackground";
            this.bBackground.Size = new System.Drawing.Size(127, 30);
            this.bBackground.TabIndex = 3;
            this.bBackground.Text = "Загрузить фон";
            this.bBackground.UseVisualStyleBackColor = true;
            this.bBackground.Click += new System.EventHandler(this.bBackground_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя фона";
            // 
            // tbBackground
            // 
            this.tbBackground.Location = new System.Drawing.Point(475, 18);
            this.tbBackground.Name = "tbBackground";
            this.tbBackground.Size = new System.Drawing.Size(100, 20);
            this.tbBackground.TabIndex = 5;
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementType,
            this.ElementName});
            this.dgvItems.Location = new System.Drawing.Point(12, 60);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(286, 150);
            this.dgvItems.TabIndex = 6;
            // 
            // dgvIn
            // 
            this.dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementIn,
            this.Input,
            this.NewIn});
            this.dgvIn.Location = new System.Drawing.Point(12, 228);
            this.dgvIn.Name = "dgvIn";
            this.dgvIn.Size = new System.Drawing.Size(286, 208);
            this.dgvIn.TabIndex = 7;
            // 
            // dgvOut
            // 
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementOut,
            this.Output,
            this.NewOut});
            this.dgvOut.Location = new System.Drawing.Point(12, 453);
            this.dgvOut.Name = "dgvOut";
            this.dgvOut.Size = new System.Drawing.Size(286, 208);
            this.dgvOut.TabIndex = 8;
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
            this.label3.Location = new System.Drawing.Point(12, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Объединение входов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Объединение выходов";
            // 
            // NewOut
            // 
            this.NewOut.HeaderText = "Новый выход";
            this.NewOut.Name = "NewOut";
            // 
            // Output
            // 
            this.Output.HeaderText = "Выход";
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Width = 60;
            // 
            // ElementOut
            // 
            this.ElementOut.HeaderText = "Элемент";
            this.ElementOut.Name = "ElementOut";
            this.ElementOut.ReadOnly = true;
            this.ElementOut.Width = 60;
            // 
            // ElementIn
            // 
            this.ElementIn.HeaderText = "Элемент";
            this.ElementIn.Name = "ElementIn";
            this.ElementIn.ReadOnly = true;
            this.ElementIn.Width = 60;
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
            // ElementType
            // 
            this.ElementType.HeaderText = "Элемент";
            this.ElementType.Name = "ElementType";
            this.ElementType.ReadOnly = true;
            this.ElementType.Width = 110;
            // 
            // ElementName
            // 
            this.ElementName.HeaderText = "Имя";
            this.ElementName.Name = "ElementName";
            this.ElementName.Width = 110;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(665, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(700, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 14;
            // 
            // NewObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 667);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
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
            this.Text = "NewObject";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewObject_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAddElement;
        private System.Windows.Forms.Button bAddObject;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Input;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Output;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewOut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}