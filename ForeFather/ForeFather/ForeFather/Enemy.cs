using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeFather
{
    class Enemy : Character
    {
        private int maxhp;
        private int offense;
        private int defense;
        private int luck;
        private int mana;
        private string name;

        public Enemy(string name, int hp, int off, int def, int luck, int mana) : base(name, hp, off, def, luck, mana)
        {
        }

        public override void enterCombat()
        {
           
        }

        public override void think()
        {
            
        }

        public override void targeting()
        {
            
        }

        public override void attack()
        {
            
        }

        public override void useMagic()
        {
            
        }

        public override void useGoods()
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
