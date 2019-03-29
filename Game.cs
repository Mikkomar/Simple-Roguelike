using System;
using System.Collections;
using System.Collections.Generic;

public class Game{

    public static List<Layer> dungeon;
    public static int numberOfLayers = 3;
    public static int dungeonWidth = 80;
    public static int dungeonLength = 50;

    static void Main(string[] args) {
        dungeon = DungeonCreator.createDungeon(numberOfLayers, dungeonWidth, dungeonLength);
        //Console.Write("debug");
        drawDungeon(0);
        Console.ReadLine();
    }

    public static void drawDungeon(int layerNumber) {
        for (int i = 0; i < dungeonWidth; i++) {
            foreach (Tile t in dungeon[layerNumber].getTiles()[i]) {
                Console.Write(t.getSymbol());
            }
            Console.WriteLine("");
        }
    }
}
