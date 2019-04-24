using System;
using System.Collections;
using System.Collections.Generic;

public class Layer{

    private int width;
    private int length;
    private int amountOfRooms;
    private int maxAmountOfRooms;
    private Tile[][] tiles;
    private List<Room> rooms;

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
        /* Create a map with no rooms */
        for(int i = 0; i < width; i++) {
            tiles[i] = new Tile[length];
            for(int j=0; j < length; j++) {
                tiles[i][j] = new Tile(' ', false, i, j);
            }
        }
        /* Create first room */
        Random roomCreator = new Random();
        int roomWidth = roomCreator.Next(7, 9);
        int roomLength = roomCreator.Next(9, 11);
        int roomX = roomCreator.Next(1, width - roomWidth-1);
        int roomY = roomCreator.Next(1, length - roomLength-1);
        createRoom(roomX, roomY, roomWidth, roomLength, Direction.east); // Creates the first room
        amountOfRooms++;

        for(int roomCreatorCount = 0; roomCreatorCount < 1000; roomCreatorCount++) {
            /* Check if map has enough rooms */
            if(amountOfRooms >= maxAmountOfRooms) {
                Console.WriteLine("Max amount of rooms created!");
                break;
            }
            /* If not enough rooms, let's create one! */
            /* Find a floor tile */
            Tile startTile = null;
            for(int tileTester = 0; tileTester < 10000; tileTester++) {
                Tile testTile = getRandomFloorTile();
                if (testTile.getSymbol().Equals('.')) {
                    startTile = testTile;
                    break;
                }
            }
            /* If floor tile was found, start building a room */
            if (startTile != null) {
                int roomOrCorridor = roomCreator.Next(0, 101);
                    if(roomOrCorridor < roomChance) {
                            Console.WriteLine("Creating room...");
                            if (createRoom(startTile.getCoordX(), startTile.getCoordY(), roomCreator.Next(3, 4), roomCreator.Next(4, 5), getRandomDirection())) {
                            amountOfRooms++;
                        }
                    }else if(roomOrCorridor >= roomChance) {
                        Console.WriteLine("Creating corridor...");
                        if(roomCreator.Next(0,2) < 1) {
                        if (createRoom(startTile.getCoordX(), startTile.getCoordY(), roomCreator.Next(3, 4), 1, getRandomDirection(false))) {
                            amountOfRooms++;
                        }
                    }
                    else {
                        if (createRoom(startTile.getCoordX(), startTile.getCoordY(), 1, roomCreator.Next(3, 4), getRandomDirection(true))) {
                            amountOfRooms++;
                        }
                    }
                    }
            }else {
                Console.WriteLine("Tile not found!");
                break;
            }
        }
        makeWalls();
    }

    public bool createRoom(int x, int y, int xlen, int ylen, Direction direction) {
        /* Check if map has enough space for room */
        if (areaIsEmpty(x, y, xlen, ylen, direction)){
            /* If map has space for room, let's build! */
            switch (direction) {
                case Direction.east:
                    for(int i = x; i < x + xlen; i++) {
                        for(int j = y; j < y + ylen; j++) {
                            tiles[i][j] = new Tile('.', true, i, j);
                        }
                    }
                    return true;
                case Direction.south:
                    for(int i = x; i < x + xlen; i++) {
                        for(int j = y - ylen; j < y; j++) {
                            tiles[i][j] = new Tile('.', true, i, j);
                        }
                    }
                    return true;
                case Direction.west:
                    for (int i = x-xlen; i < x; i++) {
                        for (int j = y - ylen; j < y; j++) {
                            tiles[i][j] = new Tile('.', true, i, j);
                        }
                    }
                    return true;
                case Direction.north:
                    for (int i = x - xlen; i < x; i++) {
                        for (int j = y; j < y + ylen; j++) {
                            tiles[i][j] = new Tile('.', true, i, j);
                        }
                    }
                    return true;
            }
        }else {
            return false;
        }
        return false;
    }

    public bool areaIsEmpty(int x, int y, int xlen, int ylen, Direction dir) {
        bool noWalls = true;
        switch (dir) {
            case Direction.east:
                try {
                    for (int i = x; i < x + xlen; i++) {
                        for (int j = y; j < y + ylen;j++) {
                            if (!(tiles[i][j].getSymbol() == ' ')) {
                                //Console.WriteLine("Tile" + tiles[i][j].getSymbol() + "detected!");
                                noWalls = false;
                            }
                        }
                    }
                } catch (Exception e) {
                    return false;
                }
                return noWalls;
            case Direction.south:
                try {
                    for (int i = x; i < x + xlen; i++) {
                        for (int j = y-ylen; j < y; j++) {
                            if (!(tiles[i][j].getSymbol() == ' ')) {
                                noWalls = false;
                            }
                        }
                    }
                }
                catch (Exception e) {
                    return false;
                }
                return noWalls;
            case Direction.west:
                try {
                    for (int i = x - xlen; i < x; i++) {
                        for (int j = y - ylen; j < y; j++) {
                            if (!(tiles[i][j].getSymbol() == ' ')) {
                                noWalls = false;
                            }
                        }
                    }
                }
                catch (Exception e) {
                    return false;
                }
                return noWalls;
            case Direction.north:
                try {
                    for (int i = x - xlen; i < x; i++) {
                        for (int j = y; j < y + ylen; j++) {
                            if (!(tiles[i][j].getSymbol() == ' ')) {
                                noWalls = false;
                            }
                        }
                    }
                }
                catch (Exception e) {
                    return false;
                }
                return noWalls;
        }
        return noWalls;
    }

    public Tile getRandomTile() {
        Random rnd = new Random();
        int randX = rnd.Next(1, width - 1);
        int randY = rnd.Next(1, length - 1);
        return tiles[randX][randY];
    }

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

    public Direction getRandomDirection() {
        Random rnd = new Random();
        int d = rnd.Next(0, 4);
        if(d == 0) {
            return Direction.east;
        }
        if(d == 1) {
            return Direction.south;
        }
        if(d == 2) {
            return Direction.west;
        }
        if(d == 3) {
            return Direction.north;
        }
        return Direction.east;
    }

    public Direction getRandomDirection(bool north) {
        Random rnd = new Random();
        int d = rnd.Next(0, 2);
        if (north) {
            if (d == 0) {
                return Direction.north;
            }
            if (d == 1) {
                return Direction.south;
            }
        }
        else {
            if (d == 2) {
                return Direction.west;
            }
            if (d == 3) {
                return Direction.east;
            }
        }
        return Direction.east;
    }

    public void makeWalls() {
        for(int i = 0; i < width; i++) {
            for(int j = 0; j < length; j++) {
                if (tiles[i][j].getSymbol().Equals('.') && tiles[i+1][j].getSymbol().Equals(' ')) {
                    tiles[i + 1][j] = new Tile('#', false, i + 1, j);
                }
                if (tiles[i][j].getSymbol().Equals('.') && tiles[i - 1][j].getSymbol().Equals(' ')) {
                    tiles[i - 1][j] = new Tile('#', false, i - 1, j);
                }
                if (tiles[i][j].getSymbol().Equals('.') && tiles[i][j+1].getSymbol().Equals(' ')) {
                    tiles[i][j + 1] = new Tile('#', false, i, j + 1);
                }
                if (tiles[i][j].getSymbol().Equals('.') && tiles[i][j - 1].getSymbol().Equals(' ')) {
                    tiles[i][j - 1] = new Tile('#', false, i, j - 1);
                }
            }
        }
    }

    public Tile[][] getTiles() {
        return tiles;
    }
}

public enum Direction {
    east,   // x+, y+
    south,  // x-, y+
    west,   // x-, y-
    north   // x+, y-
}
