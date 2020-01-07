namespace Adventure
{
    partial class FormQuestDetail
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
            this.lblQuestName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblGoldValue = new System.Windows.Forms.Label();
            this.lblRewardValue = new System.Windows.Forms.Label();
            this.lblReward = new System.Windows.Forms.Label();
            this.btnMakeActive = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblEXPValue = new System.Windows.Forms.Label();
            this.lblEXP = new System.Windows.Forms.Label();
            this.btnReward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestName
            // 
            this.lblQuestName.AutoSize = true;
            this.lblQuestName.Location = new System.Drawing.Point(13, 13);
            this.lblQuestName.Name = "lblQuestName";
            this.lblQuestName.Size = new System.Drawing.Size(51, 20);
            this.lblQuestName.TabIndex = 0;
            this.lblQuestName.Text = "label1";
            // 
            // lblDescription
            // 
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.Location = new System.Drawing.Point(17, 49);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(361, 130);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "label1";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(65, 203);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(47, 20);
            this.lblGold.TabIndex = 2;
            this.lblGold.Text = "Gold:";
            // 
            // lblGoldValue
            // 
            this.lblGoldValue.AutoSize = true;
            this.lblGoldValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGoldValue.Location = new System.Drawing.Point(123, 203);
            this.lblGoldValue.Name = "lblGoldValue";
            this.lblGoldValue.Size = new System.Drawing.Size(53, 22);
            this.lblGoldValue.TabIndex = 3;
            this.lblGoldValue.Text = "label1";
            // 
            // lblRewardValue
            // 
            this.lblRewardValue.AutoSize = true;
            this.lblRewardValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRewardValue.Location = new System.Drawing.Point(123, 235);
            this.lblRewardValue.Name = "lblRewardValue";
            this.lblRewardValue.Size = new System.Drawing.Size(53, 22);
            this.lblRewardValue.TabIndex = 5;
            this.lblRewardValue.Text = "label1";
            // 
            // lblReward
            // 
            this.lblReward.AutoSize = true;
            this.lblReward.Location = new System.Drawing.Point(44, 235);
            this.lblReward.Name = "lblReward";
            this.lblReward.Size = new System.Drawing.Size(68, 20);
            this.lblReward.TabIndex = 4;
            this.lblReward.Text = "Reward:";
            // 
            // btnMakeActive
            // 
            this.btnMakeActive.Location = new System.Drawing.Point(17, 345);
            this.btnMakeActive.Name = "btnMakeActive";
            this.btnMakeActive.Size = new System.Drawing.Size(117, 34);
            this.btnMakeActive.TabIndex = 6;
            this.btnMakeActive.Text = "Make Active";
            this.btnMakeActive.UseVisualStyleBackColor = true;
            this.btnMakeActive.Click += new System.EventHandler(this.BtnMakeActive_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(257, 345);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 34);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblEXPValue
            // 
            this.lblEXPValue.AutoSize = true;
            this.lblEXPValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEXPValue.Location = new System.Drawing.Point(123, 267);
            this.lblEXPValue.Name = "lblEXPValue";
            this.lblEXPValue.Size = new System.Drawing.Size(53, 22);
            this.lblEXPValue.TabIndex = 9;
            this.lblEXPValue.Text = "label1";
            // 
            // lblEXP
            // 
            this.lblEXP.AutoSize = true;
            this.lblEXP.Location = new System.Drawing.Point(20, 267);
            this.lblEXP.Name = "lblEXP";
            this.lblEXP.Size = new System.Drawing.Size(92, 20);
            this.lblEXP.TabIndex = 8;
            this.lblEXP.Text = "Experience:";
            // 
            // btnReward
            // 
            this.btnReward.Location = new System.Drawing.Point(140, 345);
            this.btnReward.Name = "btnReward";
            this.btnReward.Size = new System.Drawing.Size(111, 34);
            this.btnReward.TabIndex = 10;
            this.btnReward.Text = "Complete";
            this.btnReward.UseVisualStyleBackColor = true;
            this.btnReward.Click += new System.EventHandler(this.BtnReward_Click);
            // 
            // FormQuestDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 391);
            this.Controls.Add(this.btnReward);
            this.Controls.Add(this.lblEXPValue);
            this.Controls.Add(this.lblEXP);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMakeActive);
            this.Controls.Add(this.lblRewardValue);
            this.Controls.Add(this.lblReward);
            this.Controls.Add(this.lblGoldValue);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblQuestName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuestDetail";
            this.Text = "Quest Detail";
            this.Load += new System.EventHandler(this.FormQuestDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblGoldValue;
        private System.Windows.Forms.Label lblRewardValue;
        private System.Windows.Forms.Label lblReward;
        private System.Windows.Forms.Button btnMakeActive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblEXPValue;
        private System.Windows.Forms.Label lblEXP;
        private System.Windows.Forms.Button btnReward;
    }
}