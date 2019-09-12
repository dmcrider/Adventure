namespace Adventure
{
    partial class FormShop
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
            this.listViewPlayer = new System.Windows.Forms.ListView();
            this.listViewShop = new System.Windows.Forms.ListView();
            this.lblPlayerInventory = new System.Windows.Forms.Label();
            this.labelShopInventory = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picboxGold = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtGoldPlayer = new System.Windows.Forms.TextBox();
            this.txtGoldShop = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewPlayer
            // 
            this.listViewPlayer.HideSelection = false;
            this.listViewPlayer.Location = new System.Drawing.Point(40, 81);
            this.listViewPlayer.MultiSelect = false;
            this.listViewPlayer.Name = "listViewPlayer";
            this.listViewPlayer.Size = new System.Drawing.Size(273, 461);
            this.listViewPlayer.TabIndex = 0;
            this.listViewPlayer.UseCompatibleStateImageBehavior = false;
            this.listViewPlayer.View = System.Windows.Forms.View.Details;
            this.listViewPlayer.SelectedIndexChanged += new System.EventHandler(this.Inventory_SelectedIndexChanged);
            // 
            // listViewShop
            // 
            this.listViewShop.HideSelection = false;
            this.listViewShop.Location = new System.Drawing.Point(545, 81);
            this.listViewShop.MultiSelect = false;
            this.listViewShop.Name = "listViewShop";
            this.listViewShop.Size = new System.Drawing.Size(273, 461);
            this.listViewShop.TabIndex = 1;
            this.listViewShop.UseCompatibleStateImageBehavior = false;
            this.listViewShop.View = System.Windows.Forms.View.Details;
            this.listViewShop.SelectedIndexChanged += new System.EventHandler(this.Inventory_SelectedIndexChanged);
            // 
            // lblPlayerInventory
            // 
            this.lblPlayerInventory.AutoSize = true;
            this.lblPlayerInventory.Location = new System.Drawing.Point(127, 58);
            this.lblPlayerInventory.Name = "lblPlayerInventory";
            this.lblPlayerInventory.Size = new System.Drawing.Size(98, 20);
            this.lblPlayerInventory.TabIndex = 2;
            this.lblPlayerInventory.Text = "My Inventory";
            // 
            // labelShopInventory
            // 
            this.labelShopInventory.AutoSize = true;
            this.labelShopInventory.Location = new System.Drawing.Point(623, 58);
            this.labelShopInventory.Name = "labelShopInventory";
            this.labelShopInventory.Size = new System.Drawing.Size(116, 20);
            this.labelShopInventory.TabIndex = 3;
            this.labelShopInventory.Text = "Shop Inventory";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(109, 12);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(135, 30);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "&Sell Selected";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.BtnSell_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(614, 12);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(135, 30);
            this.btnBuy.TabIndex = 5;
            this.btnBuy.Text = "&Buy Selected";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.BtnBuy_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(373, 594);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // picboxGold
            // 
            this.picboxGold.Image = global::Adventure.Properties.Resources.Item_Gold;
            this.picboxGold.InitialImage = null;
            this.picboxGold.Location = new System.Drawing.Point(75, 585);
            this.picboxGold.Name = "picboxGold";
            this.picboxGold.Size = new System.Drawing.Size(46, 48);
            this.picboxGold.TabIndex = 18;
            this.picboxGold.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Adventure.Properties.Resources.Item_Gold;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(597, 585);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 48);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // txtGoldPlayer
            // 
            this.txtGoldPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGoldPlayer.Location = new System.Drawing.Point(143, 596);
            this.txtGoldPlayer.Name = "txtGoldPlayer";
            this.txtGoldPlayer.ReadOnly = true;
            this.txtGoldPlayer.Size = new System.Drawing.Size(82, 26);
            this.txtGoldPlayer.TabIndex = 20;
            // 
            // txtGoldShop
            // 
            this.txtGoldShop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGoldShop.Location = new System.Drawing.Point(669, 596);
            this.txtGoldShop.Name = "txtGoldShop";
            this.txtGoldShop.ReadOnly = true;
            this.txtGoldShop.Size = new System.Drawing.Size(82, 26);
            this.txtGoldShop.TabIndex = 21;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(418, 153);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(44, 20);
            this.lblValue.TabIndex = 22;
            this.lblValue.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Location = new System.Drawing.Point(399, 176);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(82, 26);
            this.txtTotal.TabIndex = 23;
            // 
            // FormShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 714);
            this.ControlBox = false;
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.txtGoldShop);
            this.Controls.Add(this.txtGoldPlayer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picboxGold);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.labelShopInventory);
            this.Controls.Add(this.lblPlayerInventory);
            this.Controls.Add(this.listViewShop);
            this.Controls.Add(this.listViewPlayer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormShop";
            this.Text = "Trading Post";
            this.Load += new System.EventHandler(this.FormShop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewPlayer;
        private System.Windows.Forms.ListView listViewShop;
        private System.Windows.Forms.Label lblPlayerInventory;
        private System.Windows.Forms.Label labelShopInventory;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picboxGold;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtGoldPlayer;
        private System.Windows.Forms.TextBox txtGoldShop;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtTotal;
    }
}