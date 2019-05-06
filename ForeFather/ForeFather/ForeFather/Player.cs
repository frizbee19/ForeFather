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

        public map update(Dictionary<string, Building> buildings, map current, Tile[,] tiles)
        {
            int currentGridX = rectangle.X / 50;
            if (rectangle.X >= 800)
                currentGridX = 0;
            int currentGridY = rectangle.Y / 50;
            if (rectangle.Y >= 800)
                currentGridY = 0;


            if (Keyboard.GetState().IsKeyDown(Keys.Up) && rectangle.Y > 0)
            {
                rectangle.Y -= MS;
                if (currentGridX < 15)
                {
                    if (tiles[currentGridX + 1, currentGridY].Intersects(this) || tiles[currentGridX, currentGridY].Intersects(this))
                    {
                        rectangle.Y += MS;
                    }
                    else if(currentGridY<15 && tiles[currentGridX, currentGridY + 1].Intersects(this))
                        {
                            rectangle.Y += MS;
                        }
                }
                else if (currentGridY < 15)
                {
                    rectangle.Y += MS;
                }
                else if (tiles[currentGridX, currentGridY].Intersects(this) || Intersects(buildings, current).Equals("0") && current != map.Wild1 && current != map.Wild2 && current != map.Wild3)//returns zero if it intersects
                rectangle.Y += MS;

                lastKey = Keys.Up;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && rectangle.Y <= 0)
            {
                rectangle.Y -= MS;
                if (current == map.Town)
                {
                    rectangle.Y = 800;
                    current = map.Wild2;
                }
                else
                    rectangle.Y += MS;

                lastKey = Keys.Up;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && rectangle.Y+rectangle.Height<800)
            {
                rectangle.Y += MS;
                if (currentGridX < 15)
                {
                    if (tiles[currentGridX + 1, currentGridY].Intersects(this) || tiles[currentGridX, currentGridY].Intersects(this))
                    {
                        rectangle.Y -= MS;
                    }
                }
                else if (currentGridY < 15)
                {
                    if (tiles[currentGridX, currentGridY + 1].Intersects(this) || tiles[currentGridX, currentGridY].Intersects(this))
                    {
                        rectangle.Y -= MS;
                    }
                }
                else if (tiles[currentGridX, currentGridY].Intersects(this) || Intersects(buildings, current).Equals("0") && current != map.Wild1 && current != map.Wild2 && current != map.Wild3)//returns zero if it intersects
                    rectangle.Y -= MS;

                lastKey = Keys.Down;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && rectangle.Y + rectangle.Height >= 800)
            {
                rectangle.Y += MS;
                
                if (current == map.Wild2)
                {
                    rectangle.Y = 0;
                    current = map.Town;
                    if (Intersects(buildings, current).Equals("0"))
                    {
                        rectangle.Y = 800-rectangle.Height;
                        current = map.Wild2;
                    }
                }
                else
                    rectangle.Y -= MS;

                lastKey = Keys.Down;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && rectangle.X>0)
            {
                rectangle.X -= MS;
                if (tiles[currentGridX, currentGridY].Intersects(this) || Intersects(buildings, current).Equals("0") && current != map.Wild1 && current != map.Wild2 && current != map.Wild3)//returns zero if it intersects
                    rectangle.X += MS;

                lastKey = Keys.Left;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && rectangle.X <= 0)
            {
                rectangle.X -= MS;
                if (current == map.Wild2)
                {
                    rectangle.X = 800-rectangle.Width;
                    current = map.Wild1;
                }
                else if (current == map.Wild3)
                {
                    rectangle.X = 800 - rectangle.Width;
                    current = map.Wild2;
                }
                else
                    rectangle.X += MS;

                lastKey = Keys.Left;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && rectangle.X + rectangle.Width < 800)
            {
                rectangle.X += MS;
                if (tiles[currentGridX, currentGridY].Intersects(this) || Intersects(buildings, current).Equals("0") && current!=map.Wild1 && current != map.Wild2 && current != map.Wild3)//returns zero if it intersects
                    rectangle.X -= MS;
                lastKey = Keys.Right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && rectangle.X + rectangle.Width >= 800)
            {
                rectangle.X += MS;
                if (current == map.Wild1)
                {
                    rectangle.X = 0;
                    current = map.Wild2;
                }
                else if (current == map.Wild2)
                {
                    rectangle.X = 0;
                    current = map.Wild3;
                }
                else
                    rectangle.X -= MS;

                lastKey = Keys.Left;
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
            return current;
        }

        public Rectangle getPos()
        {
            return rectangle;
        }

        public bool Intersects(Rectangle r)
        {
            if (r.Intersects(rectangle))
                return true;
            return false;
        }

        public string Intersects(Dictionary<string, Building> buildings, map currentMap)
        {
            string what="";
            foreach (KeyValuePair<string, Building> kvp in buildings)
            {
                switch (kvp.Key)
                {
                    case "1": if (currentMap != map.ConShop) { what = "!"; } break;
                    case "2": if (currentMap != map.EquiShop) { what = "!"; } break;
                    case "3":
                    case "h": if (currentMap != map.Hospital) { what = "!"; } break;
                    case "4":
                    case "i": if (currentMap != map.Inn) { what = "!"; } break;
                    case "5":
                    case "b": if (currentMap != map.Bank) { what = "!"; } break;
                    default: break;
                }
                if (currentMap == map.Town && (kvp.Value.getPos().Intersects(rectangle) && kvp.Value.getDoor().Intersects(rectangle)))
                    return kvp.Key;
                if (currentMap != map.Town && currentMap != map.Wild1 && currentMap != map.Wild2 && currentMap != map.Wild3 && (kvp.Value.Intersects(this) && kvp.Value.getDoor().Intersects(rectangle, true, true)))//adds true when intersecting door bc door can be halfway into player and for leaving place
                {
                    switch (kvp.Key)
                    {
                        case "1": if (currentMap == map.ConShop) { return kvp.Key; } break;
                        case "2": if (currentMap == map.EquiShop) { return kvp.Key; } break;
                        case "3":
                        case "h": if (currentMap == map.Hospital) { return kvp.Key; } break;
                        case "4":
                        case "i": if (currentMap == map.Inn) { return kvp.Key; } break;
                        case "5":
                        case "b": if (currentMap == map.Bank) { return kvp.Key; } break;
                        default: return "0";
                    }
                }
                else if((currentMap == map.Town || currentMap == map.Wild1 || currentMap == map.Wild2 || currentMap == map.Wild3) && kvp.Value.getPos().Intersects(rectangle) || (currentMap != map.Town && currentMap != map.Wild1 && currentMap != map.Wild2 && currentMap != map.Wild3 && (!kvp.Value.Intersects(rectangle)) && (!kvp.Value.getDoor().Intersects(rectangle, true)) && what!="!"))
                {
                    return "0";
                }

                if (what == "!")
                    what = "";
                
            }
            if(what!="!")
            return what;
            return "";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, sourceRectangle, Color.White);
        }


    }
}
