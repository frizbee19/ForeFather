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
    class Ally : Character
    {
        //private int maxhp;
        //private int offense;
        //private int defense;
        //private int luck;
        //private int mana;
        //private string name;

        public Ally(string name, int hp, int off, int def, int luck, int mana) : base(name, hp, off, def, luck, mana)
        {

        }

        public override void enterCombat()
        {

        }
        public override void think() //option selection in combat
        {

        }
        public override void targeting() //target selection
        {

        }
        public override void attack(Enemy target) //basic attack
        {
            target.getCurHp -= 10;
            getTurn = false;
        }
        public override void attack(Ally target)
        {

        }
        public override void useMagic() //takes a ability object as parameter
        {

        }
        public override void useGoods() //takes a inventory item as parameter
        {

        }

        public override void runAway()
        {

        }
        public override void faint()
        {

        }
        public override void exitCombat()
        {

        }

    }
}
