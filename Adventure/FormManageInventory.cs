using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class FormManageInventory : Form
    {
        private Player player;
        private List<Inventory> inventory;
        private CheckBox[] chkArray;
        private PictureBox[] picArray;
        private GroupBox[] grpArray;

        private List<int> selectedItems;
        private int selectedHand = 0;

        public FormManageInventory(ref Player p)
        {
            InitializeComponent();
            player = p;
            inventory = API.LoadInventory(player.character.UniqueID);

            chkArray = new CheckBox[]{ chkbxItem1, chkbxItem2, chkbxItem3, chkbxItem4, chkbxItem5, chkbxItem6, chkbxItem7, chkbxItem8, chkbxItem9, chkbxItem10 };
            picArray = new PictureBox[]{ picboxItem1, picboxItem2, picboxItem3, picboxItem4, picboxItem5, picboxItem6, picboxItem7, picboxItem8, picboxItem9, picboxItem10 };
            grpArray = new GroupBox[]{ grpItem1, grpItem2, grpItem3, grpItem4, grpItem5, grpItem6, grpItem7, grpItem8, grpItem9, grpItem10 };

            selectedItems = new List<int>();
        }

        private void FormManageInventory_Load(object sender, EventArgs e)
        {
            // Hide everything
            for(int i = 0; i < 10; i++)
            {
                chkArray[i].Visible = false;
                picArray[i].Visible = false;
                grpArray[i].Visible = false;
            }

            // Show as many items as they have
            if (inventory.Count() > 0)
            {
                int currentItem = 0;
                Item tempItem = new Item();
                foreach(Inventory inv in inventory)
                {
                    foreach(Item item in API.itemsList)
                    {
                        if(item.UniqueID == inv.ItemID)
                        {
                            tempItem = item;
                            break;
                        }
                    }
                    // Set Tag value
                    chkArray[currentItem].Tag = tempItem.UniqueID;
                    // Set Image
                    picArray[currentItem].Image = (Image)Properties.Resources.ResourceManager.GetObject("Item_" + tempItem.AssetName);
                    picArray[currentItem].Refresh();
                    // Set Item name
                    grpArray[currentItem].Text = tempItem.DisplayName;

                    // Display it
                    chkArray[currentItem].Visible = true;
                    picArray[currentItem].Visible = true;
                    grpArray[currentItem].Visible = true;

                    currentItem++;
                }
            }

            // Disable options to use/hold items
            grpHand.Enabled = false;
            btnUse.Enabled = false;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox tempbox = (CheckBox)sender;

                if (tempbox.Checked)
                {
                    // Add the item to the array
                    string tag = tempbox.Tag.ToString();
                    selectedItems.Add(int.Parse(tag));

                    // Enable appropriate buttons, if applicable
                    Item tempItem = API.itemsList.Find(x => x.UniqueID == int.Parse(tag));

                    // Enable the "use" button for potions
                    if(tempItem.HpHealed > 0 || tempItem.MagicHealed > 0)
                    {
                        // Can only use 1 item at a time
                        if (btnUse.Enabled)
                        {
                            btnUse.Enabled = false;
                        }
                        else
                        {
                            btnUse.Enabled = true;
                        }
                    }
                    else
                    {
                        btnUse.Enabled = false;
                    }

                    //Enable the "hold" options for weapons and shields
                    // Set the hand, if it's held
                    if(tempItem.AttackBonus > 0 || tempItem.DefenseBonus > 0)
                    {
                        // Can only change 1 item at a time
                        if (grpHand.Enabled)
                        {
                            grpHand.Enabled = false;
                        }
                        else
                        {
                            grpHand.Enabled = true;
                            Inventory tempInv = inventory.Find(x => x.ItemID == tempItem.UniqueID);

                            if (tempInv.IsUsing == 1)
                            {
                                if(tempInv.Hand == 1)
                                {
                                    // Left Hand
                                    radioHandLeft.Checked = true;
                                    selectedHand = tempInv.Hand;
                                }
                                else if(tempInv.Hand == 2)
                                {
                                    // Right
                                    radioHandRight.Checked = true;
                                    selectedHand = tempInv.Hand;
                                }
                            }
                        }
                    }
                    else
                    {
                        grpHand.Enabled = false;
                    }
                }
                else if (!tempbox.Checked)
                {
                    // Remove the item from the array
                    string tag = tempbox.Tag.ToString();
                    foreach(int item in selectedItems.ToArray())
                    {
                        if(item == int.Parse(tag))
                        {
                            selectedItems.Remove(int.Parse(tag));
                            selectedHand = 0;
                        }
                    }

                    // Disable any enabled options
                    if (btnUse.Enabled)
                    {
                        btnUse.Enabled = false;
                    }

                    if (grpHand.Enabled)
                    {
                        grpHand.Enabled = false;
                    }
                }
            }
            catch(Exception ex)
            {
                LogWriter.Write("FormManageInventory.CheckBox_CheckedChanged() | Something that wasn't a CheckBox called this function: " + ex);
            }
        }

        private void CheckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox tempbox = (CheckBox)sender;
                if (tempbox.Checked)
                {
                    // Check all visible boxes
                    foreach(CheckBox box in chkArray)
                    {
                        if (box.Visible)
                        {
                            box.Checked = true;
                        }
                    }

                    // Disable options to use/hold items
                    grpHand.Enabled = false;
                    btnUse.Enabled = false;
                }
                else if (!tempbox.Checked)
                {
                    foreach(CheckBox box in chkArray)
                    {
                        if (box.Visible)
                        {
                            box.Checked = false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogWriter.Write("FormManageInventory.CheckBoxSelectAll_CheckedChanged() | Something that wasn't a CheckBox called this function: " + ex);
            }
        }

        private void RadioButtonHand_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton tempBtn = (RadioButton)sender;

                if (tempBtn.Checked)
                {
                    // Set the selected hand
                    selectedHand = int.Parse(tempBtn.Tag.ToString());
                }
                else
                {
                    selectedHand = 0;
                }
            }
            catch(Exception ex)
            {
                LogWriter.Write("FormManageInventory.RadioButtonHand_CheckedChanged() | Something went wrong: " + ex);
            }
        }

        private int Heal(int current, int max, int healAmount)
        {
            current += healAmount;

            if(current > max)
            {
                return max;
            }
            else
            {
                return current;
            }
        }

        private void BtnUse_Click(object sender, EventArgs e)
        {
            if(selectedItems.Count() == 1)
            {
                try
                {
                    int itemUniqueID = selectedItems.ElementAt(0);

                    Item tempItem = API.itemsList.Find(x => x.UniqueID == itemUniqueID);
                    Inventory invItem = inventory.Find(y => y.ItemID == itemUniqueID);

                    if (tempItem.HpHealed > 0 && invItem.Quantity > 0)
                    {
                        player.character.CurrentHP = Heal(player.character.CurrentHP, player.character.MaxHP, tempItem.HpHealed);
                        invItem.Quantity--;
                    }

                    if (tempItem.MagicHealed > 0 && invItem.Quantity > 0)
                    {
                        player.character.CurrentMagic = Heal(player.character.CurrentMagic, player.character.MaxMagic, tempItem.MagicHealed);
                        invItem.Quantity--;
                    }

                    // Remove the item from their inventory if they've used the last one
                    if(invItem.Quantity <= 0)
                    {
                        invItem.IsActive = 0;
                    }
                }
                catch(Exception ex)
                {
                    LogWriter.Write("FormManageInventory.BtnUse_Click() | There was an error healing: " + ex);
                }
            }
            else if(selectedItems.Count() > 1)
            {
                LogWriter.Write("FormManageInventory.BtnUse_Click() | More than one item is selected");
            }
            else if(selectedItems.Count() == 0)
            {
                LogWriter.Write("FormManageInventory.BtnUse_Click() | No items were selected");
            }
        }

        private void BtnHold_Click(object sender, EventArgs e)
        {
            try
            {
                if(selectedHand != 0)
                {
                    Inventory selectedInv = inventory.Find(x => x.ItemID == selectedItems[0]);
                    selectedInv.IsUsing = 1;
                    selectedInv.Hand = selectedHand;
                }
                else
                {
                    LogWriter.Write("FormManageInventory.BtnHold_Click() | No hand was selected");
                }
            }
            catch(Exception ex)
            {
                LogWriter.Write("FormManageInventory.BtnHold_Click() | Something went wrong: " + ex);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool updateSuccess = API.UpdateInventory(player.character.UniqueID, inventory);

                if (updateSuccess)
                {
                    MessageBox.Show("Your inventory was successfully updated.","Inventory Update Success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update inventory. Please try again later.", "Inventory Update Failed");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                LogWriter.Write("FormManageInventory.BtnSave_Click() | Something went wrong: " + ex);
            }
        }
    }
}
