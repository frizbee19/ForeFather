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
    class Ability
    {
        private Type type;
        public Type Type { get; set; }
        private int cost;
        public int Cost { get; set; }
        private int magnitude { get; set; }
        public int Magnitude { get; set; }
        private string name;
        public string Name { get; set; }
        private TextBox description;
        public TextBox Description { get; set; }
        //to damage a target, use a negative magnitude

        public Ability(string name, int cost, int points, Type type, string desc, ContentManager content)
        {
            this.description = new TextBox(desc, false, content, name);
            this.name = name;
            this.cost = cost;
            this.magnitude = points;
            this.type = type;
        }

        public Ability(string name, int points, Type type, string desc, ContentManager content) : this(name, 0, points, type)
        {

        }



    }
}
