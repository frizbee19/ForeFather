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
    class Player
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private Rectangle sourceRectangle;
        private int trail;
        private const int MS = 5;
        private const int WIDTH = 34;
        private const int HEIGTH = 50;
        Keys lastKey;
        string character;

        public Player(ContentManager content, Rectangle rect, int t, int i)
        {
            texture = content.Load<Texture2D>("Assets\\spriteChar");
            rectangle = new Rectangle(rect.X, rect.Y, WIDTH, HEIGTH);
            trail = t;
            
            switch (i)
            {
                case 0:
                    sourceRectangle = new Rectangle(0, 0, 106, 193);
                    character = "mage";
                    break;
                case 1:
                    sourceRectangle = new Rectangle(0, 193, 101, 181);
                    character = "knight";
                    break;
                case 2:
                    sourceRectangle = new Rectangle(0, 374, 101, 185);
                    character = "rouge";
                    break;
                case 3:
                    sourceRectangle = new Rectangle(0, 559, 110, 183);
                    character = "princess?";
                    break;
                default:
                    throw new Exception("The value provided for identifier (i) is invalid. 0 <= i <= 3");
            }
        }

        public void setCoords(int newX, int newY)
        {
            rectangle.X = newX;
            rectangle.Y = newY;
        }

        public void update(Dictionary<string, Building> buildings, map current)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && rectangle.Y>0)
            {
                rectangle.Y -= MS;
                if (Intersects(buildings, current).Equals("0"))//returns zero if it intersects
                    rectangle.Y += MS;

                lastKey = Keys.Up;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && rectangle.Y+rectangle.Height<800)
            {
                rectangle.Y += MS;
                if (Intersects(buildings, current).Equals("0"))//returns zero if it intersects
                    rectangle.Y -= MS;
            
                lastKey = Keys.Down;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && rectangle.X>0)
            {
                rectangle.X -= MS;
                if (Intersects(buildings, current).Equals("0"))//returns zero if it intersects
                    rectangle.X += MS;

                lastKey = Keys.Left;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && rectangle.X + rectangle.Width < 800)
            {
                rectangle.X += MS;
                if (Intersects(buildings, current).Equals("0"))//returns zero if it intersects
                    rectangle.X -= MS;
                lastKey = Keys.Right;
            }


            switch (character)
            {
                case "mage":
                    switch (lastKey)
                    {
                        case Keys.Up:
                            sourceRectangle = new Rectangle(193, 0, 106, 193);
                            break;
                        case Keys.Down:
                            sourceRectangle = new Rectangle(0, 0, 106, 193);
                            break;
                        case Keys.Left:
                            sourceRectangle = new Rectangle(299, 0, 87, 193);
                            break;
                        case Keys.Right:
                            sourceRectangle = new Rectangle(106, 0, 87, 193);
                            break;
                    }
                    break;
                case "knight":
                    switch (lastKey)
                    {
                        case Keys.Up:
                            sourceRectangle = new Rectangle(181, 193, 101, 181);
                            break;
                        case Keys.Down:
                            sourceRectangle = new Rectangle(0, 193, 101, 181);
                            break;
                        case Keys.Left:
                            sourceRectangle = new Rectangle(282, 193, 80, 181);
                            break;
                        case Keys.Right:
                            sourceRectangle = new Rectangle(101, 193, 80, 181);
                            break;
                    }
                    break;
                case "rouge":
                    switch (lastKey)
                    {
                        case Keys.Up:
                            sourceRectangle = new Rectangle(184, 374, 101, 185);
                            break;
                        case Keys.Down:
                            sourceRectangle = new Rectangle(0, 374, 101, 185);
                            break;
                        case Keys.Left:
                            sourceRectangle = new Rectangle(285, 374, 83, 185);
                            break;
                        case Keys.Right:
                            sourceRectangle = new Rectangle(101, 374, 83, 185);
                            break;
                    }
                    break;
                case "princess?":
                    switch (lastKey)
                    {
                        case Keys.Up:
                            sourceRectangle = new Rectangle(188, 559, 110, 183);
                            break;
                        case Keys.Down:
                            sourceRectangle = new Rectangle(0, 559, 110, 183);
                            break;
                        case Keys.Left:
                            sourceRectangle = new Rectangle(298, 559, 78, 183);
                            break;
                        case Keys.Right:
                            sourceRectangle = new Rectangle(110, 559, 78, 183);
                            break;
                    }
                    break;
            }

        }

        public bool Intersects(Rectangle r)
        {
            if (r.Intersects(rectangle))
                return true;
            return false;
        }

        public string Intersects(Dictionary<string, Building> buildings, map currentMap)
        {
            foreach (KeyValuePair<string, Building> kvp in buildings)
            {
                if (currentMap == map.Town && (kvp.Value.getPos().Intersects(rectangle) && kvp.Value.getDoor().Intersects(rectangle)))
                    return kvp.Key;
                if (currentMap != map.Town && currentMap != map.Wild && kvp.Value.Intersects(rectangle))
                {
                    switch (kvp.Key)
                    {
                        case "1": if (currentMap == map.ConShop) { return kvp.Key; } break;
                        case "2": if (currentMap == map.EquiShop) { return kvp.Key; } break;
                        case "b": if (currentMap == map.Bank) { return kvp.Key; } break;
                        case "i": if (currentMap == map.Inn) { return kvp.Key; } break;
                        case "h": if (currentMap == map.Hospital) { return kvp.Key; } break;
                        default: return "0";
                    }
                }
                else if(kvp.Value.getPos().Intersects(rectangle) || (currentMap != map.Town && currentMap != map.Wild && !kvp.Value.Intersects(rectangle)))
                {
                    return "0";
                }
            }
            return "";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, sourceRectangle, Color.White);
        }


    }
}
