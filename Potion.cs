using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class Potion : Item {

    private int restoreHealth;
    private int damageHealth;

    public Potion(string n, string ty, int rh, int dh) : base(n, ty) {
        restoreHealth = rh;
        damageHealth = dh;
        symbol = 'p';
        name = "Potion of " + n;
    }

    public Potion(string n, ItemType ty, int rh, int dh, Tile til) : base(n, ty, til) {
        restoreHealth = rh;
        damageHealth = dh;
        symbol = 'p';
    }

    public int getRestoreHealth() {
        return restoreHealth;
    }

    public int getDamageHealth() {
        return damageHealth;
    }

    public void consume(Character c) {
        c.restoreHealth(restoreHealth);
        c.damageHealth(damageHealth);
    }
}
