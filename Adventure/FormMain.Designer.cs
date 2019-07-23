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
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCharacter = new System.Windows.Forms.Panel();
            this.picRightHand = new System.Windows.Forms.PictureBox();
            this.picLeftHand = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLeftHand = new System.Windows.Forms.Label();
            this.panelMagic = new System.Windows.Forms.Panel();
            this.lblMagicValue = new System.Windows.Forms.Label();
            this.lblMagicName = new System.Windows.Forms.Label();
            this.txtCONValue = new System.Windows.Forms.TextBox();
            this.txtINTValue = new System.Windows.Forms.TextBox();
            this.txtSTRValue = new System.Windows.Forms.TextBox();
            this.lblHPValue = new System.Windows.Forms.Label();
            this.panelHP = new System.Windows.Forms.Panel();
            this.lblHPName = new System.Windows.Forms.Label();
            this.lblCONName = new System.Windows.Forms.Label();
            this.lblINTName = new System.Windows.Forms.Label();
            this.lblSTRName = new System.Windows.Forms.Label();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.picboxGold = new System.Windows.Forms.PictureBox();
            this.txtInventoryGold = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panelCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRightHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGold)).BeginInit();
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
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAndExitToolStripMenuItem
            // 
            this.saveAndExitToolStripMenuItem.Name = "saveAndExitToolStripMenuItem";
            this.saveAndExitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveAndExitToolStripMenuItem.Text = "Save and E&xit";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
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
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem1.Text = "&About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1_Click);
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.supportToolStripMenuItem.Text = "&Support";
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.SupportToolStripMenuItem_Click);
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // panelCharacter
            // 
            this.panelCharacter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCharacter.Controls.Add(this.txtInventoryGold);
            this.panelCharacter.Controls.Add(this.picboxGold);
            this.panelCharacter.Controls.Add(this.picRightHand);
            this.panelCharacter.Controls.Add(this.picLeftHand);
            this.panelCharacter.Controls.Add(this.label1);
            this.panelCharacter.Controls.Add(this.lblLeftHand);
            this.panelCharacter.Controls.Add(this.panelMagic);
            this.panelCharacter.Controls.Add(this.lblMagicValue);
            this.panelCharacter.Controls.Add(this.lblMagicName);
            this.panelCharacter.Controls.Add(this.txtCONValue);
            this.panelCharacter.Controls.Add(this.txtINTValue);
            this.panelCharacter.Controls.Add(this.txtSTRValue);
            this.panelCharacter.Controls.Add(this.lblHPValue);
            this.panelCharacter.Controls.Add(this.panelHP);
            this.panelCharacter.Controls.Add(this.lblHPName);
            this.panelCharacter.Controls.Add(this.lblCONName);
            this.panelCharacter.Controls.Add(this.lblINTName);
            this.panelCharacter.Controls.Add(this.lblSTRName);
            this.panelCharacter.Controls.Add(this.lblCharacterName);
            this.panelCharacter.Location = new System.Drawing.Point(0, 27);
            this.panelCharacter.Name = "panelCharacter";
            this.panelCharacter.Size = new System.Drawing.Size(165, 733);
            this.panelCharacter.TabIndex = 2;
            // 
            // picRightHand
            // 
            this.picRightHand.Location = new System.Drawing.Point(88, 348);
            this.picRightHand.Name = "picRightHand";
            this.picRightHand.Size = new System.Drawing.Size(54, 69);
            this.picRightHand.TabIndex = 16;
            this.picRightHand.TabStop = false;
            // 
            // picLeftHand
            // 
            this.picLeftHand.Location = new System.Drawing.Point(17, 348);
            this.picLeftHand.Name = "picLeftHand";
            this.picLeftHand.Size = new System.Drawing.Size(54, 69);
            this.picLeftHand.TabIndex = 15;
            this.picLeftHand.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 40);
            this.label1.TabIndex = 14;
            this.label1.Text = "Right\r\nHand";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLeftHand
            // 
            this.lblLeftHand.AutoSize = true;
            this.lblLeftHand.Location = new System.Drawing.Point(23, 286);
            this.lblLeftHand.Name = "lblLeftHand";
            this.lblLeftHand.Size = new System.Drawing.Size(48, 40);
            this.lblLeftHand.TabIndex = 13;
            this.lblLeftHand.Text = "Left\r\nHand";
            this.lblLeftHand.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelMagic
            // 
            this.panelMagic.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelMagic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMagic.Location = new System.Drawing.Point(8, 103);
            this.panelMagic.Name = "panelMagic";
            this.panelMagic.Size = new System.Drawing.Size(152, 24);
            this.panelMagic.TabIndex = 8;
            // 
            // lblMagicValue
            // 
            this.lblMagicValue.AutoSize = true;
            this.lblMagicValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMagicValue.Location = new System.Drawing.Point(69, 80);
            this.lblMagicValue.Name = "lblMagicValue";
            this.lblMagicValue.Size = new System.Drawing.Size(49, 20);
            this.lblMagicValue.TabIndex = 12;
            this.lblMagicValue.Text = "20/20";
            // 
            // lblMagicName
            // 
            this.lblMagicName.AutoSize = true;
            this.lblMagicName.Location = new System.Drawing.Point(8, 80);
            this.lblMagicName.Name = "lblMagicName";
            this.lblMagicName.Size = new System.Drawing.Size(55, 20);
            this.lblMagicName.TabIndex = 11;
            this.lblMagicName.Text = "Magic:";
            // 
            // txtCONValue
            // 
            this.txtCONValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCONValue.Location = new System.Drawing.Point(56, 203);
            this.txtCONValue.Name = "txtCONValue";
            this.txtCONValue.ReadOnly = true;
            this.txtCONValue.Size = new System.Drawing.Size(45, 26);
            this.txtCONValue.TabIndex = 10;
            // 
            // txtINTValue
            // 
            this.txtINTValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtINTValue.Location = new System.Drawing.Point(56, 171);
            this.txtINTValue.Name = "txtINTValue";
            this.txtINTValue.ReadOnly = true;
            this.txtINTValue.Size = new System.Drawing.Size(45, 26);
            this.txtINTValue.TabIndex = 9;
            // 
            // txtSTRValue
            // 
            this.txtSTRValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSTRValue.Location = new System.Drawing.Point(57, 139);
            this.txtSTRValue.Name = "txtSTRValue";
            this.txtSTRValue.ReadOnly = true;
            this.txtSTRValue.Size = new System.Drawing.Size(45, 26);
            this.txtSTRValue.TabIndex = 8;
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
            // lblCONName
            // 
            this.lblCONName.AutoSize = true;
            this.lblCONName.Location = new System.Drawing.Point(4, 206);
            this.lblCONName.Name = "lblCONName";
            this.lblCONName.Size = new System.Drawing.Size(47, 20);
            this.lblCONName.TabIndex = 3;
            this.lblCONName.Text = "CON:";
            // 
            // lblINTName
            // 
            this.lblINTName.AutoSize = true;
            this.lblINTName.Location = new System.Drawing.Point(13, 174);
            this.lblINTName.Name = "lblINTName";
            this.lblINTName.Size = new System.Drawing.Size(38, 20);
            this.lblINTName.TabIndex = 2;
            this.lblINTName.Text = "INT:";
            // 
            // lblSTRName
            // 
            this.lblSTRName.AutoSize = true;
            this.lblSTRName.Location = new System.Drawing.Point(6, 142);
            this.lblSTRName.Name = "lblSTRName";
            this.lblSTRName.Size = new System.Drawing.Size(45, 20);
            this.lblSTRName.TabIndex = 1;
            this.lblSTRName.Text = "STR:";
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
            // picboxGold
            // 
            this.picboxGold.InitialImage = global::Adventure.Properties.Resources.Item_Gold;
            this.picboxGold.Location = new System.Drawing.Point(17, 536);
            this.picboxGold.Name = "picboxGold";
            this.picboxGold.Size = new System.Drawing.Size(54, 48);
            this.picboxGold.TabIndex = 17;
            this.picboxGold.TabStop = false;
            // 
            // txtInventoryGold
            // 
            this.txtInventoryGold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInventoryGold.Location = new System.Drawing.Point(88, 546);
            this.txtInventoryGold.Name = "txtInventoryGold";
            this.txtInventoryGold.ReadOnly = true;
            this.txtInventoryGold.Size = new System.Drawing.Size(54, 26);
            this.txtInventoryGold.TabIndex = 18;
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
            ((System.ComponentModel.ISupportInitialize)(this.picRightHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGold)).EndInit();
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
        private System.Windows.Forms.Label lblCONName;
        private System.Windows.Forms.Label lblINTName;
        private System.Windows.Forms.Label lblSTRName;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtCONValue;
        private System.Windows.Forms.TextBox txtINTValue;
        private System.Windows.Forms.TextBox txtSTRValue;
        private System.Windows.Forms.Panel panelMagic;
        private System.Windows.Forms.Label lblMagicValue;
        private System.Windows.Forms.Label lblMagicName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLeftHand;
        private System.Windows.Forms.PictureBox picRightHand;
        private System.Windows.Forms.PictureBox picLeftHand;
        private System.Windows.Forms.TextBox txtInventoryGold;
        private System.Windows.Forms.PictureBox picboxGold;
    }
}

