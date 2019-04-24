using System;
using System.Collections;
using System.Collections.Generic;

public class Tile
{

    protected bool walkable;
    protected char tileSymbol;
    protected Character character;
    protected Item item;
    protected int coordX;
    protected int coordY;

    /* A* algorithm */
    protected int cost;
    protected int heuristic;
    protected int totalCost;
    protected Tile parentTile;

	public Tile(char symbol, bool walk, int x, int y){
        tileSymbol = symbol;
        walkable = walk;
        coordX = x;
        coordY = y;
	}

    #region Gets and Sets
    public char getSymbol() {
        if (character != null) {
            return character.getSymbol();
        }
        if (item != null) {
            return item.getSymbol();
        }
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
    
    public bool getWalkable() {
        return walkable;
    }

    public int getTotalCost() {
        return totalCost;
    }
    
    public int getCost() {
        return cost;
    }

    public int getHeuristic() {
        return heuristic;
    }

    public void setCost(int n) {
        cost = n;
    }

    public void setHeuristic(int n) {
        heuristic = n;
    }

    public void calculateTotalCost() {
        totalCost = cost + heuristic;
    }

    public void setParent(Tile t) {
        parentTile = t;
    }

    public Tile getParentTile(){
        return parentTile;
    }

    public void setItem(Item i) {
        item = i;
    }

    public void deleteItem() {
        item = null;
    }

    public Item getItem() {
        return item;
    }
    #endregion
}
