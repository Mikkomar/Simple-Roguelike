using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Layer{

    private int width;
    private int length;
    private int amountOfRooms;
    private int maxAmountOfRooms;
    private Tile[][] tiles;
    private List<Room> rooms;

    private int numberOfEnemies;
    private int numberOfItems;
    private List<Character> availableEnemies;
    private List<Character> enemies;
    private List<Item> items;
    private List<Weapon> availableWeapons;
    private List<Weapon> availableNPCWeapons;
    private List<Armor> availableArmor;
    private List<Spell> availableSpells;
    private List<Potion> availablePotions;
    private Ladder ladder;

    private int roomChance;
    private int corridorChance;

    public Layer(int w, int l){
        amountOfRooms = 0;
        maxAmountOfRooms = 8;
        roomChance = 75;
        corridorChance = 100 - roomChance;
        width = w;
        length = l;
        tiles = new Tile[width][];
        rooms = new List<Room>();

        numberOfEnemies = 6; // How many enemies on one floor?
        numberOfItems = 12; // How many items on one floor?

        /* Lists to store possible instances for creation */
        availableEnemies = Game.availableCharacters;
        availableWeapons = Game.availableWeapons;
        availableArmor = Game.availableArmorList;
        availableSpells = Game.availableSpellList;
        availablePotions = Game.availablePotionList;
        availableNPCWeapons = Game.availableNPCWeapons;
        enemies = new List<Character>();
        items = new List<Item>();

        /* Create a map with no rooms */
        for(int i = 0; i < width; i++) {
            tiles[i] = new Tile[length];
            for(int j=0; j < length; j++) {
                tiles[i][j] = new Tile(' ', false, i, j);
            }
        }
        /* Create first room */
        Random roomCreator = new Random();

        for(int roomCreatorCount = 0; roomCreatorCount < 1000; roomCreatorCount++) {
            /* Check if map has enough rooms */
            if(amountOfRooms >= maxAmountOfRooms) {
                //Console.WriteLine("Max amount of rooms created!");
                break;
            }
            /* If not enough rooms, let's create one! */
            int roomWidth = roomCreator.Next(7, 11);
            int roomLength = roomCreator.Next(7, 11);
            int roomX = roomCreator.Next(1, width - roomWidth - 1);
            int roomY = roomCreator.Next(1, length - roomLength - 1);
            if (areaIsEmpty(roomX, roomY, roomWidth, roomLength)){
                rooms.Add(new Room(tiles, roomX, roomY, roomWidth, roomLength));
                amountOfRooms++;
            }
        }
        /* Now that rooms have been created, we connect them with corridors */
        createCorridors();
        /* Add walls next to border floor tiles */
        makeWalls();
        /* Add items to map */
        addItems(numberOfItems);
        /* Add enemies to map */
        addEnemies(numberOfEnemies);
    }

    /* Check if area is empty - not used in current build */
    public bool areaIsEmpty(int x, int y, int xlen, int ylen) {
        bool noWalls = true;
            try {
                for (int i = x; i < x + xlen; i++) {
                    for (int j = y; j < y + ylen;j++) {
                        if (!(tiles[i][j].getSymbol() == ' ')) {
                            noWalls = false;
                        }
                    }
                }
            } catch (Exception e) {
                return false;
            }
        return noWalls;
    }

    /* Gets a random tile */
    public Tile getRandomTile() {
        Random rnd = new Random();
        int randX = rnd.Next(1, width - 1);
        int randY = rnd.Next(1, length - 1);
        return tiles[randX][randY];
    }

    /* Gets a random floor tile */
    public Tile getRandomFloorTile() {
        Random rnd = new Random();
        Tile tile = null;
        while(tile == null) {
            int randX = rnd.Next(1, width - 1);
            int randY = rnd.Next(1, length - 1);
            if (tiles[randX][randY].getSymbol() == '.') {
                tile = tiles[randX][randY];
            }
        }
        return tile;
    }

    /* Connect rooms with corridors **/
    public void createCorridors() {
        /* Check that every room is connected to each other */
        foreach(Room m in rooms) {
            for(int i = 0; i < rooms.Count; i++) {
                /* If rooms are connected, skip creating a connecting corridor */
                if(roomsConnected(m, rooms[i])) {
                    continue;
                }else {
                    /* Link two rooms with a corridor */
                    createCorridor(m, rooms[i]);
                }
            }
        }
    }

    /* Create corridor */
    public void createCorridor(Room m, Room n) {
        /* Use A* algorithm to find a B-line between rooms */
        Pathfinder pathfinder = new Pathfinder();
        Tile startTile = tiles[m.getCenterPoint()[0]][m.getCenterPoint()[1]];
        Tile endTile = tiles[n.getCenterPoint()[0]][n.getCenterPoint()[1]];
        List<Tile> corridor = pathfinder.getShortestPath(tiles, startTile, endTile);

        /* After a path has been found, turn the tiles into floor tiles */
        foreach(Tile t in corridor) {
            t.setTileSymbol('.');
            t.setWalkable(true);
        }
    }

    /* Check if two rooms are connected */
    public bool roomsConnected(Room firstRoom, Room secondRoom) {
        /* Find a path from the center of the first room to the center of the second room */
        int[] firstCenter = firstRoom.getCenterPoint();
        int[] secondCenter = secondRoom.getCenterPoint();
        Pathfinder pathfinder = new Pathfinder();
        /* Search a path using the A* algorithm */
        return pathfinder.searchPath(tiles, tiles[firstCenter[0]][firstCenter[1]], tiles[secondCenter[0]][secondCenter[1]]);
    }

    /* Surround rooms and corridors with walls */
    public void makeWalls() {
        try {
            /* Check if an empty tiles is next to a floor tile */
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < length; j++) {
                    if (tiles[i][j].getSymbol().Equals('.') && tiles[i + 1][j].getSymbol().Equals(' ')) {
                        /* Turn the empty tile into a wall */
                        tiles[i + 1][j] = new Tile('#', false, i + 1, j);
                    }
                    if (tiles[i][j].getSymbol().Equals('.') && tiles[i - 1][j].getSymbol().Equals(' ')) {
                        tiles[i - 1][j] = new Tile('#', false, i - 1, j);
                    }
                    if (tiles[i][j].getSymbol().Equals('.') && tiles[i][j + 1].getSymbol().Equals(' ')) {
                        tiles[i][j + 1] = new Tile('#', false, i, j + 1);
                    }
                    if (tiles[i][j].getSymbol().Equals('.') && tiles[i][j - 1].getSymbol().Equals(' ')) {
                        tiles[i][j - 1] = new Tile('#', false, i, j - 1);
                    }
                }
            }
        }catch(Exception e) {

        }
    }

    /* Sprinkle enemies into random rooms */
    public void addEnemies(int amount) {
        int testCount = 1000; // Try maximum of 1000 times
        Random enemyPlacer = new Random();
        for(int i = 0; i < testCount; i++) {
            /* Check if map has enough enemies */
            if(enemies.Count == amount) {
                break;
            }
            else {
                /* Get random coordinates for the enemy */
                int room = enemyPlacer.Next(0, rooms.Count);
                int roomX = enemyPlacer.Next(rooms[room].getCoordX(), rooms[room].getCoordX() + rooms[room].getWidth());
                int roomY = enemyPlacer.Next(rooms[room].getCoordY(), rooms[room].getCoordY() + rooms[room].getLength());
                Tile enemyTile = tiles[roomX][roomY];
                /* Check if chosen tile is a floor tile and has no other character */
                if (enemyTile.isWalkable() && enemyTile.getCharacter() == null) {
                    Character typeOfEnemy = availableEnemies[enemyPlacer.Next(0, availableEnemies.Count)];
                    Character enemy = new Character(typeOfEnemy.getName(), typeOfEnemy.getMaxHealth(), typeOfEnemy.getRace(), typeOfEnemy.getClass(), typeOfEnemy.getSymbol());
                    enemy.setWeapon(availableNPCWeapons[enemyPlacer.Next(0, availableNPCWeapons.Count)]);
                    enemy.setTile(enemyTile);
                    enemies.Add(enemy);
                }
            }
        }
    }

    /* Sprinkle items into random rooms */
    public void addItems(int amount) {
        int testCount = 1000; // Try maximum of 1000 times
        Random itemPlacer = new Random();
        for (int i = 0; i < testCount; i++) {
            /* Check if map has enough items */
            if (items.Count == amount) {
                break;
            }
            else {
                /* Get random coordinates for the item */
                int room = itemPlacer.Next(0, rooms.Count);
                int roomX = itemPlacer.Next(rooms[room].getCoordX(), rooms[room].getCoordX() + rooms[room].getWidth());
                int roomY = itemPlacer.Next(rooms[room].getCoordY(), rooms[room].getCoordY() + rooms[room].getLength());
                Tile itemTile = tiles[roomX][roomY];
                /* Check if chosen tile is a floor tile and has no other character */
                if (itemTile.isWalkable()) {
                    /* Create a random type of item */
                    int itemType = itemPlacer.Next(0, 4);
                    switch (itemType) {
                        case 0: // Weapon
                            int weaponType = itemPlacer.Next(0, availableWeapons.Count);
                            Weapon tmpWeapon = availableWeapons[weaponType];
                            items.Add(new Weapon(tmpWeapon.getName(), tmpWeapon.getType(), tmpWeapon.getBaseDamage(), tmpWeapon.getCritChance(), tmpWeapon.getEvadeChance(), itemTile));
                            break;
                        case 1: // Armor
                            int armorType = itemPlacer.Next(0, availableArmor.Count);
                            Armor tmpArmor = availableArmor[armorType];
                            items.Add(new Armor(tmpArmor.getName(), tmpArmor.getType(), tmpArmor.getArmorType(), tmpArmor.getBaseDefense(), itemTile));
                            break;
                        case 2: // Spell
                            int spellType = itemPlacer.Next(0, availableSpells.Count);
                            Spell tmpSpell = availableSpells[spellType];
                            items.Add(new Spell(tmpSpell.getName(), tmpSpell.getType(), tmpSpell.getBaseDamage(), tmpSpell.getCritChance(), tmpSpell.getEvadeChance(), itemTile));
                            break;
                        case 3: // Potion
                            int potionType = itemPlacer.Next(0, availablePotions.Count);
                            Potion tmpPotion = availablePotions[potionType];
                            items.Add(new Potion(tmpPotion.getName(), tmpPotion.getType(), tmpPotion.getRestoreHealth(), tmpPotion.getDamageHealth(), itemTile));
                            break;
                    }
                }
            }
        }
    }

    public void addLadder() {
        Random rnd = new Random();
        Room rndRoom = rooms[rnd.Next(0, rooms.Count)];
        int roomX = rnd.Next(rndRoom.getCoordX(), rndRoom.getCoordX() + rndRoom.getWidth());
        int roomY = rnd.Next(rndRoom.getCoordY(), rndRoom.getCoordY() + rndRoom.getLength());
        ladder = new Ladder('H', true, roomX, roomY);
        tiles[roomX][roomY] = ladder;
    }
    public void addDragon() {
        Random rnd = new Random();
        Room rndRoom = rooms[rnd.Next(0, rooms.Count)];
        int roomX = rnd.Next(rndRoom.getCoordX(), rndRoom.getCoordX() + rndRoom.getWidth());
        int roomY = rnd.Next(rndRoom.getCoordY(), rndRoom.getCoordY() + rndRoom.getLength());
        Tile dragonTile = tiles[roomX][roomY];
        while (dragonTile.getCharacter() != null) {
            rndRoom = rooms[rnd.Next(0, rooms.Count)];
            roomX = rnd.Next(rndRoom.getCoordX(), rndRoom.getCoordX() + rndRoom.getWidth());
            roomY = rnd.Next(rndRoom.getCoordY(), rndRoom.getCoordY() + rndRoom.getLength());
            dragonTile = tiles[roomX][roomY];
        }
        Dragon dragon = new Dragon("Dragon", 50, new Race("Dragon", '&'), new Class(), '&', dragonTile);
        dragon.setWeapon(new Weapon("Fire", "Unarmed", 8, 25, 5));
        enemies.Add(dragon);
    }

    public void addPlayer(PlayerCharacter pc) {
        Tile playerTile;
        Random rnd = new Random();
        Room rndRoom = rooms[rnd.Next(0, rooms.Count)];
        int roomX = rnd.Next(rndRoom.getCoordX(), rndRoom.getCoordX() + rndRoom.getWidth());
        int roomY = rnd.Next(rndRoom.getCoordY(), rndRoom.getCoordY() + rndRoom.getLength());
        playerTile = tiles[roomX][roomY];
        while (playerTile.getCharacter() != null) {
            rndRoom = rooms[rnd.Next(0, rooms.Count)];
            roomX = rnd.Next(rndRoom.getCoordX(), rndRoom.getCoordX() + rndRoom.getWidth());
            roomY = rnd.Next(rndRoom.getCoordY(), rndRoom.getCoordY() + rndRoom.getLength());
            playerTile = tiles[roomX][roomY];
        }
        pc.moveCharacter(playerTile);
    }

    public Tile[][] getTiles() {
        return tiles;
    }

    public List<Room> getRooms() {
        return rooms;
    }

    public List<Character> getEnemies() {
        return enemies;
    }

    public Ladder getLadder() {
        return ladder;
    }
}
