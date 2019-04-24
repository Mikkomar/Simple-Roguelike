using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Item {

    protected string name;
    protected ItemType type;
    protected int weight;
    protected char symbol;
    protected Tile tile;

    public Item(string n, string t) {
        name = n;
        switch (t) {
            case "Swords":
                type = ItemType.weaponSword;
                break;
            case "Axes":
                type = ItemType.weaponAxe;
                break;
            case "Hammers":
                type = ItemType.weaponHammer;
                break;
            case "Polearms":
                type = ItemType.weaponPolearm;
                break;
            case "Bows":
                type = ItemType.weaponBow;
                break;
            case "Unarmed":
                type = ItemType.weaponUnarmed;
                break;
            case "Heavy Armor":
                type = ItemType.heavyArmor;
                break;
            case "Light Armor":
                type = ItemType.lightArmor;
                break;
            case "Destruction":
                type = ItemType.spellDestruction;
                break;
            case "HealthPotion":
                type = ItemType.potionHealth;
                break;
            case "DamagePotion":
                type = ItemType.potionDamage;
                break;
        }
    }

    public Item(string n, string t, Tile til) {
        name = n;
        tile = til;
        til.setItem(this);
        switch (t) {
            case "Swords":
                type = ItemType.weaponSword;
                break;
            case "Axes":
                type = ItemType.weaponAxe;
                break;
            case "Hammers":
                type = ItemType.weaponHammer;
                break;
            case "Polearms":
                type = ItemType.weaponPolearm;
                break;
            case "Bows":
                type = ItemType.weaponBow;
                break;
            case "Unarmed":
                type = ItemType.weaponUnarmed;
                break;
            case "Heavy Armor":
                type = ItemType.heavyArmor;
                break;
            case "Light Armor":
                type = ItemType.lightArmor;
                break;
            case "Destruction":
                type = ItemType.spellDestruction;
                break;
            case "HealthPotion":
                type = ItemType.potionHealth;
                break;
            case "DamagePotion":
                type = ItemType.potionDamage;
                break;
        }
    }

    public Item(string n, ItemType t, Tile til) {
        name = n;
        tile = til;
        til.setItem(this);
        type = t;
    }

    override public string ToString() {
        return name;
    }

    public string getName() {
        return name;
    }

    public Tile getTile() {
        return tile;
    }

    public char getSymbol() {
        return symbol;
    }

    public bool canPickUp(Character c) {
        return c.getTile() == tile; // Can pick up if on the same tale as character
    }

    public ItemType getType() {
        return type;
    }
}

public enum ItemType {
    weaponSword,
    weaponAxe,
    weaponHammer,
    weaponPolearm,
    weaponBow,
    weaponUnarmed,
    heavyArmor,
    lightArmor,
    spellDestruction,
    potionHealth,
    potionDamage
}
