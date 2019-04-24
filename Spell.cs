using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

   public class Spell : Item {

    private int baseDamage;
    private int critChance;
    private int evadeChance;
    private Skill skill;

    public Spell(string n, string ty, int bd, int cc, int ec) : base(n, ty) {
        baseDamage = bd;
        critChance = cc;
        evadeChance = ec;
        symbol = 's';
    }

    public Spell(string n, ItemType ty, int bd, int cc, int ec, Tile til) : base(n, ty, til) {
        baseDamage = bd;
        critChance = cc;
        evadeChance = ec;
        symbol = 's';
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
