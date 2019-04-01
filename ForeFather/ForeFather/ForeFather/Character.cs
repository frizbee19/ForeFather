using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeFather
{
    abstract class Character
    {
        private int maxhp;
        private int offense;
        private int defense;
        private int luck;
        private int mana;
        private string name;

        public int getMaxHp { get; set; }
        public int getOffense { get; set; }
        public int getDefense { get; set; }
        public int getLuck { get; set; }
        public int getMana { get; set; }

        public Character(string name, int hp, int off, int def, int luck, int mana)
        {
            this.maxhp = hp;
            this.offense = off;
            this.defense = def;
            this.luck = luck;
            this.mana = mana;
            this.name = name;
        }

        abstract public void enterCombat();
        abstract public void think(); //option selection in combat
        abstract public void targeting(); //target selection
        abstract public void attack(); //basic attack
        abstract public void useMagic(); //takes a ability object as parameter
        abstract public void useGoods(); //takes a inventory item as parameter
        abstract public void runAway();
        abstract public void faint();
        abstract public void exitCombat();
        

    }
}
