using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class FormShop : Form
    {
        private Character character;
        private int total = 0;

        public FormShop(Character c)
        {
            InitializeComponent();
            character = c;
        }

        private void FormShop_Load(object sender, EventArgs e)
        {
            LoadPlayerList();
            LoadShopList();
            SetGold();
            txtTotal.Text = total.ToString();
        }

        /// <summary>
        /// Display the gold on hand for the player and the shop
        /// </summary>
        private void SetGold()
        {
            txtGoldPlayer.Text = character.GetGold();
            txtGoldShop.Text = GameController.SHOP_GOLD;
        }

        /// <summary>
        /// Loads the Player's inventory
        /// </summary>
        private void LoadPlayerList()
        {
            LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Loading Player Inventory");
            // Set the columns
            listViewPlayer.Columns.Add("Item Name");
            listViewPlayer.Columns.Add("Value");
            listViewPlayer.Columns.Add("ItemID").Width = 0;
            try
            {
                // Set the lists to be shown for the player's inventory
                foreach (var item in character.Inventory)
                {
                    Item tempItem = API.itemsList.Find(x => x.UniqueID == item.ItemID);

                    // Make sure we can sell it and it's a valid item
                    if (tempItem.CanBuySell == 1 && tempItem.Active == 1)
                    {
                        listViewPlayer.Items.Add(tempItem.ShopDetails(GameController.PLAYER));
                    }
                }
            }
            catch(Exception ex)
            {
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Error loading player inventory: " + ex);
            }
        }

        /// <summary>
        /// Loads the shop's inventory
        /// </summary>
        private void LoadShopList()
        {
            LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Loading Shop Inventory");
            // Set the columns
            listViewShop.Columns.Add("Item Name");
            listViewShop.Columns.Add("Price");
            listViewPlayer.Columns.Add("ItemID").Width = 0;
            try
            {
                // Set the lists to be shown from all available items
                foreach (Item item in API.itemsList)
                {
                    // Make sure we can sell it, it's a valid item, and the character is the right level
                    if (item.CanBuySell == 1 && item.Active == 1 && item.MinPlayerLevel <= character.Level)
                    {
                        listViewPlayer.Items.Add(item.ShopDetails(GameController.SHOP));
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Error loading shop inventory: " + ex);
            }
        }

        /// <summary>
        /// Cancel the transaction and close the window
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Move an item from the shop to the player
        /// </summary>
        private void BtnBuy_Click(object sender, EventArgs e)
        {
            if (BeginTransaction(GameController.PLAYER))
            {
                try
                {
                    // Get a reference to the item
                    Item tempItem = API.itemsList.Find(x => x.UniqueID == int.Parse(listViewShop.SelectedItems[0].SubItems[2].Text));

                    // Remove it from the shop
                    listViewShop.Items.RemoveByKey(tempItem.DisplayName);

                    // Take the gold from the player
                    character.Gold -= total;

                    // Add gold to the shop
                    int shopGold = int.Parse(txtGoldShop.Text);
                    shopGold += total;
                    txtGoldShop.Text = shopGold.ToString();

                    // Add the item to the player's inventory
                    API.AddInventoryItem(character, tempItem.UniqueID);

                    // Show the item in the list
                    LoadPlayerList();

                    // Log the transaction
                    LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, $"Player bought Item#{tempItem.UniqueID} - {tempItem.DisplayName} from shop for {total}");

                    // Reset the total
                    total = 0;
                    txtTotal.Text = "0";
                }
                catch(Exception ex)
                {
                    LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Error purchasing from shop: " + ex);
                    MessageBox.Show("There was an error purchasing your items. Please try again later.", "Error Buying");
                }
            }
        }

        /// <summary>
        /// Move an item from the player to the shop
        /// </summary>
        private void BtnSell_Click(object sender, EventArgs e)
        {
            if (BeginTransaction(GameController.SHOP))
            {
                try
                {
                    // Get a reference to the item
                    Item tempItem = API.itemsList.Find(x => x.UniqueID == int.Parse(listViewPlayer.SelectedItems[0].SubItems[2].Text));

                    // Remove it from the player
                    listViewPlayer.Items.RemoveByKey(tempItem.DisplayName);

                    // Add the gold to the player
                    character.Gold += total;

                    // Take the gold from the shop
                    int shopGold = int.Parse(txtGoldShop.Text);
                    shopGold -= total;
                    txtGoldShop.Text = shopGold.ToString();

                    // Remove the item from the player's inventory
                    character.Inventory.Remove(character.Inventory.Find(y => y.ItemID == tempItem.UniqueID));

                    if (API.UpdateInventory(character.UniqueID))
                    {
                        // Show the item in the list
                        LoadPlayerList();

                        // Log the transaction
                        LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, $"Player sold Item#{tempItem.UniqueID} - {tempItem.DisplayName} to shop for {total}");

                        // Reset the total
                        total = 0;
                        txtTotal.Text = "0";
                    }
                    else
                    {
                        MessageBox.Show("There was an error selling your items. Please try again later.","Error Selling");
                    }
                }
                catch (Exception ex)
                {
                    LogWriter.Write(this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Error selling to shop: " + ex);
                    MessageBox.Show("There was an error selling your items. Please try again later.", "Error Selling");
                }
            }
        }

        /// <summary>
        /// Determine if a transaction can occur
        /// </summary>
        /// <param name="type">An integer representing who is initiating the transaction</param>
        /// <returns>True if transaction can occur, false otherwise</returns>
        private bool BeginTransaction(int type)
        {
            int goldOnHand = 0;
            if(type == GameController.PLAYER)
            {
                goldOnHand = int.Parse(txtGoldPlayer.Text);
            }
            else if(type == GameController.SHOP)
            {
                goldOnHand = int.Parse(txtGoldShop.Text);
            }

            if (total <= goldOnHand && total != 0 && GameController.HasInventorySpace())
            {
                return true;
            }

            // The Player/Shop cannot afford the transaction
            // or nothing was selected
            return false;
        }

        private void Inventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sender.GetType() == typeof(ListView))
            {
                ListView tempView = (ListView)sender;

                txtTotal.Text = tempView.SelectedItems[0].SubItems[1].Text;
                total = int.Parse(txtTotal.Text);
            }
        }
    }
}
