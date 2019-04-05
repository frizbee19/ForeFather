using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
        private bool turn;
        private int curHP;

        public bool getTurn { get; set; }
        public int getMaxHp { get; set; }
        public int getOffense { get; set; }
        public int getDefense { get; set; }
        public int getLuck { get; set; }
        public int getMana { get; set; }
        public int getCurHp { get; set; }

        public Character(string name, int hp, int off, int def, int luck, int mana)
        {
            this.maxhp = hp;
            this.offense = off;
            this.defense = def;
            this.luck = luck;
            this.mana = mana;
            this.name = name;
            this.curHP = maxhp;
            this.turn = false;
        }

        abstract public void enterCombat();
        abstract public void think(); //option selection in combat
        abstract public void targeting(); //target selection
        abstract public void attack(Enemy target);
        abstract public void attack(Ally target); //basic attack
        abstract public void useMagic(); //takes a ability object as parameter
        abstract public void useGoods(); //takes a inventory item as parameter
        abstract public void runAway();
        abstract public void faint();
        abstract public void exitCombat();
        

    }
}
