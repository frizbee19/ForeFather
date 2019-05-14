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
    public enum type { Armor, Weapon, Crystal, Health, Mana };
    public class Item
    {
        private string name;
        private int count;
        private type itemType;
        private int stat;
        
        public int Count
        {
            get { return count; } set { count = value; }                    
        }
        public String Name
        {
            get { return name; }
        }
        private string description;
        public String Description
        {
            get { return description; }
        }

        public Item(string n, string d)
        {
            name = n;
            description = d;
            count = 1;
        }

        public Item(string n, string d, type t)
        {
            name = n;
            description = d;                                                                                                                
            count = 1;
            itemType = t;
        }

        public Item(string n, string d, type t, int s)
        {
            name = n;
            description = d;
            count = 1;
            itemType = t;
            stat = s;
        }

        public void Increment()
        {
            count++;
        }
        //check which type of item it is
        public void Use(Ally c)
        {
            switch (itemType)
            { 
                case type.Health: c.addHealth(stat); break;
                case type.Mana: c.addMana(stat); break;
                default: break;
            }
        }

        public bool Equals(Item item)
        {
            return true;
        }

    }
}
