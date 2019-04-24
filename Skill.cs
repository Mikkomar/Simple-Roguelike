using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Skill {
    private static string name;
    private int level;
    private string type;

    public Skill(string n, int l, string t) {
        name = n;
        level = l;
        type = t;
    }

    public Skill() {

    }

    public void setLevel(int n) {
        level = n;
    }
}

