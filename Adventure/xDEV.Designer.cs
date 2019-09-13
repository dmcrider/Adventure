namespace Adventure
{
    partial class xDEV
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
            this.btnReduceHP = new System.Windows.Forms.Button();
            this.btnReduceMagic = new System.Windows.Forms.Button();
            this.btnNewQuest = new System.Windows.Forms.Button();
            this.btnOpenShop = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtDamage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReduceHP
            // 
            this.btnReduceHP.Location = new System.Drawing.Point(39, 73);
            this.btnReduceHP.Name = "btnReduceHP";
            this.btnReduceHP.Size = new System.Drawing.Size(129, 50);
            this.btnReduceHP.TabIndex = 0;
            this.btnReduceHP.Text = "Reduce HP";
            this.btnReduceHP.UseVisualStyleBackColor = true;
            this.btnReduceHP.Click += new System.EventHandler(this.BtnReduceHP_Click);
            // 
            // btnReduceMagic
            // 
            this.btnReduceMagic.Location = new System.Drawing.Point(233, 73);
            this.btnReduceMagic.Name = "btnReduceMagic";
            this.btnReduceMagic.Size = new System.Drawing.Size(129, 50);
            this.btnReduceMagic.TabIndex = 1;
            this.btnReduceMagic.Text = "Reduce Magic";
            this.btnReduceMagic.UseVisualStyleBackColor = true;
            this.btnReduceMagic.Click += new System.EventHandler(this.BtnReduceMagic_Click);
            // 
            // btnNewQuest
            // 
            this.btnNewQuest.Location = new System.Drawing.Point(427, 73);
            this.btnNewQuest.Name = "btnNewQuest";
            this.btnNewQuest.Size = new System.Drawing.Size(129, 50);
            this.btnNewQuest.TabIndex = 2;
            this.btnNewQuest.Text = "New Quest";
            this.btnNewQuest.UseVisualStyleBackColor = true;
            this.btnNewQuest.Click += new System.EventHandler(this.BtnNewQuest_Click);
            // 
            // btnOpenShop
            // 
            this.btnOpenShop.Location = new System.Drawing.Point(621, 73);
            this.btnOpenShop.Name = "btnOpenShop";
            this.btnOpenShop.Size = new System.Drawing.Size(129, 50);
            this.btnOpenShop.TabIndex = 3;
            this.btnOpenShop.Text = "Open Shop";
            this.btnOpenShop.UseVisualStyleBackColor = true;
            this.btnOpenShop.Click += new System.EventHandler(this.BtnOpenShop_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(39, 323);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(711, 364);
            this.txtOutput.TabIndex = 4;
            // 
            // txtDamage
            // 
            this.txtDamage.Location = new System.Drawing.Point(154, 153);
            this.txtDamage.Name = "txtDamage";
            this.txtDamage.Size = new System.Drawing.Size(100, 26);
            this.txtDamage.TabIndex = 5;
            this.txtDamage.Text = "10";
            // 
            // xDEV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDamage);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnOpenShop);
            this.Controls.Add(this.btnNewQuest);
            this.Controls.Add(this.btnReduceMagic);
            this.Controls.Add(this.btnReduceHP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "xDEV";
            this.Size = new System.Drawing.Size(807, 733);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReduceHP;
        private System.Windows.Forms.Button btnReduceMagic;
        private System.Windows.Forms.Button btnNewQuest;
        private System.Windows.Forms.Button btnOpenShop;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtDamage;
    }
}
