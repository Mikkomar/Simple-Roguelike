using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class Armor : Item{

    private ArmorType armorType;
    private int baseDefense;

    public Armor(string n, string ty, string at, int bd) : base(n, ty) {
        baseDefense = bd;
        symbol = 'A';
        switch (at) {
            case "Helmet":
                armorType = ArmorType.helmet;
                break;
            case "Cuirass":
                armorType = ArmorType.cuirass;
                break;
            case "Gauntlets":
                armorType = ArmorType.gauntlets;
                break;
            case "Boots":
                armorType = ArmorType.boots;
                break;
        }
    }

    public Armor(string n, ItemType it, ArmorType ty, int bd, Tile til) : base(n, it, til) {
        baseDefense = bd;
        symbol = 'A';
        armorType = ty;
    }

    public ArmorType getArmorType() {
        return armorType;
    }

    public int getBaseDefense() {
        return baseDefense;
    }
}

public enum ArmorType {
    helmet,
    cuirass,
    gauntlets,
    boots
}
