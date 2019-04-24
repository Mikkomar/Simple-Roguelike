using System;

public class Room{

    protected int coordX;
    protected int coordY;
    protected int width;
    protected int length;
    protected int[] centerPoint; // centerpoint of the room x,y

    public Room(Tile[][] tiles, int x, int y, int w, int l) {
        coordX = x;
        coordY = y;
        width = w;
        length = l;
        centerPoint = new int[] {coordX + width/2, coordY + length/2};

        /* Change map tiles from given coordinates to given widths into room tiles */
        for (int i = 0; i <= width; i++) {
            for (int j = 0; j <= length; j++) {
                tiles[x + i][y + j] = new Tile('.', true, i + x, j + y);
            }
        }
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

    public int[] getCenterPoint() {
        return centerPoint;
    }

    public int getCoordX() {
        return coordX;
    }

    public int getCoordY() {
        return coordY;
    }

    public int getWidth() {
        return width;
    }

    public int getLength() {
        return length;
    }
}
