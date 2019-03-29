using System;
using System.Collections;
using System.Collections.Generic;

public static class DungeonCreator
{
    public static List<Layer> createDungeon(int layers, int width, int length) {
        List<Layer> dungeon = new List<Layer>();
        for(int i = 0; i < layers; i++) {
            dungeon.Add(createLayer(width, length));
        }
        Console.WriteLine("Dungeon created!");
        return dungeon;
    }

    private static Layer createLayer(int width, int length) {
        return new Layer(width, length);
    }
}
