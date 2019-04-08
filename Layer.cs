using System;
using System.Collections;
using System.Collections.Generic;

public class Layer{

    private int width;
    private int length;
    private Tile[][] tiles;
    private List<Room> rooms;

    public Layer(int w, int l){
        width = w;
        length = l;
        tiles = new Tile[width][];
        rooms = new List<Room>();

        for(int i = 0; i < width; i++) {
            tiles[i] = new Tile[length];
            for(int j=0; j < length; j++) {
                tiles[i][j] = new Tile(' ', false, i, j);
            }
        }
        Random roomCreator = new Random();
        int roomWidth = roomCreator.Next(7, 9);
        int roomLength = roomCreator.Next(9, 11);
        int roomX = roomCreator.Next(1, width - roomWidth-1);
        int roomY = roomCreator.Next(1, length - roomLength-1);
        createRoom(roomX, roomY, roomWidth, roomLength, true, true);
        //Console.WriteLine("Layer created!");
        /* Create three corridors */
        Console.WriteLine("Making corridors");
        int corridorCounter = 0;
        while(corridorCounter < 3) {
            int direction = roomCreator.Next(0, 4); // From which wall the corridor starts
            int corridorLength = roomCreator.Next(5, 9);
            Tile start;
            if (direction == 0) {
                start = rooms[0].getRandomWallSpecific(tiles, direction);

                    createRoom(start.getCoordX(), start.getCoordY(), corridorLength, 0, true, true);
                    start.setTileSymbol(':');
                    start.setWalkable(true);
                    corridorCounter++;
                    Console.WriteLine("+Vertical corridor created! Coordinates: " + start.getCoordX() + ", " + start.getCoordY() + ", length: " + corridorLength);

            }
            if (direction == 1) {
                start = rooms[0].getRandomWallSpecific(tiles, direction);

                    createRoom(start.getCoordX(), start.getCoordY(), 0, corridorLength, true, false);
                    start.setTileSymbol(':');
                    start.setWalkable(true);
                    corridorCounter++;
                    Console.WriteLine("+Horizontal corridor created! Coordinates: " + start.getCoordX() + ", " + start.getCoordY() + ", length: " + corridorLength);

            }
            if (direction == 2) {
                start = rooms[0].getRandomWallSpecific(tiles, direction);

                    createRoom(start.getCoordX(), start.getCoordY(), corridorLength, 0, false, true);
                    start.setTileSymbol(':');
                    start.setWalkable(true);
                    corridorCounter++;
                    Console.WriteLine("-Vertical corridor created! Coordinates: " + start.getCoordX() + ", " + start.getCoordY() + ", length: " + corridorLength);

            }
            if (direction == 3) {
                start = rooms[0].getRandomWallSpecific(tiles, direction);

                    createRoom(start.getCoordX(), start.getCoordY(), 0, corridorLength, false, false);
                    start.setTileSymbol(':');
                    start.setWalkable(true);
                    corridorCounter++;
                    Console.WriteLine("-Horizontal corridor created! Coordinates: " + start.getCoordX() + ", " + start.getCoordY() + ", length: " + corridorLength);

            }
        }
        //makeWalls();
    }

    public void createRoom(int x, int y, int roomWidth, int roomLength, bool north, bool east) {
        /* Check if map has enough space for room */
        if (!isAreaBigEnough(x, y, roomWidth, roomLength)) {
            Console.WriteLine("lol");
            return;
        }
        else {
            rooms.Add(new Room(tiles, x, y, roomWidth, roomLength, north, east));
            //rooms[0].getRandomWallSpecific(tiles, 3).setTileSymbol('D');
        }
    }

    public void createCorridor(int startX, int startY, int endX, int endY) {
        for(int i = 0; i < endX; i++) {
            for(int j = 0; j < endY; j++) {

            }
        }
    }

    public bool isAreaBigEnough(int x, int y, int checkWidth, int checkLength) {
        /* Check if room size is out of bounds */
        if(x + checkWidth > width || y + checkLength > length) {
            return false;
        }
        /* Check if designated tiles are already occupied */
        for(int i=0; i < checkWidth; i++) {
            for(int j=0; j < checkLength; j++) {
                /* If a tile in area is something else than empty (= occupied) */
                if(!tiles[x+i][y+j].getSymbol().Equals(' ')) {
                    return false;
                }
            }
        }
        return true;
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
