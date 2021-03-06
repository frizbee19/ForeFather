﻿using Microsoft.Xna.Framework;
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
        private Door door;



        public Building()
        {

        }

        public Building(Texture2D s, int nX, int nY)
        {
            x = nX;
            y = nY;
            spriteSheet = s;
            door = null;

        }

        public Building( int nX, int nY)
        {
            x = nX;
            y = nY;
            door = null;

        }

        public Building(Texture2D s, Rectangle p) 
        {
            spriteSheet = s;
            position = p;
            door = null;
        }

        public Building(Rectangle p)
        {
            spriteSheet = null;
            position = p;
            door = null;
        }

        public Rectangle getPos()
        {
            return position;
        }

        public void setSize(int secondX, int secondY)
        {
            position = new Rectangle(x, y, secondX-x, secondY-y);
        }

        public Door getDoor()
        {
            return door;
        }

        public void setDoor(Door d)
        {
            door = d;
        }

        public void changeDoorSize(int howMuchWidth, int howMuchHeight)
        {
            door.setSize(howMuchWidth, howMuchHeight);
        }

        public bool hasDoor()
        {
            if (door != null)
                return true;
            return false;
        }

        public bool Intersects(Rectangle r)
        {
            if (r.Intersects(position) && (r.Y >= position.Y && r.Y+r.Height<=position.Y+position.Height) && (r.X >= position.X && r.X + r.Width <= position.X + position.Width))
                return true;
            return false;
        }

        public bool Intersects(Player p)
        {
            if (p.getPos().X>=position.X && p.getPos().X+p.getPos().Width<=position.X+position.Width && p.getPos().Y>=position.Y && p.getPos().Y+p.getPos().Height<=position.Y+position.Height)
                return true;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch, Player p)
        {
            if(spriteSheet!=null)
            spriteBatch.Draw(spriteSheet, position, Color.White);
            if (door != null)
                door.Draw(spriteBatch, p);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (spriteSheet != null)
                spriteBatch.Draw(spriteSheet, position, Color.White);
        }
    }
}
