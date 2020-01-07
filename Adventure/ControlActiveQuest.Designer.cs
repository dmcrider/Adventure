namespace Adventure
{
    partial class ControlActiveQuest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblQuestName = new System.Windows.Forms.Label();
            this.lblReward = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblGoldReward = new System.Windows.Forms.Label();
            this.lblRewardItem = new System.Windows.Forms.Label();
            this.lblEXPValue = new System.Windows.Forms.Label();
            this.lblEXP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQuestName
            // 
            this.lblQuestName.AutoSize = true;
            this.lblQuestName.Location = new System.Drawing.Point(3, 0);
            this.lblQuestName.Name = "lblQuestName";
            this.lblQuestName.Size = new System.Drawing.Size(94, 20);
            this.lblQuestName.TabIndex = 0;
            this.lblQuestName.Text = "QuestName";
            // 
            // lblReward
            // 
            this.lblReward.AutoSize = true;
            this.lblReward.Location = new System.Drawing.Point(3, 209);
            this.lblReward.Name = "lblReward";
            this.lblReward.Size = new System.Drawing.Size(68, 20);
            this.lblReward.TabIndex = 2;
            this.lblReward.Text = "Reward:";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(3, 164);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(47, 20);
            this.lblGold.TabIndex = 4;
            this.lblGold.Text = "Gold:";
            // 
            // lblDescription
            // 
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.Location = new System.Drawing.Point(7, 33);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(273, 116);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "This is the text description of the quest. Hopefully it provides enough detail.";
            // 
            // lblGoldReward
            // 
            this.lblGoldReward.AutoSize = true;
            this.lblGoldReward.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGoldReward.Location = new System.Drawing.Point(56, 162);
            this.lblGoldReward.Name = "lblGoldReward";
            this.lblGoldReward.Size = new System.Drawing.Size(65, 22);
            this.lblGoldReward.TabIndex = 22;
            this.lblGoldReward.Text = "999999";
            // 
            // lblRewardItem
            // 
            this.lblRewardItem.AutoSize = true;
            this.lblRewardItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRewardItem.Location = new System.Drawing.Point(77, 207);
            this.lblRewardItem.Name = "lblRewardItem";
            this.lblRewardItem.Size = new System.Drawing.Size(77, 22);
            this.lblRewardItem.TabIndex = 23;
            this.lblRewardItem.Text = "+2 Shield";
            // 
            // lblEXPValue
            // 
            this.lblEXPValue.AutoSize = true;
            this.lblEXPValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEXPValue.Location = new System.Drawing.Point(215, 162);
            this.lblEXPValue.Name = "lblEXPValue";
            this.lblEXPValue.Size = new System.Drawing.Size(65, 22);
            this.lblEXPValue.TabIndex = 25;
            this.lblEXPValue.Text = "999999";
            // 
            // lblEXP
            // 
            this.lblEXP.AutoSize = true;
            this.lblEXP.Location = new System.Drawing.Point(169, 164);
            this.lblEXP.Name = "lblEXP";
            this.lblEXP.Size = new System.Drawing.Size(40, 20);
            this.lblEXP.TabIndex = 24;
            this.lblEXP.Text = "Exp:";
            // 
            // ControlActiveQuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblEXPValue);
            this.Controls.Add(this.lblEXP);
            this.Controls.Add(this.lblRewardItem);
            this.Controls.Add(this.lblGoldReward);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblReward);
            this.Controls.Add(this.lblQuestName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ControlActiveQuest";
            this.Size = new System.Drawing.Size(303, 256);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestName;
        private System.Windows.Forms.Label lblReward;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblGoldReward;
        private System.Windows.Forms.Label lblRewardItem;
        private System.Windows.Forms.Label lblEXPValue;
        private System.Windows.Forms.Label lblEXP;
    }
}
