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
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndLogoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCharacter = new System.Windows.Forms.Panel();
            this.txtInventoryGold = new System.Windows.Forms.TextBox();
            this.picboxGold = new System.Windows.Forms.PictureBox();
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
            this.panelInventory = new System.Windows.Forms.Panel();
            this.btnManageInventory = new System.Windows.Forms.Button();
            this.picboxInventory8 = new System.Windows.Forms.PictureBox();
            this.picboxInventory7 = new System.Windows.Forms.PictureBox();
            this.picboxInventory6 = new System.Windows.Forms.PictureBox();
            this.picboxInventory5 = new System.Windows.Forms.PictureBox();
            this.picboxInventory4 = new System.Windows.Forms.PictureBox();
            this.picboxInventory3 = new System.Windows.Forms.PictureBox();
            this.picboxInventory2 = new System.Windows.Forms.PictureBox();
            this.picboxInventory1 = new System.Windows.Forms.PictureBox();
            this.lblInventoryPanelTitle = new System.Windows.Forms.Label();
            this.panelQuest = new System.Windows.Forms.Panel();
            this.lblQuestPanelTitle = new System.Windows.Forms.Label();
            this.panelGame = new System.Windows.Forms.Panel();
            this.panelSpells = new System.Windows.Forms.Panel();
            this.lblSpellsPanelTitle = new System.Windows.Forms.Label();
            this.tabQuests = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.panelCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightHand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftHand)).BeginInit();
            this.panelInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory1)).BeginInit();
            this.panelQuest.SuspendLayout();
            this.panelSpells.SuspendLayout();
            this.tabQuests.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.playerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1338, 24);
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
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveAndExitToolStripMenuItem
            // 
            this.saveAndExitToolStripMenuItem.Name = "saveAndExitToolStripMenuItem";
            this.saveAndExitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveAndExitToolStripMenuItem.Text = "Save and E&xit";
            this.saveAndExitToolStripMenuItem.Click += new System.EventHandler(this.SaveAndExit_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.saveAndLogoutToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.logoutToolStripMenuItem.Text = "&Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.Logout_Click);
            // 
            // saveAndLogoutToolStripMenuItem
            // 
            this.saveAndLogoutToolStripMenuItem.Name = "saveAndLogoutToolStripMenuItem";
            this.saveAndLogoutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.saveAndLogoutToolStripMenuItem.Text = "&Save And Logout";
            this.saveAndLogoutToolStripMenuItem.Click += new System.EventHandler(this.SaveAndLogout_Click);
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
            this.panelCharacter.Size = new System.Drawing.Size(254, 404);
            this.panelCharacter.TabIndex = 2;
            // 
            // txtInventoryGold
            // 
            this.txtInventoryGold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInventoryGold.Location = new System.Drawing.Point(158, 192);
            this.txtInventoryGold.Name = "txtInventoryGold";
            this.txtInventoryGold.ReadOnly = true;
            this.txtInventoryGold.Size = new System.Drawing.Size(54, 26);
            this.txtInventoryGold.TabIndex = 18;
            // 
            // picboxGold
            // 
            this.picboxGold.Image = global::Adventure.Properties.Resources.Item_Gold;
            this.picboxGold.InitialImage = null;
            this.picboxGold.Location = new System.Drawing.Point(162, 133);
            this.picboxGold.Name = "picboxGold";
            this.picboxGold.Size = new System.Drawing.Size(46, 48);
            this.picboxGold.TabIndex = 17;
            this.picboxGold.TabStop = false;
            // 
            // picRightHand
            // 
            this.picRightHand.Location = new System.Drawing.Point(133, 313);
            this.picRightHand.Name = "picRightHand";
            this.picRightHand.Size = new System.Drawing.Size(54, 69);
            this.picRightHand.TabIndex = 16;
            this.picRightHand.TabStop = false;
            // 
            // picLeftHand
            // 
            this.picLeftHand.Location = new System.Drawing.Point(62, 313);
            this.picLeftHand.Name = "picLeftHand";
            this.picLeftHand.Size = new System.Drawing.Size(54, 69);
            this.picLeftHand.TabIndex = 15;
            this.picLeftHand.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 40);
            this.label1.TabIndex = 14;
            this.label1.Text = "Right\r\nHand";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLeftHand
            // 
            this.lblLeftHand.AutoSize = true;
            this.lblLeftHand.Location = new System.Drawing.Point(65, 251);
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
            this.panelMagic.Size = new System.Drawing.Size(241, 24);
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
            this.panelHP.Size = new System.Drawing.Size(241, 24);
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
            // panelInventory
            // 
            this.panelInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInventory.Controls.Add(this.btnManageInventory);
            this.panelInventory.Controls.Add(this.picboxInventory8);
            this.panelInventory.Controls.Add(this.picboxInventory7);
            this.panelInventory.Controls.Add(this.picboxInventory6);
            this.panelInventory.Controls.Add(this.picboxInventory5);
            this.panelInventory.Controls.Add(this.picboxInventory4);
            this.panelInventory.Controls.Add(this.picboxInventory3);
            this.panelInventory.Controls.Add(this.picboxInventory2);
            this.panelInventory.Controls.Add(this.picboxInventory1);
            this.panelInventory.Controls.Add(this.lblInventoryPanelTitle);
            this.panelInventory.Location = new System.Drawing.Point(1073, 27);
            this.panelInventory.Name = "panelInventory";
            this.panelInventory.Size = new System.Drawing.Size(253, 348);
            this.panelInventory.TabIndex = 4;
            // 
            // btnManageInventory
            // 
            this.btnManageInventory.Location = new System.Drawing.Point(86, 301);
            this.btnManageInventory.Name = "btnManageInventory";
            this.btnManageInventory.Size = new System.Drawing.Size(75, 33);
            this.btnManageInventory.TabIndex = 9;
            this.btnManageInventory.Text = "Manage";
            this.btnManageInventory.UseVisualStyleBackColor = true;
            this.btnManageInventory.Click += new System.EventHandler(this.BtnManageInventory_Click);
            // 
            // picboxInventory8
            // 
            this.picboxInventory8.Location = new System.Drawing.Point(155, 240);
            this.picboxInventory8.Name = "picboxInventory8";
            this.picboxInventory8.Size = new System.Drawing.Size(49, 46);
            this.picboxInventory8.TabIndex = 8;
            this.picboxInventory8.TabStop = false;
            // 
            // picboxInventory7
            // 
            this.picboxInventory7.Location = new System.Drawing.Point(51, 240);
            this.picboxInventory7.Name = "picboxInventory7";
            this.picboxInventory7.Size = new System.Drawing.Size(49, 46);
            this.picboxInventory7.TabIndex = 7;
            this.picboxInventory7.TabStop = false;
            // 
            // picboxInventory6
            // 
            this.picboxInventory6.Location = new System.Drawing.Point(155, 172);
            this.picboxInventory6.Name = "picboxInventory6";
            this.picboxInventory6.Size = new System.Drawing.Size(49, 46);
            this.picboxInventory6.TabIndex = 6;
            this.picboxInventory6.TabStop = false;
            // 
            // picboxInventory5
            // 
            this.picboxInventory5.Location = new System.Drawing.Point(51, 172);
            this.picboxInventory5.Name = "picboxInventory5";
            this.picboxInventory5.Size = new System.Drawing.Size(49, 46);
            this.picboxInventory5.TabIndex = 5;
            this.picboxInventory5.TabStop = false;
            // 
            // picboxInventory4
            // 
            this.picboxInventory4.Location = new System.Drawing.Point(155, 104);
            this.picboxInventory4.Name = "picboxInventory4";
            this.picboxInventory4.Size = new System.Drawing.Size(49, 46);
            this.picboxInventory4.TabIndex = 4;
            this.picboxInventory4.TabStop = false;
            // 
            // picboxInventory3
            // 
            this.picboxInventory3.Location = new System.Drawing.Point(51, 104);
            this.picboxInventory3.Name = "picboxInventory3";
            this.picboxInventory3.Size = new System.Drawing.Size(49, 46);
            this.picboxInventory3.TabIndex = 3;
            this.picboxInventory3.TabStop = false;
            // 
            // picboxInventory2
            // 
            this.picboxInventory2.Location = new System.Drawing.Point(155, 39);
            this.picboxInventory2.Name = "picboxInventory2";
            this.picboxInventory2.Size = new System.Drawing.Size(49, 46);
            this.picboxInventory2.TabIndex = 2;
            this.picboxInventory2.TabStop = false;
            // 
            // picboxInventory1
            // 
            this.picboxInventory1.Location = new System.Drawing.Point(51, 39);
            this.picboxInventory1.Name = "picboxInventory1";
            this.picboxInventory1.Size = new System.Drawing.Size(49, 46);
            this.picboxInventory1.TabIndex = 1;
            this.picboxInventory1.TabStop = false;
            // 
            // lblInventoryPanelTitle
            // 
            this.lblInventoryPanelTitle.AutoSize = true;
            this.lblInventoryPanelTitle.Location = new System.Drawing.Point(86, 4);
            this.lblInventoryPanelTitle.Name = "lblInventoryPanelTitle";
            this.lblInventoryPanelTitle.Size = new System.Drawing.Size(74, 20);
            this.lblInventoryPanelTitle.TabIndex = 0;
            this.lblInventoryPanelTitle.Text = "Inventory";
            // 
            // panelQuest
            // 
            this.panelQuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQuest.Controls.Add(this.tabQuests);
            this.panelQuest.Controls.Add(this.lblQuestPanelTitle);
            this.panelQuest.Location = new System.Drawing.Point(1073, 381);
            this.panelQuest.Name = "panelQuest";
            this.panelQuest.Size = new System.Drawing.Size(253, 379);
            this.panelQuest.TabIndex = 5;
            // 
            // lblQuestPanelTitle
            // 
            this.lblQuestPanelTitle.AutoSize = true;
            this.lblQuestPanelTitle.Location = new System.Drawing.Point(93, 8);
            this.lblQuestPanelTitle.Name = "lblQuestPanelTitle";
            this.lblQuestPanelTitle.Size = new System.Drawing.Size(60, 20);
            this.lblQuestPanelTitle.TabIndex = 0;
            this.lblQuestPanelTitle.Text = "Quests";
            // 
            // panelGame
            // 
            this.panelGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGame.Location = new System.Drawing.Point(260, 27);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(807, 733);
            this.panelGame.TabIndex = 6;
            // 
            // panelSpells
            // 
            this.panelSpells.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSpells.Controls.Add(this.lblSpellsPanelTitle);
            this.panelSpells.Location = new System.Drawing.Point(0, 444);
            this.panelSpells.Name = "panelSpells";
            this.panelSpells.Size = new System.Drawing.Size(254, 316);
            this.panelSpells.TabIndex = 7;
            // 
            // lblSpellsPanelTitle
            // 
            this.lblSpellsPanelTitle.AutoSize = true;
            this.lblSpellsPanelTitle.Location = new System.Drawing.Point(101, 0);
            this.lblSpellsPanelTitle.Name = "lblSpellsPanelTitle";
            this.lblSpellsPanelTitle.Size = new System.Drawing.Size(52, 20);
            this.lblSpellsPanelTitle.TabIndex = 0;
            this.lblSpellsPanelTitle.Text = "Spells";
            // 
            // tabQuests
            // 
            this.tabQuests.Controls.Add(this.tabPage1);
            this.tabQuests.Controls.Add(this.tabPage2);
            this.tabQuests.Location = new System.Drawing.Point(4, 33);
            this.tabQuests.Name = "tabQuests";
            this.tabQuests.SelectedIndex = 0;
            this.tabQuests.Size = new System.Drawing.Size(236, 335);
            this.tabQuests.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(228, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 67);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 762);
            this.Controls.Add(this.panelSpells);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.panelQuest);
            this.Controls.Add(this.panelInventory);
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
            ((System.ComponentModel.ISupportInitialize)(this.picboxGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightHand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftHand)).EndInit();
            this.panelInventory.ResumeLayout(false);
            this.panelInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxInventory1)).EndInit();
            this.panelQuest.ResumeLayout(false);
            this.panelQuest.PerformLayout();
            this.panelSpells.ResumeLayout(false);
            this.panelSpells.PerformLayout();
            this.tabQuests.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panelInventory;
        private System.Windows.Forms.PictureBox picboxInventory8;
        private System.Windows.Forms.PictureBox picboxInventory7;
        private System.Windows.Forms.PictureBox picboxInventory6;
        private System.Windows.Forms.PictureBox picboxInventory5;
        private System.Windows.Forms.PictureBox picboxInventory4;
        private System.Windows.Forms.PictureBox picboxInventory3;
        private System.Windows.Forms.PictureBox picboxInventory2;
        private System.Windows.Forms.PictureBox picboxInventory1;
        private System.Windows.Forms.Label lblInventoryPanelTitle;
        private System.Windows.Forms.Panel panelQuest;
        private System.Windows.Forms.Label lblQuestPanelTitle;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Panel panelSpells;
        private System.Windows.Forms.Label lblSpellsPanelTitle;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAndLogoutToolStripMenuItem;
        private System.Windows.Forms.Button btnManageInventory;
        private System.Windows.Forms.TabControl tabQuests;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

