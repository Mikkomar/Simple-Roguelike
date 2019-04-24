using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class PlayerCharacter : Character{

    private List<Skill> skills; // Not in use

    /* Player character */
    public PlayerCharacter(string nname, int h, Race rrace, Class cclass, Char sym, Tile t) : base(nname, h, rrace, cclass, sym, t){
        skills = new List<Skill>();
        Random skillPicker = new Random();
        /* SKILLS NOT IN USE IN THIS  BUILD */
        foreach(Skill s in skills) {
            s.setLevel(skillPicker.Next(1, 4));
        }
        /* Add an inventory for storing items */
        inventory = new Inventory();
        /* Add starting weapon */
        inventory.addItem(Game.availableWeapons[0]);
        setWeapon(inventory.getWeapons()[0]);
    }

}

