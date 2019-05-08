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
    class QuestItem : Item
    {
        private TextBox display;
        public QuestItem(string n, string d, ContentManager c) : this(n, d, c, "Nothing happens...")
        {
        }

        public QuestItem(string n, string d, ContentManager c, string message) : base(n, d)
        {
            display = new TextBox(message, false, c, n);
        }
        //use a default character in this class, it honestly does not even matter. idk what to use this method for except for maybe displaying the text
        override
        public Ally Use(Ally c)
        {
            display.Display();
            return c;
        }

        public override bool Equals(Item item)
        {
            return item.Name == this.Name;
        }

    }
}
