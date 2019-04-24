using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

public static class Game{

    public static List<Layer> dungeon; // Layers of dungeon
    public static int numberOfLayers = 5; // How many layers the dungeon has
    public static int dungeonWidth = 50;   // Dungeon dimensions
    public static int dungeonLength = 80;

    public static List<Race> availableRaces = new List<Race>();
    public static List<Character> availableCharacters = new List<Character>();
    public static List<Weapon> availableWeapons = new List<Weapon>();
    public static List<Weapon> availableNPCWeapons = new List<Weapon>();
    public static List<Armor> availableArmorList = new List<Armor>();
    public static List<Spell> availableSpellList = new List<Spell>();
    public static List<Potion> availablePotionList = new List<Potion>();
    
    public static List<Skill> availableSkills = new List<Skill>(); // Skills not in use in the current build

    public static EventLogger eventLogger;
    public static Layer currentLayer;
    public static GameWindow gameWindow;

    [STAThread]
    static void Main(string[] args) {

    /* Create a WinForm Application */
    Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        gameWindow = new GameWindow(); // Window that the game is shown on
        RichTextBox worldBox = gameWindow.richTextBox1; // Reference to the world panel of the application
        eventLogger = new EventLogger(gameWindow.textBox2);

        loadDataBases(); // Load data (races, skills, items etc.) from databases

        dungeon = DungeonCreator.createDungeon(numberOfLayers, dungeonWidth, dungeonLength); // Create the dungeon
        currentLayer = dungeon[0];

        PlayerCharacter player = new PlayerCharacter("Player", 20, new Race("Human", 'P'), new Class(), 'P', currentLayer.getTiles()[currentLayer.getRooms()[0].getCenterPoint()[0]][currentLayer.getRooms()[0].getCenterPoint()[1]]);


        //drawDungeon(0, worldBox);
        gameWindow.initialize(player, currentLayer.getTiles(), currentLayer);
        //gameWindow.richTextBox1.Text = "" + dungeon[0].getEnemies().Count;
        Application.Run(gameWindow);
    }

    public static void drawDungeon(Layer layer, RichTextBox box) {
        try {
            box.Text = ""; // Erase text
            /* Fill box with symbols accordingly */
            for (int i = 0; i < dungeonWidth; i++) {
                foreach (Tile t in layer.getTiles()[i]) {
                    try {
                        box.AppendText(t.getSymbol().ToString());
                    }
                    catch (Exception e) {
                        continue;
                    }
                }
                box.Text = box.Text + Environment.NewLine; // New line after each line has been finished
            }
        }catch(Exception e) {
            /* Sometimes this part of the code gets a bit cranky due to cross-threading */
            drawDungeon(layer, box);
        }
    }

    /* Load data from databases */
    #region DataBase stuff
    public static void loadDataBases() {
        /* Path to database folder */
        string dataBaseFolderPath = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString()).ToString()) + "\\Databases";

        /* Load enemies */
        SQLiteConnection sqlite = new SQLiteConnection("Data Source=" + dataBaseFolderPath + "\\Enemies.db"); // Establish connection
        sqlite.Open(); // Open connection
        SQLiteCommand command = new SQLiteCommand(); // Initialize new command
        command.Connection = sqlite; // Connection the command is related to
        command.CommandText = "Select * from Enemies"; // Query
        SQLiteDataReader reader = command.ExecuteReader(); // Initialize reader
        /* Start reading data */
        while (reader.Read()) {
            /* Create new enemy from read data and add it to the list */
            availableCharacters.Add(new Character(reader.GetString(0), reader.GetInt32(1), new Race(reader.GetString(0), reader.GetString(4).ToCharArray()[0]), new Class(), reader.GetString(4).ToCharArray()[0]));
        }
        /* Close connection in a controlled manner */
        reader.Close();
        sqlite.Close();
        sqlite = null;
        reader = null;
        command = null;


        /* Load Weapons */
        sqlite = new SQLiteConnection("Data Source=" + dataBaseFolderPath + "\\Items.db");
        sqlite.Open();
        command = new SQLiteCommand();
        command.Connection = sqlite;
        command.CommandText = "Select * from Weapons";
        reader = command.ExecuteReader();
        while (reader.Read()) {
            availableWeapons.Add(new Weapon(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(4), reader.GetInt32(5)));
        }
        reader.Close();
        sqlite.Close();
        sqlite = null;
        reader = null;
        command = null;


        /* Load NPC Weapons */
        sqlite = new SQLiteConnection("Data Source=" + dataBaseFolderPath + "\\Items.db");
        sqlite.Open();
        command = new SQLiteCommand();
        command.Connection = sqlite;
        command.CommandText = "Select * from NPCWeapons";
        reader = command.ExecuteReader();
        while (reader.Read()) {
            availableNPCWeapons.Add(new Weapon(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(4), reader.GetInt32(5)));
        }
        reader.Close();
        sqlite.Close();
        sqlite = null;
        reader = null;
        command = null;

        /* Load Armor */
        sqlite = new SQLiteConnection("Data Source=" + dataBaseFolderPath + "\\Items.db");
        sqlite.Open();
        command = new SQLiteCommand();
        command.Connection = sqlite;
        command.CommandText = "Select * from Armor";
        reader = command.ExecuteReader();
        while (reader.Read()) {
            availableArmorList.Add(new Armor(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
        }
        reader.Close();
        sqlite.Close();
        sqlite = null;
        reader = null;
        command = null;


        /* Load Spells */
        sqlite = new SQLiteConnection("Data Source=" + dataBaseFolderPath + "\\Items.db");
        sqlite.Open();
        command = new SQLiteCommand();
        command.Connection = sqlite;
        command.CommandText = "Select * from Spells";
        reader = command.ExecuteReader();
        while (reader.Read()) {
            availableSpellList.Add(new Spell(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4)));
        }
        reader.Close();
        sqlite.Close();
        sqlite = null;
        reader = null;
        command = null;


        /* Load Potions */
        sqlite = new SQLiteConnection("Data Source=" + dataBaseFolderPath + "\\Items.db");
        sqlite.Open();
        command = new SQLiteCommand();
        command.Connection = sqlite;
        command.CommandText = "Select * from Potions";
        reader = command.ExecuteReader();
        while (reader.Read()) {
            availablePotionList.Add(new Potion(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
        }
        reader.Close();
        sqlite.Close();
        sqlite = null;
        reader = null;
        command = null;


        /* SKILLS NOT IN CURRENT BUILD */
    }
    #endregion


    /* CHARACTER CREATION IN PROGRESS --- IN FUTURE UPDATE
     * 
    public static PlayerCharacter createCharacter(GameWindow gw) {
        bool characterCreated = false;
        List<System.Windows.Forms.Label> skillValues = gw.skillValueList;
        List<System.Windows.Forms.CheckBox> skillCheckBoxes = gw.skillBoxList;
        int amountOfSpezializationSkills = 5;
        while (!characterCreated) {
            
        }
        return null;
    }*/

    public static void moveCharacter(KeyEventArgs e, Character player, Tile[][] tiles, List<Character> enemies) {

        eventLogger.Empty(); // empty logs

        /* Horribly organized moving controls - NEEDS REWORKING */
        Tile targetTile; // The tile the player is possibly moving to
        if (e.KeyCode == Keys.A) {
            targetTile = tiles[player.getTile().getCoordX()][player.getTile().getCoordY() - 1];
            /* If tile already has a character, player will attack */
            if (targetTile.getCharacter() != null) {
                attackCharacter(player, targetTile.getCharacter(), enemies);
            }
            /* Check that the tile player is moving to is empty and is not a wall */
            if (targetTile.isWalkable() && targetTile.getCharacter() == null) {
                /* Move character to tile */
                player.moveCharacter(tiles[player.getTile().getCoordX()][player.getTile().getCoordY() - 1]);
            }
            if(targetTile.getItem() != null) {
                /* If player steps on an item */
                eventLogger.logEvent(player.getName() + " stepped on " + targetTile.getItem().getName() + ". ");
            }
        }
        if (e.KeyCode == Keys.W) {
            targetTile = tiles[player.getTile().getCoordX() - 1][player.getTile().getCoordY()];
            if (targetTile.getCharacter() != null) {
                attackCharacter(player, targetTile.getCharacter(), enemies);
            }
            if (targetTile.isWalkable() && targetTile.getCharacter() == null) {
                player.moveCharacter(targetTile);
            }
            if (targetTile.getItem() != null) {
                eventLogger.logEvent(player.getName() + " stepped on " + targetTile.getItem().getName() + ". ");
            }
        }
        if (e.KeyCode == Keys.D) {
            targetTile = tiles[player.getTile().getCoordX()][player.getTile().getCoordY() + 1];
            if (targetTile.getCharacter() != null) {
                attackCharacter(player, targetTile.getCharacter(), enemies);
            }
            if (targetTile.isWalkable() && targetTile.getCharacter() == null) {
                player.moveCharacter(targetTile);
            }
            if (targetTile.getItem() != null) {
                eventLogger.logEvent(player.getName() + " stepped on " + targetTile.getItem().getName() + ". ");
            }
        }
        if (e.KeyCode == Keys.S) {
            targetTile = tiles[player.getTile().getCoordX() + 1][player.getTile().getCoordY()];
            if (targetTile.getCharacter() != null) {
                attackCharacter(player, targetTile.getCharacter(), enemies);
            }
            if (targetTile.isWalkable() && targetTile.getCharacter() == null) {
                player.moveCharacter(targetTile);
            }
            if (targetTile.getItem() != null) {
                eventLogger.logEvent(player.getName() + " stepped on " + targetTile.getItem().getName() + ". ");
            }
        }
        /* Check if player is on the ladder */
        if (e.KeyCode == Keys.C && currentLayer.getLadder().climbLadder()) {
            currentLayer = dungeon[dungeon.IndexOf(currentLayer) + 1];
            currentLayer.addPlayer((PlayerCharacter)player);
            eventLogger.logEvent("Climbing ladder... ");
        }
        /* Check if player picks up an item */
        if (e.KeyCode == Keys.E && player.getTile().getItem() != null) {
            Item item = player.getTile().getItem();
            player.getInventory().addItem(item);
            player.getTile().deleteItem();
            gameWindow.updateInventoryScreen();
            eventLogger.logEvent(player.getName() + " picked up " + item.getName());
        }
        /* This part is needed to stop that annoying Windows BLING sound every time the player moves */
        e.SuppressKeyPress = true;
    }

    public static void moveEnemies(List<Character> enemiesList, PlayerCharacter player, Tile[][] tiles) {
        /* Move every enemy */
        for (int i = 0; i < enemiesList.Count; i++) {
            Character enemy = enemiesList[i];
            /* If enemy is adjacent to the player, attack instead! */
            List<Tile> enemyAdjacents = getAdjacentTiles(tiles, enemy.getTile());
            if (enemyAdjacents.Contains(player.getTile())){
                attackCharacter(enemy, player, enemiesList);
                if (!player.isAlive()) {
                    eventLogger.logEvent(player.getName() + " is dead!");
                    Application.Exit();
                }
            }
            else {
                Pathfinder pathFinder = new Pathfinder();
                List<Tile> enemyPath = pathFinder.getPath(tiles, enemy.getTile(), player.getTile());
                if (enemyPath[0].getCharacter() == null) {
                    enemy.moveCharacter(enemyPath[0]);
                }
            }
        }
    }

    public static PlayerCharacter createRandomCharacter(GameWindow gw) {
        return null;
    }

    public static void attackCharacter(Character attacker, Character defender, List<Character> enemies) {
        eventLogger.logEvent(attacker.getName() + " attacked with " + attacker.getWeapon().getName() + "! ");
        string msg = attacker.attack(defender);
        eventLogger.logEvent(msg);
        if (!defender.isAlive()) {
            defender.killCharacter();
            enemies.Remove(defender);
            eventLogger.logEvent(defender.getName() + " was killed! ");
        }
    }

    public static List<Tile> getAdjacentTiles(Tile[][] tiles, Tile t) {
        List<Tile> adjacentTiles = new List<Tile>();
        try {
            adjacentTiles.Add(tiles[t.getCoordX() - 1][t.getCoordY()]);
            adjacentTiles.Add(tiles[t.getCoordX() + 1][t.getCoordY()]);
            adjacentTiles.Add(tiles[t.getCoordX()][t.getCoordY() - 1]);
            adjacentTiles.Add(tiles[t.getCoordX()][t.getCoordY() + 1]);
        }catch (Exception e) {

        }
        return adjacentTiles;
    }

}
