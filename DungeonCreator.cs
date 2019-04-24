using System;
using System.Collections;
using System.Collections.Generic;

public static class DungeonCreator
{
    public static List<Layer> createDungeon(int layers, int width, int length) {
        List<Layer> dungeon = new List<Layer>();
        /* Create layers */
        for(int i = 0; i < layers; i++) {
            dungeon.Add(createLayer(width, length));
        }
        /* Add ladders to every layers except the last one */
        for(int i = 0; i < dungeon.Count-1; i++) {
            dungeon[i].addLadder();
        }
        /* Add the final boss to the last level */
        dungeon[dungeon.Count - 1].addDragon();
        return dungeon;
    }

    private static Layer createLayer(int width, int length) {
        return new Layer(width, length);
    }
}
