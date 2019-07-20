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
            this.radioRaceHuman = new System.Windows.Forms.RadioButton();
            this.radioRaceElf = new System.Windows.Forms.RadioButton();
            this.radioRaceDwarf = new System.Windows.Forms.RadioButton();
            this.lblSTR = new System.Windows.Forms.Label();
            this.lblINT = new System.Windows.Forms.Label();
            this.lblCON = new System.Windows.Forms.Label();
            this.txtSTR = new System.Windows.Forms.TextBox();
            this.txtINT = new System.Windows.Forms.TextBox();
            this.txtCON = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpRace.SuspendLayout();
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
            this.radioRaceHuman.Text = "Human";
            this.radioRaceHuman.UseVisualStyleBackColor = true;
            this.radioRaceHuman.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
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
            this.radioRaceElf.Text = "Elf";
            this.radioRaceElf.UseVisualStyleBackColor = true;
            this.radioRaceElf.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
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
            this.radioRaceDwarf.Text = "Dwarf";
            this.radioRaceDwarf.UseVisualStyleBackColor = true;
            this.radioRaceDwarf.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
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
            this.txtSTR.Enabled = false;
            this.txtSTR.Location = new System.Drawing.Point(63, 269);
            this.txtSTR.Name = "txtSTR";
            this.txtSTR.Size = new System.Drawing.Size(100, 26);
            this.txtSTR.TabIndex = 4;
            // 
            // txtINT
            // 
            this.txtINT.Enabled = false;
            this.txtINT.Location = new System.Drawing.Point(64, 314);
            this.txtINT.Name = "txtINT";
            this.txtINT.Size = new System.Drawing.Size(100, 26);
            this.txtINT.TabIndex = 5;
            // 
            // txtCON
            // 
            this.txtCON.Enabled = false;
            this.txtCON.Location = new System.Drawing.Point(64, 358);
            this.txtCON.Name = "txtCON";
            this.txtCON.Size = new System.Drawing.Size(100, 26);
            this.txtCON.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(63, 417);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 46);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FormCharacterCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 475);
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
    }
}