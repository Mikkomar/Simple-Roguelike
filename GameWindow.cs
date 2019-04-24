using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

public partial class GameWindow : Form {
    public GameWindow() {
        InitializeComponent();
    }

    private delegate void ObjectDelegate(object obj, object obu);

    /* Some attributes */
    private PlayerCharacter player;
    private Inventory playerInventory;
    private Tile[][] tiles;
    private Layer currentLayer;
    public ThreadStart tStart;
    public Thread updateThread;
    public Thread inventoryThread;
    public Thread statThread;
    public Thread keyHandlerThread;

    private bool inventoryActive;

    /* Set up attributes and start threads */
    public void initialize(PlayerCharacter p, Tile[][] til, Layer layer) {
        player = p;
        playerInventory = p.getInventory();
        tiles = til;
        currentLayer = layer;
        inventoryActive = false;
        updateInventoryScreen();

        /* Thread that handles updating the map after player has moved */
        tStart = new ThreadStart(updateWorld);
        updateThread = new Thread(tStart);
        updateThread.Name = "World Update Thread";
        updateThread.Start();

        /* Thread that handles updating stats, health etc. */
        tStart = new ThreadStart(updateStats);
        statThread = new Thread(tStart);
        statThread.Name = "Stat Update Thread";
        statThread.Start();
    }

    private void onClick(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Q) {
            inventoryActive = !inventoryActive;
            if (inventoryActive) {
                listBox2.SelectedIndex = 0;
            }
            else {
                listBox2.SelectedIndex = -1;
            }
        }
        if (inventoryActive) {
            ObjectDelegate del = new ObjectDelegate(inventoryHandler);
            del.Invoke(sender, e);
        }
        else {
            listBox2.SelectedIndex = -1; // erase inventory interaction
            ObjectDelegate del = new ObjectDelegate(keyPressHandler);
            del.Invoke(sender, e);
        }
    }

    private void startThread() {
        updateWorld();
    }

    private void updateWorld() {
        /* Does it need to be invoked again? */
        if (InvokeRequired) {
            MethodInvoker method = new MethodInvoker(updateWorld);
            Invoke(method);
            return;
        }
        /* Check if layer has changed */
        currentLayer = Game.currentLayer;
        /* Update map */
        Game.drawDungeon(currentLayer, richTextBox1);
    }

    /* Updates stats on screen */
    private void updateStats() {
        if (InvokeRequired) {
            MethodInvoker method = new MethodInvoker(updateStats);
            Invoke(method);
            return;
        }
        /* Updates name and health values */
        label26.Text = player.getName();
        label27.Text = "" +  player.getHealth() + "/" + player.getMaxHealth();
        /* Updates equipment on screen */
        updateEquipment();
    }

    /* If a key is pressed */
    private void keyPressHandler(object sender, object k) {
        if (InvokeRequired) {
            MethodInvoker method = new MethodInvoker(updateWorld);
            Invoke(method);
            return;
        }

        KeyEventArgs e = (KeyEventArgs)k;
        /* Move character if possible */
        Game.moveCharacter(e, player, currentLayer.getTiles(), currentLayer.getEnemies());
        currentLayer = Game.currentLayer;
        /* Move enemies if possible */
        Game.moveEnemies(currentLayer.getEnemies(), player, currentLayer.getTiles());
        /* Update stats */
        tStart = new ThreadStart(updateStats);
        statThread = new Thread(tStart);
        statThread.Name = "Stat Update Thread";
        statThread.Start();
        /* Then update the map */
        tStart = new ThreadStart(updateWorld);
        updateThread = new Thread(tStart);
        updateThread.Name = "World Update Thread";
        updateThread.Start();
    }

    /* Obsolete? */
    private void onInventoryClick(object sender, KeyEventArgs e) {
        ObjectDelegate del = new ObjectDelegate(keyPressHandler);
        del.Invoke(sender, e);
    }

    /* Handles player's interaction with their inventory */
    private void inventoryHandler(object sender, object k) {
        KeyEventArgs e = (KeyEventArgs)k;
        ListBox inv = listBox2;
        /* Check that inventory isn't empty */
        if(inv.Items.Count > 0) {
            /* Going up? */
            if (e.KeyCode == Keys.W && inv.SelectedIndex > 0) {
                inv.SelectedIndex--;
            }
            /* Going down? */
            if (e.KeyCode == Keys.S && inv.SelectedIndex < inv.Items.Count-1) {
                inv.SelectedIndex++;
            }
            /* Activating an item? */
            if (e.KeyCode == Keys.E && inv.SelectedIndex > 0 && inv.SelectedIndex < inv.Items.Count-1) {
                Item selectedItem = (Item)inv.Items[inv.SelectedIndex];
                switch (selectedItem.getType()) {
                    case ItemType.weaponSword:
                        player.setWeapon((Weapon)selectedItem);
                        break;
                    case ItemType.weaponHammer:
                        player.setWeapon((Weapon)selectedItem);
                        break;
                    case ItemType.weaponAxe:
                        player.setWeapon((Weapon)selectedItem);
                        break;
                    case ItemType.weaponBow:
                        player.setWeapon((Weapon)selectedItem);
                        break;
                    case ItemType.weaponPolearm:
                        player.setWeapon((Weapon)selectedItem);
                        break;
                    case ItemType.heavyArmor:
                        player.equipArmor((Armor)selectedItem);
                        break;
                    case ItemType.lightArmor:
                        player.equipArmor((Armor)selectedItem);
                        break;
                    case ItemType.potionHealth:
                        ((Potion)selectedItem).consume(player);
                        player.getInventory().removeItem(selectedItem);
                        break;
                    case ItemType.potionDamage:
                        ((Potion)selectedItem).consume(player);
                        player.getInventory().removeItem(selectedItem);
                        break;
                    default:
                        break;
                }
                /* If an item was activated, update equipment and inventory */
                updateStats();
                updateInventoryScreen();
                e.SuppressKeyPress = true; // No BING
            }
        }
    }

    /* Update inventory list */
    public void updateInventoryScreen() {
        ListBox inventoryScreen = listBox2;
        inventoryScreen.Items.Clear();
        foreach(Weapon w in playerInventory.getWeapons()) {
            inventoryScreen.Items.Add(w);
        }
        foreach (Armor w in playerInventory.getArmor()) {
            inventoryScreen.Items.Add(w);
        }
        foreach (Spell w in playerInventory.getSpells()) {
            inventoryScreen.Items.Add(w);
        }
        foreach (Potion w in playerInventory.getPotions()) {
            inventoryScreen.Items.Add(w);
        }
    }

    public void updateEquipment() {
        Label weaponLabel = label28;
        Label helmetLabel = label30;
        Label cuirassLabel = label32;
        Label gauntletLabel = label34;
        Label bootLabel = label36;

        Label damageLabel = label39;
        Label critLabel = label47;
        Label missLabel = label48;
        Label helmDefLabel = label41;
        Label cuiDefLabel = label42;
        Label gauDefLabel = label43;
        Label booDefLabel = label44;

        if (player.getWeapon() != null) {
            weaponLabel.Text = player.getWeapon().getName();
            damageLabel.Text = "" + player.getWeapon().getBaseDamage();
            critLabel.Text = "" + player.getWeapon().getCritChance();
            missLabel.Text = "" + player.getWeapon().getEvadeChance();
        }
        else {
            weaponLabel.Text = "None";
            damageLabel.Text = "0";
            critLabel.Text = "0";
            missLabel.Text = "0";
        }
        if (player.getHelmet() != null) {
            helmetLabel.Text = player.getHelmet().getName();
            helmDefLabel.Text = "" + player.getHelmet().getBaseDefense();
        }
        else {
            helmetLabel.Text = "None";
            helmDefLabel.Text = "0";
        }
        if (player.getCuirass() != null) {
            cuirassLabel.Text = player.getCuirass().getName();
            cuiDefLabel.Text = "" + player.getCuirass().getBaseDefense();
        }
        else {
            cuirassLabel.Text = "None";
            cuiDefLabel.Text = "0";
        }
        if (player.getGauntlets() != null) {
            gauntletLabel.Text = player.getGauntlets().getName();
            gauDefLabel.Text = "" + player.getGauntlets().getBaseDefense();
        }
        else {
            gauntletLabel.Text = "None";
            gauDefLabel.Text = "0";
        }
        if (player.getBoots() != null) {
            bootLabel.Text = player.getBoots().getName();
            booDefLabel.Text = "" + player.getBoots().getBaseDefense();
        }
        else {
            bootLabel.Text = "None";
            booDefLabel.Text = "0";
        }
    }

    private void inventoryBrowser() {

    }

    private void label1_Click(object sender, EventArgs e) {

    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

    }

    private void richTextBox3_TextChanged(object sender, EventArgs e) {

    }

    private void label25_Click(object sender, EventArgs e) {

    }

    private void label44_Click(object sender, EventArgs e) {

    }

    private void label39_Click(object sender, EventArgs e) {

    }

    private void label40_Click(object sender, EventArgs e) {

    }

    private void label41_Click(object sender, EventArgs e) {

    }

    private void label42_Click(object sender, EventArgs e) {

    }

    private void GameWindow_Load(object sender, EventArgs e) {

    }

    private void label48_Click(object sender, EventArgs e) {

    }

    private void label43_Click(object sender, EventArgs e) {

    }

    private void label47_Click(object sender, EventArgs e) {

    }

    private void label45_Click(object sender, EventArgs e) {

    }

    private void label46_Click(object sender, EventArgs e) {

    }

    private void label38_Click(object sender, EventArgs e) {

    }
}
