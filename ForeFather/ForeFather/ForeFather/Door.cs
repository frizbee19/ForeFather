using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeFather
{
    class Door
    {
        private Texture2D sprite;
        private Rectangle position;

        public Door()
        {

        }

        public Door(Texture2D s)
        {
            sprite = s;
        }

        public Door(Texture2D s, Rectangle pos)
        {
            sprite = s;
            position = pos;
        }

        public void Draw(SpriteBatch spriteBatch, Color draw)
        {
            spriteBatch.Draw(sprite, position, draw);
        }

    }
}
