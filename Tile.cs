using System;
using System.Collections;
using System.Collections.Generic;

public class Tile
{

    protected bool walkable;
    protected char tileSymbol;
    protected Character character;
    protected int coordX;
    protected int coordY;

	public Tile(char symbol, bool walk, int x, int y){
        tileSymbol = symbol;
        walkable = walk;
        coordX = x;
        coordY = y;
	}

    #region Gets and Sets
    public char getSymbol() {
        return tileSymbol;
    }

    public void setTileSymbol(char s) {
        tileSymbol = s;
    }

    public Character getCharacter() {
        return character;
    }

    public void setCharacter(Character c) {
        character = c;
    }

    public bool isWalkable() {
        return walkable;
    }
    
    public void setWalkable(bool w) {
        walkable = w;
    }

    public int getCoordX() {
        return coordX;
    }

    public int getCoordY() {
        return coordY;
    }
    #endregion
}
