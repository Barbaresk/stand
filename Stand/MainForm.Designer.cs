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
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCreateElement = new System.Windows.Forms.Button();
            this.bOpenElement = new System.Windows.Forms.Button();
            this.bCreateObject = new System.Windows.Forms.Button();
            this.bStand = new System.Windows.Forms.Button();
            this.bOpenObject = new System.Windows.Forms.Button();
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
            this.menu.Size = new System.Drawing.Size(452, 24);
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
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
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
            this.импортОбъектовToolStripMenuItem.Click += new System.EventHandler(this.bOpenObject_Click);
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
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // bCreateElement
            // 
            this.bCreateElement.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateElement.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateElement.FlatAppearance.BorderSize = 0;
            this.bCreateElement.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateElement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateElement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateElement.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bCreateElement.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCreateElement.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bCreateElement.Location = new System.Drawing.Point(74, 64);
            this.bCreateElement.Name = "bCreateElement";
            this.bCreateElement.Size = new System.Drawing.Size(300, 50);
            this.bCreateElement.TabIndex = 5;
            this.bCreateElement.TabStop = false;
            this.bCreateElement.Text = "СОЗДАТЬ ЭЛЕМЕНТ";
            this.bCreateElement.UseVisualStyleBackColor = false;
            this.bCreateElement.Click += new System.EventHandler(this.bCreateElement_Click);
            // 
            // bOpenElement
            // 
            this.bOpenElement.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bOpenElement.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.bOpenElement.FlatAppearance.BorderSize = 0;
            this.bOpenElement.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
            this.bOpenElement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.bOpenElement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.bOpenElement.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bOpenElement.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOpenElement.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bOpenElement.Location = new System.Drawing.Point(74, 134);
            this.bOpenElement.Name = "bOpenElement";
            this.bOpenElement.Size = new System.Drawing.Size(300, 50);
            this.bOpenElement.TabIndex = 6;
            this.bOpenElement.TabStop = false;
            this.bOpenElement.Text = "ОТКРЫТЬ ЭЛЕМЕНТ";
            this.bOpenElement.UseVisualStyleBackColor = false;
            this.bOpenElement.Click += new System.EventHandler(this.bOpenElement_Click);
            // 
            // bCreateObject
            // 
            this.bCreateObject.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateObject.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateObject.FlatAppearance.BorderSize = 0;
            this.bCreateObject.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateObject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateObject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.bCreateObject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bCreateObject.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCreateObject.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bCreateObject.Location = new System.Drawing.Point(74, 204);
            this.bCreateObject.Name = "bCreateObject";
            this.bCreateObject.Size = new System.Drawing.Size(300, 50);
            this.bCreateObject.TabIndex = 7;
            this.bCreateObject.TabStop = false;
            this.bCreateObject.Text = "СОЗДАТЬ ОБЪЕКТ";
            this.bCreateObject.UseVisualStyleBackColor = false;
            this.bCreateObject.Click += new System.EventHandler(this.bCreateObject_Click);
            // 
            // bStand
            // 
            this.bStand.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bStand.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.bStand.FlatAppearance.BorderSize = 0;
            this.bStand.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
            this.bStand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.bStand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.bStand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bStand.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bStand.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bStand.Location = new System.Drawing.Point(74, 344);
            this.bStand.Name = "bStand";
            this.bStand.Size = new System.Drawing.Size(300, 50);
            this.bStand.TabIndex = 8;
            this.bStand.TabStop = false;
            this.bStand.Text = "ЗАПУСТИТЬ СТЕНД";
            this.bStand.UseVisualStyleBackColor = false;
            this.bStand.Click += new System.EventHandler(this.bStand_Click);
            // 
            // bOpenObject
            // 
            this.bOpenObject.BackColor = System.Drawing.Color.LightSteelBlue;
            this.bOpenObject.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bOpenObject.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOpenObject.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bOpenObject.Location = new System.Drawing.Point(74, 274);
            this.bOpenObject.Name = "bOpenObject";
            this.bOpenObject.Size = new System.Drawing.Size(300, 50);
            this.bOpenObject.TabIndex = 9;
            this.bOpenObject.Text = "ОТКРЫТЬ ОБЪЕКТ";
            this.bOpenObject.UseVisualStyleBackColor = false;
            this.bOpenObject.Click += new System.EventHandler(this.bOpenObject_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(452, 433);
            this.Controls.Add(this.bOpenObject);
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
        private System.Windows.Forms.Button bOpenObject;
    }
}

