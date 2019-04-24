using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Inventory {

    private List<Weapon> weapons;
    private List<Armor> armor;
    private List<Spell> spells;
    private List<Potion> potions;

    public Inventory() {
        weapons = new List<Weapon>();
        armor = new List<Armor>();
        spells = new List<Spell>();
        potions = new List<Potion>();
    }

    /* Sorts inventory */
    public void sortInventory() {
        weapons.OrderBy(x => x.getName());
        armor.OrderBy(x => x.getName());
        spells.OrderBy(x => x.getName());
        potions.OrderBy(x => x.getName());
    }

    /* Remove item from inventory */
    public void removeItem(Item i) {
        if (weapons.Contains(i)) {
            weapons.Remove((Weapon)i);
        }
        if (armor.Contains(i)) {
            armor.Remove((Armor)i);
        }
        if (spells.Contains(i)) {
            spells.Remove((Spell)i);
        }
        if (potions.Contains(i)) {
            potions.Remove((Potion)i);
        }
        sortInventory();
    }

    /* Add item to inventory */
    public void addItem(Item i) {
        switch (i.getType()){
            case ItemType.weaponSword:
                weapons.Add((Weapon)i);
                break;
            case ItemType.weaponAxe:
                weapons.Add((Weapon)i);
                break;
            case ItemType.weaponHammer:
                weapons.Add((Weapon)i);
                break;
            case ItemType.weaponPolearm:
                weapons.Add((Weapon)i);
                break;
            case ItemType.weaponBow:
                weapons.Add((Weapon)i);
                break;
            case ItemType.heavyArmor:
                armor.Add((Armor)i);
                break;
            case ItemType.lightArmor:
                armor.Add((Armor)i);
                break;
            case ItemType.spellDestruction:
                spells.Add((Spell)i);
                break;
            case ItemType.potionHealth:
                potions.Add((Potion)i);
                break;
            case ItemType.potionDamage:
                potions.Add((Potion)i);
                break;
        }
        sortInventory();
    }

    public List<Weapon> getWeapons() {
        return weapons;
    }

    public List<Armor> getArmor() {
        return armor;
    }

    public List<Spell> getSpells() {
        return spells;
    }

    public List<Potion> getPotions() {
        return potions;
    }
}

