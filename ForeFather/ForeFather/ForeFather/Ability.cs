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
    abstract class Ability
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
            if (checkEffect() == false)
                throw new Exception("invalid effect"); 
        }

        public bool checkEffect()
        {
            bool returnVar = false;
            for (int i = 0; i < effect.Length; i++)
                if (effect == effects[i])
                    returnVar = true;
                else
                    returnVar = false;

            return returnVar;        
        }
    }
}
