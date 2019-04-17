﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeFather
{
    class Armor : Item
    {
        private int defense;
        public int Defense
        {
            get { return defense; } set { defense = value; }
        }
        
        public Armor(string n, string d, int magnitude) : base(n, d + "\r\nThe armor rating is " + magnitude)
        {
            defense = magnitude;
        } 

        override
        public Character Use(Character c)
        {
            //placeholder
            return c;
        }

        override
        public bool Equals(Item item)
        {
            return item.Name == this.Name && ((Armor)item).Defense == this.Defense;
        }
    }
}
