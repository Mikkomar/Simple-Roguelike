using System;

public class Character
{

    protected string name;
    protected Race race;
    protected Class characterClass;
    protected char symbol;

    protected int maxHealth;
    protected int health;
    protected Tile currentTile;

    protected Inventory inventory;
    protected Weapon weapon;
    protected Armor helmet;
    protected Armor cuirass;
    protected Armor gauntlets;
    protected Armor boots;


	public Character(string nname, int maxH, Race rrace, Class cclass, char sym, Tile t)
	{
        name = nname;
        maxHealth = maxH;
        health = maxH;
        race = rrace;
        characterClass = cclass;
        symbol = sym;
        currentTile = t;
        t.setCharacter(this);
	}

    public Character(string nname, int maxH, Race rrace, Class cclass, char sym) {
        name = nname;
        maxHealth = maxH;
        health = maxH;
        race = rrace;
        characterClass = cclass;
        symbol = sym;
    }

    /* Used to move a character from one tile to another */
    public void moveCharacter(Tile t) {
        currentTile.setCharacter(null);
        currentTile = t;
        t.setCharacter(this);
    }

    public string attack(Character c) {
        int damage = calculateDamageDone();
        bool crit = checkCritical();
        bool ev = checkEvasion();
        if (ev) {
            return "It missed! "; // If missed
        }
        else {
            if (crit) {
                damage += 2;
            }
            c.damageHealth(damage);
            if (crit) {
                return "Critical hit! "; // If crit
            }
            else {
                return ""; // If no crit or miss
            }
        }
    }

    public bool checkCritical() {
        Random critChecker = new Random();
        /* Check if critical hit */
        if(critChecker.Next(0,101) <= weapon.getCritChance()) {
            return true;
        }
        else {
            return false;
        }
    }

    public bool checkEvasion() {
        Random evChecker = new Random();
        /* Check if missed */
        if (evChecker.Next(0, 101) <= weapon.getEvadeChance()) {
            return true;
        }
        else {
            return false;
        }
    }

    public void checkHealth() {
        if(health <= 0) {
            killCharacter();
        }
    }

    public bool isAlive() {
        return health > 0;
    }

    public int getHealth() {
        return health;
    }

    public void setHealth(int h) {
        health = h;
    }

    public void damageHealth(int h) {
        health -= h;
    }

    public void restoreHealth(int h) {
        health += h;
        if(health > maxHealth) {
            health = maxHealth;
        }
    }

    public int getMaxHealth() {
        return maxHealth;
    }

    public void setWeapon(Weapon w) {
        weapon = w;
    }

    public Weapon getWeapon() {
        return weapon;
    }

    public int calculateDamageDone() {
        return weapon.getBaseDamage();
    }

    public void killCharacter() {
        currentTile.setCharacter(null);
        currentTile = null;
    }

    public void equipArmor(Armor a) {
        switch (a.getArmorType()) {
            case ArmorType.helmet:
                helmet = a;
                break;
            case ArmorType.cuirass:
                cuirass = a;
                break;
            case ArmorType.gauntlets:
                gauntlets = a;
                break;
            case ArmorType.boots:
                boots = a;
                break;
        }
    }

    public char getSymbol() {
        return symbol;
    }

    public Tile getTile() {
        return currentTile;
    }

    public string getName() {
        return name;
    }

    public Class getClass() {
        return characterClass;
    }

    public Race getRace() {
        return race;
    }

    public Inventory getInventory() {
        return inventory;
    }

    public void sortInventory() {
        inventory.sortInventory();
    }

    public void setTile(Tile t) {
        currentTile = t;
        t.setCharacter(this);
    }

    public void setHelmet(Armor a) {
        if (a.getArmorType() == ArmorType.helmet) {
            helmet = a;
        }
    }

    public void setCuirass(Armor a) {
        if (a.getArmorType() == ArmorType.cuirass) {
            cuirass = a;
        }
    }

    public void setGauntlets(Armor a) {
        if (a.getArmorType() == ArmorType.gauntlets) {
            gauntlets = a;
        }
    }

    public void setBoots(Armor a) {
        if (a.getArmorType() == ArmorType.boots) {
            boots = a;
        }
    }

    public Armor getHelmet() {
        return helmet;
    }

    public Armor getCuirass() {
        return cuirass;
    }

    public Armor getGauntlets() {
        return gauntlets;
    }

    public Armor getBoots() {
        return boots;
    }


}
