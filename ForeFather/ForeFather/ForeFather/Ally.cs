
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
    public class Ally
    {
        private int maxhp;

        private int offense;

        private int defense;

        private int luck;

        private int mana;

        private string name;

        private int curHP;

        private int XP;

        private int level;

        private int maxMana;

        private Armor armor;

        private Crystal crystal;

        private Weapon weapon;

        Ability test = new Ability("test", "damageOverTime");

        public Ability getAbility { get { return test; } }

        public string getName { get { return name; } set { name = value; } }

        public int getMaxHp { get { return maxhp; } set { maxhp = value; } }

        public int getOffense { get { return offense; } set { offense = value;  } }

        public int getDefense { get { return defense; } set { defense = value; } }

        public int getLuck { get { return luck; } set { luck = value; } }

        public int getMana { get { return mana; } set { mana = value; } }

        public int getCurHp { get { return curHP; } set { curHP = value; } }

        public int getXP { get; set; }

        public int getLevel { get; set; }

        public int getMaxMana { get; set; }

        public Armor getArmor { get; set; }

        public Weapon getWeapon { get; set; }

        public Crystal getCrystal { get; set; }


        public int TotalDmg;

        protected int bashDmg;

        public Ally(string name, int hp, int off, int def, int luck, int mana)
        {
            this.maxhp = hp;

            this.offense = off;

            this.defense = def;

            this.luck = luck;

            this.maxMana = mana;

            this.mana = maxMana;

            this.name = name;

            this.curHP = maxhp;

            this.XP = 0;

            this.level = 0;
            bashDmg = 5 * (1 + ((offense / 100) - (defense / 100)));
        }

        public void attack(Enemy target) //basic attack
        {
            target.getCurHp -= bashDmg; 
        }

        public void useMagic() //takes a ability object as parameter
        {

        }

        public void useGoods() //takes a inventory item as parameter
        {

        }


        public void runAway()
        {

        }

        public void faint()
        {

        }

    }
}
