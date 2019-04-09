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
    class Combat
    {
        private List<Ally> allies;
        private List<Enemy> enemies;
        private bool turn;
        Random rand = new Random();

        public Combat(List<Ally> allies, List<Enemy> enemies)
        {
            this.allies = allies;
            this.enemies = enemies;

            if (rand.Next(1) == 0)
                turn = false;
            else
                turn = true;
        }

        public void update()
        {
            if (turn == true)
            {
                for()
            }
        }

    }
}
