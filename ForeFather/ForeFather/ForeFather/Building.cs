using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeFather
{
    class Building 
    {
        private Texture2D spriteSheet;
        private Rectangle position;
        int x, y;

        public Building()
        {

        }

        public Building(Texture2D s, int nX, int nY)
        {
            x = nX;
            y = nY;
            spriteSheet = s;
        }

        public Building(Texture2D s, Rectangle p) 
        {
            spriteSheet = s;
            position = p;
        }

        public void setSize(int secondX, int secondY)
        {
            position = new Rectangle(x, y, secondX-x, secondY-y);
        }
    }
}
