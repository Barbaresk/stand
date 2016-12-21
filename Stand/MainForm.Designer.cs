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
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортОбъектовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьОбъектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.элементыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортЭлементовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьЭлементToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCreateElement = new System.Windows.Forms.Button();
            this.bOpenElement = new System.Windows.Forms.Button();
            this.bCreateObject = new System.Windows.Forms.Button();
            this.bStand = new System.Windows.Forms.Button();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.объектыToolStripMenuItem,
            this.элементыToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(431, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // создатьОбъектToolStripMenuItem
            // 
            this.создатьОбъектToolStripMenuItem.Name = "создатьОбъектToolStripMenuItem";
            this.создатьОбъектToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.создатьОбъектToolStripMenuItem.Text = "Создать объект";
            this.создатьОбъектToolStripMenuItem.Click += new System.EventHandler(this.newObject_Click);
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
            // bCreateElement
            // 
            this.bCreateElement.Location = new System.Drawing.Point(12, 27);
            this.bCreateElement.Name = "bCreateElement";
            this.bCreateElement.Size = new System.Drawing.Size(200, 200);
            this.bCreateElement.TabIndex = 5;
            this.bCreateElement.Text = "Создать элемент";
            this.bCreateElement.UseVisualStyleBackColor = true;
            this.bCreateElement.Click += new System.EventHandler(this.bCreateElement_Click);
            // 
            // bOpenElement
            // 
            this.bOpenElement.Location = new System.Drawing.Point(218, 27);
            this.bOpenElement.Name = "bOpenElement";
            this.bOpenElement.Size = new System.Drawing.Size(200, 200);
            this.bOpenElement.TabIndex = 6;
            this.bOpenElement.Text = "Открыть элемент";
            this.bOpenElement.UseVisualStyleBackColor = true;
            this.bOpenElement.Click += new System.EventHandler(this.bOpenElement_Click);
            // 
            // bCreateObject
            // 
            this.bCreateObject.Location = new System.Drawing.Point(12, 233);
            this.bCreateObject.Name = "bCreateObject";
            this.bCreateObject.Size = new System.Drawing.Size(200, 200);
            this.bCreateObject.TabIndex = 7;
            this.bCreateObject.Text = "Создать объект";
            this.bCreateObject.UseVisualStyleBackColor = true;
            this.bCreateObject.Click += new System.EventHandler(this.bCreateObject_Click);
            // 
            // bStand
            // 
            this.bStand.Location = new System.Drawing.Point(218, 233);
            this.bStand.Name = "bStand";
            this.bStand.Size = new System.Drawing.Size(200, 200);
            this.bStand.TabIndex = 8;
            this.bStand.Text = "Стенд";
            this.bStand.UseVisualStyleBackColor = true;
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 445);
            this.Controls.Add(this.bStand);
            this.Controls.Add(this.bCreateObject);
            this.Controls.Add(this.bOpenElement);
            this.Controls.Add(this.bCreateElement);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Навигатор";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортОбъектовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem элементыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортЭлементовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьЭлементToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьОбъектToolStripMenuItem;
        private System.Windows.Forms.Button bCreateElement;
        private System.Windows.Forms.Button bOpenElement;
        private System.Windows.Forms.Button bCreateObject;
        private System.Windows.Forms.Button bStand;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}

