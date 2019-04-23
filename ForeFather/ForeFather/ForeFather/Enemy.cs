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
    class Enemy
    {
        private int maxhp;
        private int offense;
        private int defense;
        private int luck;
        private int mana;
        private string name;
        private int curHP;
        private int level;

        public int getMaxHp { get; set; }
        public int getOffense { get; set; }
        public int getDefense { get; set; }
        public int getLuck { get; set; }
        public int getMana { get; set; }
        public int getCurHp { get; set; }
        public int getLevel { get; set; }
        public int totalDmg;

        public Enemy(string name, int hp, int off, int def, int luck, int mana)
        {
            this.maxhp = hp;
            this.offense = off;
            this.defense = def;
            this.luck = luck;
            this.mana = mana;
            this.name = name;
            this.curHP = maxhp;
        }

        public void think()
        {

        }

        public void attack(Ally Target)
        {

        }

        public void useMagic()
        {

        }

        public void useGoods()
        {

        }

        public void faint()
        {

        }

    }
}