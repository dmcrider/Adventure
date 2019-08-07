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
                        }
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
                    foreach(CheckBox box in chkArray)
                    {
                        if (box.Visible)
                        {
                            box.Checked = true;
                        }
                    }
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
    }
}
