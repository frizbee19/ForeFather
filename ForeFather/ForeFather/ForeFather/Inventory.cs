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
    class Inventory
    {
        List<Item> inventory;
        List<TextBox> descriptions;
        ContentManager Content;
        public Inventory(ContentManager c)
        {
            Content = c;
            inventory = new List<Item>();
            descriptions = new List<TextBox>();
        }

        public void addItem(Item item)
        {
            bool contains = false;
            //increments count if is already in inv
            for(int i = 0; i < inventory.Count; i++)
            {
                bool temp = false;
                if(!contains)
                {
                    temp = item.Equals(inventory[i]);
                    contains = temp;
                }
                if(temp)
                {
                    inventory[i].Count++;
                }
            }
            if(!contains)
            {
                inventory.Add(item);
                descriptions.Add(new TextBox(item.Description, false, Content, item.Name));
            }
        }
    }
}
