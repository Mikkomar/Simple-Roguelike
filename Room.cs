using System;

public class Room{

    protected int coordX;
    protected int coordY;
    protected int width;
    protected int length;

	public Room(Tile[][] tiles, int x, int y, int w, int l, bool north, bool east){
        coordX = x;
        coordY = y;
        width = w;
        length = l;

        /* Change map tiles from given coordinates to given widths into room tiles */
        for (int i = 0; i <= width; i++) {
            for (int j = 0; j <= length; j++) {
                if (north && east) {
                    tiles[x+i][y+j] = new Tile('.', true, i + x, j + y);
                }
                if (north && !east) {
                    tiles[x-i][y+j] = new Tile('o', true, i - x, y + j);
                }
                if (!north && east) {
                    tiles[x+i][y-j] = new Tile('p', true, x+i, j - y);
                }
                if (!north && !east) {
                    tiles[x-i][y-j] = new Tile('å', true, x-i, y-j);
                }
            }
        }
        Console.WriteLine("Room established!");
    }

    public Tile getRandomWall(Tile[][] tiles) {
        Random random = new Random();
        if(random.Next(0,2) == 0) {
            if (random.Next(0, 2) == 0) {
                return tiles[coordX][coordY + random.Next(1, length - 1)];
            }
            else {
                return tiles[coordX+width][coordY + random.Next(1, length - 1)];
            }
        }else {
            if (random.Next(0, 2) == 0) {
                return tiles[coordX + random.Next(1, width - 1)][coordY];
            }
            else {
                return tiles[coordX + random.Next(1, width - 1)][coordY+length];
            }
        }
    }

    /* Get a random tile from specific wall
     * direction == 0 => north
     * direction == 1 => east
     * direction == 2 => south
     * direction == 3 => west */
    public Tile getRandomWallSpecific(Tile[][] tiles, int direction) {
        Random random = new Random();
        if (direction == 0) {
            return tiles[coordX + width][coordY + random.Next(1, length)];
        }
        if (direction == 1) {
            return tiles[coordX + random.Next(1, width)][coordY + length];
        }
        if (direction == 2) {
            return tiles[coordX + width][coordY + random.Next(1, length)];
        }
        if (direction == 3) {
            return tiles[coordX + random.Next(1, width)][coordY];
        }
        return null;
    }
}
