namespace Adventure
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCharacter = new System.Windows.Forms.Panel();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.lblSTRName = new System.Windows.Forms.Label();
            this.lblINTName = new System.Windows.Forms.Label();
            this.lblCONName = new System.Windows.Forms.Label();
            this.lblSTRValue = new System.Windows.Forms.Label();
            this.lblINTValue = new System.Windows.Forms.Label();
            this.lblCONValue = new System.Windows.Forms.Label();
            this.panelHP = new System.Windows.Forms.Panel();
            this.lblHPName = new System.Windows.Forms.Label();
            this.lblHPValue = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelCharacter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.playerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1161, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAndExitToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAndExitToolStripMenuItem
            // 
            this.saveAndExitToolStripMenuItem.Name = "saveAndExitToolStripMenuItem";
            this.saveAndExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAndExitToolStripMenuItem.Text = "Save and E&xit";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.supportToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem1.Text = "&About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.supportToolStripMenuItem.Text = "&Support";
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.SupportToolStripMenuItem_Click);
            // 
            // panelCharacter
            // 
            this.panelCharacter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCharacter.Controls.Add(this.lblHPValue);
            this.panelCharacter.Controls.Add(this.panelHP);
            this.panelCharacter.Controls.Add(this.lblHPName);
            this.panelCharacter.Controls.Add(this.lblCONValue);
            this.panelCharacter.Controls.Add(this.lblINTValue);
            this.panelCharacter.Controls.Add(this.lblSTRValue);
            this.panelCharacter.Controls.Add(this.lblCONName);
            this.panelCharacter.Controls.Add(this.lblINTName);
            this.panelCharacter.Controls.Add(this.lblSTRName);
            this.panelCharacter.Controls.Add(this.lblCharacterName);
            this.panelCharacter.Location = new System.Drawing.Point(0, 27);
            this.panelCharacter.Name = "panelCharacter";
            this.panelCharacter.Size = new System.Drawing.Size(165, 733);
            this.panelCharacter.TabIndex = 2;
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Location = new System.Drawing.Point(4, 4);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(67, 20);
            this.lblCharacterName.TabIndex = 0;
            this.lblCharacterName.Text = "Terithan";
            // 
            // lblSTRName
            // 
            this.lblSTRName.AutoSize = true;
            this.lblSTRName.Location = new System.Drawing.Point(6, 134);
            this.lblSTRName.Name = "lblSTRName";
            this.lblSTRName.Size = new System.Drawing.Size(45, 20);
            this.lblSTRName.TabIndex = 1;
            this.lblSTRName.Text = "STR:";
            // 
            // lblINTName
            // 
            this.lblINTName.AutoSize = true;
            this.lblINTName.Location = new System.Drawing.Point(13, 154);
            this.lblINTName.Name = "lblINTName";
            this.lblINTName.Size = new System.Drawing.Size(38, 20);
            this.lblINTName.TabIndex = 2;
            this.lblINTName.Text = "INT:";
            // 
            // lblCONName
            // 
            this.lblCONName.AutoSize = true;
            this.lblCONName.Location = new System.Drawing.Point(4, 174);
            this.lblCONName.Name = "lblCONName";
            this.lblCONName.Size = new System.Drawing.Size(47, 20);
            this.lblCONName.TabIndex = 3;
            this.lblCONName.Text = "CON:";
            // 
            // lblSTRValue
            // 
            this.lblSTRValue.AutoSize = true;
            this.lblSTRValue.Location = new System.Drawing.Point(57, 134);
            this.lblSTRValue.Name = "lblSTRValue";
            this.lblSTRValue.Size = new System.Drawing.Size(27, 20);
            this.lblSTRValue.TabIndex = 4;
            this.lblSTRValue.Text = "10";
            // 
            // lblINTValue
            // 
            this.lblINTValue.AutoSize = true;
            this.lblINTValue.Location = new System.Drawing.Point(57, 154);
            this.lblINTValue.Name = "lblINTValue";
            this.lblINTValue.Size = new System.Drawing.Size(27, 20);
            this.lblINTValue.TabIndex = 5;
            this.lblINTValue.Text = "10";
            // 
            // lblCONValue
            // 
            this.lblCONValue.AutoSize = true;
            this.lblCONValue.Location = new System.Drawing.Point(57, 174);
            this.lblCONValue.Name = "lblCONValue";
            this.lblCONValue.Size = new System.Drawing.Size(27, 20);
            this.lblCONValue.TabIndex = 6;
            this.lblCONValue.Text = "10";
            // 
            // panelHP
            // 
            this.panelHP.BackColor = System.Drawing.Color.Firebrick;
            this.panelHP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelHP.Location = new System.Drawing.Point(8, 49);
            this.panelHP.Name = "panelHP";
            this.panelHP.Size = new System.Drawing.Size(152, 24);
            this.panelHP.TabIndex = 7;
            // 
            // lblHPName
            // 
            this.lblHPName.AutoSize = true;
            this.lblHPName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHPName.Location = new System.Drawing.Point(11, 26);
            this.lblHPName.Name = "lblHPName";
            this.lblHPName.Size = new System.Drawing.Size(35, 20);
            this.lblHPName.TabIndex = 0;
            this.lblHPName.Text = "HP:";
            // 
            // lblHPValue
            // 
            this.lblHPValue.AutoSize = true;
            this.lblHPValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHPValue.Location = new System.Drawing.Point(52, 26);
            this.lblHPValue.Name = "lblHPValue";
            this.lblHPValue.Size = new System.Drawing.Size(49, 20);
            this.lblHPValue.TabIndex = 1;
            this.lblHPValue.Text = "20/20";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(361, 158);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(117, 51);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 762);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.panelCharacter);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormMain";
            this.Text = "Adventure";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelCharacter.ResumeLayout(false);
            this.panelCharacter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAndExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.Panel panelCharacter;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.Label lblHPValue;
        private System.Windows.Forms.Panel panelHP;
        private System.Windows.Forms.Label lblHPName;
        private System.Windows.Forms.Label lblCONValue;
        private System.Windows.Forms.Label lblINTValue;
        private System.Windows.Forms.Label lblSTRValue;
        private System.Windows.Forms.Label lblCONName;
        private System.Windows.Forms.Label lblINTName;
        private System.Windows.Forms.Label lblSTRName;
        private System.Windows.Forms.Button btnTest;
    }
}

