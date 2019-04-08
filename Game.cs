using System;
using System.Collections;
using System.Collections.Generic;

public class Game{

    public static List<Layer> dungeon;
    public static int numberOfLayers = 1;
    public static int dungeonWidth = 50;
    public static int dungeonLength = 80;

    static void Main(string[] args) {
        dungeon = DungeonCreator.createDungeon(numberOfLayers, dungeonWidth, dungeonLength);
        //Console.Write("debug");
        drawDungeon(0);
        Console.ReadLine();
    }

    public static void drawDungeon(int layerNumber) {
        for (int i = 0; i < dungeonWidth; i++) {
            foreach (Tile t in dungeon[layerNumber].getTiles()[i]) {
                try {
                    Console.Write(t.getSymbol());
                }catch(Exception e) {

                }
            }
            Console.WriteLine("");
        }
    }
}
