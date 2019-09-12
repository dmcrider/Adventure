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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblReward = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.txtGoldReward = new System.Windows.Forms.TextBox();
            this.txtRewardItem = new System.Windows.Forms.TextBox();
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
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(4, 24);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(218, 122);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Text = "This is the description of the quest. It won\'t be very long, but it could span a " +
    "few lines.";
            // 
            // lblReward
            // 
            this.lblReward.AutoSize = true;
            this.lblReward.Location = new System.Drawing.Point(3, 196);
            this.lblReward.Name = "lblReward";
            this.lblReward.Size = new System.Drawing.Size(68, 20);
            this.lblReward.TabIndex = 2;
            this.lblReward.Text = "Reward:";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(24, 164);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(47, 20);
            this.lblGold.TabIndex = 4;
            this.lblGold.Text = "Gold:";
            // 
            // txtGoldReward
            // 
            this.txtGoldReward.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGoldReward.Location = new System.Drawing.Point(77, 162);
            this.txtGoldReward.Name = "txtGoldReward";
            this.txtGoldReward.ReadOnly = true;
            this.txtGoldReward.Size = new System.Drawing.Size(54, 26);
            this.txtGoldReward.TabIndex = 19;
            // 
            // txtRewardItem
            // 
            this.txtRewardItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRewardItem.Location = new System.Drawing.Point(77, 190);
            this.txtRewardItem.Name = "txtRewardItem";
            this.txtRewardItem.ReadOnly = true;
            this.txtRewardItem.Size = new System.Drawing.Size(126, 26);
            this.txtRewardItem.TabIndex = 20;
            // 
            // ControlActiveQuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.txtRewardItem);
            this.Controls.Add(this.txtGoldReward);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblReward);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblQuestName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ControlActiveQuest";
            this.Size = new System.Drawing.Size(221, 227);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblReward;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.TextBox txtGoldReward;
        private System.Windows.Forms.TextBox txtRewardItem;
    }
}
