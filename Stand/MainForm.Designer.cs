namespace VirtualStand
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйСтендToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьСтендToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортОбъектовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.элементыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортЭлементовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lDirectory = new System.Windows.Forms.Label();
            this.lStand = new System.Windows.Forms.Label();
            this.создатьОбъектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.объектыToolStripMenuItem,
            this.элементыToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(412, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйСтендToolStripMenuItem,
            this.открытьСтендToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйСтендToolStripMenuItem
            // 
            this.новыйСтендToolStripMenuItem.Name = "новыйСтендToolStripMenuItem";
            this.новыйСтендToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.новыйСтендToolStripMenuItem.Text = "Новый стенд";
            this.новыйСтендToolStripMenuItem.Click += new System.EventHandler(this.newStand_Click);
            // 
            // открытьСтендToolStripMenuItem
            // 
            this.открытьСтендToolStripMenuItem.Name = "открытьСтендToolStripMenuItem";
            this.открытьСтендToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.открытьСтендToolStripMenuItem.Text = "Открыть стенд";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // объектыToolStripMenuItem
            // 
            this.объектыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортОбъектовToolStripMenuItem,
            this.создатьОбъектToolStripMenuItem});
            this.объектыToolStripMenuItem.Name = "объектыToolStripMenuItem";
            this.объектыToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.объектыToolStripMenuItem.Text = "Объекты";
            // 
            // импортОбъектовToolStripMenuItem
            // 
            this.импортОбъектовToolStripMenuItem.Name = "импортОбъектовToolStripMenuItem";
            this.импортОбъектовToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.импортОбъектовToolStripMenuItem.Text = "Открыть объект";
            // 
            // элементыToolStripMenuItem
            // 
            this.элементыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортЭлементовToolStripMenuItem,
            this.создатьЭлементToolStripMenuItem});
            this.элементыToolStripMenuItem.Name = "элементыToolStripMenuItem";
            this.элементыToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.элементыToolStripMenuItem.Text = "Элементы";
            // 
            // импортЭлементовToolStripMenuItem
            // 
            this.импортЭлементовToolStripMenuItem.Name = "импортЭлементовToolStripMenuItem";
            this.импортЭлементовToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.импортЭлементовToolStripMenuItem.Text = "Открыть элемент";
            this.импортЭлементовToolStripMenuItem.Click += new System.EventHandler(this.openElement_Click);
            // 
            // создатьЭлементToolStripMenuItem
            // 
            this.создатьЭлементToolStripMenuItem.Name = "создатьЭлементToolStripMenuItem";
            this.создатьЭлементToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.создатьЭлементToolStripMenuItem.Text = "Создать элемент";
            this.создатьЭлементToolStripMenuItem.Click += new System.EventHandler(this.newElement_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Текущая директория:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Стенд";
            // 
            // lDirectory
            // 
            this.lDirectory.AutoSize = true;
            this.lDirectory.Location = new System.Drawing.Point(135, 24);
            this.lDirectory.Name = "lDirectory";
            this.lDirectory.Size = new System.Drawing.Size(24, 13);
            this.lDirectory.TabIndex = 3;
            this.lDirectory.Text = "нет";
            // 
            // lStand
            // 
            this.lStand.AutoSize = true;
            this.lStand.Location = new System.Drawing.Point(135, 37);
            this.lStand.Name = "lStand";
            this.lStand.Size = new System.Drawing.Size(24, 13);
            this.lStand.TabIndex = 4;
            this.lStand.Text = "нет";
            // 
            // создатьОбъектToolStripMenuItem
            // 
            this.создатьОбъектToolStripMenuItem.Name = "создатьОбъектToolStripMenuItem";
            this.создатьОбъектToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.создатьОбъектToolStripMenuItem.Text = "Создать объект";
            this.создатьОбъектToolStripMenuItem.Click += new System.EventHandler(this.newObject_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 304);
            this.Controls.Add(this.lStand);
            this.Controls.Add(this.lDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Редактор стендов";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйСтендToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьСтендToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортОбъектовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem элементыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортЭлементовToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lDirectory;
        private System.Windows.Forms.Label lStand;
        private System.Windows.Forms.ToolStripMenuItem создатьЭлементToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьОбъектToolStripMenuItem;
    }
}

