using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Weapon : Item{

    private int baseDamage;
    private int critChance;
    private int evadeChance;
    private Skill skill;

    public Weapon(string n, string ty, int bd, int cc, int ec) : base(n, ty) {
        baseDamage = bd;
        critChance = cc;
        evadeChance = ec;
        symbol = 'w';
    }

    public Weapon(string n, string ty, int bd, int cc, int ec, Tile ti) : base(n, ty, ti) {
        baseDamage = bd;
        critChance = cc;
        evadeChance = ec;
        symbol = 'w';
    }

    public Weapon(string n, ItemType ty, int bd, int cc, int ec, Tile ti) : base(n, ty, ti) {
        baseDamage = bd;
        critChance = cc;
        evadeChance = ec;
        symbol = 'w';
    }


    public int getBaseDamage() {
        return baseDamage;
    }

    public int getCritChance() {
        return critChance;
    }

    public int getEvadeChance() {
        return evadeChance;
    }
}
