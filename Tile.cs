using System;
using System.Collections;
using System.Collections.Generic;

public class Tile
{

    private bool walkable;
    private char tileSymbol;
    private Character character;

	public Tile(char symbol){
        tileSymbol = symbol;
	}

    public char getSymbol() {
        return tileSymbol;
    }
}
