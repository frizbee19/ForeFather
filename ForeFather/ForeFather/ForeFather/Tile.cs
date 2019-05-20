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

        private Color color;
    
        private bool isWalkable;

        private bool isEnemy;
  

        public bool getEnemy { get { return isEnemy; }   set { isEnemy = value; }   }
            
        

        public Tile() : base()
        {
            
        }

        public Tile(Texture2D s, Rectangle sR) 
        {
            spriteSheet = s;
            sourceRect = sR;
            color = Color.White;
            isEnemy = false;
        }

        public Tile(Texture2D s, Rectangle sR, Rectangle p)
        {
            spriteSheet = s;
            sourceRect = sR;
            position = p;
            color = Color.White;
            isEnemy = false;
        }

        public Tile(Texture2D s, Rectangle sR, Rectangle p, bool isWalk)
        {
            spriteSheet = s;
            sourceRect = sR;
            position = p;
            isWalkable = isWalk;
            color = Color.White;
            isEnemy = false;
        }

        public Tile(Texture2D s, Rectangle sR, Rectangle p, bool isWalk, Color c)
        {
            spriteSheet = s;
            sourceRect = sR;
            position = p;
            isWalkable = isWalk;
            color = Color.Black;
            isEnemy = false;
        }

        public Rectangle getPos()
        {
            return position;
        }

        public bool getWalk()
        {
            return isWalkable;
        }


        public void setWalk(bool walk)
        {
            isWalkable = walk;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteSheet, position, sourceRect, color);
        }

    }
}
