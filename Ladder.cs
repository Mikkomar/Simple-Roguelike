using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ladder : Tile{

    /* A tile to transfer player between dungeon layers */
    public Ladder(char symbol, bool walk, int x, int y) : base(symbol, walk, x, y) {

    }

    public bool climbLadder() {
        /* Check if player is on the ladder */
        if(character == null) {
            return false;
        }
        if(character.GetType() == typeof(PlayerCharacter)) {
            return true;
        }
        else {
            return false;
        }
    }
}
