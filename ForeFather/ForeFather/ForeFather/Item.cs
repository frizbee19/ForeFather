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
    //parent class for all items
    abstract class Item
    {
        private string name;
        private int count;
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

        public void Increment()
        {
            count++;
        }
        //all items will have a unique use method
        public abstract Character Use(Character character);

        public abstract bool Equals(Item item);

    }
}
