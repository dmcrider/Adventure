namespace Adventure
{
    partial class FormCharacterCreation
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
            this.grpRace = new System.Windows.Forms.GroupBox();
            this.radioRaceDwarf = new System.Windows.Forms.RadioButton();
            this.radioRaceElf = new System.Windows.Forms.RadioButton();
            this.radioRaceHuman = new System.Windows.Forms.RadioButton();
            this.lblSTR = new System.Windows.Forms.Label();
            this.lblINT = new System.Windows.Forms.Label();
            this.lblCON = new System.Windows.Forms.Label();
            this.txtSTR = new System.Windows.Forms.TextBox();
            this.txtINT = new System.Windows.Forms.TextBox();
            this.txtCON = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpEquipment = new System.Windows.Forms.GroupBox();
            this.txtEquipAdventureGold = new System.Windows.Forms.TextBox();
            this.txtEquipExplorerGold = new System.Windows.Forms.TextBox();
            this.picboxEquipAdventureGold = new System.Windows.Forms.PictureBox();
            this.picboxEquipExploreGold = new System.Windows.Forms.PictureBox();
            this.picboxEquipAdventureShield = new System.Windows.Forms.PictureBox();
            this.picboxEquipAdventureSword = new System.Windows.Forms.PictureBox();
            this.picboxEquipExplorerSword = new System.Windows.Forms.PictureBox();
            this.radioEquipAdventure = new System.Windows.Forms.RadioButton();
            this.radioEquipExplorer = new System.Windows.Forms.RadioButton();
            this.lblCharacterName = new System.Windows.Forms.Label();
            this.txtCharacterName = new System.Windows.Forms.TextBox();
            this.grpRace.SuspendLayout();
            this.grpEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipAdventureGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipExploreGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipAdventureShield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipAdventureSword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipExplorerSword)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRace
            // 
            this.grpRace.Controls.Add(this.radioRaceDwarf);
            this.grpRace.Controls.Add(this.radioRaceElf);
            this.grpRace.Controls.Add(this.radioRaceHuman);
            this.grpRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRace.Location = new System.Drawing.Point(13, 14);
            this.grpRace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRace.Name = "grpRace";
            this.grpRace.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpRace.Size = new System.Drawing.Size(150, 223);
            this.grpRace.TabIndex = 0;
            this.grpRace.TabStop = false;
            this.grpRace.Text = "Race";
            // 
            // radioRaceDwarf
            // 
            this.radioRaceDwarf.AutoSize = true;
            this.radioRaceDwarf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioRaceDwarf.Location = new System.Drawing.Point(26, 157);
            this.radioRaceDwarf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioRaceDwarf.Name = "radioRaceDwarf";
            this.radioRaceDwarf.Size = new System.Drawing.Size(69, 24);
            this.radioRaceDwarf.TabIndex = 2;
            this.radioRaceDwarf.TabStop = true;
            this.radioRaceDwarf.Tag = "3";
            this.radioRaceDwarf.Text = "Dwarf";
            this.radioRaceDwarf.UseVisualStyleBackColor = true;
            this.radioRaceDwarf.CheckedChanged += new System.EventHandler(this.RadioButtonRace_CheckedChanged);
            // 
            // radioRaceElf
            // 
            this.radioRaceElf.AutoSize = true;
            this.radioRaceElf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioRaceElf.Location = new System.Drawing.Point(26, 100);
            this.radioRaceElf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioRaceElf.Name = "radioRaceElf";
            this.radioRaceElf.Size = new System.Drawing.Size(46, 24);
            this.radioRaceElf.TabIndex = 1;
            this.radioRaceElf.TabStop = true;
            this.radioRaceElf.Tag = "2";
            this.radioRaceElf.Text = "Elf";
            this.radioRaceElf.UseVisualStyleBackColor = true;
            this.radioRaceElf.CheckedChanged += new System.EventHandler(this.RadioButtonRace_CheckedChanged);
            // 
            // radioRaceHuman
            // 
            this.radioRaceHuman.AutoSize = true;
            this.radioRaceHuman.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioRaceHuman.Location = new System.Drawing.Point(26, 49);
            this.radioRaceHuman.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioRaceHuman.Name = "radioRaceHuman";
            this.radioRaceHuman.Size = new System.Drawing.Size(79, 24);
            this.radioRaceHuman.TabIndex = 0;
            this.radioRaceHuman.TabStop = true;
            this.radioRaceHuman.Tag = "1";
            this.radioRaceHuman.Text = "Human";
            this.radioRaceHuman.UseVisualStyleBackColor = true;
            this.radioRaceHuman.CheckedChanged += new System.EventHandler(this.RadioButtonRace_CheckedChanged);
            // 
            // lblSTR
            // 
            this.lblSTR.AutoSize = true;
            this.lblSTR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTR.Location = new System.Drawing.Point(15, 272);
            this.lblSTR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSTR.Name = "lblSTR";
            this.lblSTR.Size = new System.Drawing.Size(41, 20);
            this.lblSTR.TabIndex = 1;
            this.lblSTR.Text = "STR";
            // 
            // lblINT
            // 
            this.lblINT.AutoSize = true;
            this.lblINT.Location = new System.Drawing.Point(22, 317);
            this.lblINT.Name = "lblINT";
            this.lblINT.Size = new System.Drawing.Size(34, 20);
            this.lblINT.TabIndex = 2;
            this.lblINT.Text = "INT";
            // 
            // lblCON
            // 
            this.lblCON.AutoSize = true;
            this.lblCON.Location = new System.Drawing.Point(13, 361);
            this.lblCON.Name = "lblCON";
            this.lblCON.Size = new System.Drawing.Size(43, 20);
            this.lblCON.TabIndex = 3;
            this.lblCON.Text = "CON";
            // 
            // txtSTR
            // 
            this.txtSTR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSTR.Enabled = false;
            this.txtSTR.Location = new System.Drawing.Point(63, 269);
            this.txtSTR.Name = "txtSTR";
            this.txtSTR.ReadOnly = true;
            this.txtSTR.Size = new System.Drawing.Size(100, 26);
            this.txtSTR.TabIndex = 4;
            // 
            // txtINT
            // 
            this.txtINT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtINT.Enabled = false;
            this.txtINT.Location = new System.Drawing.Point(64, 314);
            this.txtINT.Name = "txtINT";
            this.txtINT.ReadOnly = true;
            this.txtINT.Size = new System.Drawing.Size(100, 26);
            this.txtINT.TabIndex = 5;
            // 
            // txtCON
            // 
            this.txtCON.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCON.Enabled = false;
            this.txtCON.Location = new System.Drawing.Point(64, 358);
            this.txtCON.Name = "txtCON";
            this.txtCON.ReadOnly = true;
            this.txtCON.Size = new System.Drawing.Size(100, 26);
            this.txtCON.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(486, 417);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(164, 46);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // grpEquipment
            // 
            this.grpEquipment.Controls.Add(this.txtEquipAdventureGold);
            this.grpEquipment.Controls.Add(this.txtEquipExplorerGold);
            this.grpEquipment.Controls.Add(this.picboxEquipAdventureGold);
            this.grpEquipment.Controls.Add(this.picboxEquipExploreGold);
            this.grpEquipment.Controls.Add(this.picboxEquipAdventureShield);
            this.grpEquipment.Controls.Add(this.picboxEquipAdventureSword);
            this.grpEquipment.Controls.Add(this.picboxEquipExplorerSword);
            this.grpEquipment.Controls.Add(this.radioEquipAdventure);
            this.grpEquipment.Controls.Add(this.radioEquipExplorer);
            this.grpEquipment.Location = new System.Drawing.Point(217, 14);
            this.grpEquipment.Name = "grpEquipment";
            this.grpEquipment.Size = new System.Drawing.Size(433, 223);
            this.grpEquipment.TabIndex = 8;
            this.grpEquipment.TabStop = false;
            this.grpEquipment.Text = "Starting Equipment";
            // 
            // txtEquipAdventureGold
            // 
            this.txtEquipAdventureGold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEquipAdventureGold.Location = new System.Drawing.Point(323, 167);
            this.txtEquipAdventureGold.Name = "txtEquipAdventureGold";
            this.txtEquipAdventureGold.ReadOnly = true;
            this.txtEquipAdventureGold.Size = new System.Drawing.Size(42, 26);
            this.txtEquipAdventureGold.TabIndex = 8;
            // 
            // txtEquipExplorerGold
            // 
            this.txtEquipExplorerGold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEquipExplorerGold.Location = new System.Drawing.Point(75, 167);
            this.txtEquipExplorerGold.Name = "txtEquipExplorerGold";
            this.txtEquipExplorerGold.ReadOnly = true;
            this.txtEquipExplorerGold.Size = new System.Drawing.Size(42, 26);
            this.txtEquipExplorerGold.TabIndex = 7;
            // 
            // picboxEquipAdventureGold
            // 
            this.picboxEquipAdventureGold.InitialImage = global::Adventure.Properties.Resources.Item_Gold;
            this.picboxEquipAdventureGold.Location = new System.Drawing.Point(275, 157);
            this.picboxEquipAdventureGold.Name = "picboxEquipAdventureGold";
            this.picboxEquipAdventureGold.Size = new System.Drawing.Size(42, 36);
            this.picboxEquipAdventureGold.TabIndex = 6;
            this.picboxEquipAdventureGold.TabStop = false;
            // 
            // picboxEquipExploreGold
            // 
            this.picboxEquipExploreGold.InitialImage = global::Adventure.Properties.Resources.Item_Gold;
            this.picboxEquipExploreGold.Location = new System.Drawing.Point(27, 157);
            this.picboxEquipExploreGold.Name = "picboxEquipExploreGold";
            this.picboxEquipExploreGold.Size = new System.Drawing.Size(42, 36);
            this.picboxEquipExploreGold.TabIndex = 5;
            this.picboxEquipExploreGold.TabStop = false;
            // 
            // picboxEquipAdventureShield
            // 
            this.picboxEquipAdventureShield.InitialImage = global::Adventure.Properties.Resources.Item_Shield;
            this.picboxEquipAdventureShield.Location = new System.Drawing.Point(275, 79);
            this.picboxEquipAdventureShield.Name = "picboxEquipAdventureShield";
            this.picboxEquipAdventureShield.Size = new System.Drawing.Size(56, 51);
            this.picboxEquipAdventureShield.TabIndex = 4;
            this.picboxEquipAdventureShield.TabStop = false;
            // 
            // picboxEquipAdventureSword
            // 
            this.picboxEquipAdventureSword.InitialImage = global::Adventure.Properties.Resources.Item_ShortSword;
            this.picboxEquipAdventureSword.Location = new System.Drawing.Point(351, 79);
            this.picboxEquipAdventureSword.Name = "picboxEquipAdventureSword";
            this.picboxEquipAdventureSword.Size = new System.Drawing.Size(56, 51);
            this.picboxEquipAdventureSword.TabIndex = 3;
            this.picboxEquipAdventureSword.TabStop = false;
            // 
            // picboxEquipExplorerSword
            // 
            this.picboxEquipExplorerSword.InitialImage = global::Adventure.Properties.Resources.Item_ShortSword;
            this.picboxEquipExplorerSword.Location = new System.Drawing.Point(27, 79);
            this.picboxEquipExplorerSword.Name = "picboxEquipExplorerSword";
            this.picboxEquipExplorerSword.Size = new System.Drawing.Size(56, 51);
            this.picboxEquipExplorerSword.TabIndex = 2;
            this.picboxEquipExplorerSword.TabStop = false;
            // 
            // radioEquipAdventure
            // 
            this.radioEquipAdventure.AutoSize = true;
            this.radioEquipAdventure.Location = new System.Drawing.Point(252, 49);
            this.radioEquipAdventure.Name = "radioEquipAdventure";
            this.radioEquipAdventure.Size = new System.Drawing.Size(155, 24);
            this.radioEquipAdventure.TabIndex = 1;
            this.radioEquipAdventure.TabStop = true;
            this.radioEquipAdventure.Tag = "adventurer";
            this.radioEquipAdventure.Text = "Adventurer\'s Pack";
            this.radioEquipAdventure.UseVisualStyleBackColor = true;
            this.radioEquipAdventure.CheckedChanged += new System.EventHandler(this.RadioButtonEquipment_CheckedChanged);
            // 
            // radioEquipExplorer
            // 
            this.radioEquipExplorer.AutoSize = true;
            this.radioEquipExplorer.Location = new System.Drawing.Point(6, 49);
            this.radioEquipExplorer.Name = "radioEquipExplorer";
            this.radioEquipExplorer.Size = new System.Drawing.Size(135, 24);
            this.radioEquipExplorer.TabIndex = 0;
            this.radioEquipExplorer.TabStop = true;
            this.radioEquipExplorer.Tag = "explorer";
            this.radioEquipExplorer.Text = "Explorer\'s Pack";
            this.radioEquipExplorer.UseVisualStyleBackColor = true;
            this.radioEquipExplorer.CheckedChanged += new System.EventHandler(this.RadioButtonEquipment_CheckedChanged);
            // 
            // lblCharacterName
            // 
            this.lblCharacterName.AutoSize = true;
            this.lblCharacterName.Location = new System.Drawing.Point(223, 269);
            this.lblCharacterName.Name = "lblCharacterName";
            this.lblCharacterName.Size = new System.Drawing.Size(140, 20);
            this.lblCharacterName.TabIndex = 9;
            this.lblCharacterName.Text = "Character\'s Name:";
            // 
            // txtCharacterName
            // 
            this.txtCharacterName.Location = new System.Drawing.Point(378, 266);
            this.txtCharacterName.MaxLength = 25;
            this.txtCharacterName.Name = "txtCharacterName";
            this.txtCharacterName.Size = new System.Drawing.Size(246, 26);
            this.txtCharacterName.TabIndex = 10;
            // 
            // FormCharacterCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 475);
            this.Controls.Add(this.txtCharacterName);
            this.Controls.Add(this.lblCharacterName);
            this.Controls.Add(this.grpEquipment);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCON);
            this.Controls.Add(this.txtINT);
            this.Controls.Add(this.txtSTR);
            this.Controls.Add(this.lblCON);
            this.Controls.Add(this.lblINT);
            this.Controls.Add(this.lblSTR);
            this.Controls.Add(this.grpRace);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCharacterCreation";
            this.Text = "Character Creation";
            this.Load += new System.EventHandler(this.FormCharacterCreation_Load);
            this.grpRace.ResumeLayout(false);
            this.grpRace.PerformLayout();
            this.grpEquipment.ResumeLayout(false);
            this.grpEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipAdventureGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipExploreGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipAdventureShield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipAdventureSword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEquipExplorerSword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpRace;
        private System.Windows.Forms.RadioButton radioRaceDwarf;
        private System.Windows.Forms.RadioButton radioRaceElf;
        private System.Windows.Forms.RadioButton radioRaceHuman;
        private System.Windows.Forms.Label lblSTR;
        private System.Windows.Forms.Label lblINT;
        private System.Windows.Forms.Label lblCON;
        private System.Windows.Forms.TextBox txtSTR;
        private System.Windows.Forms.TextBox txtINT;
        private System.Windows.Forms.TextBox txtCON;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpEquipment;
        private System.Windows.Forms.PictureBox picboxEquipAdventureShield;
        private System.Windows.Forms.PictureBox picboxEquipAdventureSword;
        private System.Windows.Forms.PictureBox picboxEquipExplorerSword;
        private System.Windows.Forms.RadioButton radioEquipAdventure;
        private System.Windows.Forms.RadioButton radioEquipExplorer;
        private System.Windows.Forms.PictureBox picboxEquipAdventureGold;
        private System.Windows.Forms.PictureBox picboxEquipExploreGold;
        private System.Windows.Forms.TextBox txtEquipAdventureGold;
        private System.Windows.Forms.TextBox txtEquipExplorerGold;
        private System.Windows.Forms.Label lblCharacterName;
        private System.Windows.Forms.TextBox txtCharacterName;
    }
}