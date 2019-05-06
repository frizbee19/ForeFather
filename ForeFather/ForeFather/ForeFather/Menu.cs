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
using System.IO;

namespace ForeFather
{
    class Menu : TextBox
    {
        private List<Ally> allies;
        private int curOption;
        private List<TextBox> options;

        public Menu(string p, ContentManager content, string name) : base(p, false, content, name)
        {
            allies = new List<Ally>();
            options = new List<TextBox>();
            curOption = 0;
        }
        //controls
        public void Update(KeyboardState kb, KeyboardState oldKB)
        {
            if(kb.IsKeyDown(Keys.Down) && !oldKB.IsKeyDown(Keys.Down))
            {
                if(curOption == options.Count - 1)
                {
                    curOption = 0;
                }
                else
                {
                    curOption++;
                }
            }
            if (kb.IsKeyDown(Keys.Up) && !oldKB.IsKeyDown(Keys.Up))
            {
                if (curOption == 0)
                {
                    curOption = options.Count - 1;
                }
                else
                {
                    curOption--;
                }
            }
            //if(kb.IsKeyDown(Keys.Enter))
        }
    }
}
