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
    public class Ability
    {
        //bruh
        const int baseDamage = 2;
        string name;
        string effect;

        string[] effects = {"damageOverTime", "stun"};

        public Ability (string n, string e)
        {
            name = n;
            effect = e;
        }
        
        public void applyDoT(int numRounds, int damageValue, Enemy enemy, Combat combat)
        {
            if (effect.Equals(effects[0]))
            {
                for (int i = 0; i < numRounds; i++)
                {
                    if (!combat.getTurnStatus())
                        enemy.getCurHp -= damageValue;
                }
            }
        }

        public void applyStun(int numRounds, int damageValue, Enemy enemy, Combat combat)
        {
            if (effect.Equals(effects[0]))
            {
                for (int i = 0; i < numRounds; i++)
                {
                    if (combat.getTurnStatus())
                        combat.getIsStunned = true;
                }
            }
        }
    }
}
