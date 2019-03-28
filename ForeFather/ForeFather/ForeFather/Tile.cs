using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeFather
{
    class Tile
    {

        private Texture2D spriteSheet;
        private Rectangle sourceRect;
        private Rectangle position;

        public Tile()
        {
            
        }

        public Tile(Texture2D s, Rectangle sR)
        {
            spriteSheet = s;
            sourceRect = sR;
        }

        public Tile(Texture2D s, Rectangle sR, Rectangle p)
        {
            spriteSheet = s;
            sourceRect = sR;
            position = p;
        }

        public Rectangle getPos()
        {
            return position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, position, sourceRect, Color.White);
        }

    }
}
