using System;
using System.Collections;
using System.Collections.Generic;

public class Layer{

    private int width;
    private int length;
    private Tile[][] tiles;

    public Layer(int w, int l){
        width = w;
        length = l;
        tiles = new Tile[width][];

        for(int i = 0; i < width; i++) {
            tiles[i] = new Tile[length];
            for(int j = 0; j < length; j++) {
                tiles[i][j] = new Tile('a');
                //Console.WriteLine("Layer created!");
            }
        }
	}

    public Tile[][] getTiles() {
        return tiles;
    }
}
